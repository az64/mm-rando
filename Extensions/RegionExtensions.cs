using MMRando.Attributes;
using MMRando.GameObjects;

namespace MMRando.Extensions
{
    public static class RegionExtensions
    {
        public static string Name(this Region region)
        {
            return region.GetAttribute<RegionNameAttribute>()?.Name;
        }
    }
}
