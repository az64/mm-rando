using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MMRando
{

    public partial class mmrMain
    {

        Random RNG;

        string[] GOSSIP_START = new string[] { "They say ", "I hear ", "It seems ", "Apparently, ", "It appears " };
        string[] GOSSIP_MID = new string[] { "leads to ", "yields ", "brings ", "holds ", "conceals ", "posesses " };
        string[] GOSSIP_JUNK = new string[] 
        { 
            "\x1E\x69\x4FThey say that Jimmie1717's mod\x11lottery is \x01RIGGED!\x00\xBF",
            "\x1E\x69\x4FReal ZELDA players use HOLD targeting!\xBF",
            "\x1E\x69\x4FThey say items are random...\xBF",
            "\x1E\x69\x4FThey say the \x05" + "blue dog\x00 shall prevail...\xBF",
            "\x1E\x69\x4FMy body craves for the touch of\x11\x01mashed potatoes\x00...\xBF",
            "\x1E\x69\x2B" + "Dear Mario, please come to the \x11" + "castle. I've baked a cake for you.\x11Yours truly, Princess Toadstool\x11\x06Peach\x00\xBF",
            "\x1E\x69\x56I overheard something useful:\x11\xDF\xBF",
            "\x1E\x69\x56I overheard something useful:\x11\xD6\xBF",
            "\x1E\x69\x4FThey say the best button for bombchus\x11is \x04\xB7\x00...\xBF",
            "\x1E\x69\x4FThey say the key to victory is\x11" + "beating the game...\xBF",
            "\x1E\x38\x0BThey say a certain player once stole\x11their items back from Takkuri...\xBF",
            "\x1E\x69\x4FThey say wearing the \x01" + "Bremen Mask\x00\x11increases your chances of beating the\x11Gorman bros...\xBF",
            "\x1E\x69\x6FUse the boost to get through!\xBF",
            "\x1E\x69\x4FThey say the \x04gold dog\x00 cheats...\xBF"
        };

        uint[,] TATL_COLOURS = new uint[,] { // normal, npc, check, enemy, boss
            { 0xffffe6ff, 0xdca05000, 0x9696ffff, 0x9696ff00, 0x00ff00ff, 0x00ff0000, 0xffff00ff, 0xc89b0000, 0xffff00ff, 0xc89b0000 },
            { 0x200020ff, 0x80000000, 0x001080ff, 0x0080ff00, 0x104000ff, 0x80ff0000, 0x800000ff, 0x20002000, 0x800000ff, 0xff800000 },
            { 0xffc0e0ff, 0xff00ff00, 0xe040ffff, 0xff000000, 0xff80ffff, 0xff00ff00, 0xffe000ff, 0xff000000, 0xff0000ff, 0xff000000 },
            { 0xc0ffffff, 0x0000ff00, 0xffffffff, 0x00ffff00, 0x00ffffff, 0x00ffff00, 0xc080ffff, 0x0000ff00, 0x8080ffff, 0x0000ff00 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        int[] ENTRANCE_OLD = new int[] { 0x3000, 0x3C00, 0x2A00, 0x8C00 };
        int[] EXIT_OLD = new int[] { 0x8610, 0xB210, 0xAC10, 0x6A70 };
        int[] DC_FLAG_OLD = new int[] { 0x57C, 0x589, 0x59C, 0x59F };
        int[] DC_MASK_OLD = new int[] { 0x02, 0x80, 0x20, 0x80 };
        int[] ENTRANCE_NEW = new int[] { -1, -1, -1, -1 };
        int[] EXIT_NEW = new int[] { -1, -1, -1, -1 };
        int[] DC_FLAG_NEW = new int[] { -1, -1, -1, -1 };
        int[] DC_MASK_NEW = new int[] { -1, -1, -1, -1 };
        int[] NewEnts = new int[] { -1, -1, -1, -1 };
        int[] NewExts = new int[] { -1, -1, -1, -1 };

        bool SongsMixed;
        bool ExcludeSoS;
        bool Keysanity;
        bool BottleCatch;
        bool Shops;
        bool Other;
        bool User;

        public class ItemObject
        {
            public int ID = new int();
            public List<int> Dependence = new List<int>();
            public List<List<int>> Conditional = new List<List<int>>();
            public int Time_Needed = new int();
            public int Time_Available = new int();
            public int Replaces = -1;
            public List<int> Cannot_Require = new List<int>();
        }

        public class SeqInfo
        {
            public string Name;
            public int Replaces = -1;
            public int MM_seq = -1;
            public List<int> Type = new List<int>();
            public int Inst;
        }

        public class Gossip
        {
            public string[] SrcMsg;
            public string[] DestMsg;
        }

        List<ItemObject> ItemList;
        List<SeqInfo> SeqList;
        List<SeqInfo> TargetSeqs;
        List<Gossip> GossipList;

        List<int> ConditionsChecked;
        Dictionary<int, bool> DependenceChecked;
        Dictionary<int, bool> SubChecked;
        List<int[]> ConditionRemoves;
        List<string> GossipQuotes;

        Dictionary<int, List<int>> ForbiddenPlacement = new Dictionary<int, List<int>>
        {
            // Keaton_Mask and Mama_Letter are obtained one directly after another
            // Cannot place items at Keaton_Mask that may be overwritten by item obtained at Mama_Letter
            { Keaton_Mask, new List<int> { Wallet_2, M_Shield, Moon_Tear, Land_Deed, Swamp_Deed, Mountain_Deed, Ocean_Deed, Room_Key, Mama_Letter, Kafei_Letter, Pendant } },
            // Cannot place items at Mama_Letter that can replace an item obtained at Keaton_Mask
            { Mama_Letter, new List<int> { Bomb_Bag, Bomb_Bag_1, Quiver_1 } },

            // Gold Dust cannot be obtained a second time at certain locations
            // All chests are Recovery Heart the 2nd time
            {
                Bottle_G, new List<int>
                {
                    Hero_Bow, Fire_Arrow, Ice_Arrow, Light_Arrow, Lens, Hookshot, Bottle_D, M_Shield,
                    HP_SwSch, // Rewards 20 rupees for some reason
                    Captain_Hat, Giant_Mask, Lab_Fish_HP, To_GR_Grotto,
                }
                .Concat(Enumerable.Range(HP_TCGame, HP_Knuckle - HP_TCGame + 1))
                .Concat(Enumerable.Range(WF_Map, ST_Key4 - WF_Map + 1))
                .Concat(Enumerable.Range(Lens_Cave_RR, SCT_PR - Lens_Cave_RR + 1))
                .ToList()
            },
        };

        //rando functions

        private void MakeGossipQuotes()
        {
            GossipList = new List<Gossip>();
            GossipQuotes = new List<string>();
            string[] lines = Properties.Resources.GOSSIP.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int i = 0;
            while (i < lines.Length)
            {
                Gossip g = new Gossip();
                g.SrcMsg = lines[i].Split(';');
                g.DestMsg = lines[i + 1].Split(';');
                i += 2;
                GossipList.Add(g);
            };
            for (i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].Replaces == -1)
                {
                    continue;
                };
                if ((!BottleCatch) && ((i >= B_Fairy) && (i <= B_Mushroom)))
                {
                    continue;
                };
                if ((!Shops) && ((i >= TP_RP) && (i <= ZS_RP)))
                {
                    continue;
                };
                if ((!Keysanity) && ((i >= WF_Map) && (i <= ST_Key4)))
                {
                    continue;
                };
                int msgstart = RNG.Next(5);
                int msgmid = RNG.Next(6);
                bool fake = (RNG.Next(20) == 0);
                int r = ItemList[i].Replaces;
                if (r > IST_NEW) { r -= 23; };
                int j = i;
                if (j > IST_NEW) { j -= 23; };
                if (fake) { r = RNG.Next(GossipList.Count); };
                int l = GossipList[r].SrcMsg.Length;
                int k = GossipList[j].DestMsg.Length;
                string src = GossipList[r].SrcMsg[RNG.Next(l)];
                string dest = GossipList[j].DestMsg[RNG.Next(k)];
                string sound;
                if (fake)
                {
                    sound = "\x1E\x69\x0A";
                }
                else
                {
                    sound = "\x1E\x69\x0C";
                };
                string GossipMsg = sound;
                GossipMsg += GOSSIP_START[msgstart];
                GossipMsg += "\x01" + src + "\x00\x11";
                GossipMsg += GOSSIP_MID[msgmid];
                GossipMsg += "\x06" + dest + "\x00" + "...\xBF";
                GossipQuotes.Add(GossipMsg);
            };
            for (i = 0; i < GOSSIP_JUNK.Length; i++)
            {
                GossipQuotes.Add(GOSSIP_JUNK[i]);
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
            ItemObject[] DE = new ItemObject[] { ItemList[WF_ACCESS], ItemList[SH_ACCESS], ItemList[IST_ACCESS], ItemList[GB_ACCESS] };
            int[] DI = new int[] { WF_ACCESS, SH_ACCESS, IST_ACCESS, GB_ACCESS };
            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine($"Entrance {DI[NewEnts[i]]} placed at {DE[i].ID}.");
                ItemList[DI[NewEnts[i]]] = DE[i];
            };
            DE = new ItemObject[] { ItemList[WF_CLEAR], ItemList[SH_CLEAR], ItemList[ST_CLEAR], ItemList[GB_CLEAR] };
            DI = new int[] { WF_CLEAR, SH_CLEAR, ST_CLEAR, GB_CLEAR };
            for (int i = 0; i < 4; i++)
            {
                ItemList[DI[i]] = DE[NewEnts[i]];
            };
            for (int i = 0; i < 4; i++)
            {
                ENTRANCE_NEW[i] = ENTRANCE_OLD[NewEnts[i]];
                EXIT_NEW[i] = EXIT_OLD[NewExts[i]];
                DC_FLAG_NEW[i] = DC_FLAG_OLD[NewExts[i]];
                DC_MASK_NEW[i] = DC_MASK_OLD[NewExts[i]];
            };
        }

        private void ReadSeqInfo()
        {
            SeqList = new List<SeqInfo>();
            TargetSeqs = new List<SeqInfo>();
            string[] lines = Properties.Resources.SEQS.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int i = 0;
            while (i < lines.Length)
            {
                SeqInfo s = new SeqInfo();
                SeqInfo t = new SeqInfo();
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
                    TargetSeqs.Add(t);
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
                    SeqList.Add(s);
                };
            };
        }

        private void BGMShuffle()
        {
            while (TargetSeqs.Count > 0)
            {
                List<SeqInfo> Unassigned = SeqList.FindAll(u => u.Replaces == -1);
                int t = RNG.Next(TargetSeqs.Count);
                while (true)
                {
                    int s = RNG.Next(Unassigned.Count);
                    if (Unassigned[s].Name.StartsWith("mm") & (RNG.Next(2) == 0))
                    {
                        continue;
                    };
                    for (int i = 0; i < Unassigned[s].Type.Count; i++)
                    {
                        if (TargetSeqs[t].Type.Contains(Unassigned[s].Type[i]))
                        {
                            Unassigned[s].Replaces = TargetSeqs[t].Replaces;
                            Debug.WriteLine(Unassigned[s].Name + " -> " + TargetSeqs[t].Name);
                            TargetSeqs.RemoveAt(t);
                            break;
                        }
                        else if (i + 1 == Unassigned[s].Type.Count)
                        {
                            if ((RNG.Next(30) == 0) && ((Unassigned[s].Type[0] & 8) == (TargetSeqs[t].Type[0] & 8)) &&
                                (Unassigned[s].Type.Contains(10) == TargetSeqs[t].Type.Contains(10)) && (!Unassigned[s].Type.Contains(16)))
                            {
                                Unassigned[s].Replaces = TargetSeqs[t].Replaces;
                                Debug.WriteLine(Unassigned[s].Name + " -> " + TargetSeqs[t].Name);
                                TargetSeqs.RemoveAt(t);
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
            SeqList.RemoveAll(u => u.Replaces == -1);
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
                    TATL_COLOURS[4, i] = BitConverter.ToUInt32(c, 0);
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
                string[] DN = new string[] { "Woodfall", "Snowhead", "Inverted Stone Tower", "Great Bay" };
                for (int i = 0; i < 4; i++)
                {
                    LogFile.WriteLine(DN[i].PadRight(32, '-') + "---->>" + DN[NewEnts[i]].PadLeft(32, '-'));
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
            ItemList.RemoveAll(u => u.Replaces == -1);
            LogFile.WriteLine("--------------Item------------------------------Destination-----------");
            for (int i = 0; i < ItemList.Count; i++)
            {
                LogFile.WriteLine(ITEM_NAMES[ItemList[i].ID].PadRight(32, '-') + "---->>" + ITEM_NAMES[ItemList[i].Replaces].PadLeft(32, '-'));
            };
            LogFile.WriteLine("");
            LogFile.WriteLine("-----------Destination------------------------------Item--------------");
            ItemList.Sort((i, j) => i.Replaces.CompareTo(j.Replaces));
            for (int i = 0; i < ItemList.Count; i++)
            {
                LogFile.WriteLine(ITEM_NAMES[ItemList[i].Replaces].PadRight(32, '-') + "<<----" + ITEM_NAMES[ItemList[i].ID].PadLeft(32, '-'));
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
            return (itemId >= SOUTH_ACCESS && itemId <= IST_NEW) || itemId > To_GR_Grotto;
        }

        private bool CheckDependence(int CurrentItem, int Target, bool skip)
        {
            Debug.WriteLine($"CheckDependence({CurrentItem}, {Target}, {skip})");
            if (!skip)
            {
                DependenceChecked[Target] = true;
            };
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
                        if (!IsFakeItem(d) && ItemList[d].Replaces == -1)
                        {
                            continue;
                        }
                        int[] check = new int[] { Target, i, j };
                        if (ItemList[d].Replaces != -1) { d = ItemList[d].Replaces; };
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
                if (IsFakeItem(d) || ItemList[d].Replaces != -1)
                {
                    if (ItemList[d].Replaces != -1) d = ItemList[d].Replaces;
                    if (DependenceChecked.ContainsKey(d))
                    {
                        if (!skip)
                        {
                            DependenceChecked[Target] = DependenceChecked[d];
                        }
                        if (DependenceChecked[d])
                        {
                            Debug.WriteLine($"{CurrentItem} is dependent on {d}");
                        }
                        return DependenceChecked[d];
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
                if (d != -1)
                {
                    if (ItemList[d].Replaces != -1) { d = ItemList[d].Replaces; };
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
            if (ForbiddenPlacement.ContainsKey(Target) && ForbiddenPlacement[Target].Contains(CurrentItem))
            {
                Debug.WriteLine($"{Target} forbids placement of {CurrentItem}");
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
            if (ItemList[CurrentItem].Replaces != -1)
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
                if ((((CurrentItem > Wallet_2) && (CurrentItem < HP_Mayor)) || (CurrentItem > Song_Oath)) && (availableTargets.Contains(0)))
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
                    ItemList[CurrentItem].Replaces = availableTargets[TargetSlot];
                    Debug.WriteLine($"----Placed {CurrentItem} at {ItemList[CurrentItem].Replaces}----");
                    if ((ItemList[CurrentItem].Time_Needed != 0) && (availableTargets[TargetSlot] > Moon_Tear) && (availableTargets[TargetSlot] < Room_Key))
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
            SongsMixed = cMixSongs.Checked;
            ExcludeSoS = cSoS.Checked;
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
                    if ((i > Song_Oath && i < WF_Map) || i > To_GR_Grotto)
                    {
                        continue;
                    };
                    ItemList[i].Replaces = i;
                };
                for (int i = 0; i < fItemEdit.selected_items.Count; i++)
                {
                    int j = fItemEdit.selected_items[i];
                    if (j > Song_Oath)
                    {
                        j += 23;
                    };
                    int k = ItemList.FindIndex(u => u.ID == j);
                    if (k != -1)
                    {
                        ItemList[k].Replaces = -1;
                    };
                    if ((j > ST_Key4) && (j < B_Fairy))
                    {
                        Shops = true;
                    };
                };
                if (!SongsMixed)
                {
                    TargetPool = new List<int>();
                    for (int i = Song_Soaring; i < Song_Oath + 1; i++)
                    {
                        if (ItemList[i].Replaces != -1)
                        {
                            continue;
                        };
                        TargetPool.Add(i);
                    };
                    for (int i = Song_Soaring; i < Song_Oath + 1; i++)
                    {
                        PlaceItem(i, TargetPool);
                    };
                };
                TargetPool = new List<int>();
                for (int i = B_Fairy; i < B_Mushroom + 1; i++)
                {
                    TargetPool.Add(i);
                };
                for (int i = B_Fairy; i < B_Mushroom + 1; i++)
                {
                    PlaceItem(i, TargetPool);
                };
            }
            else
            {
                if (ExcludeSoS)
                {
                    ItemList[Song_Soaring].Replaces = Song_Soaring;
                };
                if (!SongsMixed)
                {
                    TargetPool = new List<int>();
                    for (int i = Song_Soaring; i < Song_Oath + 1; i++)
                    {
                        if (ItemList[i].Replaces != -1)
                        {
                            continue;
                        };
                        TargetPool.Add(i);
                    };
                    for (int i = Song_Soaring; i < Song_Oath + 1; i++)
                    {
                        PlaceItem(i, TargetPool);
                    };
                };
                if (!Keysanity)
                {
                    for (int i = WF_Map; i < ST_Key4 + 1; i++)
                    {
                        ItemList[i].Replaces = i;
                    };
                };
                if (!Shops)
                {
                    for (int i = TP_RP; i < ZS_RP + 1; i++)
                    {
                        ItemList[i].Replaces = i;
                    };
                    ItemList[Bomb_Bag].Replaces = Bomb_Bag;
                    ItemList[Bomb_Bag_1].Replaces = Bomb_Bag_1;
                    ItemList[All_Night].Replaces = All_Night;
                };
                if (!Other)
                {
                    for (int i = Lens_Cave_RR; i < To_GR_Grotto + 1; i++)
                    {
                        ItemList[i].Replaces = i;
                    };
                };
                if (BottleCatch)
                {
                    TargetPool = new List<int>();
                    for (int i = B_Fairy; i < B_Mushroom + 1; i++)
                    {
                        TargetPool.Add(i);
                    };
                    for (int i = B_Fairy; i < B_Mushroom + 1; i++)
                    {
                        PlaceItem(i, TargetPool);
                    };
                }
                else
                {
                    for (int i = B_Fairy; i < B_Mushroom + 1; i++)
                    {
                        ItemList[i].Replaces = i;
                    };
                };
            };
            TargetPool = new List<int>();
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (((i > Song_Oath && i < WF_Map) || i > To_GR_Grotto) || (ItemList[i].Replaces != -1))
                {
                    continue;
                };
                TargetPool.Add(i);
            };
            PlaceItem(Room_Key, TargetPool);
            PlaceItem(Kafei_Letter, TargetPool);
            PlaceItem(Pendant, TargetPool);
            PlaceItem(Mama_Letter, TargetPool);
            if (ItemList.FindIndex(u => u.Replaces == 0) == -1)
            {
                int free = RNG.Next(Song_Oath + 1);
                while (((free > Wallet_2) && (free < HP_Mayor)) || (free == Wallet_2) || (free == M_Shield) || (ItemList[free].Replaces != -1) || ((free > Fairy_Sword) && (free < Notebook)))
                {
                    free = RNG.Next(Song_Oath + 1);
                };
                ItemList[free].Replaces = 0;
                TargetPool.RemoveAt(0);
            };
            for (int i = Deku_Mask; i < HP_Mayor; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = Postman_Hat; i < SOUTH_ACCESS; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = WF_Map; i < TP_RP; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = TP_RP; i < B_Fairy; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = HP_Mayor; i < Postman_Hat; i++)
            {
                PlaceItem(i, TargetPool);
            };
            for (int i = Lens_Cave_RR; i < To_GR_Grotto + 1; i++)
            {
                PlaceItem(i, TargetPool);
            };
        }

    }

}