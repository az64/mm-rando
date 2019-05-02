using MMRando.Models;
using MMRando.Utils;
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

        public Settings RandomizerSettings { get; set; } = new Settings();

        public class ItemObject
        {
            public int ID { get; set; }
            public List<int> DependsOnItems { get; set; } = new List<int>();
            public List<List<int>> Conditional { get; set; } = new List<List<int>>();
            public List<int> CannotRequireItems { get; set; } = new List<int>();
            public int TimeNeeded { get; set; }
            public int TimeAvailable { get; set; }
            public int ReplacesItemId { get; set; } = -1;
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
                Items.MaskDeku, new List<int>
                {
                    Items.UpgradeGildedSword,
                    Items.UpgradeMirrorShield,
                    Items.UpgradeBiggestQuiver,
                    Items.UpgradeBigBombBag,
                    Items.UpgradeBiggestBombBag,
                    Items.UpgradeGiantWallet
                }
                .Concat(Enumerable.Range(Items.TradeItemMoonTear, Items.TradeItemMamaLetter - Items.TradeItemMoonTear + 1))
                .Concat(Enumerable.Range(Items.ItemBottleWitch, Items.ItemBottleMilk - Items.ItemBottleWitch + 1))
                .ToList()
            },

            // Keaton_Mask and Mama_Letter are obtained one directly after another
            // Keaton_Mask cannot be replaced by items that may be overwritten by item obtained at Mama_Letter
            {
                Items.MaskKeaton,
                new List<int> {
                    Items.UpgradeGiantWallet,
                    Items.UpgradeGildedSword,
                    Items.UpgradeMirrorShield,
                    Items.UpgradeBiggestQuiver,
                    Items.UpgradeBigBombBag,
                    Items.UpgradeBiggestBombBag,
                    Items.TradeItemMoonTear,
                    Items.TradeItemLandDeed,
                    Items.TradeItemSwampDeed,
                    Items.TradeItemMountainDeed,
                    Items.TradeItemOceanDeed,
                    Items.TradeItemRoomKey,
                    Items.TradeItemMamaLetter,
                    Items.TradeItemKafeiLetter,
                    Items.TradeItemPendant
                }
            },
        };

        Dictionary<int, List<int>> ForbiddenPlacedAt = new Dictionary<int, List<int>>
        {
            // Gold Dust cannot be obtained a second time at certain locations
            // All chests are Recovery Heart the 2nd time
            {
                Items.ItemBottleGoronRace, new List<int>
                {
                    Items.ItemBow,
                    Items.ItemFireArrow,
                    Items.ItemIceArrow,
                    Items.ItemLightArrow,
                    Items.ItemLens,
                    Items.ItemHookshot,
                    Items.ItemBottleDampe,
                    Items.UpgradeMirrorShield,
                    Items.HeartPieceNotebookPostman, // Rewards 50 rupees when collecting 2nd time
                    Items.HeartPieceKeaton, // Rewards 20 rupees when collecting 2nd time
                    Items.HeartPieceSwSch, // Rewards 20 rupees when collecting 2nd time
                    Items.MaskCaptainHat,
                    Items.MaskGiant,
                    Items.HeartPieceLabFish,
                    Items.GrottoToGR,
                }
                .Concat(Enumerable.Range(Items.HeartPieceTCGame, Items.HeartPieceKnuckle - Items.HeartPieceTCGame+ 1))
                .Concat(Enumerable.Range(Items.ItemWoodfallMap, Items.ItemStoneTowerKey4 - Items.ItemWoodfallMap + 1))
                .Concat(Enumerable.Range(Items.ChestLensCaveRedRupee, Items.ChestSouthClockTownPurpleRupee - Items.ChestLensCaveRedRupee + 1))
                .ToList()
            },
        };

        //rando functions

        #region Gossip quotes

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

                // Skip hints for vanilla bottle content
                if ((!RandomizerSettings.RandomizeBottleCatchContents)
                    && ItemUtils.IsBottleCatchContent(itemIndex))
                {
                    continue;
                };

                // Skip hints for vanilla shop items
                if ((!RandomizerSettings.AddShopItems)
                    && ItemUtils.IsShopItem(itemIndex))
                {
                    continue;
                };

                // Skip hints for vanilla dungeon items
                if (!RandomizerSettings.AddDungeonItems
                    && ItemUtils.IsDungeonItem(itemIndex))
                {
                    continue;
                };

                int sourceItemId = ItemList[itemIndex].ReplacesItemId;
                if (ItemUtils.IsItemDefinedPastAreas(sourceItemId))
                {
                    sourceItemId -= Values.NumberOfAreasAndOther;
                };

                int toItemId = itemIndex;
                if (ItemUtils.IsItemDefinedPastAreas(toItemId))
                {
                    toItemId -= Values.NumberOfAreasAndOther;
                };

                // 5% chance of being fake
                bool isFake = (RNG.Next(100) < 5);
                if (isFake)
                {
                    sourceItemId = RNG.Next(GossipList.Count);
                };

                int sourceMessageLength = GossipList[sourceItemId]
                    .SourceMessage
                    .Length;

                int destinationMessageLength = GossipList[toItemId]
                    .DestinationMessage
                    .Length;

                // Randomize messages
                string sourceMessage = GossipList[sourceItemId]
                    .SourceMessage[RNG.Next(sourceMessageLength)];

                string destinationMessage = GossipList[toItemId]
                    .DestinationMessage[RNG.Next(destinationMessageLength)];

                // Sound differs if hint is fake
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

        #endregion

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
                ItemList[Items.AreaWoodFallAccess],
                ItemList[Items.AreaSnowheadAccess],
                ItemList[Items.AreaISTAccess],
                ItemList[Items.AreaGreatBayAccess]
            };

            int[] DI = new int[] {
                Items.AreaWoodFallAccess,
                Items.AreaSnowheadAccess,
                Items.AreaISTAccess,
                Items.AreaGreatBayAccess
            };

            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine($"Entrance {DI[_newEnts[i]]} placed at {DE[i].ID}.");
                ItemList[DI[_newEnts[i]]] = DE[i];
            };

            DE = new ItemObject[] {
                ItemList[Items.AreaWoodFallClear],
                ItemList[Items.AreaSnowheadClear],
                ItemList[Items.AreaStoneTowerClear],
                ItemList[Items.AreaGreatBayClear]
            };

            DI = new int[] {
                Items.AreaWoodFallClear,
                Items.AreaSnowheadClear,
                Items.AreaStoneTowerClear,
                Items.AreaGreatBayClear
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

        #region Sequences and BGM

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

                SequenceInfo sourceSequence = new SequenceInfo
                {
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
            if (!RandomizerSettings.RandomizeBGM)
            {
                return;
            };
            ReadSeqInfo();
            BGMShuffle();
        }

        #endregion

        private void SetTatlColour()
        {
            if (RandomizerSettings.TatlColorSchema == TatlColorSchema.Rainbow)
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
            if (RandomizerSettings.LogicMode == LogicMode.Vanilla)
            {
                return;
            };

            var settingsString = EncodeSettings();

            StreamWriter LogFile = new StreamWriter($"SpoilerLog-{settingsString}.txt");
            if (RandomizerSettings.RandomizeDungeonEntrances)
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
                LogFile.WriteLine(Items.ITEM_NAMES[ItemList[i].ID].PadRight(32, '-') + "---->>" + Items.ITEM_NAMES[ItemList[i].ReplacesItemId].PadLeft(32, '-'));
            };
            LogFile.WriteLine("");
            LogFile.WriteLine("-----------Destination------------------------------Item--------------");
            ItemList.Sort((i, j) => i.ReplacesItemId.CompareTo(j.ReplacesItemId));
            for (int i = 0; i < ItemList.Count; i++)
            {
                LogFile.WriteLine(Items.ITEM_NAMES[ItemList[i].ReplacesItemId].PadRight(32, '-') + "<<----" + Items.ITEM_NAMES[ItemList[i].ID].PadLeft(32, '-'));
            };
            LogFile.Close();
        }

        private void PrepareRulesetItemData()
        {
            string[] data = ReadRulesetFromResources();

            if (data == null)
            {
                for (var i = 0; i < Items.TotalNumberOfItems; i++)
                {
                    var currentItem = new ItemObject
                    {
                        ID = i,
                        TimeAvailable = 63
                    };

                    ItemList.Add(currentItem);
                }
            }

            PopulateItemList(data);
            AddRequirementsForSongOath();
        }

        private void AddRequirementsForSongOath()
        {
            int[] OathReq = new int[] { 100, 103, 108, 113 };
            ItemList[Items.SongOath].DependsOnItems = new List<int>();
            ItemList[Items.SongOath].DependsOnItems.Add(OathReq[RNG.Next(4)]);
        }

        private void PopulateItemList(string[] data)
        {
            ItemList = new List<ItemObject>();

            int itemId = 0;
            int lineNumber = 0;

            var currentItem = new ItemObject();

            // Process lines in groups of 4
            foreach (string line in data)
            {
                if (line.Contains("-"))
                {
                    continue;
                }

                switch (lineNumber)
                {
                    case 0:
                        //dependence
                        ProcessDependenciesForItem(currentItem, line);
                        break;
                    case 1:
                        //conditionals
                        ProcessConditionalsForItem(currentItem, line);
                        break;
                    case 2:
                        //time needed
                        currentItem.TimeNeeded = Convert.ToInt32(line);
                        break;
                    case 3:
                        //time available
                        currentItem.TimeAvailable = Convert.ToInt32(line);
                        if (currentItem.TimeAvailable == 0)
                        {
                            currentItem.TimeAvailable = 63;
                        };
                        break;
                };

                lineNumber++;

                if (lineNumber == 4)
                {
                    currentItem.ID = itemId;
                    ItemList.Add(currentItem);

                    currentItem = new ItemObject();

                    itemId++;
                    lineNumber = 0;
                }
            }
        }

        private void ProcessConditionalsForItem(ItemObject currentItem, string line)
        {
            List<List<int>> conditional = new List<List<int>>();

            if (line == "")
            {
                currentItem.Conditional = null;
            }
            else
            {
                foreach (string conditions in line.Split(';'))
                {
                    int[] conditionaloption = Array.ConvertAll(conditions.Split(','), int.Parse);
                    conditional.Add(conditionaloption.ToList());
                };
                currentItem.Conditional = conditional;
            };
        }

        private void ProcessDependenciesForItem(ItemObject currentItem, string line)
        {
            List<int> dependencies = new List<int>();

            if (line == "")
            {
                currentItem.DependsOnItems = null;
            }
            else
            {
                foreach (string dependency in line.Split(','))
                {
                    dependencies.Add(Convert.ToInt32(dependency));
                };
                currentItem.DependsOnItems = dependencies;
            };
        }

        private string[] ReadRulesetFromResources()
        {
            string[] lines;
            var mode = (int)RandomizerSettings.LogicMode;

            if (mode == Values.CasualMode0)
            {
                lines = Properties.Resources.REQ_CASUAL.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
            else if (mode == Values.GlitchedMode1)
            {
                lines = Properties.Resources.REQ_GLITCH.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
            else if (mode == Values.UserLogicMode3)
            {
                using (StreamReader Req = new StreamReader(File.Open(openLogic.FileName, FileMode.Open)))
                {
                    lines = Req.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                }
            }
            else
            {
                lines = null;
            }

            return lines;
        }

        private bool CheckDependence(int CurrentItem, int Target, bool skip)
        {
            Debug.WriteLine($"CheckDependence({CurrentItem}, {Target}, {skip})");
            if (!skip)
            {
                DependenceChecked[Target] = true;
            };

            // permanent items ignore dependencies of Blast Mask check
            if (Target == Items.MaskBlast && !ItemUtils.IsTemporaryItem(CurrentItem))
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
                if (ItemList[CurrentItem].CannotRequireItems != null)
                {
                    for (int i = 0; i < ItemList[CurrentItem].CannotRequireItems.Count; i++)
                    {
                        if (ItemList[Target].Conditional.FindAll(u => u.Contains(ItemList[CurrentItem].CannotRequireItems[i]) || u.Contains(CurrentItem)).Count == ItemList[Target].Conditional.Count)
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
                        if (!ItemUtils.IsFakeItem(d) && ItemList[d].ReplacesItemId == -1)
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
            if (ItemList[Target].DependsOnItems == null)
            {
                if (!skip)
                {
                    DependenceChecked[Target] = false;
                }
                return false;
            };
            //cycle through all things
            for (int i = 0; i < ItemList[Target].DependsOnItems.Count; i++)
            {
                int d = ItemList[Target].DependsOnItems[i];
                if (d == CurrentItem)
                {
                    Debug.WriteLine($"{Target} has direct dependence on {CurrentItem}");
                    return true;
                };
                if (ItemList[CurrentItem].CannotRequireItems != null)
                {
                    for (int j = 0; j < ItemList[CurrentItem].CannotRequireItems.Count; j++)
                    {
                        if (ItemList[Target].DependsOnItems.Contains(ItemList[CurrentItem].CannotRequireItems[j]))
                        {
                            Debug.WriteLine($"Dependence {ItemList[CurrentItem].CannotRequireItems[j]} of {Target} cannot be required by {CurrentItem}");
                            return true;
                        };
                    };
                };
                if (ItemUtils.IsFakeItem(d) || ItemList[d].ReplacesItemId != -1)
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
                            if (ItemList[x].CannotRequireItems == null)
                            {
                                ItemList[x].CannotRequireItems = new List<int>();
                            };
                            ItemList[d].CannotRequireItems.Add(CurrentItem);
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
                    if (ItemList[Target].DependsOnItems == null)
                    {
                        ItemList[Target].DependsOnItems = new List<int>();
                    };
                    int j = ItemList[Target].Conditional[0][i];
                    ItemList[Target].DependsOnItems.Add(j);
                    if (ItemList[j].CannotRequireItems == null)
                    {
                        ItemList[j].CannotRequireItems = new List<int>();
                    };
                    ItemList[j].CannotRequireItems.Add(CurrentItem);
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
                        if (ItemList[Target].DependsOnItems == null)
                        {
                            ItemList[Target].DependsOnItems = new List<int>();
                        };
                        ItemList[Target].DependsOnItems.Add(testitem);
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
            if (Target == Items.MaskBlast)
            {
                if (!ItemUtils.IsTemporaryItem(CurrentItem))
                {
                    ItemList[Target].DependsOnItems = null;
                }
            }
            ConditionsChecked.Add(Target);
            UpdateConditionals(CurrentItem, Target);
            if (ItemList[Target].DependsOnItems == null)
            {
                return;
            };
            for (int i = 0; i < ItemList[Target].DependsOnItems.Count; i++)
            {
                int d = ItemList[Target].DependsOnItems[i];
                if (ItemList[d].CannotRequireItems == null)
                {
                    ItemList[d].CannotRequireItems = new List<int>();
                };
                ItemList[d].CannotRequireItems.Add(CurrentItem);
                if (ItemUtils.IsFakeItem(d) || ItemList[d].ReplacesItemId != -1)
                {
                    if (ItemList[d].ReplacesItemId != -1) d = ItemList[d].ReplacesItemId;
                    if (!ConditionsChecked.Contains(d))
                    {
                        CheckConditionals(CurrentItem, d);
                    };
                };
            };
            ItemList[Target].DependsOnItems.RemoveAll(u => u == -1);
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
            if (ItemList[CurrentItem].TimeNeeded != 0)
            {
                if ((ItemList[CurrentItem].TimeNeeded & ItemList[Target].TimeAvailable) == 0)
                {
                    Debug.WriteLine($"{CurrentItem} is needed at {ItemList[CurrentItem].TimeNeeded} but {Target} is only available at {ItemList[Target].TimeAvailable}");
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

        private void PlaceItem(int currentItem, List<int> targets)
        {
            if (ItemList[currentItem].ReplacesItemId != -1)
            {
                return;
            };
            var availableTargets = targets.ToList();
            while (true)
            {
                if (availableTargets.Count == 0)
                {
                    throw new Exception($"Unable to place {currentItem} anywhere.");
                }
                int TargetSlot = 0;
                if (currentItem > Items.SongOath && availableTargets.Contains(0))
                {
                    TargetSlot = RNG.Next(1, availableTargets.Count);
                }
                else
                {
                    TargetSlot = RNG.Next(availableTargets.Count);
                };
                Debug.WriteLine($"----Attempting to place {currentItem} at {availableTargets[TargetSlot]}.---");
                if (CheckMatch(currentItem, availableTargets[TargetSlot]))
                {
                    ItemList[currentItem].ReplacesItemId = availableTargets[TargetSlot];
                    Debug.WriteLine($"----Placed {currentItem} at {ItemList[currentItem].ReplacesItemId}----");
                    if (ItemList[currentItem].TimeNeeded != 0
                        && (availableTargets[TargetSlot] > Items.TradeItemMoonTear)
                        && (availableTargets[TargetSlot] < Items.TradeItemRoomKey))
                    {
                        ItemList[availableTargets[TargetSlot]].TimeNeeded = ItemList[currentItem].TimeNeeded;
                    };
                    targets.Remove(availableTargets[TargetSlot]);
                    return;
                }
                else
                {
                    Debug.WriteLine($"----Failed to place {currentItem} at {availableTargets[TargetSlot]}----");
                    availableTargets.RemoveAt(TargetSlot);
                }
            };
        }

        private void ItemShuffle()
        {
            PrepareItemShuffle();

            var ItemPool = new List<int>();
            for (int i = 0; i < ItemList.Count; i++)
            {
                // Skip item if its in area and other, greater than GrottoToGR or has placement
                if ((ItemUtils.IsAreaOrOther(i)
                    || ItemUtils.IsOutOfRange(i))
                    || (ItemList[i].ReplacesItemId != -1))
                {
                    continue;
                }

                ItemPool.Add(i);
            };

            PlaceItem(Items.TradeItemRoomKey, ItemPool);
            PlaceItem(Items.TradeItemKafeiLetter, ItemPool);
            PlaceItem(Items.TradeItemPendant, ItemPool);
            PlaceItem(Items.TradeItemMamaLetter, ItemPool);

            if (ItemList.FindIndex(u => u.ReplacesItemId == Items.MaskDeku) == -1)
            {
                int free = RNG.Next(Items.SongOath + 1);
                if (ForbiddenReplacedBy.ContainsKey(Items.MaskDeku))
                {
                    while (ItemList[free].ReplacesItemId != -1
                        || ForbiddenReplacedBy[Items.MaskDeku].Contains(free))
                    {
                        free = RNG.Next(Items.SongOath + 1);
                    }
                }
                ItemList[free].ReplacesItemId = Items.MaskDeku;
                ItemPool.Remove(Items.MaskDeku);
            };
            for (int i = Items.MaskDeku; i < Items.HeartPieceNotebookMayor; i++)
            {
                PlaceItem(i, ItemPool);
            };
            for (int i = Items.MaskPostmanHat; i < Items.AreaSouthAccess; i++)
            {
                PlaceItem(i, ItemPool);
            };
            for (int i = Items.ItemWoodfallMap; i < Items.ShopItemTownRedPotion; i++)
            {
                PlaceItem(i, ItemPool);
            };
            for (int i = Items.ShopItemTownRedPotion; i < Items.BottleCatchFairy; i++)
            {
                PlaceItem(i, ItemPool);
            };
            for (int i = Items.HeartPieceNotebookMayor; i < Items.MaskPostmanHat; i++)
            {
                PlaceItem(i, ItemPool);
            };
            for (int i = Items.ChestLensCaveRedRupee; i < Items.GrottoToGR + 1; i++)
            {
                PlaceItem(i, ItemPool);
            };
        }

        /// <summary>
        /// Adds items to randomization pool or preserves items vanilla based on Custom Item List and/or settings.
        /// </summary>
        private void PrepareItemShuffle()
        {
            if (RandomizerSettings.UseCustomItemList)
            {
                ShuffleUsingCustomItemList();
                return;
            }

            if (RandomizerSettings.ExcludeSongOfSoaring)
            {
                ItemList[Items.SongSoaring].ReplacesItemId = Items.SongSoaring;
            }

            if (!RandomizerSettings.AddSongs)
            {
                PreserveSongs();
            }

            if (!RandomizerSettings.AddDungeonItems)
            {
                PreserveDungeonItems();
            }

            if (!RandomizerSettings.AddShopItems)
            {
                PreserveShopItems();
            }

            if (!RandomizerSettings.AddOther)
            {
                PreserveOther();
            }

            if (RandomizerSettings.RandomizeBottleCatchContents)
            {
                AddBottleCatchContents();
            }
            else
            {
                PreserveBottleCatchContents();
            }
        }

        /// <summary>
        /// Keeps bottle catch contents vanilla
        /// </summary>
        private void PreserveBottleCatchContents()
        {
            for (int i = Items.BottleCatchFairy; i < Items.BottleCatchMushroom + 1; i++)
            {
                ItemList[i].ReplacesItemId = i;
            }
        }

        /// <summary>
        /// Randomizes bottle catch contents
        /// </summary>
        private void AddBottleCatchContents()
        {
            var itemPool = new List<int>();
            for (int i = Items.BottleCatchFairy; i < Items.BottleCatchMushroom + 1; i++)
            {
                itemPool.Add(i);
            };

            for (int i = Items.BottleCatchFairy; i < Items.BottleCatchMushroom + 1; i++)
            {
                PlaceItem(i, itemPool);
            };
        }

        /// <summary>
        /// Keeps other vanilla
        /// </summary>
        private void PreserveOther()
        {
            for (int i = Items.ChestLensCaveRedRupee; i < Items.GrottoToGR + 1; i++)
            {
                ItemList[i].ReplacesItemId = i;
            };
        }

        /// <summary>
        /// Keeps shop items vanilla
        /// </summary>
        private void PreserveShopItems()
        {
            for (int i = Items.ShopItemTownRedPotion; i < Items.ShopItemZoraRedPotion + 1; i++)
            {
                ItemList[i].ReplacesItemId = i;
            };

            ItemList[Items.ItemBombBag].ReplacesItemId = Items.ItemBombBag;
            ItemList[Items.UpgradeBigBombBag].ReplacesItemId = Items.UpgradeBigBombBag;
            ItemList[Items.MaskAllNight].ReplacesItemId = Items.MaskAllNight;
        }

        /// <summary>
        /// Keeps dungeon items vanilla
        /// </summary>
        private void PreserveDungeonItems()
        {
            for (int i = Items.ItemWoodfallMap; i < Items.ItemStoneTowerKey4 + 1; i++)
            {
                ItemList[i].ReplacesItemId = i;
            };
        }

        /// <summary>
        /// Keeps songs vanilla
        /// </summary>
        private void PreserveSongs()
        {
            var ItemPool = new List<int>();
            for (int i = Items.SongSoaring; i < Items.SongOath + 1; i++)
            {
                if (ItemList[i].ReplacesItemId != -1)
                {
                    continue;
                };

                ItemPool.Add(i);
            };

            for (int i = Items.SongSoaring; i < Items.SongOath + 1; i++)
            {
                PlaceItem(i, ItemPool);
            };
        }

        /// <summary>
        /// Adds custom item list to randomization. NOTE: keeps area and other vanilla, randomizes bottle catch contents
        /// </summary>
        private void ShuffleUsingCustomItemList()
        {
            RandomizerSettings.AddShopItems = false;

            // Should these be vanilla by default? Why not check settings.
            PreserveAreasAndOther();
            ApplyCustomItemList();

            // Should these be randomized by default? Why not check settings.
            AddBottleCatchContents();

            if (!RandomizerSettings.AddSongs)
            {
                PreserveSongs();
            }
        }

        /// <summary>
        /// Adds items specified from the Custom Item List to the randomizer pool, while keeping the rest vanilla
        /// </summary>
        private void ApplyCustomItemList()
        {
            for (int i = 0; i < fItemEdit.selected_items.Count; i++)
            {
                int selectedItem = fItemEdit.selected_items[i];

                if (selectedItem > Items.SongOath)
                {
                    // Skip entries describing areas and other
                    selectedItem += Values.NumberOfAreasAndOther;
                }
                int selectedItemIndex = ItemList.FindIndex(u => u.ID == selectedItem);

                if (selectedItemIndex != -1)
                {
                    ItemList[selectedItemIndex].ReplacesItemId = -1;
                }

                if (ItemUtils.IsShopItem(selectedItem))
                {
                    RandomizerSettings.AddShopItems = true;
                }
            }
        }

        /// <summary>
        /// Keeps area and other vanilla
        /// </summary>
        private void PreserveAreasAndOther()
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemUtils.IsAreaOrOther(i)
                    || ItemUtils.IsOutOfRange(i))
                {
                    continue;
                }

                ItemList[i].ReplacesItemId = i;
            };
        }
    }

}
