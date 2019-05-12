using MMRando.Constants;
using MMRando.Models.Rom;
using System;
using System.Collections.Generic;

namespace MMRando.Utils
{
    public static class ItemSwapUtils
    {
        static int cycle_repeat = 0;

        public static void ReplaceGetItemTable(string ModsDir)
        {
            ResourceUtils.ApplyHack(ModsDir + "replace-gi-table");
            int last_file = RomData.MMFileList.Count - 1;
            Addresses.GetItemTable = RomUtils.AddNewFile(ModsDir + "gi-table");
            ReadWriteUtils.WriteToROM(0xBDAEAC, (uint)last_file + 1);
            ResourceUtils.ApplyHack(ModsDir + "update-chests");
            RomUtils.AddNewFile(ModsDir + "chest-table");
            ReadWriteUtils.WriteToROM(0xBDAEA8, (uint)last_file + 2);
            ResourceUtils.ApplyHack(ModsDir + "standing-hearts");
            ResourceUtils.ApplyHack(ModsDir + "fix-item-checks");
            cycle_repeat = 0xC72DF6;
            SceneUtils.ResetSceneFlagMask();
        }

        private static void InitIndices()
        {
            RomData.GetItemIndices = new List<int>();
            RomData.BottleIndices = new List<int[]>();
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
                        RomData.GetItemIndices.Add(-1);
                        string[] sindices = lines[i].Split(',');
                        int k = sindices.Length;
                        int[] indices = new int[k];
                        for (int j = 0; j < k; j++)
                        {
                            indices[j] = Convert.ToInt32(sindices[j], 16);
                        };
                        RomData.BottleIndices.Add(indices);
                    }
                    else
                    {
                        RomData.BottleIndices.Add(null);
                        RomData.GetItemIndices.Add(Convert.ToInt32(lines[i], 16));
                    }

                    i++;
                }
            }
        }

        private static void InitGetBottleList()
        {
            RomData.BottleList = new List<BottleCatchEntry[]>();
            int f = RomUtils.GetFileIndexForWriting(Addresses.BottleCatchTable);
            int baseaddr = Addresses.BottleCatchTable - RomData.MMFileList[f].Addr;
            for (int i = 0; i < RomData.BottleIndices.Count; i++)
            {
                if (RomData.BottleIndices[i] == null)
                {
                    RomData.BottleList.Add(null);
                }
                else
                {
                    BottleCatchEntry[] bi = new BottleCatchEntry[RomData.BottleIndices[i].Length];
                    for (int j = 0; j < RomData.BottleIndices[i].Length; j++)
                    {
                        BottleCatchEntry b = new BottleCatchEntry();
                        int offset = RomData.BottleIndices[i][j] * 6;
                        b.ItemGained = RomData.MMFileList[f].Data[baseaddr + offset + 3];
                        b.Index = RomData.MMFileList[f].Data[baseaddr + offset + 4];
                        b.Message = RomData.MMFileList[f].Data[baseaddr + offset + 5];
                        bi[j] = b;
                    };
                    RomData.BottleList.Add(bi);
                }
            }
        }

        private static void InitGetItemList()
        {
            RomData.GetItemList = new List<GetItemEntry>();
            int f = RomUtils.GetFileIndexForWriting(Addresses.GetItemTable);
            int baseaddr = Addresses.GetItemTable - RomData.MMFileList[f].Addr;
            for (int i = 0; i < RomData.GetItemIndices.Count; i++)
            {
                if (RomData.GetItemIndices[i] == -1)
                {
                    RomData.GetItemList.Add(null);
                }
                else
                {
                    int offset = (RomData.GetItemIndices[i] - 1) * 8;
                    GetItemEntry g = new GetItemEntry();
                    g.ItemGained = RomData.MMFileList[f].Data[baseaddr + offset];
                    g.Flag = RomData.MMFileList[f].Data[baseaddr + offset + 1];
                    g.Index = RomData.MMFileList[f].Data[baseaddr + offset + 2];
                    g.Type = RomData.MMFileList[f].Data[baseaddr + offset + 3];
                    g.Message = (short)((RomData.MMFileList[f].Data[baseaddr + offset + 4] << 8)
                        | RomData.MMFileList[f].Data[baseaddr + offset + 5]);
                    g.Object = (short)((RomData.MMFileList[f].Data[baseaddr + offset + 6] << 8) 
                        | RomData.MMFileList[f].Data[baseaddr + offset + 7]);
                    RomData.GetItemList.Add(g);
                }
            }
        }

        public static void InitItems()
        {
            InitIndices();
            InitGetItemList();
            InitGetBottleList();
        }

        public static void WriteNewBottle(int ItemSlot, int NewItem)
        {
            int f = RomUtils.GetFileIndexForWriting(Addresses.BottleCatchTable);
            int baseaddr = Addresses.BottleCatchTable - RomData.MMFileList[f].Addr;
            for (int i = 0; i < RomData.BottleIndices[ItemSlot].Length; i++)
            {
                int offset = RomData.BottleIndices[ItemSlot][i] * 6;
                RomData.MMFileList[f].Data[baseaddr + offset + 3] = RomData.BottleList[NewItem][0].ItemGained;
                RomData.MMFileList[f].Data[baseaddr + offset + 4] = RomData.BottleList[NewItem][0].Index;
                RomData.MMFileList[f].Data[baseaddr + offset + 5] = RomData.BottleList[NewItem][0].Message;
            };
        }

        public static void WriteNewItem(int ItemSlot, int NewItem, bool IsRepeatable, bool RepeatCycle)
        {
            int f = RomUtils.GetFileIndexForWriting(Addresses.GetItemTable);
            int baseaddr = Addresses.GetItemTable - RomData.MMFileList[f].Addr;
            var itemIndex = RomData.GetItemIndices[ItemSlot];
            if (ItemSlot == Items.ItemGoldDust)
            {
                itemIndex = 0x6A; // Place items intended for Gold Dust at the Goron Race Bottle location.
            }
            int offset = (itemIndex - 1) * 8;
            RomData.MMFileList[f].Data[baseaddr + offset] = RomData.GetItemList[NewItem].ItemGained;
            RomData.MMFileList[f].Data[baseaddr + offset + 1] = RomData.GetItemList[NewItem].Flag;
            RomData.MMFileList[f].Data[baseaddr + offset + 2] = RomData.GetItemList[NewItem].Index;
            RomData.MMFileList[f].Data[baseaddr + offset + 3] = RomData.GetItemList[NewItem].Type;
            RomData.MMFileList[f].Data[baseaddr + offset + 4] = (byte)(RomData.GetItemList[NewItem].Message >> 8);
            RomData.MMFileList[f].Data[baseaddr + offset + 5] = (byte)(RomData.GetItemList[NewItem].Message & 0xFF);
            RomData.MMFileList[f].Data[baseaddr + offset + 6] = (byte)(RomData.GetItemList[NewItem].Object >> 8);
            RomData.MMFileList[f].Data[baseaddr + offset + 7] = (byte)(RomData.GetItemList[NewItem].Object & 0xFF);

            if (RepeatCycle)
            {
                ReadWriteUtils.WriteToROM(cycle_repeat, (ushort)itemIndex);
                cycle_repeat += 2;
            }

            if (!IsRepeatable)
            {
                SceneUtils.UpdateSceneFlagMask(itemIndex);
            }

            if (NewItem == Items.ItemBottleWitch)
            {
                ReadWriteUtils.WriteToROM(0xB49982, (ushort)itemIndex);
                ReadWriteUtils.WriteToROM(0xC72B42, (ushort)itemIndex);
            }

            if (NewItem == Items.ItemBottleMadameAroma)
            {
                ReadWriteUtils.WriteToROM(0xB4999A, (ushort)itemIndex);
                ReadWriteUtils.WriteToROM(0xC72B4E, (ushort)itemIndex);
            }

            if (NewItem == Items.ItemBottleAliens)
            {
                ReadWriteUtils.WriteToROM(0xB499A6, (ushort)itemIndex);
                ReadWriteUtils.WriteToROM(0xC72B5A, (ushort)itemIndex);
            };
            // Goron Race Bottle now rewards a plain Gold Dust, so this is unnecessary until a proper fix for Goron Dust is found.
            //if (NewItem == Items.ItemBottleGoronRace)
            //{
            //    WriteToROM(0xB499B2, (ushort)GetItemIndices[ItemSlot]);
            //    WriteToROM(0xC72B66, (ushort)GetItemIndices[ItemSlot]);
            //};
        }

    }

}