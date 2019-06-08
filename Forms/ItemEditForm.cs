using MMRando.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMRando.Forms
{
    public partial class ItemEditForm : Form
    {
        string[] ITEM_NAMES = new string[] { "Deku Mask", "Hero's Bow", "Fire Arrow", "Ice Arrow", "Light Arrow", "Bomb Bag", "Magic Bean", 
        "Powder Keg", "Pictobox", "Lens of Truth", "Hookshot", "Great Fairy's Sword", "Witch Bottle", "Aliens Bottle", "Gold Dust", 
        "Beaver Race Bottle", "Dampe Bottle", "Chateau Bottle", "Bombers' Notebook", "Razor Sword", "Gilded Sword", "Mirror Shield",
        "Town Archery Quiver", "Swamp Archery Quiver", "Town Bomb Bag", "Mountain Bomb Bag", "Town Wallet", "Ocean Wallet", "Moon's Tear", 
        "Land Title Deed", "Swamp Title Deed", "Mountain Title Deed", "Ocean Title Deed", "Room Key", "Letter to Kafei", "Pendant of Memories",
        "Letter to Mama", "Mayor Dotour HP", "Postman HP", "Rosa Sisters HP", "??? HP", "Grandma Short Story HP", "Grandma Long Story HP",
        "Keaton Quiz HP", "Deku Playground HP", "Town Archery HP", "Honey and Darling HP", "Swordsman's School HP", "Postbox HP",
        "Termina Field Gossips HP", "Termina Field Business Scrub HP", "Swamp Archery HP", "Pictograph Contest HP", "Boat Archery HP",
        "Frog Choir HP", "Beaver Race HP", "Seahorse HP", "Fisherman Game HP", "Evan HP", "Dog Race HP", "Poe Hut HP", 
        "Treasure Chest Game HP", "Peahat Grotto HP", "Dodongo Grotto HP", "Woodfall Chest HP", "Twin Islands Chest HP",
        "Ocean Spider House HP", "Graveyard Iron Knuckle HP", "Postman's Hat", "All Night Mask", "Blast Mask", "Stone Mask", "Great Fairy's Mask",
        "Keaton Mask", "Bremen Mask", "Bunny Hood", "Don Gero's Mask", "Mask of Scents", "Romani Mask", "Circus Leader's Mask", "Kafei's Mask",
        "Couple's Mask", "Mask of Truth", "Kamaro's Mask", "Gibdo Mask", "Garo Mask", "Captain's Hat", "Giant's Mask", "Goron Mask", "Zora Mask",
        "Song of Healing", "Song of Soaring", "Epona's Song", "Song of Storms", "Sonata of Awakening", "Goron Lullaby", "New Wave Bossa Nova",
        "Elegy of Emptiness", "Oath to Order",
        "Woodfall Map", "Woodfall Compass", "Woodfall Boss Key", "Woodfall Key 1", "Snowhead Map", "Snowhead Compass", "Snowhead Boss Key",
        "Snowhead Key 1", "Snowhead Key 2", "Snowhead Key 3", "Great Bay Map", "Great Bay Compass", "Great Bay Boss Key", "Great Bay Key 1",
        "Stone Tower Map", "Stone Tower Compass", "Stone Tower Boss Key", "Stone Tower Key 1", "Stone Tower Key 2", "Stone Tower Key 3",
        "Stone Tower Key 4", "Trading Post Red Potion", "Trading Post Green Potion", "Trading Post Shield", "Trading Post Fairy",
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
        "Mountain Village Grotto Bottle (Spring)", "Path to Ikana 20r", "Path to Ikana Grotto", "Stone Tower 100r", "Stone Tower Bombchu 10",
        "Stone Tower Magic Bean", "Path to Snowhead Grotto", "Twin Islands 20r", "Secret Shrine HP", "Secret Shrine Dinolfos",
        "Secret Shrine Wizzrobe", "Secret Shrine Wart", "Secret Shrine Garo Master", "Inn Staff Room", "Inn Guest Room", "Mystery Woods Grotto",
        "East Clock Town 100r", "South Clock Town 20r", "South Clock Town 50r", "Bank HP", "South Clock Town HP", "North Clock Town HP",
        "Path to Swamp HP", "Swamp Scrub HP", "Deku Palace HP", "Goron Village Scrub HP", "Bio Baba Grotto HP", "Lab Fish HP", "Great Bay Like-Like HP",
        "Pirates' Fortress HP", "Zora Hall Scrub HP", "Path to Snowhead HP", "Great Bay Coast HP", "Ikana Scrub HP", "Ikana Castle HP", 
        "Odolwa Heart Container", "Goht Heart Container", "Gyorg Heart Container", "Twinmold Heart Container", "Map: Clock Town", "Map: Woodfall",
        "Map: Snowhead", "Map: Romani Ranch", "Map: Great Bay", "Map: Stone Tower", "Goron Racetrack Grotto", "Ikana Scrub 200r", "Deku Trial HP",
        "Goron Trial HP", "Zora Trial HP", "Link Trial HP", "Fierce Deity's Mask" };

        bool updating = false;
        private readonly Settings _settings;

        public ItemEditForm(Settings settings)
        {
            InitializeComponent();

            _settings = settings;

            for (int i = 0; i < ITEM_NAMES.Length; i++)
            {
                lItems.Items.Add(ITEM_NAMES[i]);
            }
            if (_settings.CustomItemList != null)
            {
                UpdateString(_settings.CustomItemList);
            }
            else
            {
                tSetting.Text = "0-0-0-0";
            }
        }

        private void fItemEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            };
        }

        private void UpdateString(List<int> selections)
        {
            int[] n = new int[8];
            string[] ns = new string[8];
            for (int i = 0; i < selections.Count; i++)
            {
                int j = selections[i] / 32;
                int k = selections[i] % 32;
                n[j] |= (int)(1 << k);
                ns[j] = Convert.ToString(n[j], 16);
            };
            tSetting.Text = ns[7] + "-" + ns[6] + "-" + ns[5] + "-" + ns[4] + "-"
                + ns[3] + "-" + ns[2] + "-" + ns[1] + "-" + ns[0];
            _settings.CustomItemListString = tSetting.Text;
        }

        private void UpdateChecks(string c)
        {
            _settings.CustomItemListString = c;
            _settings.CustomItemList.Clear();
            string[] v = c.Split('-');
            int[] vi = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if (v[7 - i] != "")
                {
                    vi[i] = Convert.ToInt32(v[7 - i], 16);
                };
            };
            for (int i = 0; i < 255; i++)
            {
                int j = i / 32;
                int k = i % 32;
                if (((vi[j] >> k) & 1) > 0)
                {
                    _settings.CustomItemList.Add(i);
                };
            };
            foreach (ListViewItem l in lItems.Items)
            {
                if (_settings.CustomItemList.Contains(l.Index))
                {
                    l.Checked = true;
                }
                else
                {
                    l.Checked = false;
                };
            };
        }

        private void tSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                updating = true;
                UpdateChecks(tSetting.Text);
                updating = false;
            };
        }

        private void lItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (updating)
            {
                return;
            };
            updating = true;
            if (e.Item.Checked)
            {
                _settings.CustomItemList.Add(e.Item.Index);
            }
            else
            {
                _settings.CustomItemList.Remove(e.Item.Index);
            }
            UpdateString(_settings.CustomItemList);
            updating = false;
        }

    }
}
