using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMRando.Attributes
{
    public class ChestTypeAttribute : Attribute
    {
        public ChestType Type { get; private set; }

        public ChestTypeAttribute(ChestType type)
        {
            Type = type;
        }

        public enum ChestType
        {
            LargeGold = 0x00,
            SmallWooden,
            SmallGold,
            BossKey,
        }
    }
}
