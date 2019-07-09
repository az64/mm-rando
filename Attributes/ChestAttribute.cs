using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMRando.Attributes
{
    public class ChestAttribute : Attribute
    {
        public int[] Addresses { get; private set; }
        public AppearanceType Type { get; private set; }

        public ChestAttribute(int address, AppearanceType type = AppearanceType.Normal, params int[] additionalAddresses)
        {
            Addresses = additionalAddresses.Concat(new[] { address }).ToArray();
            Type = type;
        }

        public enum AppearanceType
        {
            Normal,
            AppearsClear,
            AppearsSwitch,
            Invisible,
        }

        public static byte GetType(ChestTypeAttribute.ChestType chestType, AppearanceType appearanceType)
        {
            if (chestType == ChestTypeAttribute.ChestType.SmallGold)
            {
                chestType = ChestTypeAttribute.ChestType.SmallWooden; // todo?
            }
            switch (appearanceType)
            {
                case AppearanceType.Normal:
                    return (byte)chestType;
                case AppearanceType.Invisible:
                    if (chestType == ChestTypeAttribute.ChestType.SmallWooden)
                    {
                        return 6; // invisible wooden chest
                    }
                    else
                    {
                        return 4; // invisible gold chest
                    }
                case AppearanceType.AppearsClear:
                    if (chestType == ChestTypeAttribute.ChestType.SmallWooden)
                    {
                        return 7; // wooden chest - clear flag
                    }
                    else
                    {
                        return 1; // gold chest - clear flag
                    }
                case AppearanceType.AppearsSwitch:
                    if (chestType == ChestTypeAttribute.ChestType.SmallWooden)
                    {
                        return 0xC; // wooden chest - switch flag
                    }
                    else
                    {
                        return 0xB; // gold chest - switch flag
                    }
                default:
                    throw new ArgumentException("Invalid appearance type.", nameof(appearanceType));
            }
        }
    }

    public class GrottoChestAttribute : Attribute
    {
        public int[] Addresses { get; private set; }

        public GrottoChestAttribute(params int[] addresses)
        {
            Addresses = addresses;
        }
    }
}
