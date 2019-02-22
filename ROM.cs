using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace MMRando
{

    public partial class ROMFuncs
    {

        public static void SetStrings(string filename, string ver, string setting)
        {
            ApplyHack(filename);
            int veraddr = 0xC44E30;
            int settingaddr = 0xC44E70;
            string verstring = "MM Rando " + ver + " (dev)\x00";
            string settingstring = setting + "\x00";
            byte[] buffer = new byte[verstring.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)verstring[i];
            };
            int f = AddrToFile((uint)veraddr);
            CheckCompressed(f);
            int addr = veraddr - MMFileList[f].Addr;
            Arr_Insert(buffer, 0, buffer.Length, MMFileList[f].Data, addr);
            buffer = new byte[settingstring.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)settingstring[i];
            };
            addr = settingaddr - MMFileList[f].Addr;
            Arr_Insert(buffer, 0, buffer.Length, MMFileList[f].Data, addr);
        }

        private static int AddNewFile(string filename)
        {
            MMFile newfile = new MMFile();
            newfile.Addr = MMFileList[MMFileList.Count - 1].End;
            newfile.IsCompressed = false;
            BinaryReader data = new BinaryReader(File.Open(filename, FileMode.Open));
            int len = (int)data.BaseStream.Length;
            newfile.Data = new byte[len];
            data.Read(newfile.Data, 0, len);
            data.Close();
            newfile.End = newfile.Addr + len;
            MMFileList.Add(newfile);
            return newfile.Addr;
        }

        private static int AddrToFile(uint RAddr)
        {
            int i = 0;
            for (; i < MMFileList.Count; i++)
            {
                if ((RAddr >= MMFileList[i].Addr) && (RAddr < MMFileList[i].End))
                {
                    break;
                };
            };
            return i;
        }

        private static void CheckCompressed(int File)
        {
            if (MMFileList[File].IsCompressed && !MMFileList[File].WasEdited)
            {
                MMFileList[File].Data = Yaz0Decompress(MMFileList[File].Data);
                MMFileList[File].WasEdited = true;
            };
        }

        public static int ByteswapROM(string filename)
        {
            BinaryReader ROM = new BinaryReader(File.Open(filename, FileMode.Open));
            if (ROM.BaseStream.Length % 4 != 0)
            {
                ROM.Close();
                return -1;
            };
            byte[] buffer = new byte[4];
            ROM.Read(buffer, 0, 4);
            // very hacky
            int r = -1;
            ROM.BaseStream.Seek(0, 0);
            if (buffer[0] == 0x80)
            {
                r = 1;
            }
            else if (buffer[1] == 0x80)
            {
                r = 0;
                BinaryWriter newROM = new BinaryWriter(File.Open(filename + ".z64", FileMode.Create));
                while (ROM.BaseStream.Position < ROM.BaseStream.Length)
                {
                    newROM.Write(Byteswap16(ReadU16(ROM)));
                };
                newROM.Close();
            }
            else if (buffer[3] == 0x80)
            {
                r = 0;
                BinaryWriter newROM = new BinaryWriter(File.Open(filename + ".z64", FileMode.Create));
                while (ROM.BaseStream.Position < ROM.BaseStream.Length)
                {
                    newROM.Write(Byteswap32(ReadU32(ROM)));
                };
                newROM.Close();
            };
            ROM.Close();
            return r;
        }

        private static void UpdateFileTable(byte[] ROM)
        {
            for (int i = 0; i < MMFileList.Count; i++)
            {
                Arr_WriteU32(ROM, FileTable + (i * 16), (uint)MMFileList[i].Addr);
                Arr_WriteU32(ROM, FileTable + (i * 16) + 4, (uint)MMFileList[i].End);
                Arr_WriteU32(ROM, FileTable + (i * 16) + 8, (uint)MMFileList[i].Cmp_Addr);
                Arr_WriteU32(ROM, FileTable + (i * 16) + 12, (uint)MMFileList[i].Cmp_End);
            };
        }

        public static byte[] BuildROM(string FileName)
        {
            Parallel.ForEach(MMFileList, file =>
            {
                if (file.IsCompressed && file.WasEdited)
                {
                    file.Data = Yaz0Compress(file.Data);
                };
            });
            byte[] ROM = new byte[0x2000000];
            int ROMAddr = 0;
            for (int i = 0; i < MMFileList.Count; i++)
            {
                if (MMFileList[i].Cmp_Addr == -1)
                {
                    continue;
                };
                MMFileList[i].Cmp_Addr = ROMAddr;
                int file_len = MMFileList[i].Data.Length;
                if (MMFileList[i].IsCompressed)
                {
                    MMFileList[i].Cmp_End = ROMAddr + file_len;
                };
                Arr_Insert(MMFileList[i].Data, 0, file_len, ROM, ROMAddr);
                ROMAddr += file_len;
            };
            UpdateFileTable(ROM);
            SignROM(ROM);
            FixCRC(ROM);
            BinaryWriter NewROM = new BinaryWriter(File.Open(FileName, FileMode.Create));
            NewROM.Write(ROM, 0, ROM.Length);
            NewROM.Close();
            return ROM;
        }

        private static void SignROM(byte[] ROM)
        {
            string VerString = "MajoraRando";
            string DateString = DateTime.UtcNow.ToString("yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            for (int i = 0; i < VerString.Length; i++)
            {
                ROM[SignAddr + i] = (byte)VerString[i];
            };
            for (int i = 0; i < DateString.Length; i++)
            {
                ROM[SignAddr + i + 12] = (byte)DateString[i];
            };
        }

        private static void FixCRC(byte[] ROM)
        {
            // reference: http://n64dev.org/n64crc.html
            uint[] CRC = new uint[2];
            uint seed = 0xDF26F436;
            uint t1, t2, t3, t4, t5, t6, r, d;
            int i = 0x1000;
            t1 = t2 = t3 = t4 = t5 = t6 = seed;
            while (i < 0x101000)
            {
                d = Arr_ReadU32(ROM, i);
                if ((t6 + d) < t6) { t4++; };
                t6 += d;
                t3 ^= d;
                r = (d << (byte)(d & 0x1F)) | (d >> (byte)(32 - (d & 0x1F)));
                t5 += r;
                if (t2 < d)
                {
                    t2 ^= (t6 ^ d);
                }
                else
                {
                    t2 ^= r;
                };
                t1 += (Arr_ReadU32(ROM, 0x750 + (i & 0xFF)) ^ d);
                i += 4;
            };
            CRC[0] = t6 ^ t4 ^ t3;
            CRC[1] = t5 ^ t2 ^ t1;
            Arr_WriteU32(ROM, 16, CRC[0]);
            Arr_WriteU32(ROM, 20, CRC[1]);
        }

        private static void ExtractAll(BinaryReader ROM)
        {
            for (int i = 0; i < MMFileList.Count; i++)
            {
                if (MMFileList[i].Cmp_Addr == -1) { continue; };
                ROM.BaseStream.Seek(MMFileList[i].Cmp_Addr, 0);
                if (MMFileList[i].IsCompressed)
                {
                    byte[] CmpFile = new byte[MMFileList[i].Cmp_End - MMFileList[i].Cmp_Addr];
                    ROM.Read(CmpFile, 0, CmpFile.Length);
                    MMFileList[i].Data = CmpFile;
                }
                else
                {
                    MMFileList[i].Data = new byte[MMFileList[i].End - MMFileList[i].Addr];
                    ROM.Read(MMFileList[i].Data, 0, MMFileList[i].Data.Length);
                };
            };
        }

        public static void ReadFileTable(BinaryReader ROM)
        {
            MMFileList = new List<MMFile>();
            ROM.BaseStream.Seek(FileTable, 0);
            while (true)
            {
                MMFile Current_File = new MMFile();
                Current_File.Addr = (int)ReadU32(ROM);
                Current_File.End = (int)ReadU32(ROM);
                if (Current_File.Addr == Current_File.End)
                {
                    break;
                };
                Current_File.Cmp_Addr = (int)ReadU32(ROM);
                Current_File.Cmp_End = (int)ReadU32(ROM);
                Current_File.IsCompressed = (Current_File.Cmp_End != 0);
                MMFileList.Add(Current_File);
            };
            ExtractAll(ROM);
        }

        public static bool CheckOldCRC(BinaryReader ROM)
        {
            ROM.BaseStream.Seek(16, 0);
            uint CRC1 = ReadU32(ROM);
            uint CRC2 = ReadU32(ROM);
            if ((CRC1 == 0x5354631C) && (CRC2 == 0x03A2DEF0))
            {
                return true;
            };
            return false;
        }

    }

}