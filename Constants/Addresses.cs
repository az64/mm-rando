using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MMRando.Constants
{
    public static class Addresses
    {
        public static int FileTable = 0x1A500;
        public static int SignAddress = 0x1A4D0;
        public static int TextFile = 0xAD1000;
        public static int ObjTable = 0xC58C80;
        public static int SceneTable = 0xC5A1E0;
        public static int SceneFlagMasks = 0xC5C500;
        public static int TextTable = 0xC5D0D8;
        public static int SeqTable = 0xC77B80;
        public static int InstSetMap = 0xC77A60;

        public static int GetItemTable = 0;
        public static int BottleCatchTable = 0xCD7C08;

        public static int GossipStart = 0x20B0;
        public static int GossipEnd = 0x20E8;

        public static ReadOnlyCollection<int> GossipExclude
            = new ReadOnlyCollection<int> ( new int[] {
                0x20D0,
                0x20D1,
                0x20D2
            });
    }
}
