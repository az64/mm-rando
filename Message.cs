using System;
using System.Collections.Generic;
using System.Linq;

namespace MMRando
{

    public partial class ROMFuncs
    {

        //todo - allow rebuilding text file

        private static void WriteMsg(int addr, byte[] msg)
        {
            int f = GetFileIndexForWriting(TxTFile);
            Arr_Insert(msg, 0, msg.Length, MMFileList[f].Data, addr);
        }

        private static MMMsg FindMsg(int n)
        {
            int f = GetFileIndexForWriting(TxtTable);
            int basea = TxtTable - MMFileList[f].Addr;
            MMMsg m = new MMMsg();
            while (true)
            {
                int x = (MMFileList[f].Data[basea] << 8) + MMFileList[f].Data[basea + 1];
                if (n == x)
                {
                    m.Addr = (int)(Arr_ReadU32(MMFileList[f].Data, basea + 4) & 0xFFFFFF);
                    m.Size = (int)(Arr_ReadU32(MMFileList[f].Data, basea + 12) & 0xFFFFFF) - m.Addr;
                    break;
                };
                if (x > n)
                {
                    return null;
                };
                basea += 8;
            };
            return m;
        }

        public static bool IsBadMsg(string msg)
        {
            return msg.Contains("a segment of health") || msg.Contains("currency") ||
                msg.Contains("money") || msg.Contains("cash") ||
                msg.Contains("wealth") || msg.Contains("riches and stuff") ||
                msg.Contains("increased life");
        }

        public static void WriteGossipMsg(List<string> msg, Random RNG)
        {
            byte[] msgheader = new byte[] { 2, 0, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            for (int i = GossipStart; i < GossipEnd; i++)
            {
                if (GossipExclude.Contains(i))
                {
                    continue;
                };
                MMMsg m = FindMsg(i);
                if (m == null)
                {
                    continue;
                };
                int j;
                int l = m.Size + 1;
                do
                {
                    j = RNG.Next(msg.Count);
                    if (IsBadMsg(msg[j]))
                    {
                        if (RNG.Next(8) != 0)
                        {
                            continue;
                        };
                    };
                    l = msg[j].Length + msgheader.Length;
                } while (l > m.Size);
                byte[] data = new byte[l];
                Arr_Insert(msgheader, 0, msgheader.Length, data, 0);
                for (int k = 0; k < msg[j].Length; k++)
                {
                    data[k + msgheader.Length] = (byte)msg[j][k];
                };
                WriteMsg(m.Addr, data);
                msg.RemoveAt(j);
            };
        }

    }

}