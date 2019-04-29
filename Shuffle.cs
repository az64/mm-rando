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

        private int[] _newEntrances = new int[] { -1, -1, -1, -1 };
        private int[] _newExits = new int[] { -1, -1, -1, -1 };
        private int[] _newDCFlags = new int[] { -1, -1, -1, -1 };
        private int[] _newDCMasks = new int[] { -1, -1, -1, -1 };
        private int[] _newEnts = new int[] { -1, -1, -1, -1 };
        private int[] _newExts = new int[] { -1, -1, -1, -1 };

        public bool isSongsMixed { get; set; }
        public bool ExcludeSongOfSoaring { get; set; }
        public bool Keysanity { get; set; }
        public bool BottleCatch { get; set; }
        public bool Shops { get; set; }
        public bool Other { get; set; }
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
            public int Instrument { get; set; }
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
        Dictionary<int, bool> DependenceChecked { get; set; }
        Dictionary<int, bool> SubChecked { get; set; }
        List<int[]> ConditionRemoves { get; set; }
        List<string> GossipQuotes { get; set; }

        Dictionary<int, List<int>> ForbiddenReplacedBy = new Dictionary<int, List<int>>
        {
            // Deku_Mask should not be replaced by trade items, or items that can be downgraded.
            {
                MaskDeku, new List<int>
                {
                    UpgradeGildedSword,
                    UpgradeMirrorShield,
                    UpgradeBiggestQuiver,
                    UpgradeBigBombBag,
                    UpgradeBiggestBombBag,
                    UpgradeGiantWallet
                }
                .Concat(Enumerable.Range(TradeItemMoonTear, TradeItemMamaLetter - TradeItemMoonTear + 1))
                .Concat(Enumerable.Range(ItemBottle_W, ItemBottle_M - ItemBottle_W + 1))
                .ToList()
            },

            // Keaton_Mask and Mama_Letter are obtained one directly after another
            // Keaton_Mask cannot be replaced by items that may be overwritten by item obtained at Mama_Letter
            {
                MaskKeaton,
                new List<int> {
                    UpgradeGiantWallet,
                    UpgradeGildedSword,
                    UpgradeMirrorShield,
                    UpgradeBiggestQuiver,
                    UpgradeBigBombBag,
                    UpgradeBiggestBombBag,
                    TradeItemMoonTear,
                    TradeItemLandDeed,
                    TradeItemSwampDeed,
                    TradeItemMountainDeed,
                    TradeItemOceanDeed,
                    TradeItemRoomKey,
                    TradeItemMamaLetter,
                    TradeItemKafeiLetter,
                    TradeItemPendant
                }
            },
        };

        Dictionary<int, List<int>> ForbiddenPlacedAt = new Dictionary<int, List<int>>
        {
            // Gold Dust cannot be obtained a second time at certain locations
            // All chests are Recovery Heart the 2nd time
            {
                ItemBottle_G, new List<int>
                {
                    ItemBow,
                    ItemFireArrow,
                    ItemIceArrow,
                    ItemLightArrow,
                    ItemLens,
                    ItemHookshot,
                    ItemBottle_D,
                    UpgradeMirrorShield,
                    HeartPieceSwSch, // Rewards 20 rupees for some reason
                    MaskCaptainHat,
                    MaskGiant,
                    HeartPieceLabFish,
                    GrottoToGR,
                }
                .Concat(Enumerable.Range(HeartPieceTCGame, HeartPieceKnuckle - HeartPieceTCGame+ 1))
                .Concat(Enumerable.Range(ItemWoodfallMap, ItemStoneTowerKey4 - ItemWoodfallMap + 1))
                .Concat(Enumerable.Range(ChestLensCaveRedRupee, ChestSouthClockTownPurpleRupee - ChestLensCaveRedRupee + 1))
                .ToList()
            },
        };

        //rando functions

        private void MakeGossipQuotes()
        {
            GossipQuotes = new List<string>();
            ReadAndPopulateGossipList();
            
            for (int itemIndex = 0; itemIndex < ItemList.Count; itemIndex++)
            {
                if (ItemList[itemIndex].ReplacesItemId == -1)
                {
                    continue;
                };

                if ((!BottleCatch) 
                    && ((itemIndex >= BottleCatchFairy) 
                    && (itemIndex <= BottleCatchMushroom)))
                {
                    continue;
                };

                if ((!Shops) 
                    && ((itemIndex >= ShopItemTownRedPotion) 
                    && (itemIndex <= ShopItemZoraRedPotion)))
                {
                    continue;
                };

                if ((!Keysanity) 
                    && ((itemIndex >= ItemWoodfallMap) 
                    && (itemIndex <= ItemStoneTowerKey4)))
                {
                    continue;
                };

                int sourceItemId = ItemList[itemIndex].ReplacesItemId;
                if (sourceItemId > AreaInvertedStoneTowerNew) {
                   sourceItemId -= Values.NumberOfAreasAndOther;
                }; 

                int toItemId = itemIndex;
                if (toItemId > AreaInvertedStoneTowerNew) {
                    toItemId -= Values.NumberOfAreasAndOther;
                };

                bool isFake = (RNG.Next(100) < 5);
                if (isFake) {
                    sourceItemId = RNG.Next(GossipList.Count);
                };

                int sourceMessageLength = GossipList[sourceItemId]
                    .SourceMessage
                    .Length;

                int destinationMessageLength = GossipList[toItemId]
                    .DestinationMessage
                    .Length;

                string sourceMessage = GossipList[sourceItemId]
                    .SourceMessage[RNG.Next(sourceMessageLength)];

                string destinationMessage = GossipList[toItemId]
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

                var quote = BuildGossipQuote(soundAddress, sourceMessage, destinationMessage);

                GossipQuotes.Add(quote);
            };

            for (int i = 0; i < Values.JunkGossipMessages.Length; i++)
            {
                GossipQuotes.Add(Values.JunkGossipMessages[i]);
            };
        }

        private void ReadAndPopulateGossipList()
        {
            GossipList = new List<Gossip>();

            string[] gossipLines = Properties.Resources.GOSSIP
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < gossipLines.Length; i += 2)
            {
                var sourceMessage = gossipLines[i].Split(';');
                var destinationMessage = gossipLines[i + 1].Split(';');
                var nextGossip = new Gossip
                {
                    SourceMessage = sourceMessage,
                    DestinationMessage = destinationMessage
                };

                GossipList.Add(nextGossip);
            };
        }

        public string BuildGossipQuote(string soundAddress, string sourceMessage, string destinationMessage)
        {
            int randomMessageStartIndex = RNG.Next(Values.GossipMessageStartSentences.Length);
            int randomMessageMidIndex = RNG.Next(Values.GossipMessageMidSentences.Length);

            var quote = new StringBuilder();
            quote.Append(soundAddress);
            quote.Append(Values.GossipMessageStartSentences[randomMessageStartIndex]);
            quote.Append("\x01" + sourceMessage + "\x00\x11");
            quote.Append(Values.GossipMessageMidSentences[randomMessageMidIndex]);
            quote.Append("\x06" + destinationMessage + "\x00" + "...\xBF");
            return quote.ToString();
        }

        private void EntranceShuffle()
        {
            _newEntrances = new int[] { -1, -1, -1, -1 };
            _newExits = new int[] { -1, -1, -1, -1 };
            _newDCFlags = new int[] { -1, -1, -1, -1 };
            _newDCMasks = new int[] { -1, -1, -1, -1 };
            _newEnts = new int[] { -1, -1, -1, -1 };
            _newExts = new int[] { -1, -1, -1, -1 };

            for (int i = 0; i < 4; i++)
            {
                int n;
                do
                {
                    n = RNG.Next(4);
                } while (_newEnts.Contains(n));

                _newEnts[i] = n;
                _newExts[n] = i;
            };

            ItemObject[] DE = new ItemObject[] {
                ItemList[AreaWoodFallAccess],
                ItemList[AreaSnowheadAccess],
                ItemList[AreaISTAccess],
                ItemList[AreaGreatBayAccess]
            };

            int[] DI = new int[] {
                AreaWoodFallAccess,
                AreaSnowheadAccess,
                AreaISTAccess,
                AreaGreatBayAccess
            };

            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine($"Entrance {DI[_newEnts[i]]} placed at {DE[i].ID}.");
                ItemList[DI[_newEnts[i]]] = DE[i];
            };

            DE = new ItemObject[] {
                ItemList[AreaWoodFallClear],
                ItemList[AreaSnowheadClear],
                ItemList[AreaStoneTowerClear],
                ItemList[AreaGreatBayClear]
            };

            DI = new int[] {
                AreaWoodFallClear,
                AreaSnowheadClear,
                AreaStoneTowerClear,
                AreaGreatBayClear
            };

            for (int i = 0; i < 4; i++)
            {
                ItemList[DI[i]] = DE[_newEnts[i]];
            };

            for (int i = 0; i < 4; i++)
            {
                _newEntrances[i] = Values.OldEntrances[_newEnts[i]];
                _newExits[i] = Values.OldExits[_newExts[i]];
                _newDCFlags[i] = Values.OldDCFlags[_newExts[i]];
                _newDCMasks[i] = Values.OldMaskFlags[_newExts[i]];
            };
        }

        private void ReadSeqInfo()
        {
            SequenceList = new List<SequenceInfo>();
            TargetSequences = new List<SequenceInfo>();

            string[] lines = Properties.Resources.SEQS
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            int i = 0;
            while (i < lines.Length)
            {
                var sourceName = lines[i];
                var sourceType = Array.ConvertAll(lines[i + 1].Split(','), int.Parse).ToList();
                var sourceInstrument = Convert.ToInt32(lines[i + 2], 16);

                var targetName = lines[i];
                var targetType = Array.ConvertAll(lines[i + 1].Split(','), int.Parse).ToList();
                var targetInstrument = Convert.ToInt32(lines[i + 2], 16);

                SequenceInfo sourceSequence = new SequenceInfo {
                    Name = sourceName,
                    Type = sourceType,
                    Instrument = sourceInstrument
                };

                SequenceInfo targetSequence = new SequenceInfo
                {
                    Name = targetName,
                    Type = targetType,
                    Instrument = targetInstrument
                };

                if (sourceSequence.Name.StartsWith("mm-"))
                {
                    targetSequence.Replaces = Convert.ToInt32(lines[i + 3], 16);
                    sourceSequence.MM_seq = Convert.ToInt32(lines[i + 3], 16);
                    TargetSequences.Add(targetSequence);
                    i += 4;
                }
                else
                {
                    if (sourceSequence.Name == "mmr-f-sot")
                    {
                        sourceSequence.Replaces = 0x33;
                    };

                    i += 3;
                };

                if (sourceSequence.MM_seq != 0x18)
                {
                    SequenceList.Add(sourceSequence);
                };
            };
        }

        private void BGMShuffle()
        {
            while (TargetSequences.Count > 0)
            {
                List<SequenceInfo> Unassigned = SequenceList.FindAll(u => u.Replaces == -1);

                int targetIndex = RNG.Next(TargetSequences.Count);
                while (true)
                {
                    int unassignedIndex = RNG.Next(Unassigned.Count);

                    if (Unassigned[unassignedIndex].Name.StartsWith("mm") 
                        & (RNG.Next(100) < 50))
                    {
                        continue;
                    };

                    for (int i = 0; i < Unassigned[unassignedIndex].Type.Count; i++)
                    {
                        if (TargetSequences[targetIndex].Type.Contains(Unassigned[unassignedIndex].Type[i]))
                        {
                            Unassigned[unassignedIndex].Replaces = TargetSequences[targetIndex].Replaces;
                            Debug.WriteLine(Unassigned[unassignedIndex].Name + " -> " + TargetSequences[targetIndex].Name);
                            TargetSequences.RemoveAt(targetIndex);
                            break;
                        }
                        else if (i + 1 == Unassigned[unassignedIndex].Type.Count)
                        {
                            if ((RNG.Next(30) == 0) 
                                && ((Unassigned[unassignedIndex].Type[0] & 8) == (TargetSequences[targetIndex].Type[0] & 8)) 
                                && (Unassigned[unassignedIndex].Type.Contains(10) == TargetSequences[targetIndex].Type.Contains(10)) 
                                && (!Unassigned[unassignedIndex].Type.Contains(16)))
                            {
                                Unassigned[unassignedIndex].Replaces = TargetSequences[targetIndex].Replaces;
                                Debug.WriteLine(Unassigned[unassignedIndex].Name + " -> " + TargetSequences[targetIndex].Name);
                                TargetSequences.RemoveAt(targetIndex);
                                break;
                            };
                        };
                    };

                    if (Unassigned[unassignedIndex].Replaces != -1)
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
                    LogFile.WriteLine(destinations[i].PadRight(32, '-') + "---->>" + destinations[_newEnts[i]].PadLeft(32, '-'));
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

        private bool IsFakeItem(int itemId)
        {
            return (itemId >= AreaSouthAccess && itemId <= AreaInvertedStoneTowerNew) || itemId > GrottoToGR;
        }

        private bool IsTemporaryItem(int itemId)
        {
            return (itemId >= TradeItemMoonTear && itemId <= TradeItemMamaLetter) 
                || itemId == ItemWoodfallKey1 
                || (itemId >= ItemSnowheadKey1 && itemId <= ItemSnowheadKey3)
                || itemId == ItemGreatBayKey1
                || (itemId >= ItemStoneTowerKey1 && itemId <= ItemStoneTowerKey4);
        }

        private bool CheckDependence(int CurrentItem, int Target, bool skip)
        {
            Debug.WriteLine($"CheckDependence({CurrentItem}, {Target}, {skip})");
            if (!skip)
            {
                DependenceChecked[Target] = true;
            };

            // permanent items ignore dependencies of Blast Mask check
            if (Target == MaskBlast && !IsTemporaryItem(CurrentItem))
            {
                if (!skip)
                {
                    DependenceChecked[Target] = false;
                }
                return false;
            }

            if ((ItemList[Target].Conditional != null) && (ItemList[Target].Conditional.Count != 0))
            {
                if (ItemList[Target].Conditional.FindAll(u => u.Contains(CurrentItem)).Count == ItemList[Target].Conditional.Count)
                {
                    Debug.WriteLine($"All conditionals of {Target} contains {CurrentItem}");
                    return true;
                };
                if (ItemList[CurrentItem].Cannot_Require != null)
                {
                    for (int i = 0; i < ItemList[CurrentItem].Cannot_Require.Count; i++)
                    {
                        if (ItemList[Target].Conditional.FindAll(u => u.Contains(ItemList[CurrentItem].Cannot_Require[i]) || u.Contains(CurrentItem)).Count == ItemList[Target].Conditional.Count)
                        {
                            Debug.WriteLine($"All conditionals of {Target} cannot be required by {CurrentItem}");
                            return true;
                        };
                    };
                };
                int k = 0;
                for (int i = 0; i < ItemList[Target].Conditional.Count; i++)
                {
                    bool match = false;
                    for (int j = 0; j < ItemList[Target].Conditional[i].Count; j++)
                    {
                        int d = ItemList[Target].Conditional[i][j];
                        if (!IsFakeItem(d) && ItemList[d].ReplacesItemId == -1)
                        {
                            continue;
                        }
                        int[] check = new int[] { Target, i, j };
                        if (ItemList[d].ReplacesItemId != -1) { d = ItemList[d].ReplacesItemId; };
                        if (!SubChecked.ContainsKey(d))
                        {
                            SubChecked[d] = true;
                            SubChecked[d] = CheckDependence(CurrentItem, d, true);
                        }
                        if (SubChecked[d])
                        {
                            ConditionRemoves.Add(check);
                            if (!match)
                            {
                                k++;
                                match = true;
                            }
                        }
                    };
                };
                if (k == ItemList[Target].Conditional.Count)
                {
                    Debug.WriteLine($"All conditionals of {Target} failed dependency check for {CurrentItem}.");
                    return true;
                };
            };
            if (ItemList[Target].Dependence == null)
            {
                if (!skip)
                {
                    DependenceChecked[Target] = false;
                }
                return false;
            };
            //cycle through all things
            for (int i = 0; i < ItemList[Target].Dependence.Count; i++)
            {
                int d = ItemList[Target].Dependence[i];
                if (d == CurrentItem)
                {
                    Debug.WriteLine($"{Target} has direct dependence on {CurrentItem}");
                    return true;
                };
                if (ItemList[CurrentItem].Cannot_Require != null)
                {
                    for (int j = 0; j < ItemList[CurrentItem].Cannot_Require.Count; j++)
                    {
                        if (ItemList[Target].Dependence.Contains(ItemList[CurrentItem].Cannot_Require[j]))
                        {
                            Debug.WriteLine($"Dependence {ItemList[CurrentItem].Cannot_Require[j]} of {Target} cannot be required by {CurrentItem}");
                            return true;
                        };
                    };
                };
                if (IsFakeItem(d) || ItemList[d].ReplacesItemId != -1)
                {
                    if (ItemList[d].ReplacesItemId != -1) d = ItemList[d].ReplacesItemId;
                    if (DependenceChecked.ContainsKey(d))
                    {
                        if (DependenceChecked[d])
                        {
                            Debug.WriteLine($"{CurrentItem} is dependent on {d}");
                            return true;
                        }
                    }
                    else
                    {
                        if (CheckDependence(CurrentItem, d, false))
                        {
                            return true;
                        }
                    }
                }
            };
            if (!skip)
            {
                DependenceChecked[Target] = false;
            }
            return false;
        }

        private void RemoveConditionals(int CurrentItem)
        {
            for (int i = 0; i < ConditionRemoves.Count; i++)
            {
                int x = ConditionRemoves[i][0];
                int y = ConditionRemoves[i][1];
                int z = ConditionRemoves[i][2];
                ItemList[x].Conditional[y] = null;
            };
            for (int i = 0; i < ConditionRemoves.Count; i++)
            {
                int x = ConditionRemoves[i][0];
                int y = ConditionRemoves[i][1];
                int z = ConditionRemoves[i][2];
                for (int j = 0; j < ItemList[x].Conditional.Count; j++)
                {
                    if (ItemList[x].Conditional[j] != null)
                    {
                        for (int k = 0; k < ItemList[x].Conditional[j].Count; k++)
                        {
                            int d = ItemList[x].Conditional[j][k];
                            if (ItemList[x].Cannot_Require == null)
                            {
                                ItemList[x].Cannot_Require = new List<int>();
                            };
                            ItemList[d].Cannot_Require.Add(CurrentItem);
                        };
                    };
                };
            };
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].Conditional != null)
                {
                    ItemList[i].Conditional.RemoveAll(u => u == null);
                };
            };
            /*
            for (int i = 0; i < ConditionRemoves.Count; i++)
            {
                for (int j = 0; j < ItemList[ConditionRemoves[i][0]].Conditional[ConditionRemoves[i][1]].Count; j++)
                {
                    int d = ItemList[ConditionRemoves[i][0]].Conditional[ConditionRemoves[i][1]][j];
                    if (ItemList[d].Cannot_Require == null)
                    {
                        ItemList[d].Cannot_Require = new List<int>();
                    };
                    ItemList[d].Cannot_Require.Add(CurrentItem);
                    if (ItemList[ConditionRemoves[i][0]].Dependence == null)
                    {
                        ItemList[ConditionRemoves[i][0]].Dependence = new List<int>();
                    };
                    ItemList[ConditionRemoves[i][0]].Dependence.Add(d);
                };
                ItemList[ConditionRemoves[i][0]].Conditional[ConditionRemoves[i][1]] = null;
            };
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].Conditional != null)
                {
                    if (ItemList[i].Conditional.Contains(null))
                    {
                        ItemList[i].Conditional = null;
                    };
                };
            };
            */
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
            /*
            if (ItemList[Target].Cannot_Require != null)
            {
                for (int i = 0; i < ItemList[CurrentItem].Cannot_Require.Count; i++)
                {
                    ItemList[Target].Conditional.RemoveAll(u => u.Contains(ItemList[CurrentItem].Cannot_Require[i]));
                };
            };
            ItemList[Target].Conditional.RemoveAll(u => u.Contains(CurrentItem));
            if (ItemList[Target].Conditional.Count == 0)
            {
                return;
            };
            */
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
                    ItemList[j].Cannot_Require.Add(CurrentItem);
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
                //for (int i = 0; i < ItemList[Target].Conditional.Count; i++)
                //{
                //    for (int j = 0; j < ItemList[Target].Conditional[i].Count; j++)
                //    {
                //        int k = ItemList[Target].Conditional[i][j];
                //        if (ItemList[k].Cannot_Require == null)
                //        {
                //            ItemList[k].Cannot_Require = new List<int>();
                //        };
                //        ItemList[k].Cannot_Require.Add(CurrentItem);
                //    };
                //};
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
            if (Target == MaskBlast)
            {
                if (!IsTemporaryItem(CurrentItem))
                {
                    ItemList[Target].Dependence = null;
                }
            }
            ConditionsChecked.Add(Target);
            UpdateConditionals(CurrentItem, Target);
            if (ItemList[Target].Dependence == null)
            {
                return;
            };
            for (int i = 0; i < ItemList[Target].Dependence.Count; i++)
            {
                int d = ItemList[Target].Dependence[i];
                if (ItemList[d].Cannot_Require == null)
                {
                    ItemList[d].Cannot_Require = new List<int>();
                };
                ItemList[d].Cannot_Require.Add(CurrentItem);
                if (IsFakeItem(d) || ItemList[d].ReplacesItemId != -1)
                {
                    if (ItemList[d].ReplacesItemId != -1) d = ItemList[d].ReplacesItemId;
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
            if (ForbiddenPlacedAt.ContainsKey(CurrentItem) && ForbiddenPlacedAt[CurrentItem].Contains(Target))
            {
                Debug.WriteLine($"{CurrentItem} forbidden from being placed at {Target}");
                return false;
            }
            if (ForbiddenReplacedBy.ContainsKey(Target) && ForbiddenReplacedBy[Target].Contains(CurrentItem))
            {
                Debug.WriteLine($"{Target} forbids being replaced by {CurrentItem}");
                return false;
            }
            //check timing
            if (ItemList[CurrentItem].Time_Needed != 0)
            {
                if ((ItemList[CurrentItem].Time_Needed & ItemList[Target].Time_Available) == 0)
                {
                    Debug.WriteLine($"{CurrentItem} is needed at {ItemList[CurrentItem].Time_Needed} but {Target} is only available at {ItemList[Target].Time_Available}");
                    return false;
                };
            };
            //check direct dependence
            ConditionRemoves = new List<int[]>();
            SubChecked = new Dictionary<int, bool>();
            DependenceChecked = new Dictionary<int, bool>();
            if (CheckDependence(CurrentItem, Target, false))
            {
                return false;
            };
            //check conditional dependence
            RemoveConditionals(CurrentItem);
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
            var availableTargets = Targets.ToList();
            while (true)
            {
                if (availableTargets.Count == 0)
                {
                    throw new Exception($"Unable to place {CurrentItem} anywhere.");
                }
                int TargetSlot = 0;
                if (CurrentItem > SongOath && availableTargets.Contains(0))
                {
                    TargetSlot = RNG.Next(1, availableTargets.Count);
                }
                else
                {
                    TargetSlot = RNG.Next(availableTargets.Count);
                };
                Debug.WriteLine($"----Attempting to place {CurrentItem} at {availableTargets[TargetSlot]}.---");
                if (CheckMatch(CurrentItem, availableTargets[TargetSlot]))
                {
                    ItemList[CurrentItem].ReplacesItemId = availableTargets[TargetSlot];
                    Debug.WriteLine($"----Placed {CurrentItem} at {ItemList[CurrentItem].ReplacesItemId}----");
                    if ((ItemList[CurrentItem].Time_Needed != 0) && (availableTargets[TargetSlot] > TradeItemMoonTear) && (availableTargets[TargetSlot] < TradeItemRoomKey))
                    {
                        ItemList[availableTargets[TargetSlot]].Time_Needed = ItemList[CurrentItem].Time_Needed;
                    };
                    Targets.Remove(availableTargets[TargetSlot]);
                    return;
                }
                else
                {
                    Debug.WriteLine($"----Failed to place {CurrentItem} at {availableTargets[TargetSlot]}----");
                    availableTargets.RemoveAt(TargetSlot);
                }
            };
        }

        private void ItemShuffle()
        {
            isSongsMixed = cMixSongs.Checked;
            ExcludeSongOfSoaring = cSoS.Checked;
            Keysanity = cDChests.Checked;
            BottleCatch = cBottled.Checked;
            Shops = cShop.Checked;
            Other = cAdditional.Checked;
            User = cUserItems.Checked;
            List<int> TargetPool = new List<int>();
            if (User)
            {
                Shops = false;
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if ((i > SongOath && i < ItemWoodfallMap) || i > GrottoToGR)
                    {
                        continue;
                    };
                    ItemList[i].ReplacesItemId = i;
                };
                for (int i = 0; i < fItemEdit.selected_items.Count; i++)
                {
                    int j = fItemEdit.selected_items[i];
                    if (j > SongOath)
                    {
                        // Skip entries describing areas and other
                        j += Values.NumberOfAreasAndOther;
                    };
                    int k = ItemList.FindIndex(u => u.ID == j);
                    if (k != -1)
                    {
                        ItemList[k].ReplacesItemId = -1;
                    };
                    if ((j > ItemStoneTowerKey4) && (j < BottleCatchFairy))
                    {
                        Shops = true;
                    };
                };
                if (!isSongsMixed)
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
                if (!isSongsMixed)
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
                if (((i > SongOath && i < ItemWoodfallMap) || i > GrottoToGR) || (ItemList[i].ReplacesItemId != -1))
                {
                    continue;
                };
                TargetPool.Add(i);
            };
            PlaceItem(TradeItemRoomKey, TargetPool);
            PlaceItem(TradeItemKafeiLetter, TargetPool);
            PlaceItem(TradeItemPendant, TargetPool);
            PlaceItem(TradeItemMamaLetter, TargetPool);
            if (ItemList.FindIndex(u => u.ReplacesItemId == MaskDeku) == -1)
            {
                int free = RNG.Next(SongOath + 1);
                if (ForbiddenReplacedBy.ContainsKey(MaskDeku))
                {
                    while (ItemList[free].ReplacesItemId != -1 || ForbiddenReplacedBy[MaskDeku].Contains(free))
                    {
                        free = RNG.Next(SongOath + 1);
                    }
                }
                ItemList[free].ReplacesItemId = MaskDeku;
                TargetPool.Remove(MaskDeku);
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
