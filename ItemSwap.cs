using System;
using System.Collections.Generic;
using System.IO;

namespace MMRando
{

    public partial class ROMFuncs
    {

        static int cycle_repeat = 0;

        public static void ReplaceGetItemTable(string ModsDir)
        {
            ApplyHack(ModsDir + "replace-gi-table");
            int last_file = MMFileList.Count - 1;
            GetItemTable = AddNewFile(ModsDir + "gi-table");
            WriteToROM(0xBDAEAC, (uint)last_file + 1);
            ApplyHack(ModsDir + "update-chests");
            AddNewFile(ModsDir + "chest-table");
            WriteToROM(0xBDAEA8, (uint)last_file + 2);
            ApplyHack(ModsDir + "standing-hearts");
            ApplyHack(ModsDir + "fix-item-checks");
            cycle_repeat = 0xC72DF6;
            ResetSceneFlagMask();
        }

        private static void InitIndices()
        {
            GetItemIndices = new List<int>();
            BottleIndices = new List<int[]>();
            string[] lines = Properties.Resources.ITEM_INDICES.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int i = 0;
            bool bottle = false;
            while (i < lines.Length)
            {
                if (lines[i] == "bottle")
                {
                    bottle = true;
                    i++;
                }
                else if (lines[i] == "endbottle")
                {
                    bottle = false;
                    i++;
                }
                else
                {
                    if (lines[i].StartsWith("-"))
                    {
                        i++;
                        continue;
                    };
                    if (bottle)
                    {
                        GetItemIndices.Add(-1);
                        string[] sindices = lines[i].Split(',');
                        int k = sindices.Length;
                        int[] indices = new int[k];
                        for (int j = 0; j < k; j++)
                        {
                            indices[j] = Convert.ToInt32(sindices[j], 16);
                        };
                        BottleIndices.Add(indices);
                    }
                    else
                    {
                        BottleIndices.Add(null);
                        GetItemIndices.Add(Convert.ToInt32(lines[i], 16));
                    };
                    i++;
                };
            };
        }

        private static void InitGetBottleList()
        {
            BottleList = new List<BottleCatchEntry[]>();
            int f = GetFileIndexForWriting(BottleCatchTable);
            int baseaddr = BottleCatchTable - MMFileList[f].Addr;
            for (int i = 0; i < BottleIndices.Count; i++)
            {
                if (BottleIndices[i] == null)
                {
                    BottleList.Add(null);
                }
                else
                {
                    BottleCatchEntry[] bi = new BottleCatchEntry[BottleIndices[i].Length];
                    for (int j = 0; j < BottleIndices[i].Length; j++)
                    {
                        BottleCatchEntry b = new BottleCatchEntry();
                        int offset = BottleIndices[i][j] * 6;
                        b.ItemGained = MMFileList[f].Data[baseaddr + offset + 3];
                        b.Index = MMFileList[f].Data[baseaddr + offset + 4];
                        b.Message = MMFileList[f].Data[baseaddr + offset + 5];
                        bi[j] = b;
                    };
                    BottleList.Add(bi);
                };
            };
        }

        private static void InitGetItemList()
        {
            GetItemList = new List<GetItemEntry>();
            int f = GetFileIndexForWriting(GetItemTable);
            int baseaddr = GetItemTable - MMFileList[f].Addr;
            for (int i = 0; i < GetItemIndices.Count; i++)
            {
                if (GetItemIndices[i] == -1)
                {
                    GetItemList.Add(null);
                }
                else
                {
                    int offset = (GetItemIndices[i] - 1) * 8;
                    GetItemEntry g = new GetItemEntry();
                    g.ItemGained = MMFileList[f].Data[baseaddr + offset];
                    g.Flag = MMFileList[f].Data[baseaddr + offset + 1];
                    g.Index = MMFileList[f].Data[baseaddr + offset + 2];
                    g.Type = MMFileList[f].Data[baseaddr + offset + 3];
                    g.Message = (short)((MMFileList[f].Data[baseaddr + offset + 4] << 8) | MMFileList[f].Data[baseaddr + offset + 5]);
                    g.Object = (short)((MMFileList[f].Data[baseaddr + offset + 6] << 8) | MMFileList[f].Data[baseaddr + offset + 7]);
                    GetItemList.Add(g);
                };
            };
        }

        public static void InitItems()
        {
            InitIndices();
            InitGetItemList();
            InitGetBottleList();
        }

        public static void WriteNewBottle(int ItemSlot, int NewItem)
        {
            int f = GetFileIndexForWriting(BottleCatchTable);
            int baseaddr = BottleCatchTable - MMFileList[f].Addr;
            for (int i = 0; i < BottleIndices[ItemSlot].Length; i++)
            {
                int offset = BottleIndices[ItemSlot][i] * 6;
                MMFileList[f].Data[baseaddr + offset + 3] = BottleList[NewItem][0].ItemGained;
                MMFileList[f].Data[baseaddr + offset + 4] = BottleList[NewItem][0].Index;
                MMFileList[f].Data[baseaddr + offset + 5] = BottleList[NewItem][0].Message;
            };
        }

        public static void WriteNewItem(int ItemSlot, int NewItem, bool IsRepeatable, bool RepeatCycle)
        {
            int f = GetFileIndexForWriting(GetItemTable);
            int baseaddr = GetItemTable - MMFileList[f].Addr;
            int offset = (GetItemIndices[ItemSlot] - 1) * 8;
            MMFileList[f].Data[baseaddr + offset] = GetItemList[NewItem].ItemGained;
            MMFileList[f].Data[baseaddr + offset + 1] = GetItemList[NewItem].Flag;
            MMFileList[f].Data[baseaddr + offset + 2] = GetItemList[NewItem].Index;
            MMFileList[f].Data[baseaddr + offset + 3] = GetItemList[NewItem].Type;
            MMFileList[f].Data[baseaddr + offset + 4] = (byte)(GetItemList[NewItem].Message >> 8);
            MMFileList[f].Data[baseaddr + offset + 5] = (byte)(GetItemList[NewItem].Message & 0xFF);
            MMFileList[f].Data[baseaddr + offset + 6] = (byte)(GetItemList[NewItem].Object >> 8);
            MMFileList[f].Data[baseaddr + offset + 7] = (byte)(GetItemList[NewItem].Object & 0xFF);
            if (RepeatCycle)
            {
                WriteToROM(cycle_repeat, (ushort)GetItemIndices[ItemSlot]);
                cycle_repeat += 2;
            };
            if (!IsRepeatable)
            {
                UpdateSceneFlagMask(GetItemIndices[ItemSlot]);
            };
            if (NewItem == 12)
            {
                WriteToROM(0xB49982, (ushort)GetItemIndices[ItemSlot]);
                WriteToROM(0xC72B42, (ushort)GetItemIndices[ItemSlot]);
            };
            if (NewItem == 17)
            {
                WriteToROM(0xB4999A, (ushort)GetItemIndices[ItemSlot]);
                WriteToROM(0xC72B4E, (ushort)GetItemIndices[ItemSlot]);
            };
            if (NewItem == 13)
            {
                WriteToROM(0xB499A6, (ushort)GetItemIndices[ItemSlot]);
                WriteToROM(0xC72B5A, (ushort)GetItemIndices[ItemSlot]);
            };
            if (NewItem == 14)
            {
                WriteToROM(0xB499B2, (ushort)GetItemIndices[ItemSlot]);
                WriteToROM(0xC72B66, (ushort)GetItemIndices[ItemSlot]);
            };
        }

    }

}