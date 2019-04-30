using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MMRando
{

    public partial class ROMFuncs
    {

        //todo - rewrite this
        public static void RebuildAudioSeq(List<mmrMain.SeqInfo> SeqList)
        {
            List<MMSeq> OldSeq = new List<MMSeq>();
            int f = GetFileIndexForWriting(SeqTable);
            int basea = MMFileList[f].Addr;
            for (int i = 0; i < 128; i++)
            {
                MMSeq entry = new MMSeq();
                if (i == 0x1E)
                {
                    entry.Addr = 2;
                    entry.Size = 0;
                    OldSeq.Add(entry);
                    continue;
                };
                int entryaddr = SeqTable + (i * 16);
                entry.Addr = (int)Arr_ReadU32(MMFileList[f].Data, entryaddr - basea);
                entry.Size = (int)Arr_ReadU32(MMFileList[f].Data, (entryaddr - basea) + 4);
                if (entry.Size > 0)
                {
                    entry.Data = new byte[entry.Size];
                    Array.Copy(MMFileList[4].Data, entry.Addr, entry.Data, 0, entry.Size);
                }
                else
                {
                    int j = SeqList.FindIndex(u => u.Replaces == i);
                    if (j != -1)
                    {
                        if ((entry.Addr > 0) && (entry.Addr < 128))
                        {
                            if (SeqList[j].Replaces != 0x28)
                            {
                                SeqList[j].Replaces = entry.Addr;
                            }
                            else
                            {
                                entry.Data = OldSeq[0x18].Data;
                                entry.Size = OldSeq[0x18].Size;
                            };
                        };
                    };
                };
                OldSeq.Add(entry);
            };
            List<MMSeq> NewSeq = new List<MMSeq>();
            int addr = 0;
            byte[] NewAudioSeq = new byte[0];
            for (int i = 0; i < 128; i++)
            {
                MMSeq newentry = new MMSeq();
                if (OldSeq[i].Size == 0)
                {
                    newentry.Addr = OldSeq[i].Addr;
                }
                else
                {
                    newentry.Addr = addr;
                };
                int j = SeqList.FindIndex(u => u.Replaces == i);
                if (j != -1)
                {
                    if (SeqList[j].MM_seq != -1)
                    {
                        newentry.Size = OldSeq[SeqList[j].MM_seq].Size;
                        newentry.Data = OldSeq[SeqList[j].MM_seq].Data;
                    }
                    else
                    {
                        BinaryReader seq = new BinaryReader(File.Open(SeqList[j].Name, FileMode.Open));
                        int len = (int)seq.BaseStream.Length;
                        byte[] data = new byte[len];
                        seq.Read(data, 0, len);
                        seq.Close();
                        if (data[1] != 0x20)
                        {
                            data[1] = 0x20;
                        };
                        newentry.Size = len;
                        newentry.Data = data;
                    };
                }
                else
                {
                    newentry.Size = OldSeq[i].Size;
                    newentry.Data = OldSeq[i].Data;
                };
                NewSeq.Add(newentry);
                if (newentry.Data != null)
                {
                    NewAudioSeq = NewAudioSeq.Concat(newentry.Data).ToArray();
                };
                addr += newentry.Size;
            };
            if (addr > (MMFileList[4].End - MMFileList[4].Addr))
            {
                MMFile newa = new MMFile();
                newa.Addr = MMFileList[MMFileList.Count - 1].End;
                newa.End = newa.Addr + addr;
                newa.IsCompressed = false;
                newa.Data = NewAudioSeq;
                MMFileList.Add(newa);
                ApplyHack(mmrMain.ModsDir + "reloc-audio");
                MMFileList[4].Data = new byte[0];
                MMFileList[4].Cmp_Addr = -1;
                MMFileList[4].Cmp_End = -1;
            }
            else
            {
                MMFileList[4].Data = NewAudioSeq;
            };
            //update pointer table
            f = GetFileIndexForWriting(SeqTable);
            for (int i = 0; i < 128; i++)
            {
                Arr_WriteU32(MMFileList[f].Data, (SeqTable + (i * 16)) - basea, (uint)NewSeq[i].Addr);
                Arr_WriteU32(MMFileList[f].Data, 4 + (SeqTable + (i * 16)) - basea, (uint)NewSeq[i].Size);
            };
            //update inst sets
            f = GetFileIndexForWriting(InstSetMap);
            basea = MMFileList[f].Addr;
            for (int i = 0; i < 128; i++)
            {
                int paddr = (InstSetMap - basea) + (i * 2) + 2;
                int j = -1;
                if (NewSeq[i].Size == 0)
                {
                    j = SeqList.FindIndex(u => u.Replaces == NewSeq[i].Addr);
                }
                else
                {
                    j = SeqList.FindIndex(u => u.Replaces == i);
                };
                if (j != -1)
                {
                    MMFileList[f].Data[paddr] = (byte)SeqList[j].Inst;
                };
            };
        }

    }

}