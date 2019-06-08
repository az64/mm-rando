using MMRando.Models.Rom;
using System;
using System.Collections.Generic;

namespace MMRando.Utils
{
    public static class ItemSwapUtils
    {
        const int BOTTLE_CATCH_TABLE = 0xCD7C08;
        static int cycle_repeat = 0;
        static int GET_ITEM_TABLE = 0;

        public static void ReplaceGetItemTable(string ModsDir)
        {
            ResourceUtils.ApplyHack(ModsDir + "replace-gi-table");
            int last_file = RomData.MMFileList.Count - 1;
            GET_ITEM_TABLE = RomUtils.AddNewFile(ModsDir + "gi-table");
            ReadWriteUtils.WriteToROM(0xBDAEAC, (uint)last_file + 1);
            ResourceUtils.ApplyHack(ModsDir + "update-chests");
            RomUtils.AddNewFile(ModsDir + "chest-table");
            ReadWriteUtils.WriteToROM(0xBDAEA8, (uint)last_file + 2);
            ResourceUtils.ApplyHack(ModsDir + "standing-hearts");
            ResourceUtils.ApplyHack(ModsDir + "fix-item-checks");
            cycle_repeat = 0xC72DF6;
            SceneUtils.ResetSceneFlagMask();
        }

        public static void InitIndices()
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
            int f = RomUtils.GetFileIndexForWriting(BOTTLE_CATCH_TABLE);
            int baseaddr = BOTTLE_CATCH_TABLE - RomData.MMFileList[f].Addr;
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
            int f = RomUtils.GetFileIndexForWriting(GET_ITEM_TABLE);
            int baseaddr = GET_ITEM_TABLE - RomData.MMFileList[f].Addr;
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

        public static void WriteNewBottle(int location, int item)
        {
            System.Diagnostics.Debug.WriteLine($"Writing {Items.ITEM_NAMES[item]} --> {Items.ITEM_NAMES[location]}");

            location = ItemUtils.SubtractItemOffset(location);
            item = ItemUtils.SubtractItemOffset(item);

            int f = RomUtils.GetFileIndexForWriting(BOTTLE_CATCH_TABLE);
            int baseaddr = BOTTLE_CATCH_TABLE - RomData.MMFileList[f].Addr;
            var fileData = RomData.MMFileList[f].Data;
            for (int i = 0; i < RomData.BottleIndices[location].Length; i++)
            {
                int offset = RomData.BottleIndices[location][i] * 6 + baseaddr;
                var newBottle = RomData.BottleList[item][0];
                var data = new byte[]
                {
                    newBottle.ItemGained,
                    newBottle.Index,
                    newBottle.Message,
                };
                ReadWriteUtils.Arr_Insert(data, 0, data.Length, fileData, offset + 3);
            }
        }

        public static void WriteNewItem(int location, int item)
        {
            System.Diagnostics.Debug.WriteLine($"Writing {Items.ITEM_NAMES[item]} --> {Items.ITEM_NAMES[location]}");

            bool isRepeatable = Items.REPEATABLE.Contains(item);
            bool isCycleRepeatable = Items.CYCLE_REPEATABLE.Contains(item);

            location = ItemUtils.SubtractItemOffset(location);
            item = ItemUtils.SubtractItemOffset(item);
            
            int f = RomUtils.GetFileIndexForWriting(GET_ITEM_TABLE);
            int baseaddr = GET_ITEM_TABLE - RomData.MMFileList[f].Addr;
            var getItemIndex = RomData.GetItemIndices[location];
            if (location == Items.ItemGoldDust)
            {
                getItemIndex = 0x6A; // Place items intended for Gold Dust at the Goron Race Bottle location.
            }
            int offset = (getItemIndex - 1) * 8 + baseaddr;
            var newItem = RomData.GetItemList[item];
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
            
            if (isCycleRepeatable)
            {
                ReadWriteUtils.WriteToROM(cycle_repeat, (ushort)getItemIndex);
                cycle_repeat += 2;
            }

            if (!isRepeatable)
            {
                SceneUtils.UpdateSceneFlagMask(getItemIndex);
            }

            if (item == Items.ItemBottleWitch)
            {
                ReadWriteUtils.WriteToROM(0xB49982, (ushort)getItemIndex);
                ReadWriteUtils.WriteToROM(0xC72B42, (ushort)getItemIndex);
            }

            if (item == Items.ItemBottleMadameAroma)
            {
                ReadWriteUtils.WriteToROM(0xB4999A, (ushort)getItemIndex);
                ReadWriteUtils.WriteToROM(0xC72B4E, (ushort)getItemIndex);
            }

            if (item == Items.ItemBottleAliens)
            {
                ReadWriteUtils.WriteToROM(0xB499A6, (ushort)getItemIndex);
                ReadWriteUtils.WriteToROM(0xC72B5A, (ushort)getItemIndex);
            }
            // Goron Race Bottle now rewards a plain Gold Dust, so this is unnecessary until a proper fix for Goron Dust is found.
            //if (NewItem == Items.ItemBottleGoronRace)
            //{
            //    WriteToROM(0xB499B2, (ushort)getItemIndex);
            //    WriteToROM(0xC72B66, (ushort)getItemIndex);
            //}
        }

    }

}