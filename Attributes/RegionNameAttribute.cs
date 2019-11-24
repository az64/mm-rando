using System;

namespace MMRando.Attributes
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
