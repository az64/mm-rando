using MMRando.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static MMRando.Models.SoundEffects.SoundAttributes;

namespace MMRando.Models.SoundEffects
{
    public static class SoundExtensions
    {
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
        /// <para>Returns false if sound has no tags</para>
        /// </summary>
        public static bool IsReplacable(this SoundEffect sound)
        {
            return sound.GetAttribute<ReplacableAttribute>() != null;
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

            var replacebleAttribute = source.GetAttribute<ReplacableAttribute>();
            var baseInstruction = replacebleAttribute.Instruction;
            var addresses = replacebleAttribute.Addresses;

            var instruction = baseInstruction + (ushort) newSound;

            foreach(var address in addresses) { 
                ReadWriteUtils.WriteToROM(address, instruction);
            }
        }
    }
}
