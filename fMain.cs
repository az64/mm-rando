using MMRando.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MMRando
{

    public partial class MainRandomizerForm : Form
    {
        public Settings Settings { get; set; } = new Settings();

        private int _progressPercentage = 0;

        bool IsUpdating = false;
        bool Output_VC = false;
        string OldSettingsString = "";
        int SeedOld = 0;

        fAbout About = new fAbout();
        fManual Manual = new fManual();
        fLogicEdit LogicEditor = new fLogicEdit();
        fItemEdit ItemEditor = new fItemEdit();

        public static string MainDirectory = Application.StartupPath;
        public static string MusicDirectory = Application.StartupPath + "\\music\\";
        public static string ModsDirectory = Application.StartupPath + "\\mods\\";
        public static string AddrsDirectory = Application.StartupPath + "\\addresses\\";
        public static string ObjsDirectory = Application.StartupPath + "\\obj\\";
        public static string VCDirectory = Application.StartupPath + "\\vc\\";

        //read/write settings

        private void SeedRNG()
        {
            RNG = new Random(RandomizerSettings.Seed);
        }

        #region Settings

        public void InitializeSettings()
        {
            cDMult.SelectedIndex = 0;
            cDType.SelectedIndex = 0;
            cGravity.SelectedIndex = 0;
            cFloors.SelectedIndex = 0;
            cMode.SelectedIndex = 0;
            cLink.SelectedIndex = 0;
            cTatl.SelectedIndex = 0;
            cSpoiler.Checked = true;
            cSoS.Checked = true;
            cGossip.Checked = true;
            //cQText.Checked = true;
            //cCutsc.Checked = true;

            bTunic.BackColor = Color.FromArgb(0x1E, 0x69, 0x1B);

            RandomizerSettings.GenerateSpoilerLog = true;
            RandomizerSettings.ExcludeSongOfSoaring = true;
            RandomizerSettings.EnableGossipHints = true;
            RandomizerSettings.TunicColor = bTunic.BackColor;
            RandomizerSettings.Seed = Math.Abs(Environment.TickCount);

            tSeed.Text = RandomizerSettings.Seed.ToString();

            var oldSettingsString = tSString.Text;

            UpdateSettingsString();

            OldSettingsString = oldSettingsString;
        }

        private int[] BuildSettingsBytes()
        {
            int[] O = new int[3];

            if (RandomizerSettings.UseCustomItemList) { O[0] += 8192; };
            if (RandomizerSettings.AddOther) { O[0] += 4096; };
            if (RandomizerSettings.EnableGossipHints) { O[0] += 2048; };
            if (RandomizerSettings.ExcludeSongOfSoaring) { O[0] += 1024; };
            if (RandomizerSettings.GenerateSpoilerLog) { O[0] += 512; };
            if (RandomizerSettings.AddSongs) { O[0] += 256; };
            if (RandomizerSettings.RandomizeBottleCatchContents) { O[0] += 128; };
            if (RandomizerSettings.AddDungeonItems) { O[0] += 64; };
            if (RandomizerSettings.AddShopItems) { O[0] += 32; };
            if (RandomizerSettings.RandomizeDungeonEntrances) { O[0] += 16; };
            if (RandomizerSettings.RandomizeBGM) { O[0] += 8; };
            if (RandomizerSettings.RandomizeEnemies) { O[0] += 4; };
            if (RandomizerSettings.ShortenCutscenes) { O[0] += 2; };
            if (RandomizerSettings.QuickTextEnabled) { O[0] += 1; };

            O[1] = ((byte)RandomizerSettings.LogicMode << 16)
                | ((byte)RandomizerSettings.Character << 8)
                | ((byte)RandomizerSettings.TatlColorSchema)
                | ((byte)RandomizerSettings.DamageEffect << 24)
                    | ((byte)RandomizerSettings.DamageMode << 28);

            O[2] = (RandomizerSettings.TunicColor.R << 16)
                | (RandomizerSettings.TunicColor.G << 8)
                | (RandomizerSettings.TunicColor.B)
                | ((byte)RandomizerSettings.FloorType << 24)
                    | ((byte)RandomizerSettings.MovementMode << 28);

            return O;
        }

        // TODO add to settings class
        private void UpdateSettingsString()
        {
            var settingsString = EncodeSettings();
            tSString.Text = settingsString;

            saveROM.FileName = $"MMR-{settingsString}.z64";
            saveWad.FileName = $"MMR-{settingsString}.wad";
        }

        private string EncodeSettings()
        {
            int[] Options = BuildSettingsBytes();

            var settingsStringBuilder = new StringBuilder();

            settingsStringBuilder.Append(Base36.Encode(Convert.ToInt32(RandomizerSettings.Seed)));
            settingsStringBuilder.Append("-");
            settingsStringBuilder.Append(Base36.Encode(Options[0]));
            settingsStringBuilder.Append("-");
            settingsStringBuilder.Append(Base36.Encode(Options[1]));
            settingsStringBuilder.Append("-");
            settingsStringBuilder.Append(Base36.Encode(Options[2]));

            var settingsString = settingsStringBuilder.ToString();
            return settingsString;
        }

        // TODO add to settings class
        private void SetOptions(string[] O)
        {
            tSeed.Text = Base36.Decode(O[0]).ToString();

            int Checks = (int)Base36.Decode(O[1]);
            int Combos = (int)Base36.Decode(O[2]);
            int ColourAndMisc = (int)Base36.Decode(O[3]);

            RandomizerSettings.UseCustomItemList = (Checks & 8192) > 0;
            RandomizerSettings.AddOther = (Checks & 4096) > 0;
            RandomizerSettings.EnableGossipHints = (Checks & 2048) > 0;
            RandomizerSettings.ExcludeSongOfSoaring = (Checks & 1024) > 0;
            RandomizerSettings.GenerateSpoilerLog = (Checks & 512) > 0;
            RandomizerSettings.AddSongs = (Checks & 256) > 0;
            RandomizerSettings.RandomizeBottleCatchContents = (Checks & 128) > 0;
            RandomizerSettings.AddDungeonItems = (Checks & 64) > 0;
            RandomizerSettings.AddShopItems = (Checks & 32) > 0;
            RandomizerSettings.RandomizeDungeonEntrances = (Checks & 16) > 0;
            RandomizerSettings.RandomizeBGM = (Checks & 8) > 0;
            RandomizerSettings.RandomizeEnemies = (Checks & 4) > 0;
            RandomizerSettings.ShortenCutscenes = (Checks & 2) > 0;
            RandomizerSettings.QuickTextEnabled = (Checks & 1) > 0;

            cUserItems.Checked = RandomizerSettings.UseCustomItemList;
            cAdditional.Checked = RandomizerSettings.AddOther;
            cGossip.Checked = RandomizerSettings.EnableGossipHints;
            cSoS.Checked = RandomizerSettings.ExcludeSongOfSoaring;
            cSpoiler.Checked = RandomizerSettings.GenerateSpoilerLog;
            cMixSongs.Checked = RandomizerSettings.AddSongs;
            cBottled.Checked = RandomizerSettings.RandomizeBottleCatchContents;
            cDChests.Checked = RandomizerSettings.AddDungeonItems;
            cShop.Checked = RandomizerSettings.AddShopItems;
            cDEnt.Checked = RandomizerSettings.RandomizeDungeonEntrances;
            cBGM.Checked = RandomizerSettings.RandomizeBGM;
            cEnemy.Checked = RandomizerSettings.RandomizeEnemies;
            cCutsc.Checked = RandomizerSettings.ShortenCutscenes;
            cQText.Checked = RandomizerSettings.QuickTextEnabled;

            var damageMultiplierIndex = (int)((Combos & 0xF0000000) >> 28);
            var damageTypeIndex = (Combos & 0xF000000) >> 24;
            var modeIndex = (Combos & 0xFF0000) >> 16;
            var characterIndex = (Combos & 0xFF00) >> 8;
            var tatlColorIndex = Combos & 0xFF;
            var gravityTypeIndex = (int)((ColourAndMisc & 0xF0000000) >> 28);
            var floorTypeIndex = (ColourAndMisc & 0xF000000) >> 24;
            var tunicColor = Color.FromArgb(
                (ColourAndMisc & 0xFF0000) >> 16,
                (ColourAndMisc & 0xFF00) >> 8,
                ColourAndMisc & 0xFF);

            RandomizerSettings.DamageMode = (DamageMode)damageMultiplierIndex;
            RandomizerSettings.DamageEffect = (DamageEffect)damageTypeIndex;
            RandomizerSettings.LogicMode = (LogicMode)modeIndex;
            RandomizerSettings.Character = (Character)characterIndex;
            RandomizerSettings.TatlColorSchema = (TatlColorSchema)tatlColorIndex;
            RandomizerSettings.MovementMode = (MovementMode)gravityTypeIndex;
            RandomizerSettings.FloorType = (FloorType)floorTypeIndex;
            RandomizerSettings.TunicColor = tunicColor;

            cDMult.SelectedIndex = damageMultiplierIndex;
            cDType.SelectedIndex = damageTypeIndex;
            cMode.SelectedIndex = modeIndex;
            cLink.SelectedIndex = characterIndex;
            cTatl.SelectedIndex = tatlColorIndex;
            cGravity.SelectedIndex = gravityTypeIndex;
            cFloors.SelectedIndex = floorTypeIndex;
            bTunic.BackColor = tunicColor;
        }

        private void UpdateSettingsFromString(string Settings)
        {
            SetOptions(Settings.Split('-'));
            saveROM.FileName = "MMR-" + Settings + ".z64";
            saveWad.FileName = "MMR-" + Settings + ".wad";
        }

        #endregion

        //form functions

        #region Forms Code

        private void mmrMain_Load(object sender, EventArgs e)
        {
            // initialise some stuff
            IsUpdating = true;

            InitializeSettings();
            InitializeBackgroundWorker();

            IsUpdating = false;
        }

        private void InitializeBackgroundWorker()
        {
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_WorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pProgress.Value = e.ProgressPercentage;
            var message = (string)e.UserState;
            lStatus.Text = message;
        }

        private void bgWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pProgress.Value = 0;
            lStatus.Text = "Ready...";
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TryRandomize(sender as BackgroundWorker, e);
        }

        private void bTunic_Click(object sender, EventArgs e)
        {
            IsUpdating = true;

            cTunic.ShowDialog();
            bTunic.BackColor = cTunic.Color;
            UpdateSettingsString();

            IsUpdating = false;
        }

        private void bopen_Click(object sender, EventArgs e)
        {
            openROM.ShowDialog();

            RandomizerSettings.InputRomPath = openROM.FileName;
            tROMName.Text = RandomizerSettings.InputRomPath;
        }

        private void bRandomise_Click(object sender, EventArgs e)
        {
            if (saveROM.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("No output selected; ROM will not be saved.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bgWorker.RunWorkerAsync();
        }

        private void tSString_Enter(object sender, EventArgs e)
        {
            OldSettingsString = tSString.Text;
            IsUpdating = true;
        }

        private void tSString_Leave(object sender, EventArgs e)
        {
            try
            {
                UpdateSettingsFromString(tSString.Text);
            }
            catch
            {
                tSString.Text = OldSettingsString;
                UpdateSettingsFromString(tSString.Text);
                MessageBox.Show("Settings string is invalid; reverted to previous settings.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            IsUpdating = false;
        }

        private void tSString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cDummy.Select();
            };
        }

        private void tSeed_Enter(object sender, EventArgs e)
        {
            SeedOld = Convert.ToInt32(tSeed.Text);
            IsUpdating = true;
        }

        private void tSeed_Leave(object sender, EventArgs e)
        {
            try
            {
                int seed = Convert.ToInt32(tSeed.Text);
                if (seed < 0)
                {
                    seed = Math.Abs(seed);
                    tSeed.Text = seed.ToString();
                    MessageBox.Show("Seed must be positive",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    RandomizerSettings.Seed = seed;
                }
            }
            catch
            {
                tSeed.Text = SeedOld.ToString();
                MessageBox.Show("Invalid seed: must be a positive integer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            UpdateSettingsString();
            IsUpdating = false;
        }

        private void tSeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cDummy.Select();
            };
        }

        private void cSpoiler_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.GenerateSpoilerLog = cSpoiler.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }


        private void cAdditional_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.AddOther = cAdditional.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cBGM_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.RandomizeBGM = cBGM.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cBottled_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.RandomizeBottleCatchContents = cBottled.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cCutsc_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.ShortenCutscenes = cCutsc.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cDChests_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.AddDungeonItems = cDChests.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cDEnt_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.RandomizeDungeonEntrances = cDEnt.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cDMult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.DamageMode = (DamageMode)cDMult.SelectedIndex;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.DamageEffect = (DamageEffect)cDType.SelectedIndex;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cEnemy_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.RandomizeEnemies = cEnemy.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.FloorType = (FloorType)cFloors.SelectedIndex;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cGossip_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.EnableGossipHints = cGossip.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cGravity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.MovementMode = (MovementMode)cGravity.SelectedIndex;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.Character = (Character)cLink.SelectedIndex;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cMixSongs_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.AddSongs = cMixSongs.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cQText_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.QuickTextEnabled = cQText.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cShop_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.AddShopItems = cShop.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cSoS_CheckedChanged(object sender, EventArgs e)
        {
            EnableBoxes();
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.ExcludeSongOfSoaring = cSoS.Checked;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cTatl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;

                RandomizerSettings.TatlColorSchema = (TatlColorSchema)cTatl.SelectedIndex;

                UpdateSettingsString();
                IsUpdating = false;
            };
        }

        private void cMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                if (RandomizerSettings.LogicMode == LogicMode.UserLogic)
                {
                    if (openLogic.ShowDialog() == DialogResult.OK)
                    {
                        //do nothing?
                    }
                    else
                    {
                        cMode.SelectedIndex = 0;
                    };
                };
                IsUpdating = true;
                RandomizerSettings.LogicMode = (LogicMode)cMode.SelectedIndex;
                UpdateSettingsString();
                IsUpdating = false;
            };
            EnableBoxes();
        }

        private void cVC_CheckedChanged(object sender, EventArgs e)
        {
            Output_VC = cVC.Checked;
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mAbout_Click(object sender, EventArgs e)
        {
            About.ShowDialog();
        }

        private void mManual_Click(object sender, EventArgs e)
        {
            Manual.Show();
        }

        private void mByteswap_Click(object sender, EventArgs e)
        {
            if (openBROM.ShowDialog() == DialogResult.OK)
            {
                int r = ROMFuncs.ByteswapROM(openBROM.FileName);
                switch (r)
                {
                    case 0:
                        MessageBox.Show("Successfully byteswapped ROM.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        break;
                    case 1:
                        MessageBox.Show("ROM appears to be big endian.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        break;
                    default:
                        MessageBox.Show("Could not byteswap ROM.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                };
            };
        }

        private void mLogicEdit_Click(object sender, EventArgs e)
        {
            LogicEditor.Show();
        }

        private void mItemIncl_Click(object sender, EventArgs e)
        {
            ItemEditor.Show();
        }

        public MainRandomizerForm()
        {
            InitializeComponent();
        }

        private void EnableBoxes()
        {
            if (RandomizerSettings.LogicMode == LogicMode.Vanilla)
            {
                cMixSongs.Enabled = false;
                cSoS.Enabled = false;
                cDChests.Enabled = false;
                cDEnt.Enabled = false;
                cBottled.Enabled = false;
                cShop.Enabled = false;
                cSpoiler.Enabled = false;
                cGossip.Enabled = false;
                cAdditional.Enabled = false;
                cUserItems.Enabled = false;
            }
            else
            {
                cMixSongs.Enabled = true;
                cSoS.Enabled = true;
                cDChests.Enabled = true;
                cDEnt.Enabled = true;
                cBottled.Enabled = true;
                cShop.Enabled = true;
                cSpoiler.Enabled = true;
                cGossip.Enabled = true;
                cAdditional.Enabled = true;
                cUserItems.Enabled = true;
            };

            if (RandomizerSettings.UseCustomItemList)
            {
                cSoS.Enabled = false;
                cDChests.Enabled = false;
                cBottled.Enabled = false;
                cShop.Enabled = false;
                cAdditional.Enabled = false;
            }
            else
            {
                if (RandomizerSettings.LogicMode != LogicMode.Vanilla)
                {
                    cSoS.Enabled = true;
                    cDChests.Enabled = true;
                    cBottled.Enabled = true;
                    cShop.Enabled = true;
                    cAdditional.Enabled = true;
                };
            };
        }

        #endregion

        /// <summary>
        /// Try to perform randomization and make rom
        /// </summary>
        private void TryRandomize(BackgroundWorker worker, DoWorkEventArgs e)
        {
            try
            {
                Randomize(worker, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error randomizing logic: {ex.Message}\r\n\r\nPlease try a different seed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(RandomizerSettings.InputRomPath))
            {
                MessageBox.Show("Input ROM not selected or doesn't exist, cannot generate output.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (saveROM.FileName == "")
            {
                MessageBox.Show("Output file not selected.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Output_VC)
            {
                if (saveWad.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Output file not selected.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                };
            };
            if (!ValidateROM(RandomizerSettings.InputRomPath))
            {
                MessageBox.Show("Cannot verify input ROM is Majora's Mask (U).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MakeROM(RandomizerSettings.InputRomPath, saveROM.FileName, worker);

            MessageBox.Show("Successfully built output ROM!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

        }
        /// <summary>
        /// Randomizes the ROM with respect to the configured ruleset.
        /// </summary>
        private void Randomize(BackgroundWorker worker, DoWorkEventArgs e)
        {
            SeedRNG();

            if (RandomizerSettings.LogicMode != LogicMode.Vanilla)
            {
                worker.ReportProgress(5, "Preparing ruleset...");
                PrepareRulesetItemData();

                if (RandomizerSettings.RandomizeDungeonEntrances)
                {
                    worker.ReportProgress(10, "Shuffling entrances...");
                    EntranceShuffle();
                };

                worker.ReportProgress(15, "Shuffling items...");
                ItemShuffle();

                if (RandomizerSettings.EnableGossipHints)
                {
                    worker.ReportProgress(35, "Making gossip quotes...");
                }

                //gossip
                SeedRNG();
                MakeGossipQuotes();
            }

            worker.ReportProgress(40, "Coloring Tatl...");
            //Randomize tatl colour
            SeedRNG();
            SetTatlColour();

            worker.ReportProgress(45, "Randomizing Music...");

            //Sort BGM
            SeedRNG();
            SortBGM();
        }
    }

}
