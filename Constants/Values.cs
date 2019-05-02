namespace MMRando
{
    public static class Values
    {
        /// <summary>
        /// Item indices ranging from 98 and to (inclusive) 120 define 
        /// areas and other (epona, explosive, arrow). In total they make up 23 entries.
        /// </summary>
        public const int NumberOfAreasAndOther = 23;

        public static readonly byte[] MessageHeader = new byte[] { 2, 0, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

        public static readonly string[] GossipMessageStartSentences = new string[] {
            "They say ",
            "I hear ",
            "It seems ",
            "Apparently, ",
            "It appears " };

        public static readonly string[] GossipMessageMidSentences = new string[] {
            "leads to ",
            "yields ",
            "brings ",
            "holds ",
            "conceals ",
            "posesses "
        };

        public static readonly string[] JunkGossipMessages = new string[]
        {
            "\x1E\x69\x4FThey say that Jimmie1717's mod\x11lottery is \x01RIGGED!\x00\xBF",
            "\x1E\x69\x4FReal ZELDA players use HOLD targeting!\xBF",
            "\x1E\x69\x4FThey say items are random...\xBF",
            "\x1E\x69\x4FThey say the \x05" + "blue dog\x00 shall prevail...\xBF",
            "\x1E\x69\x4FMy body craves for the touch of\x11\x01mashed potatoes\x00...\xBF",
            "\x1E\x69\x2B" + "Dear Mario, please come to the \x11" + "castle. I've baked a cake for you.\x11Yours truly, Princess Toadstool\x11\x06Peach\x00\xBF",
            "\x1E\x69\x56I overheard something useful:\x11\xDF\xBF",
            "\x1E\x69\x56I overheard something useful:\x11\xD6\xBF",
            "\x1E\x69\x4FThey say the best button for bombchus\x11is \x04\xB7\x00...\xBF",
            "\x1E\x69\x4FThey say the key to victory is\x11" + "beating the game...\xBF",
            "\x1E\x38\x0BThey say a certain player once stole\x11their items back from Takkuri...\xBF",
            "\x1E\x69\x4FThey say wearing the \x01" + "Bremen Mask\x00\x11increases your chances of beating the\x11Gorman bros...\xBF",
            "\x1E\x69\x6FUse the boost to get through!\xBF",
            "\x1E\x69\x4FThey say the \x04gold dog\x00 cheats...\xBF"
        };

        public static readonly uint[,] TatlColours = new uint[,] { // normal, npc, check, enemy, boss
            { 0xffffe6ff, 0xdca05000, 0x9696ffff, 0x9696ff00, 0x00ff00ff, 0x00ff0000, 0xffff00ff, 0xc89b0000, 0xffff00ff, 0xc89b0000 },
            { 0x200020ff, 0x80000000, 0x001080ff, 0x0080ff00, 0x104000ff, 0x80ff0000, 0x800000ff, 0x20002000, 0x800000ff, 0xff800000 },
            { 0xffc0e0ff, 0xff00ff00, 0xe040ffff, 0xff000000, 0xff80ffff, 0xff00ff00, 0xffe000ff, 0xff000000, 0xff0000ff, 0xff000000 },
            { 0xc0ffffff, 0x0000ff00, 0xffffffff, 0x00ffff00, 0x00ffffff, 0x00ffff00, 0xc080ffff, 0x0000ff00, 0x8080ffff, 0x0000ff00 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public static readonly int[] OldEntrances = new int[] { 0x3000, 0x3C00, 0x2A00, 0x8C00 };
        public static readonly int[] OldExits = new int[] { 0x8610, 0xB210, 0xAC10, 0x6A70 };
        public static readonly int[] OldDCFlags = new int[] { 0x57C, 0x589, 0x59C, 0x59F };
        public static readonly int[] OldMaskFlags = new int[] { 0x02, 0x80, 0x20, 0x80 };

        // Settings constants

        public const int CasualMode0 = 0;
        public const int GlitchedMode1 = 1;
        public const int VanillaMode2 = 2;
        public const int UserLogicMode3 = 3;
        public const int NoLogicMode4 = 4;
    }
}
