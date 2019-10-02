using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMRando.Models.SoundEffects
{
    /// <summary>
    /// Marks a sound effect from a message as replacable, requiring a sound id and at least one address
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class ReplacableInMessageAttribute : Attribute
    {
        public ReadOnlyCollection<ushort> MessageIds { get; private set; }
        public ushort SoundId { get; private set; }
        public ReplacableInMessageAttribute(ushort soundId, ushort messageId, params ushort[] additionalMessageIds)
        {
            SoundId = soundId;

            var messageIds = new List<ushort> { messageId };
            if (additionalMessageIds?.Length > 0)
            {
                messageIds.AddRange(additionalMessageIds);
            }

            MessageIds = new ReadOnlyCollection<ushort>(messageIds);
        }
    }
}
