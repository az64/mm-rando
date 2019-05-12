using MMRando.Forms;
using MMRando.Models;
using MMRando.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MMRando
{
    public partial class MainForm : Form
    {
        private bool _isUpdating = false;
        private string _oldSettingsString = "";
        private int _seedOld = 0;

        public Settings _settings { get; set; }

        public AboutForm About { get; private set; }
        public ManualForm Manual { get; private set; }
        public LogicEditorForm LogicEditor { get; private set; }
        public ItemEditForm ItemEditor { get; private set; }

        private Randomizer _randomizer;
        private Builder _builder;


        public static string AssemblyVersion
        {
            get
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                return $"Majora's Mask Randomizer v{v}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeSettings();

            _randomizer = new Randomizer(_settings);
            _builder = new Builder(_randomizer, _settings);

            ItemEditor = new ItemEditForm(_settings.CustomItemList);
            LogicEditor = new LogicEditorForm();
            Manual = new ManualForm();
            About = new AboutForm();


            Text = AssemblyVersion;
        }

        #region Forms Code

        private void mmrMain_Load(object sender, EventArgs e)
        {
            // initialise some stuff
            _isUpdating = true;

            InitializeBackgroundWorker();

            _isUpdating = false;
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
            EnableAllControls(true);
            EnableCheckBoxes();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TryRandomize(sender as BackgroundWorker, e);
        }

        private void bTunic_Click(object sender, EventArgs e)
        {
            _isUpdating = true;

            cTunic.ShowDialog();
            _settings.TunicColor = cTunic.Color;
            bTunic.BackColor = cTunic.Color;
            UpdateSettingsString();

            _isUpdating = false;
        }

        private void bopen_Click(object sender, EventArgs e)
        {
            openROM.ShowDialog();

            _settings.InputROMFilename = openROM.FileName;
            tROMName.Text = _settings.InputROMFilename;
        }

        private void bRandomise_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFile()) return;

            saveROM.FileName = _settings.DefaultOutputROMFilename;
            if ((_settings.OutputRom || _settings.OutputVC) && saveROM.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("No output directory selected; Nothing will be saved.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _settings.OutputROMFilename = saveROM.FileName;

            EnableAllControls(false);
            bgWorker.RunWorkerAsync();
        }

        private void tSString_Enter(object sender, EventArgs e)
        {
            _oldSettingsString = tSString.Text;
            _isUpdating = true;
        }

        private void tSString_Leave(object sender, EventArgs e)
        {
            try
            {
                _settings.Update(tSString.Text);
                UpdateCheckboxes();
            }
            catch
            {
                tSString.Text = _oldSettingsString;
                _settings.Update(_oldSettingsString);
                MessageBox.Show("Settings string is invalid; reverted to previous settings.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _isUpdating = false;
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
            _seedOld = Convert.ToInt32(tSeed.Text);
            _isUpdating = true;
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
                    _settings.Seed = seed;
                }
            }
            catch
            {
                tSeed.Text = _seedOld.ToString();
                MessageBox.Show("Invalid seed: must be a positive integer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            UpdateSettingsString();
            _isUpdating = false;
        }

        private void UpdateCheckboxes()
        {
            cUserItems.Checked = _settings.UseCustomItemList;
            cAdditional.Checked = _settings.AddOther;
            cGossip.Checked = _settings.EnableGossipHints;
            cSoS.Checked = _settings.ExcludeSongOfSoaring;
            cSpoiler.Checked = _settings.GenerateSpoilerLog;
            cMixSongs.Checked = _settings.AddSongs;
            cBottled.Checked = _settings.RandomizeBottleCatchContents;
            cDChests.Checked = _settings.AddDungeonItems;
            cShop.Checked = _settings.AddShopItems;
            cDEnt.Checked = _settings.RandomizeDungeonEntrances;
            cBGM.Checked = _settings.RandomizeBGM;
            cEnemy.Checked = _settings.RandomizeEnemies;
            cCutsc.Checked = _settings.ShortenCutscenes;
            cQText.Checked = _settings.QuickTextEnabled;
            cFreeHints.Checked = _settings.FreeHints;

            cDMult.SelectedIndex = (int)_settings.DamageMode;
            cDType.SelectedIndex = (int)_settings.DamageEffect;
            cMode.SelectedIndex = (int)_settings.LogicMode;
            cLink.SelectedIndex = (int)_settings.Character;
            cTatl.SelectedIndex = (int)_settings.TatlColorSchema;
            cGravity.SelectedIndex = (int)_settings.MovementMode;
            cFloors.SelectedIndex = (int)_settings.FloorType;
            bTunic.BackColor = _settings.TunicColor;
        }

        private void tSeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cDummy.Select();
            }
        }

        private void cUserItems_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.UseCustomItemList = cUserItems.Checked);
        }

        private void cSpoiler_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.GenerateSpoilerLog = cSpoiler.Checked);
        }


        private void cAdditional_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.AddOther = cAdditional.Checked);
        }

        private void cBGM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.RandomizeBGM = cBGM.Checked);
        }

        private void cBottled_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.RandomizeBottleCatchContents = cBottled.Checked);
        }

        private void cCutsc_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.ShortenCutscenes = cCutsc.Checked);
        }

        private void cDChests_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.AddDungeonItems = cDChests.Checked);
        }

        private void cDEnt_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.RandomizeDungeonEntrances = cDEnt.Checked);
        }

        private void cDMult_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.DamageMode = (DamageMode)cDMult.SelectedIndex);
        }

        private void cDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.DamageEffect = (DamageEffect)cDType.SelectedIndex);
        }

        private void cEnemy_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.RandomizeEnemies = cEnemy.Checked);
        }

        private void cFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.FloorType = (FloorType)cFloors.SelectedIndex);
        }

        private void cGossip_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.EnableGossipHints = cGossip.Checked);
        }

        private void cGravity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.MovementMode = (MovementMode)cGravity.SelectedIndex);
        }

        private void cLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.Character = (Character)cLink.SelectedIndex);
        }

        private void cMixSongs_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.AddSongs = cMixSongs.Checked);
        }

        private void cQText_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.QuickTextEnabled = cQText.Checked);
        }

        private void cShop_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.AddShopItems = cShop.Checked);
        }

        private void cSoS_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.ExcludeSongOfSoaring = cSoS.Checked);
        }

        private void cTatl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.TatlColorSchema = (TatlColorSchema)cTatl.SelectedIndex);
        }

        private void cMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdating)
            {
                return;
            }

            if (_settings.LogicMode == LogicMode.UserLogic
                && openLogic.ShowDialog() != DialogResult.OK)
            {
                cMode.SelectedIndex = 0;
            }

            UpdateSingleSetting(() => _settings.LogicMode = (LogicMode)cMode.SelectedIndex);
            _settings.UserLogicFileName = openLogic.FileName;
        }

        private void cVC_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _settings.OutputVC = cVC.Checked);
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
                int result = RomUtils.ByteswapROM(openBROM.FileName);
                switch (result)
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



        /// <summary>
        /// Checks for settings that invalidate others, and disable the checkboxes for them.
        /// </summary>
        private void EnableCheckBoxes()
        {

            if (_settings.LogicMode == LogicMode.Vanilla)
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

            if (_settings.UseCustomItemList)
            {
                cSoS.Enabled = false;
                cDChests.Enabled = false;
                cBottled.Enabled = false;
                cShop.Enabled = false;
                cAdditional.Enabled = false;
            }
            else
            {
                if (_settings.LogicMode != LogicMode.Vanilla)
                {
                    cSoS.Enabled = true;
                    cDChests.Enabled = true;
                    cBottled.Enabled = true;
                    cShop.Enabled = true;
                    cAdditional.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Utility function that takes a function should update a single setting. 
        /// This function makes sure concurrent updates are not allowed, updates 
        /// settings string and enables/disables checkboxes automatically.
        /// </summary>
        /// <param name="update">A setting-updating function</param>
        private void UpdateSingleSetting(Action update)
        {
            if (_isUpdating)
            {
                return;
            }

            _isUpdating = true;

            update?.Invoke();
            UpdateSettingsString();
            EnableCheckBoxes();

            _isUpdating = false;
        }

        private void UpdateSettingsString()
        {
            tSString.Text = _settings.ToString();
        }

        private void EnableAllControls(bool v)
        {
            cAdditional.Enabled = v;
            cBGM.Enabled = v;
            cBottled.Enabled = v;
            cCutsc.Enabled = v;
            cDChests.Enabled = v;
            cDEnt.Enabled = v;
            cMode.Enabled = v;
            cDMult.Enabled = v;
            cDType.Enabled = v;
            cDummy.Enabled = v;
            cEnemy.Enabled = v;
            cFloors.Enabled = v;
            cGossip.Enabled = v;
            cGravity.Enabled = v;
            cLink.Enabled = v;
            cMixSongs.Enabled = v;
            cSoS.Enabled = v;
            cShop.Enabled = v;
            cUserItems.Enabled = v;
            cVC.Enabled = v;
            cQText.Enabled = v;
            cSpoiler.Enabled = v;
            cTatl.Enabled = v;

            bopen.Enabled = v;
            bRandomise.Enabled = v;
            bTunic.Enabled = v;

            tSeed.Enabled = v;
            tSString.Enabled = v;
        }

        #endregion

        #region Settings

        public void InitializeSettings()
        {
            _settings = new Settings();

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

            bTunic.BackColor = Color.FromArgb(0x1E, 0x69, 0x1B);

            _settings.GenerateSpoilerLog = true;
            _settings.ExcludeSongOfSoaring = true;
            _settings.EnableGossipHints = true;
            _settings.TunicColor = bTunic.BackColor;
            _settings.Seed = Math.Abs(Environment.TickCount);

            tSeed.Text = _settings.Seed.ToString();

            var oldSettingsString = tSString.Text;
            UpdateSettingsString();
            _oldSettingsString = oldSettingsString;
        }


        #endregion

        #region Randomization

        /// <summary>
        /// Try to perform randomization and make rom
        /// </summary>
        private void TryRandomize(BackgroundWorker worker, DoWorkEventArgs e)
        {
            try
            {
                _randomizer.Randomize(worker, e);
            }
            catch (Exception ex)
            {
                string nl = Environment.NewLine;
                MessageBox.Show($"Error randomizing logic: {ex.Message}{nl}{nl}Please try a different seed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Additional validation of preconditions
            if (!ValidateInputFile()) return;

            if (!_builder.ValidateROM(_settings.InputROMFilename))
            {
                MessageBox.Show("Cannot verify input ROM is Majora's Mask (U).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _builder.MakeROM(_settings.InputROMFilename, _settings.OutputROMFilename, worker);

            MessageBox.Show("Successfully built output ROM!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// Checks that the input file exists
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputFile()
        {
            if (!File.Exists(_settings.InputROMFilename))
            {
                MessageBox.Show("Input ROM not selected or doesn't exist, cannot generate output.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }

}
