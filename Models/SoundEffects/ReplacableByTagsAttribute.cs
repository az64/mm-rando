using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMRando.Models.SoundEffects
{
    /// <summary>
    /// Specify which tags are valid for replacing the sound.
    /// </summary>
    public sealed class ReplacableByTagsAttribute : Attribute
    {
        public ReadOnlyCollection<SoundEffectTag> Tags { get; private set; }

        public ReplacableByTagsAttribute(SoundEffectTag tag, params SoundEffectTag[] additionalTags)
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