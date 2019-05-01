using System;

namespace MMRando
{

    public partial class ROMFuncs
    {

        private static int GetEntranceAddr(int ent)
        {
            int offset = ((ent >> 9) * 12) + 0xC5BC64;
            int f = GetFileIndexForWriting(offset);
            offset -= MMFileList[f].Addr;
            uint p1 = Arr_ReadU32(MMFileList[f].Data, offset);
            offset = ((ent >> 4) & 0x1F) * 4;
            p1 = (uint)((p1 & 0xFFFFFF) + 0xA96540 - MMFileList[f].Addr);
            p1 = Arr_ReadU32(MMFileList[f].Data, (int)(p1 + offset));
            p1 = (uint)((p1 & 0xFFFFFF) + 0xA96540 - MMFileList[f].Addr);
            offset = (ent & 0xF) << 2;
            return (int)p1 + offset;
        }

        public static void WriteEntrances(int[] olde, int[] newe)
        {
            int f = GetFileIndexForWriting(0xC5BC64);
            uint[] data = new uint[newe.Length];
            for (int i = 0; i < newe.Length; i++)
            {
                data[i] = Arr_ReadU32(MMFileList[f].Data, GetEntranceAddr(newe[i]));
            };
            for (int i = 0; i < newe.Length; i++)
            {
                Arr_WriteU32(MMFileList[f].Data, GetEntranceAddr(olde[i]), data[i]);
            };
        }

    }

}