using MMRando.Constants;
using MMRando.Models.Rom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MMRando.Utils
{
    public class AudioSequenceUtils
    {
        //todo - rewrite this
        public static void RebuildAudioSeq(List<SequenceInfo> SeqList)
        {
            List<MMSequence> OldSeq = new List<MMSequence>();
            int f = RomUtils.GetFileIndexForWriting(Addresses.SeqTable);
            int basea = RomData.MMFileList[f].Addr;
            for (int i = 0; i < 128; i++)
            {
                MMSequence entry = new MMSequence();
                if (i == 0x1E)
                {
                    entry.Addr = 2;
                    entry.Size = 0;
                    OldSeq.Add(entry);
                    continue;
                };
                int entryaddr = Addresses.SeqTable + (i * 16);
                entry.Addr = (int)ReadWriteUtils.Arr_ReadU32(RomData.MMFileList[f].Data, entryaddr - basea);
                entry.Size = (int)ReadWriteUtils.Arr_ReadU32(RomData.MMFileList[f].Data, (entryaddr - basea) + 4);
                if (entry.Size > 0)
                {
                    entry.Data = new byte[entry.Size];
                    Array.Copy(RomData.MMFileList[4].Data, entry.Addr, entry.Data, 0, entry.Size);
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
            List<MMSequence> NewSeq = new List<MMSequence>();
            int addr = 0;
            byte[] NewAudioSeq = new byte[0];
            for (int i = 0; i < 128; i++)
            {
                MMSequence newentry = new MMSequence();
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
            if (addr > (RomData.MMFileList[4].End - RomData.MMFileList[4].Addr))
            {
                MMFile newa = new MMFile();
                newa.Addr = RomData.MMFileList[RomData.MMFileList.Count - 1].End;
                newa.End = newa.Addr + addr;
                newa.IsCompressed = false;
                newa.Data = NewAudioSeq;
                RomData.MMFileList.Add(newa);
                ResourceUtils.ApplyHack(Values.ModsDirectory + "reloc-audio");
                RomData.MMFileList[4].Data = new byte[0];
                RomData.MMFileList[4].Cmp_Addr = -1;
                RomData.MMFileList[4].Cmp_End = -1;
            }
            else
            {
                RomData.MMFileList[4].Data = NewAudioSeq;
            }

            //update pointer table
            f = RomUtils.GetFileIndexForWriting(Addresses.SeqTable);
            for (int i = 0; i < 128; i++)
            {
                ReadWriteUtils.Arr_WriteU32(RomData.MMFileList[f].Data, (Addresses.SeqTable + (i * 16)) - basea, (uint)NewSeq[i].Addr);
                ReadWriteUtils.Arr_WriteU32(RomData.MMFileList[f].Data, 4 + (Addresses.SeqTable + (i * 16)) - basea, (uint)NewSeq[i].Size);
            };
            //update inst sets
            f = RomUtils.GetFileIndexForWriting(Addresses.InstSetMap);
            basea = RomData.MMFileList[f].Addr;
            for (int i = 0; i < 128; i++)
            {
                int paddr = (Addresses.InstSetMap - basea) + (i * 2) + 2;
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
                    RomData.MMFileList[f].Data[paddr] = (byte)SeqList[j].Instrument;
                };
            };
        }

    }

}