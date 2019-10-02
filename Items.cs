using MMRando.Models.Rom;
using MMRando.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MMRando
{
    public class Items
    {
        /// <summary>
        /// Item indices ranging from 98 and to (inclusive) 120 define 
        /// areas and other (epona, explosive, arrow). In total they make up 23 entries.
        /// </summary>
        public const int NumberOfAreasAndOther = 23;

        public static GetItemEntry RecoveryHeart => new GetItemEntry
        {
            ItemGained = 0x83,
            Flag = 0x80,
            Index = 0x09,
            Type = 0x00,
            Message = 0x000A,
            Object = 0x0090
        };
    }
}