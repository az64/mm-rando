using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MMRando
{

    public partial class MainRandomizerForm
    {

        Random RNG;

        private int[] ENTRANCE_NEW = new int[] { -1, -1, -1, -1 };
        private int[] EXIT_NEW = new int[] { -1, -1, -1, -1 };
        private int[] DC_FLAG_NEW = new int[] { -1, -1, -1, -1 };
        private int[] DC_MASK_NEW = new int[] { -1, -1, -1, -1 };
        private int[] NewEnts = new int[] { -1, -1, -1, -1 };
        private int[] NewExts = new int[] { -1, -1, -1, -1 };

        public bool SongsMixed { get; set; }
        public bool ExcludeSongOfSoaring { get; set; }
        public bool Keysanity { get; set; }
        public bool BottleCatch { get; set; }
        public bool Shops { get; set; }
        public bool Other { get; set; } // todo rename??
        public bool User { get; set; }

        public class ItemObject
        {
            public int ID { get; set; }
            public List<int> Dependence { get; set; } = new List<int>();
            public List<List<int>> Conditional { get; set; } = new List<List<int>>();
            public int Time_Needed { get; set; }
            public int Time_Available { get; set; }
            public int ReplacesItemId { get; set; } = -1;
            public List<int> Cannot_Require { get; set; } = new List<int>();
        }

        public class SequenceInfo
        {
            public string Name { get; set; }
            public int Replaces { get; set; } = -1;
            public int MM_seq { get; set; } = -1;
            public List<int> Type { get; set; } = new List<int>();
            public int Inst { get; set; }
        }

        public class Gossip
        {
            public string[] SourceMessage { get; set; }
            public string[] DestinationMessage { get; set; }
        }

        List<ItemObject> ItemList { get; set; }
        List<SequenceInfo> SequenceList { get; set; }
        List<SequenceInfo> TargetSequences { get; set; }
        List<Gossip> GossipList { get; set; }

        List<int> ConditionsChecked { get; set; }
        List<int> DependenceChecked { get; set; }
        List<string> GossipQuotes { get; set; }

        //rando functions

        private void MakeGossipQuotes()
        {
            GossipList = new List<Gossip>();
            GossipQuotes = new List<string>();

            string[] lines = Properties.Resources.GOSSIP
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            int itemIndex = 0;
            while (itemIndex < lines.Length)
            {
                var sourceMessage = lines[itemIndex].Split(';');
                var destinationMessage = lines[itemIndex + 1].Split(';');
                var currentGossip = new Gossip
                {
                    SourceMessage = sourceMessage,
                    DestinationMessage = destinationMessage
                };

                itemIndex += 2;
                GossipList.Add(currentGossip);
            };

            for (itemIndex = 0; itemIndex < ItemList.Count; itemIndex++)
            {
                if (ItemList[itemIndex].ReplacesItemId == -1)
                {
                    continue;
                };

                if ((!BottleCatch) && ((itemIndex >= BottleCatchFairy) && (itemIndex <= BottleCatchMushroom)))
                {
                    continue;
                };

                if ((!Shops) && ((itemIndex >= ShopItemTownRedPotion) && (itemIndex <= ShopItemZoraRedPotion)))
                {
                    continue;
                };

                if ((!Keysanity) && ((itemIndex >= ItemWoodfallMap) && (itemIndex <= ItemStoneTowerKey4)))
                {
                    continue;
                };

                int messageStart = RNG.Next(Values.PartialGossipMessageStartSentences.Length);
                int messageMid = RNG.Next(Values.PartialGossipMessageMidSentences.Length);
                bool isFake = (RNG.Next(100) < 5);
                int replacesItemId = ItemList[itemIndex].ReplacesItemId;
                if (replacesItemId > AreaISTNew) {
                   replacesItemId -= 23; // TODO significance of 23?
                }; 

                int itemIndexCopy = itemIndex;
                if (itemIndexCopy > AreaISTNew) {
                    itemIndexCopy -= 23; // TODO significance of 23?
                };

                if (isFake) { replacesItemId = RNG.Next(GossipList.Count); };

                int sourceMessageLength = GossipList[replacesItemId]
                    .SourceMessage
                    .Length;
                int destinationMessageLength = GossipList[itemIndexCopy]
                    .DestinationMessage
                    .Length;

                string sourceMessage = GossipList[replacesItemId]
                    .SourceMessage[RNG.Next(sourceMessageLength)];
                string destinationMessage = GossipList[itemIndexCopy]
                    .DestinationMessage[RNG.Next(destinationMessageLength)];

                string soundAddress;
                if (isFake)
                {
                    soundAddress = "\x1E\x69\x0A";
                }
                else
                {
                    soundAddress = "\x1E\x69\x0C";
                };
                var gossipMessageBuilder = new StringBuilder();
                gossipMessageBuilder.Append(soundAddress);
                gossipMessageBuilder.Append(Values.PartialGossipMessageStartSentences[messageStart]);
                gossipMessageBuilder.Append("\x01" + sourceMessage + "\x00\x11");
                gossipMessageBuilder.Append(Values.PartialGossipMessageMidSentences[messageMid]);
                gossipMessageBuilder.Append("\x06" + destinationMessage + "\x00" + "...\xBF");

                GossipQuotes.Add(gossipMessageBuilder.ToString());
            };
            for (itemIndex = 0; itemIndex < Values.JunkGossipMessages.Length; itemIndex++)
            {
                GossipQuotes.Add(Values.JunkGossipMessages[itemIndex]);
            };
        }

        private void EntranceShuffle()
        {
            ENTRANCE_NEW = new int[] { -1, -1, -1, -1 };
            EXIT_NEW = new int[] { -1, -1, -1, -1 };
            DC_FLAG_NEW = new int[] { -1, -1, -1, -1 };
            DC_MASK_NEW = new int[] { -1, -1, -1, -1 };
            NewEnts = new int[] { -1, -1, -1, -1 };
            NewExts = new int[] { -1, -1, -1, -1 };
            for (int i = 0; i < 4; i++)
            {
                int n;
                do
                {
                    n = RNG.Next(4);
                } while (NewEnts.Contains(n));
                NewEnts[i] = n;
                NewExts[n] = i;
            };
            ItemObject[] DE = new ItemObject[] { ItemList[AreaWoodFallAccess], ItemList[AreaSnowheadAccess], ItemList[AreaISTAccess], ItemList[AreaGreatBayAccess] };
            int[] DI = new int[] { AreaWoodFallAccess, AreaSnowheadAccess, AreaISTAccess, AreaGreatBayAccess };
            for (int i = 0; i < 4; i++)
            {
                ItemList[DI[NewEnts[i]]] = DE[i];
            };
            DE = new ItemObject[] { ItemList[AreaWoodFallClear], ItemList[AreaSnowheadClear], ItemList[AreaStoneTowerClear], ItemList[AreaGreatBayClear] };
            DI = new int[] { AreaWoodFallClear, AreaSnowheadClear, AreaStoneTowerClear, AreaGreatBayClear };
            for (int i = 0; i < 4; i++)
            {
                ItemList[DI[i]] = DE[NewEnts[i]];
            };
            for (int i = 0; i < 4; i++)
            {
                ENTRANCE_NEW[i] = Values.ENTRANCE_OLD[NewEnts[i]];
                EXIT_NEW[i] = Values.EXIT_OLD[NewExts[i]];
                DC_FLAG_NEW[i] = Values.DC_FLAG_OLD[NewExts[i]];
                DC_MASK_NEW[i] = Values.DC_MASK_OLD[NewExts[i]];
            };
        }

        private void ReadSeqInfo()
        {
            SequenceList = new List<SequenceInfo>();
            TargetSequences = new List<SequenceInfo>();
            string[] lines = Properties.Resources.SEQS.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int i = 0;
            while (i < lines.Length)
            {
                SequenceInfo s = new SequenceInfo();
                SequenceInfo t = new SequenceInfo();
                s.Name = lines[i];
                s.Type = Array.ConvertAll(lines[i + 1].Split(','), int.Parse).ToList();
                s.Inst = Convert.ToInt32(lines[i + 2], 16);
                t.Name = lines[i];
                t.Type = Array.ConvertAll(lines[i + 1].Split(','), int.Parse).ToList();
                t.Inst = Convert.ToInt32(lines[i + 2], 16);
                if (s.Name.StartsWith("mm-"))
                {
                    t.Replaces = Convert.ToInt32(lines[i + 3], 16);
                    s.MM_seq = Convert.ToInt32(lines[i + 3], 16);
                    TargetSequences.Add(t);
                    i += 4;
                }
                else
                {
                    if (s.Name == "mmr-f-sot")
                    {
                        s.Replaces = 0x33;
                    };
                    i += 3;
                };
                if (s.MM_seq != 0x18)
                {
                    SequenceList.Add(s);
                };
            };
        }

        private void BGMShuffle()
        {
            while (TargetSequences.Count > 0)
            {
                List<SequenceInfo> Unassigned = SequenceList.FindAll(u => u.Replaces == -1);
                int t = RNG.Next(TargetSequences.Count);
                while (true)
                {
                    int s = RNG.Next(Unassigned.Count);
                    if (Unassigned[s].Name.StartsWith("mm-") & (RNG.Next(2) == 0))
                    {
                        continue;
                    };
                    for (int i = 0; i < Unassigned[s].Type.Count; i++)
                    {
                        if (TargetSequences[t].Type.Contains(Unassigned[s].Type[i]))
                        {
                            Unassigned[s].Replaces = TargetSequences[t].Replaces;
                            Debug.WriteLine(Unassigned[s].Name + " -> " + TargetSequences[t].Name);
                            TargetSequences.RemoveAt(t);
                            break;
                        }
                        else if (i + 1 == Unassigned[s].Type.Count)
                        {
                            if ((RNG.Next(30) == 0) && ((Unassigned[s].Type[0] & 8) == (TargetSequences[t].Type[0] & 8)) &&
                                (Unassigned[s].Type.Contains(10) == TargetSequences[t].Type.Contains(10)) && (!Unassigned[s].Type.Contains(16)))
                            {
                                Unassigned[s].Replaces = TargetSequences[t].Replaces;
                                Debug.WriteLine(Unassigned[s].Name + " -> " + TargetSequences[t].Name);
                                TargetSequences.RemoveAt(t);
                                break;
                            };
                        };
                    };
                    if (Unassigned[s].Replaces != -1)
                    {
                        break;
                    };
                };
            };
            SequenceList.RemoveAll(u => u.Replaces == -1);
        }

        private void SortBGM()
        {
            if (!cBGM.Checked)
            {
                return;
            };
            ReadSeqInfo();
            BGMShuffle();
        }

        private void SetTatlColour()
        {
            if (cTatl.SelectedIndex == 4)
            {
                for (int i = 0; i < 10; i++)
                {
                    byte[] c = new byte[4];
                    RNG.NextBytes(c);
                    if ((i % 2) == 0)
                    {
                        c[0] = 0xFF;
                    }
                    else
                    {
                        c[0] = 0;
                    };
                    Values.TatlColours[4, i] = BitConverter.ToUInt32(c, 0);
                };
            };
        }

        private void MakeSpoilerLog()
        {
            if (cMode.SelectedIndex == 2)
            {
                return;
            };
            StreamWriter LogFile = new StreamWriter("SpoilerLog-" + UpdateSettingsString() + ".txt");
            if (cDEnt.Checked)
            {
                LogFile.WriteLine("------------Entrance----------------------------Destination-----------");
                string[] destinations = new string[] { "Woodfall", "Snowhead", "Inverted Stone Tower", "Great Bay" };
                for (int i = 0; i < 4; i++)
                {
                    LogFile.WriteLine(destinations[i].PadRight(32, '-') + "---->>" + destinations[NewEnts[i]].PadLeft(32, '-'));
                };
                LogFile.WriteLine("");
            }; /*
            if (!Other)
            {
                ItemList.RemoveRange(Lens_Cave_RR, TM_StoneTower - Lens_Cave_RR + 1);
            };
            if (!BottleCatch)
            {
                ItemList.RemoveRange(B_Fairy, B_Mushroom - B_Fairy + 1);
            };
            if (!Shops)
            {
                ItemList.RemoveRange(TP_RP, ZS_RP - TP_RP + 1);
            };
            if (!Keysanity)
            {
                ItemList.RemoveRange(WF_Map, ST_Key4 - WF_Map + 1);
            }; */
            ItemList.RemoveAll(u => u.ReplacesItemId == -1);
            LogFile.WriteLine("--------------Item------------------------------Destination-----------");
            for (int i = 0; i < ItemList.Count; i++)
            {
                LogFile.WriteLine(ITEM_NAMES[ItemList[i].ID].PadRight(32, '-') + "---->>" + ITEM_NAMES[ItemList[i].ReplacesItemId].PadLeft(32, '-'));
            };
            LogFile.WriteLine("");
            LogFile.WriteLine("-----------Destination------------------------------Item--------------");
            ItemList.Sort((i, j) => i.ReplacesItemId.CompareTo(j.ReplacesItemId));
            for (int i = 0; i < ItemList.Count; i++)
            {
                LogFile.WriteLine(ITEM_NAMES[ItemList[i].ReplacesItemId].PadRight(32, '-') + "<<----" + ITEM_NAMES[ItemList[i].ID].PadLeft(32, '-'));
            };
            LogFile.Close();
        }

        private void ReadRulesetItemData()
        {
            ItemList = new List<ItemObject>();
            string[] lines;
            if (cMode.SelectedIndex == 0)
            {
                lines = Properties.Resources.REQ_CASUAL.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
            else if (cMode.SelectedIndex == 1)
            {
                lines = Properties.Resources.REQ_GLITCH.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
            else if (cMode.SelectedIndex == 3)
            {
                StreamReader Req = new StreamReader(File.Open(openLogic.FileName, FileMode.Open));
                lines = Req.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                Req.Close();
            }
            else
            {
                lines = null;
            };
            ItemObject CurrentItem = new ItemObject();
            int i = 0;
            int j = 0;
            if (lines == null)
            {
                for (i = 0; i < 255; i++)
                {
                    CurrentItem.ID = i;
                    CurrentItem.Dependence = null;
                    CurrentItem.Conditional = null;
                    CurrentItem.Time_Needed = 0;
                    CurrentItem.Time_Available = 63;
                    ItemList.Add(CurrentItem);
                    CurrentItem = new ItemObject();
                };
            }
            else
            {
                foreach (string l in lines)
                {
                    if (!(l.Contains("-")))
                    {
                        List<int> dependence = new List<int>();
                        List<List<int>> conditional = new List<List<int>>();
                        switch (j)
                        {
                            case 0:
                                //dependence
                                if (l == "")
                                {
                                    CurrentItem.Dependence = null;
                                }
                                else
                                {
                                    foreach (string k in l.Split(','))
                                    {
                                        dependence.Add(Convert.ToInt32(k));
                                    };
                                    CurrentItem.Dependence = dependence;
                                };
                                break;
                            case 1:
                                //conditionals
                                if (l == "")
                                {
                                    CurrentItem.Conditional = null;
                                }
                                else
                                {
                                    foreach (string k in l.Split(';'))
                                    {
                                        int[] conditionaloption = Array.ConvertAll(k.Split(','), int.Parse);
                                        conditional.Add(conditionaloption.ToList());
                                    };
                                    CurrentItem.Conditional = conditional;
                                };
                                break;
                            case 2:
                                //time needed
                                CurrentItem.Time_Needed = Convert.ToInt32(l);
                                break;
                            case 3:
                                //time available
                                CurrentItem.Time_Available = Convert.ToInt32(l);
                                if (CurrentItem.Time_Available == 0) { CurrentItem.Time_Available = 63; };
                                break;
                        };
                        j++;
                        if (j == 4)
                        {
                            CurrentItem.ID = i;
                            ItemList.Add(CurrentItem);
                            CurrentItem = new ItemObject();
                            i++;
                            j = 0;
                        };
                    };
                };
            };
        }

        private bool CheckDependence(int CurrentItem, int Target)
        {
            DependenceChecked.Add(Target);
            if ((ItemList[Target].Conditional != null) && (ItemList[Target].Conditional.Count != 0))
            {
                if (ItemList[Target].Conditional.FindAll(u => u.Contains(CurrentItem)).Count == ItemList[Target].Conditional.Count)
                {
                    return true;
                };
            };
            if (ItemList[Target].Dependence == null)
            {
                return false;
            };
            //cycle through all things
            for (int i = 0; i < ItemList[Target].Dependence.Count; i++)
            {
                int d = ItemList[Target].Dependence[i];
                if (d == CurrentItem)
                {
                    return true;
                };
                if (ItemList[CurrentItem].Cannot_Require != null)
                {
                    for (int j = 0; j < ItemList[CurrentItem].Cannot_Require.Count; j++)
                    {
                        if (ItemList[Target].Dependence.Contains(ItemList[CurrentItem].Cannot_Require[j]))
                        {
                            return true;
                        };
                    };
                };
                if (ItemList[d].ReplacesItemId != -1) { d = ItemList[d].ReplacesItemId; };
                if (!DependenceChecked.Contains(d))
                {
                    if (CheckDependence(CurrentItem, d))
                    {
                        return true;
                    };
                };
            };
            return false;
        }

        private void UpdateConditionals(int CurrentItem, int Target)
        {
            if ((ItemList[Target].Conditional == null) || (ItemList[Target].Conditional.Count == 0))
            {
                return;
            };
            //if ((Target == 114) || (Target == 115))
            //{
            //    return;
            //};
            ItemList[Target].Conditional.RemoveAll(u => u.Contains(CurrentItem));
            if (ItemList[Target].Conditional.Count == 1)
            {
                for (int i = 0; i < ItemList[Target].Conditional[0].Count; i++)
                {
                    if (ItemList[Target].Dependence == null)
                    {
                        ItemList[Target].Dependence = new List<int>();
                    };
                    int j = ItemList[Target].Conditional[0][i];
                    ItemList[Target].Dependence.Add(j);
                    if (ItemList[j].Cannot_Require == null)
                    {
                        ItemList[j].Cannot_Require = new List<int>();
                    };
                    if ((Target == 115) || (Target == 114))
                    {
                        ItemList[j].Cannot_Require.Add(Target);
                    }
                    else
                    {
                        ItemList[j].Cannot_Require.Add(CurrentItem);
                    };
                };
                ItemList[Target].Conditional.RemoveAt(0);
            }
            else
            {
                //check if all conditions have a common item
                for (int i = 0; i < ItemList[Target].Conditional[0].Count; i++)
                {
                    int testitem = ItemList[Target].Conditional[0][i];
                    if (ItemList[Target].Conditional.FindAll(u => u.Contains(testitem)).Count == ItemList[Target].Conditional.Count)
                    {
                        // require this item and remove from conditions
                        if (ItemList[Target].Dependence == null)
                        {
                            ItemList[Target].Dependence = new List<int>();
                        };
                        ItemList[Target].Dependence.Add(testitem);
                        for (int j = 0; j < ItemList[Target].Conditional.Count; j++)
                        {
                            ItemList[Target].Conditional[j].Remove(testitem);
                        };
                        break;
                    };
                };
            };
        }

        private void AddConditionals(int Target, int CurrentItem, int d)
        {
            List<List<int>> BaseConditional = ItemList[Target].Conditional;
            if (BaseConditional == null)
            {
                BaseConditional = new List<List<int>>();
            };
            ItemList[Target].Conditional = new List<List<int>>();
            foreach (List<int> c in ItemList[d].Conditional)
            {
                if (!c.Contains(CurrentItem))
                {
                    List<List<int>> NewConditional = new List<List<int>>();
                    if (BaseConditional.Count == 0)
                    {
                        NewConditional.Add(c);
                    }
                    else
                    {
                        foreach (List<int> b in BaseConditional)
                        {
                            NewConditional.Add(b.Concat(c).ToList());
                        };
                    };
                    ItemList[Target].Conditional.AddRange(NewConditional);
                };
            }
        }

        private void CheckConditionals(int CurrentItem, int Target)
        {
            ConditionsChecked.Add(Target);
            UpdateConditionals(CurrentItem, Target);
            if (ItemList[Target].Dependence == null)
            {
                return;
            };
            for (int i = 0; i < ItemList[Target].Dependence.Count; i++)
            {
                int d = ItemList[Target].Dependence[i];
                if ((d == OtherExplosive) || (d == OtherArrow))
                {
                    foreach (List<int> c in ItemList[d].Conditional)
                    {
                        if (c.Contains(CurrentItem))
                        {
                            AddConditionals(Target, CurrentItem, d);
                            ItemList[Target].Dependence[i] = -1;
                            //d = -1;
                        };
                    };
                };
                if (d != -1)
                {
                    if (ItemList[d].ReplacesItemId != -1) { d = ItemList[d].ReplacesItemId; };
                    if (!ConditionsChecked.Contains(d))
                    {
                        CheckConditionals(CurrentItem, d);
                    };
                };
            };
            ItemList[Target].Dependence.RemoveAll(u => u == -1);
        }

        private bool CheckMatch(int CurrentItem, int Target)
        {
            //check timing
            if (ItemList[CurrentItem].Time_Needed != 0)
            {
                if ((ItemList[CurrentItem].Time_Needed & ItemList[Target].Time_Available) == 0)
                {
                    return false;
                };
            };
            //check direct dependence
            DependenceChecked = new List<int>();
            if (CheckDependence(CurrentItem, Target))
            {
                return false;
            };
            //check conditional dependence
            ConditionsChecked = new List<int>();
            CheckConditionals(CurrentItem, Target);
            return true;
        }

        private void PlaceItem(int CurrentItem, List<int> Targets)
        {
            if (ItemList[CurrentItem].ReplacesItemId != -1)
            {
                return;
            };
            while (true)
            {
                int TargetSlot = 0;
                if ((((CurrentItem > UpgradeGiantWallet) && (CurrentItem < HeartPieceNotebookMayor)) || (CurrentItem > SongOath)) && (Targets.Contains(0)))
                {
                    TargetSlot = RNG.Next(1, Targets.Count);
                }
                else
                {
                    TargetSlot = RNG.Next(Targets.Count);
                };
                if (CheckMatch(CurrentItem, Targets[TargetSlot]))
                {
                    ItemList[CurrentItem].ReplacesItemId = Targets[TargetSlot];
                    if ((ItemList[CurrentItem].Time_Needed != 0) && (Targets[TargetSlot] > TradeItemMoonTear) && (Targets[TargetSlot] < TradeItemRoomKey))
                    {
                        ItemList[Targets[TargetSlot]].Time_Needed = ItemList[CurrentItem].Time_Needed;
                    };
                    Targets.RemoveAt(TargetSlot);
                    return;
                };
            };
        }

        private void ItemShuffle()
        {
            SongsMixed = cMixSongs.Checked;
            ExcludeSongOfSoaring = cSoS.Checked;
            Keysanity = cDChests.Checked;
            BottleCatch = cBottled.Checked;
            Shops = cShop.Checked;
            Other = cAdditional.Checked;
            User = cUserItems.Checked;
            List<int> TargetPool = new List<int>();
            if (User)
            {
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if ((i > SongOath) && (i < ItemWoodfallMap))
                    {
                        continue;
                    };
                    ItemList[i].ReplacesItemId = i;
                };
                for (int i = 0; i < fItemEdit.selected_items.Count; i++)
                {
                    int j = fItemEdit.selected_items[i];
                    if (j > 97)
                    {
                        j += 23;
                    };
                    int k = ItemList.FindIndex(u => u.ID == j);
                    if (k != -1)
                    {
                        ItemList[k].ReplacesItemId = -1;
                    };
                };
                if (!SongsMixed)
                {
                    TargetPool = new List<int>();
                    for (int i = SongSoaring; i < SongOath + 1; i++)
                    {
                        if (ItemList[i].ReplacesItemId != -1)
                        {
                            continue;
                        };
                        TargetPool.Add(i);
                    };
                    for (int i = SongSoaring; i < SongOath + 1; i++)
                    {
                        PlaceItem(i, TargetPool);
                    };
                };
                TargetPool = new List<int>();
                for (int i = BottleCatchFairy; i < BottleCatchMushroom + 1; i++)
                {
                    TargetPool.Add(i);
                };
                for (int i = BottleCatchFairy; i < BottleCatchMushroom + 1; i++)
                {
                    PlaceItem(i, TargetPool);
                };
            }
            else
            {
                if (ExcludeSongOfSoaring)
                {
                    ItemList[SongSoaring].ReplacesItemId = SongSoaring;
                };
                if (!SongsMixed)
                {
                    TargetPool = new List<int>();
                    for (int i = SongSoaring; i < SongOath + 1; i++)
                    {
                        if (ItemList[i].ReplacesItemId != -1)
                        {
                            continue;
                        };
                        TargetPool.Add(i);
                    };
                    for (int i = SongSoaring; i < SongOath + 1; i++)
                    {
                        PlaceItem(i, TargetPool);
                    };
                };
                if (!Keysanity)
                {
                    for (int i = ItemWoodfallMap; i < ItemStoneTowerKey4 + 1; i++)
                    {
                        ItemList[i].ReplacesItemId = i;
                    };
                };
                if (!Shops)
                {
                    for (int i = ShopItemTownRedPotion; i < ShopItemZoraRedPotion + 1; i++)
                    {
                        ItemList[i].ReplacesItemId = i;
                    };
                    ItemList[ItemBombBag].ReplacesItemId = ItemBombBag;
                    ItemList[UpgradeBigBombBag].ReplacesItemId = UpgradeBigBombBag;
                    ItemList[MaskAllNight].ReplacesItemId = MaskAllNight;
                };
                if (!Other)
                {
                    for (int i = ChestLensCaveRedRupee; i < GrottoToGR + 1; i++)
                    {
                        ItemList[i].ReplacesItemId = i;
                    };
                };
                if (BottleCatch)
                {
                    TargetPool = new List<int>();
                    for (int i = BottleCatchFairy; i < BottleCatchMushroom + 1; i++)
                    {
                        TargetPool.Add(i);
                    };
                    for (int i = BottleCatchFairy; i < BottleCatchMushroom + 1; i++)
                    {
                        PlaceItem(i, TargetPool);
                    };
                }
                else
                {
                    for (int i = BottleCatchFairy; i < BottleCatchMushroom + 1; i++)
                    {
                        ItemList[i].ReplacesItemId = i;
                    };
                };
            };
            TargetPool = new List<int>();
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (((i > SongOath) && (i < ItemWoodfallMap)) || (ItemList[i].ReplacesItemId != -1))
                {
                    continue;
                };
                TargetPool.Add(i);
            };
            PlaceItem(TradeItemRoomKey, TargetPool);
            PlaceItem(TradeItemKafeiLetter, TargetPool);
            PlaceItem(TradeItemPendant, TargetPool);
            PlaceItem(TradeItemMamaLetter, TargetPool);
            if (ItemList[0].ReplacesItemId == -1)
            {
                int free = RNG.Next(SongOath + 1);
                while (((free > UpgradeGiantWallet) && (free < HeartPieceNotebookMayor)) || (free == UpgradeGiantWallet) || (free == UpgradeMirrorShield) || (ItemList[free].ReplacesItemId != -1))
                {
                    free = RNG.Next(SongOath + 1);
                };
                ItemList[free].ReplacesItemId = 0;
                TargetPool.RemoveAt(0);
            };
            for (int i = MaskDeku; i < HeartPieceNotebookMayor; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = MaskPostmanHat; i < AreaSouthAccess; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = ItemWoodfallMap; i < ShopItemTownRedPotion; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = ShopItemTownRedPotion; i < BottleCatchFairy; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = HeartPieceNotebookMayor; i < MaskPostmanHat; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = ChestLensCaveRedRupee; i < GrottoToGR + 1; i++)
            {
                PlaceItem(i, TargetPool);
            };
        }

    }

}