using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMRando.Models.SoundEffects
{
    /// <summary>
    /// Mark the sound effect with tags. E.g. Short.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class TagsAttribute : Attribute
    {
        public ReadOnlyCollection<SoundEffectTag> Tags { get; private set; }

        public TagsAttribute(SoundEffectTag tag, params SoundEffectTag[] additionalTags)
        {
            var tags = new List<SoundEffectTag> { tag };
            if (additionalTags?.Length > 0)
            {
                tags.AddRange(additionalTags);
            }

            Tags = new ReadOnlyCollection<SoundEffectTag>(tags);
        }
    }
}
