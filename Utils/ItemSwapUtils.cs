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
            bool bottle = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("-"))
                {
                    continue;
                }
                else if (line == "bottle")
                {
                    bottle = true;
                    continue;
                }
                else if (line == "endbottle")
                {
                    bottle = false;
                    continue;
                }
                else if (bottle)
                {
                    RomData.GetItemIndices.Add(-1);
                    int[] indices = Array.ConvertAll(
                        line.Split(','), item => Convert.ToInt32(item, 16));
                    RomData.BottleIndices.Add(indices);
                }
                else
                {
                    RomData.BottleIndices.Add(null);
                    RomData.GetItemIndices.Add(Convert.ToInt32(line, 16));
                }

            }
        }

        private static void InitGetBottleList()
        {
            RomData.BottleList = new List<BottleCatchEntry[]>();
            int f = RomUtils.GetFileIndexForWriting(Addresses.BottleCatchTable);
            int baseaddr = Addresses.BottleCatchTable - RomData.MMFileList[f].Addr;
            var fileData = RomData.MMFileList[f].Data;
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
                        int offset = RomData.BottleIndices[i][j] * 6 + baseaddr;
                        BottleCatchEntry b = new BottleCatchEntry
                        {
                            ItemGained = fileData[offset + 3],
                            Index = fileData[offset + 4],
                            Message = fileData[offset + 5]
                        };
                        bi[j] = b;
                    }
                    RomData.BottleList.Add(bi);
                }
            }
        }

        private static void InitGetItemList()
        {
            RomData.GetItemList = new List<GetItemEntry>();
            int f = RomUtils.GetFileIndexForWriting(Addresses.GetItemTable);
            int baseaddr = Addresses.GetItemTable - RomData.MMFileList[f].Addr;
            var fileData = RomData.MMFileList[f].Data;
            for (int i = 0; i < RomData.GetItemIndices.Count; i++)
            {
                if (RomData.GetItemIndices[i] == -1)
                {
                    RomData.GetItemList.Add(null);
                }
                else
                {
                    int offset = (RomData.GetItemIndices[i] - 1) * 8 + baseaddr;
                    GetItemEntry g = new GetItemEntry
                    {
                        ItemGained = fileData[offset],
                        Flag = fileData[offset + 1],
                        Index = fileData[offset + 2],
                        Type = fileData[offset + 3],
                        Message = (short)((fileData[offset + 4] << 8) | fileData[offset + 5]),
                        Object = (short)((fileData[offset + 6] << 8) | fileData[offset + 7])
                    };
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
            var fileData = RomData.MMFileList[f].Data;
            for (int i = 0; i < RomData.BottleIndices[ItemSlot].Length; i++)
            {
                int offset = RomData.BottleIndices[ItemSlot][i] * 6 + baseaddr;
                var newBottle = RomData.BottleList[NewItem][0];
                var data = new byte[]
                {
                    newBottle.ItemGained,
                    newBottle.Index,
                    newBottle.Message,
                };
                ReadWriteUtils.Arr_Insert(data, 0, data.Length, fileData, offset + 3);
            }
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
            int offset = (itemIndex - 1) * 8 + baseaddr;
            var newItem = RomData.GetItemList[NewItem];
            var fileData = RomData.MMFileList[f].Data;
            var data = new byte[]
            {
                newItem.ItemGained,
                newItem.Flag,
                newItem.Index,
                newItem.Type,
                (byte)(newItem.Message >> 8),
                (byte)(newItem.Message & 0xFF),
                (byte)(newItem.Object >> 8),
                (byte)(newItem.Object & 0xFF),
            };
            ReadWriteUtils.Arr_Insert(data, 0, data.Length, fileData, offset);

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