using MMR.Randomizer.GameObjects;
using System;

namespace MMR.Randomizer.Attributes
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
