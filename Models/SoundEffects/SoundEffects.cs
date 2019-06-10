using System;
using System.Collections.Generic;
using System.Linq;

namespace MMRando.Models.SoundEffects
{
    /// <summary>
    /// 
    /// </summary>
    public static class SoundEffects
    {
        public static List<SoundEffect> All()
        {
            return Enum.GetValues(typeof(SoundEffect))
               .Cast<SoundEffect>()
               .ToList();
        }

        public static List<SoundEffect> Replacable()
        {
            return All().Where(sound => sound.IsReplacable()).ToList();
        }

        /// <summary>
        /// Filter sounds by any number of tags
        /// </summary>
        /// <param name="tags">Tags to filter on</param>
        /// <returns></returns>
        public static List<SoundEffect> FilterByTags(params SoundEffectTag[] tags)
        {
            var all = All();
            if (tags == null || tags.Length == 0) return all;
            return all.Where(sound => tags.Any(tag => sound.HasTag(tag))).ToList();
        }
    }
}
