using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMRando.Attributes
{
    public class ChestAttribute : Attribute
    {
        public int Address { get; private set; }
        public AppearanceType Type { get; private set; }

        public ChestAttribute(int address, AppearanceType type = AppearanceType.Normal, params int[] additionalAddresses)
        {
            Address = address;
            Type = type;
        }

        public enum AppearanceType
        {
            Normal,
            AppearsClear,
            AppearsSwitch,
            Invisible,
        }
    }
}
