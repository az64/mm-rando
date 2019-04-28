﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMRando
{
    public partial class fLogicEdit : Form
    {
        string[] ITEM_NAMES = new string[] { "Deku Mask", "Hero's Bow", "Fire Arrow", "Ice Arrow", "Light Arrow", "Bomb Bag (20)", "Magic Bean", 
        "Powder Keg", "Pictobox", "Lens of Truth", "Hookshot", "Great Fairy's Sword", "Witch Bottle", "Aliens Bottle", "Goron Race Bottle", 
        "Beaver Race Bottle", "Dampe Bottle", "Chateau Bottle", "Bombers' Notebook", "Razor Sword", "Gilded Sword", "Mirror Shield",
        "Town Archery Quiver (40)", "Swamp Archery Quiver (50)", "Town Bomb Bag (30)", "Mountain Bomb Bag (40)", "Town Wallet (200)", "Ocean Wallet (500)", "Moon's Tear", 
        "Land Title Deed", "Swamp Title Deed", "Mountain Title Deed", "Ocean Title Deed", "Room Key", "Letter to Kafei", "Pendant of Memories",
        "Letter to Mama", "Mayor Dotour HP", "Postman HP", "Rosa Sisters HP", "??? HP", "Grandma Short Story HP", "Grandma Long Story HP",
        "Keaton Quiz HP", "Deku Playground HP", "Town Archery HP", "Honey and Darling HP", "Swordsman's School HP", "Postbox HP",
        "Termina Field Gossips HP", "Termina Field Business Scrub HP", "Swamp Archery HP", "Pictograph Contest HP", "Boat Archery HP",
        "Frog Choir HP", "Beaver Race HP", "Seahorse HP", "Fisherman Game HP", "Evan HP", "Dog Race HP", "Poe Hut HP", 
        "Treasure Chest Game HP", "Peahat Grotto HP", "Dodongo Grotto HP", "Woodfall Chest HP", "Twin Islands Chest HP",
        "Ocean Spider House HP", "Graveyard Iron Knuckle HP", "Postman's Hat", "All Night Mask", "Blast Mask", "Stone Mask", "Great Fairy's Mask",
        "Keaton Mask", "Bremen Mask", "Bunny Hood", "Don Gero's Mask", "Mask of Scents", "Romani Mask", "Circus Leader's Mask", "Kafei's Mask",
        "Couple's Mask", "Mask of Truth", "Kamaro's Mask", "Gibdo Mask", "Garo Mask", "Captain's Hat", "Giant's Mask", "Goron Mask", "Zora Mask",
        "Song of Soaring", "Epona's Song", "Song of Storms", "Sonata of Awakening", "Goron Lullaby", "New Wave Bossa Nova",
        "Elegy of Emptiness", "Oath to Order", "Poison swamp access", "Woodfall Temple access", "Woodfall clear", "North access", "Snowhead Temple access",
        "Snowhead clear", "Epona access", "West access", "Pirates' Fortress access", "Great Bay Temple access", "Great Bay clear", "East access",
        "Ikana Canyon access", "Stone Tower Temple access", "Inverted Stone Tower Temple access", "Ikana clear", "Explosives", "Arrows", "(Unused)", "(Unused)", 
        "(Unused)", "(Unused)", "(Unused)",
        "Woodfall Map", "Woodfall Compass", "Woodfall Boss Key", "Woodfall Key 1", "Snowhead Map", "Snowhead Compass", "Snowhead Boss Key",
        "Snowhead Key 1 - block room", "Snowhead Key 2 - icicle room", "Snowhead Key 3 - bridge room", "Great Bay Map", "Great Bay Compass", "Great Bay Boss Key", "Great Bay Key 1",
        "Stone Tower Map", "Stone Tower Compass", "Stone Tower Boss Key", "Stone Tower Key 1 - armos room", "Stone Tower Key 2 - eyegore room", "Stone Tower Key 3 - updraft room",
        "Stone Tower Key 4 - death armos maze", "Trading Post Red Potion", "Trading Post Green Potion", "Trading Post Shield", "Trading Post Fairy",
        "Trading Post Stick", "Trading Post Arrow 30", "Trading Post Nut 10", "Trading Post Arrow 50", "Witch Shop Blue Potion",
        "Witch Shop Red Potion", "Witch Shop Green Potion", "Bomb Shop Bomb 10", "Bomb Shop Chu 10", "Goron Shop Bomb 10", "Goron Shop Arrow 10",
        "Goron Shop Red Potion", "Zora Shop Shield", "Zora Shop Arrow 10", "Zora Shop Red Potion", "Bottle: Fairy", "Bottle: Deku Princess",
        "Bottle: Fish", "Bottle: Bug", "Bottle: Poe", "Bottle: Big Poe", "Bottle: Spring Water", "Bottle: Hot Spring Water", "Bottle: Zora Egg",
        "Bottle: Mushroom", "Lens Cave 20r", "Lens Cave 50r", "Bean Grotto 20r", "HSW Grotto 20r", "Graveyard Bad Bats", "Ikana Grotto",
        "PF 20r Lower", "PF 20r Upper", "PF Tank 20r", "PF Guard Room 100r", "PF HP Room 20r", "PF HP Room 5r", "PF Maze 20r", "PR 20r (1)", "PR 20r (2)",
        "Bombers' Hideout 100r", "Termina Bombchu Grotto", "Termina 20r Grotto", "Termina Underwater 20r", "Termina Grass 20r", "Termina Stump 20r",
        "Great Bay Coast Grotto", "Great Bay Cape Ledge (1)", "Great Bay Cape Ledge (2)", "Great Bay Cape Grotto", "Great Bay Cape Underwater", 
        "PF Exterior 20r (1)", "PF Exterior 20r (2)", "PF Exterior 20r (3)", "Path to Swamp Grotto", "Doggy Racetrack 50r", "Graveyard Grotto",
        "Swamp Grotto", "Woodfall 5r", "Woodfall 20r", "Well Right Path 50r", "Well Left Path 50r", "Mountain Village Chest (Spring)",
        "Mountain Village Grotto (Spring)", "Path to Ikana 20r", "Path to Ikana Grotto", "Stone Tower 100r", "Stone Tower Bombchu 10",
        "Stone Tower Magic Bean", "Path to Snowhead Grotto", "Twin Islands 20r", "Secret Shrine HP", "Secret Shrine Dinolfos",
        "Secret Shrine Wizzrobe", "Secret Shrine Wart", "Secret Shrine Garo Master", "Inn Staff Room", "Inn Guest Room", "Mystery Woods Grotto",
        "East Clock Town 100r", "South Clock Town 20r", "South Clock Town 50r", "Bank HP", "South Clock Town HP", "North Clock Town HP",
        "Path to Swamp HP", "Swamp Scrub HP", "Deku Palace HP", "Goron Village Scrub HP", "Bio Baba Grotto HP", "Lab Fish HP", "Great Bay Like-Like HP",
        "Pirates' Fortress HP", "Zora Hall Scrub HP", "Path to Snowhead HP", "Great Bay Coast HP", "Ikana Scrub HP", "Ikana Castle HP", 
        "Odolwa Heart Container", "Goht Heart Container", "Gyorg Heart Container", "Twinmold Heart Container", "Map: Clock Town", "Map: Woodfall",
        "Map: Snowhead", "Map: Romani Ranch", "Map: Great Bay", "Map: Stone Tower", "Goron Racetrack Grotto" };

        bool updating = false;
        int n;
        
        public class ItemLogic
        {
            public List<int> Dependence = new List<int>();
            public List<List<int>> Conditional = new List<List<int>>();
            public int Time_Needed = new int();
            public int Time_Available = new int();
        }

        List<ItemLogic> ItemList;

        private void CheckOnTrue(CheckBox a, int n, int m)
        {
            if (((n >> m) & 1) > 0)
            {
                a.Checked = true;
            }
            else
            {
                a.Checked = false;
            };
        }

        private void FillDependence(int n)
        {
            lRequired.Items.Clear();
            for (int i = 0; i < ItemList[n].Dependence.Count; i++)
            {
                lRequired.Items.Add(ITEM_NAMES[ItemList[n].Dependence[i]]);
            };
        }

        private void UpdateDependence(int n)
        {
            fItemSelect ItemSelect = new fItemSelect();
            DialogResult R = ItemSelect.ShowDialog();
            if (R == DialogResult.OK)
            {
                List<int> Returned = fItemSelect.ReturnItems;
                if (Returned.Count == 0)
                {
                    return;
                };
                for (int i = 0; i < Returned.Count; i++)
                {
                    if (!ItemList[n].Dependence.Contains(Returned[i]))
                    {
                        ItemList[n].Dependence.Add(Returned[i]);
                    };
                };
                FillDependence(n);
            };
        }

        private void FillConditional(int n)
        {
            lConditional.Items.Clear();
            for (int i = 0; i < ItemList[n].Conditional.Count; i++)
            {
                string l = "";
                for (int j = 0; j < ItemList[n].Conditional[i].Count; j++)
                {
                    l += ITEM_NAMES[ItemList[n].Conditional[i][j]];
                    if (j != ItemList[n].Conditional[i].Count - 1)
                    {
                        l += ",";
                    };
                };
                lConditional.Items.Add(l);
            };
        }

        private void UpdateConditional(int n)
        {
            fItemSelect ItemSelect = new fItemSelect();
            DialogResult R = ItemSelect.ShowDialog();
            if (R == DialogResult.OK)
            {
                List<int> Returned = fItemSelect.ReturnItems;
                if (Returned.Count == 0)
                {
                    return;
                };
                ItemList[n].Conditional.Add(Returned);
                FillConditional(n);
            };
        }

        private void FillTime(int n)
        {
            CheckOnTrue(cNDay1, ItemList[n].Time_Needed, 0);
            CheckOnTrue(cNNight1, ItemList[n].Time_Needed, 1);
            CheckOnTrue(cNDay2, ItemList[n].Time_Needed, 2);
            CheckOnTrue(cNNight2, ItemList[n].Time_Needed, 3);
            CheckOnTrue(cNDay3, ItemList[n].Time_Needed, 4);
            CheckOnTrue(cNNight3, ItemList[n].Time_Needed, 5);
            CheckOnTrue(cADay1, ItemList[n].Time_Available, 0);
            CheckOnTrue(cANight1, ItemList[n].Time_Available, 1);
            CheckOnTrue(cADay2, ItemList[n].Time_Available, 2);
            CheckOnTrue(cANight2, ItemList[n].Time_Available, 3);
            CheckOnTrue(cADay3, ItemList[n].Time_Available, 4);
            CheckOnTrue(cANight3, ItemList[n].Time_Available, 5);
        }

        private void UpdateTime(int n)
        {
            int Av = 0;
            if (cADay1.Checked) { Av += 1; };
            if (cANight1.Checked) { Av += 2; };
            if (cADay2.Checked) { Av += 4; };
            if (cANight2.Checked) { Av += 8; };
            if (cADay3.Checked) { Av += 16; };
            if (cANight3.Checked) { Av += 32; };
            ItemList[n].Time_Available = Av;
            int Ne = 0;
            if (cNDay1.Checked) { Ne += 1; };
            if (cNNight1.Checked) { Ne += 2; };
            if (cNDay2.Checked) { Ne += 4; };
            if (cNNight2.Checked) { Ne += 8; };
            if (cNDay3.Checked) { Ne += 16; };
            if (cNNight3.Checked) { Ne += 32; };
            ItemList[n].Time_Needed = Ne;
        }

        public fLogicEdit()
        {
            InitializeComponent();
            nItem.Minimum = 0;
            nItem.Maximum = ITEM_NAMES.Length - 1;
            ItemList = new List<ItemLogic>();
            for (int i = 0; i < ITEM_NAMES.Length; i++)
            {
                ItemLogic l = new ItemLogic();
                ItemList.Add(l);
            };
            nItem.Value = 0;
        }

        private void fLogicEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            };
        }

        private void nItem_ValueChanged(object sender, EventArgs e)
        {
            n = (int)nItem.Value;
            lIName.Text = ITEM_NAMES[n];
            updating = true;
            FillDependence(n);
            FillConditional(n);
            FillTime(n);
            updating = false;
        }

        private void cNDay1_CheckedChanged(object sender, EventArgs e)
        {
            if (updating)
            {
                return;
            };
            UpdateTime(n);
        }

        private void bReqAdd_Click(object sender, EventArgs e)
        {
            UpdateDependence(n);
        }

        private void bConAdd_Click(object sender, EventArgs e)
        {
            UpdateConditional(n);
        }

        private void bReqClear_Click(object sender, EventArgs e)
        {
            if (lRequired.SelectedIndex != -1)
            {
                ItemList[n].Dependence.RemoveAt(lRequired.SelectedIndex);
                FillDependence(n);
            };
        }

        private void bConClear_Click(object sender, EventArgs e)
        {
            if (lConditional.SelectedIndex != -1)
            {
                ItemList[n].Conditional.RemoveAt(lConditional.SelectedIndex);
                FillConditional(n);
            };
        }

        private void mNew_Click(object sender, EventArgs e)
        {
            nItem.Minimum = 0;
            nItem.Maximum = ITEM_NAMES.Length - 1;
            ItemList = new List<ItemLogic>();
            for (int i = 0; i < ITEM_NAMES.Length; i++)
            {
                ItemLogic l = new ItemLogic();
                ItemList.Add(l);
            };
            nItem.Value = 1;
            nItem.Value = 0;
        }

        private void mImport_Click(object sender, EventArgs e)
        {
            if (openLogic.ShowDialog() == DialogResult.OK)
            {
                StreamReader LogicFile = new StreamReader(File.Open(openLogic.FileName, FileMode.Open));
                ItemList = new List<ItemLogic>();
                string[] lines = LogicFile.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                int i = 0;
                while (true)
                {
                    if (i == lines.Length)
                    {
                        break;
                    };
                    if (lines[i].Contains("-"))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        ItemLogic l = new ItemLogic();
                        l.Dependence = new List<int>();
                        if (lines[i] != "")
                        {
                            foreach (string j in lines[i].Split(','))
                            {
                                l.Dependence.Add(Convert.ToInt32(j));
                            };
                        };
                        l.Conditional = new List<List<int>>();
                        if (lines[i + 1] != "")
                        {
                            foreach (string j in lines[i + 1].Split(';'))
                            {
                                List<int> c = new List<int>();
                                foreach (string k in j.Split(','))
                                {
                                    c.Add(Convert.ToInt32(k));
                                };
                                l.Conditional.Add(c);
                            };
                        };
                        l.Time_Needed = Convert.ToInt32(lines[i + 2]);
                        l.Time_Available = Convert.ToInt32(lines[i + 3]);
                        ItemList.Add(l);
                        i += 4;
                    };
                };
                LogicFile.Close();
                nItem.Value = 1;
                nItem.Value = 0;
            };
        }

        private void mSave_Click(object sender, EventArgs e)
        {
            if (saveLogic.ShowDialog() == DialogResult.OK)
            {
                StreamWriter LogicFile = new StreamWriter(File.Open(saveLogic.FileName, FileMode.Create));
                for (int i = 0; i < ItemList.Count; i++)
                {
                    LogicFile.WriteLine("- " + ITEM_NAMES[i]);
                    for (int j = 0; j < ItemList[i].Dependence.Count; j++)
                    {
                        LogicFile.Write(ItemList[i].Dependence[j].ToString());
                        if (j != ItemList[i].Dependence.Count - 1)
                        {
                            LogicFile.Write(",");
                        };
                    };
                    LogicFile.WriteLine();
                    for (int j = 0; j < ItemList[i].Conditional.Count; j++)
                    {
                        for (int k = 0; k < ItemList[i].Conditional[j].Count; k++)
                        {
                            LogicFile.Write(ItemList[i].Conditional[j][k].ToString());
                            if (k != ItemList[i].Conditional[j].Count - 1)
                            {
                                LogicFile.Write(",");
                            };
                        };
                        if (j != ItemList[i].Conditional.Count - 1)
                        {
                            LogicFile.Write(";");
                        };
                    };
                    LogicFile.WriteLine();
                    LogicFile.WriteLine(ItemList[i].Time_Needed);
                    if (i != ItemList.Count - 1)
                    {
                        LogicFile.WriteLine(ItemList[i].Time_Available);
                    }
                    else
                    {
                        LogicFile.Write(ItemList[i].Time_Available);
                    };
                };
                LogicFile.Close();
            };
        }
    }
}
