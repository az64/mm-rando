using MMRando.GameObjects;
using System;

namespace MMRando.Attributes
{
    public class RegionAttribute : Attribute
    {
        public Region Region { get; private set; }

        public RegionAttribute(Region region)
        {
            Region = region;
        }
    }
}
