using MMRando.Models.Rom;
using MMRando.Utils;
using System;
using System.Linq;

namespace MMRando.Models.SoundEffects
{
    public static class SoundEffectExtensions
    {
        public const ushort DefaultSoundEffectFlags = 0x0800;

        private static TAttribute GetAttribute<TAttribute>(this SoundEffect value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        /// <summary>
        /// <para>Checks if current soundeffect has been tagged with Tag.Replacable</para> 
        /// 
        /// </summary>
        public static bool IsReplacable(this SoundEffect sound)
        {
            return sound.GetAttribute<ReplacableAttribute>() != null || sound.GetAttribute<ReplacableInMessageAttribute>() != null;
        }

        /// <summary>
        /// <para>Checks if current soundeffect has ReplacableInMessage Attribute</para> 
        /// 
        /// </summary>
        public static bool IsReplacableInMessage(this SoundEffect sound)
        {
            return sound.GetAttribute<ReplacableInMessageAttribute>() != null;
        }

        /// <summary>
        /// Checks if current sound is tagged with provided tag
        /// </summary>
        /// <returns></returns>
        public static bool HasTag(this SoundEffect sound, SoundEffectTag tag)
        {
            return sound.GetAttribute<TagsAttribute>()?.Tags?.Contains(tag) ?? false;
        }

        /// <summary>
        /// Retrieves the list of tags that are valid for this sound's replacement. If the sound has no ReplacableByTags attribute specified, returns all tags.
        /// </summary>
        /// <returns></returns>
        public static SoundEffectTag[] ReplacableByTags(this SoundEffect sound)
        {
            var tags = sound.GetAttribute<ReplacableByTagsAttribute>()?.Tags?.ToArray();
            return tags ?? Enum.GetValues(typeof(SoundEffectTag)).Cast<SoundEffectTag>().ToArray();
        }

        /// <summary>
        /// <para>Replaces current sound effect with a new one</para>
        /// 
        /// Throws InvalidOperationException if current sound cannot be replaced
        /// </summary>
        public static void ReplaceWith(this SoundEffect source, SoundEffect newSound)
        {
            if (!source.IsReplacable())
            {
                throw new InvalidOperationException($"Sound effect {source} is not replacable!");
            }

            var replacableAttribute = source.GetAttribute<ReplacableAttribute>();
            var addresses = replacableAttribute.Addresses;

            var newValue = (ushort)newSound;

            var effect = source.GetAttribute<EffectAttribute>();
            if (effect != null)
            {
                newValue = (ushort)((effect.Flags & 0x0E00) | (newValue & 0xF1FF));
            }
            else
            {
                newValue = (ushort)(newSound + DefaultSoundEffectFlags);
            }

            foreach (var address in addresses)
            {
                ReadWriteUtils.WriteToROM(address, newValue);
            }
        }

        /// <summary>
        /// <para>Replaces current sound effect in a message with a new one</para>
        /// 
        /// Throws InvalidOperationException if current sound cannot be replaced
        /// </summary>
        public static void ReplaceInMessageWith(this SoundEffect source, SoundEffect newSound, MessageTable messageTable)
        {
            if (!source.IsReplacableInMessage())
            {
                throw new InvalidOperationException($"Sound effect {source} is not replacable!");
            }

            var replacableAttribute = source.GetAttribute<ReplacableInMessageAttribute>();

            foreach (var messageId in replacableAttribute.MessageIds)
            {
                var message = messageTable.GetMessage(messageId);

                var oldSoundId = replacableAttribute.SoundId;
                var oldSoundEffect = (ushort)(oldSoundId & 0x0E00);
                var oldSoundBytes = new string(new char[] { Convert.ToChar((oldSoundId & 0xFF00) >> 8), Convert.ToChar(oldSoundId & 0xFF) });
                var oldSoundLocation = message.Message.IndexOf(oldSoundBytes);

                if (oldSoundLocation < 0)
                {
                    throw new InvalidProgramException($"Sound effect {source} has invalid sound replacement setup!");
                }

                var newSoundId = (uint)newSound;
                var newSoundBytes = new string(new char[] {
                    Convert.ToChar(((newSoundId | oldSoundEffect) & 0xFF00) >> 8),
                    Convert.ToChar(newSoundId & 0xFF)
                });

                var newMessage = message.Message.Replace(oldSoundBytes, newSoundBytes);
                message.Message = newMessage;
            }
        }
    }
}
