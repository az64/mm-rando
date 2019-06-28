using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMRando.Attributes
{
    public class StartingItemAttribute : Attribute
    {
        public int Address { get; private set; }
        public byte Value { get; private set; }

        public StartingItemAttribute(int address, byte value)
        {
            Address = address;
            Value = value;
        }
    }
}
