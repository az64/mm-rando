using System;
using System.IO;

namespace MMRando
{

    public partial class ROMFuncs
    {

        public static void WriteFileAddr(int[] Addr, byte[] data, byte[] file)
        {
            for (int i = 0; i < Addr.Length; i++)
            {
                Arr_Insert(data, 0, data.Length, file, Addr[i]);
            };
        }

        public static void WriteROMAddr(int[] Addr, byte[] data)
        {
            for (int i = 0; i < Addr.Length; i++)
            {
                int var = (int)(Addr[i] & 0xF0000000) >> 28;
                int rAddr = Addr[i] & 0xFFFFFFF;
                byte[] rdata = data;
                if (var == 1)
                {
                    rdata[0] += 0xA;
                    rdata[1] -= 0x70;
                };
                int f = GetFileIndexForWriting(rAddr);
                int dest = rAddr - MMFileList[f].Addr;
                Arr_Insert(rdata, 0, rdata.Length, MMFileList[f].Data, dest);
            };
        }

        public static void WriteToROM(int Addr, byte val)
        {
            int f = GetFileIndexForWriting(Addr);
            int dest = Addr - MMFileList[f].Addr;
            MMFileList[f].Data[dest] = val;
        }

        public static void WriteToROM(int Addr, ushort val)
        {
            int f = GetFileIndexForWriting(Addr);
            int dest = Addr - MMFileList[f].Addr;
            MMFileList[f].Data[dest] = (byte)((val & 0xFF00) >> 8);
            MMFileList[f].Data[dest + 1] = (byte)(val & 0xFF);
        }

        public static void WriteToROM(int Addr, uint val)
        {
            int f = GetFileIndexForWriting(Addr);
            int dest = Addr - MMFileList[f].Addr;
            MMFileList[f].Data[dest] = (byte)((val & 0xFF000000) >> 24);
            MMFileList[f].Data[dest + 1] = (byte)((val & 0xFF0000) >> 16);
            MMFileList[f].Data[dest + 2] = (byte)((val & 0xFF00) >> 8);
            MMFileList[f].Data[dest + 3] = (byte)(val & 0xFF);
        }

        public static void WriteToROM(int Addr, byte[] val)
        {
            int f = GetFileIndexForWriting(Addr);
            int dest = Addr - MMFileList[f].Addr;
            Arr_Insert(val, 0, val.Length, MMFileList[f].Data, dest);
        }

        private static void Arr_Insert(byte[] src, int start, int len, byte[] dest, int addr)
        {
            for (int i = 0; i < len; i++)
            {
                dest[addr + i] = src[start + i];
            }
        }

        private static uint Byteswap32(uint val)
        {
            return ((val & 0xFF) << 24) | ((val & 0xFF00) << 8) | ((val & 0xFF0000) >> 8) | ((val & 0xFF000000) >> 24);
        }

        private static ushort Byteswap16(ushort val)
        {
            return (ushort)(((val & 0xFF) << 8) | ((val & 0xFF00) >> 8));
        }

        private static uint Arr_ReadU32(byte[] Arr, int Src)
        {
            return (uint)((Arr[Src] << 24) | (Arr[Src + 1] << 16) | (Arr[Src + 2] << 8) | Arr[Src + 3]);
        }

        private static ushort Arr_ReadU16(byte[] Arr, int Src)
        {
            return (ushort)((Arr[Src] << 8) | (Arr[Src + 1]));
        }

        public static void Arr_WriteU32(byte[] Arr, int Dest, uint val)
        {
            Arr[Dest] = (byte)((val & 0xFF000000) >> 24);
            Arr[Dest + 1] = (byte)((val & 0xFF0000) >> 16);
            Arr[Dest + 2] = (byte)((val & 0xFF00) >> 8);
            Arr[Dest + 3] = (byte)(val & 0xFF);
        }

        public static void Arr_WriteU16(byte[] Arr, int Dest, ushort val)
        {
            Arr[Dest] = (byte)((val & 0xFF00) >> 8);
            Arr[Dest + 1] = (byte)(val & 0xFF);
        }

        private static uint ReadU32(BinaryReader ROM)
        {
            return Byteswap32(ROM.ReadUInt32());
        }

        private static int ReadS32(BinaryReader ROM)
        {
            return (int)ReadU32(ROM);
        }

        private static ushort ReadU16(BinaryReader ROM)
        {
            return Byteswap16(ROM.ReadUInt16());
        }

        private static void WriteU32(BinaryWriter ROM, uint val)
        {
            ROM.Write(Byteswap32(val));
        }

        private static void WriteU16(BinaryWriter ROM, ushort val)
        {
            ROM.Write(Byteswap16(val));
        }

    }

}