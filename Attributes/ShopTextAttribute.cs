using System;

namespace MMRando.Attributes
{
    public class ShopTextAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsMultiple { get; private set; }

        public ShopTextAttribute(string name = null, string description = null, bool isMultiple = false)
        {
            Name = name;
            Description = description;
            IsMultiple = isMultiple;
        }
    }
}
