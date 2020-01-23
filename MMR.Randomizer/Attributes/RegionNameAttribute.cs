using System;

namespace MMR.Randomizer.Attributes
{
    public class RegionNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public RegionNameAttribute(string name)
        {
            Name = name;
        }
    }
}
