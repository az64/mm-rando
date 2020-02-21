using MMR.Randomizer.Models.Settings;
using MMR.UI.Forms.Tooltips;
using MMR.Randomizer;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MMR.Randomizer.Models;
using MMR.Randomizer.Utils;
using MMR.Randomizer.Asm;
using MMR.Randomizer.Models.Colors;
using MMR.Common.Utils;

namespace MMR.UI.Forms
{
    using Randomizer = Randomizer.Randomizer;
    public partial class MainForm : Form
    {
        private bool _isUpdating = false;
        private string _oldSettingsString = "";
        private int _seedOld = 0;
        public Configuration _configuration { get; set; }

        public AboutForm About { get; private set; }
        public ManualForm Manual { get; private set; }
        public LogicEditorForm LogicEditor { get; private set; }
        public ItemEditForm ItemEditor { get; private set; }
        public StartingItemEditForm StartingItemEditor { get; private set; }
        public JunkLocationEditForm JunkLocationEditor { get; private set; }
        public HudConfigForm HudConfig { get; private set; }


        public const string SETTINGS_EXTENSION = ".cfg";


        public static string AssemblyVersion
        {
            get
            {
                Version v = typeof(Randomizer).Assembly.GetName().Version;
                return $"Majora's Mask Randomizer v{v}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeSettings();
            InitializeTooltips();
            InitializeHUDGroupBox();

            ItemEditor = new ItemEditForm();
            UpdateCustomItemAmountLabel();

            StartingItemEditor = new StartingItemEditForm();
            UpdateCustomStartingItemAmountLabel();

            JunkLocationEditor = new JunkLocationEditForm();
            UpdateJunkLocationAmountLabel();

            LogicEditor = new LogicEditorForm();
            Manual = new ManualForm();
            About = new AboutForm();
            HudConfig = new HudConfigForm();


            Text = AssemblyVersion;

            LoadSettings();
        }

        private void InitializeTooltips()
        {
            // ROM Settings
            TooltipBuilder.SetTooltip(cN64, "Output a randomized .z64 ROM that can be loaded into a N64 Emulator.");
            TooltipBuilder.SetTooltip(cVC, "Output a randomized .WAD file that can be loaded into a Wii Virtual Channel.");
            TooltipBuilder.SetTooltip(cSpoiler, "Output a spoiler log.\n\n The spoiler log contains a list over all items, and their shuffled locations.\n In addition, the spoiler log contains version information, seed and settings string used in the randomization.");
            TooltipBuilder.SetTooltip(cHTMLLog, "Output a html spoiler log (Requires spoiler log to be checked).\n\n Similar to the regular spoiler log, but readable in browsers. The locations/items are hidden by default, and hovering over them will make them visible.");
            TooltipBuilder.SetTooltip(cPatch, "Output a patch file that can be applied using the Patch settings tab to reproduce the same ROM.\nPatch file includes all settings except Tunic and Tatl color.");

            // Main Settings
            TooltipBuilder.SetTooltip(cMode, "Select mode of logic:\n - Casual: The randomization logic ensures that the game can be beaten casually.\n - Using glitches: The randomization logic allows for placement of items that are only obtainable using known glitches.\n - Vanilla Layout: All items are left vanilla.\n - User logic: Upload your own custom logic to be used in the randomization.\n - No logic: Completely random, no guarantee the game is beatable.");

            TooltipBuilder.SetTooltip(cUserItems, "Only randomize a custom list of items.\n\nThe item list can be edited from the menu: Customize -> Item List Editor. When checked, some settings will become disabled.");
            TooltipBuilder.SetTooltip(cMixSongs, "Enable songs being placed among items in the randomization pool.");
            TooltipBuilder.SetTooltip(cDChests, "Enable keys, boss keys, maps and compasses being placed in the randomization pool.");
            TooltipBuilder.SetTooltip(cShop, "Enable shop items being placed in the randomization pool.");
            TooltipBuilder.SetTooltip(cBottled, "Enable captured bottle contents being randomized.");
            TooltipBuilder.SetTooltip(cSoS, "Exclude song of soaring from being placed in the randomization pool.");
            TooltipBuilder.SetTooltip(cDEnt, "Enable randomization of dungeon entrances. \n\nStone Tower Temple is always vanilla, but Inverted Stone Tower Temple is randomized.");
            TooltipBuilder.SetTooltip(cAdditional, "Enable miscellaneous items being placed in the randomization pool.\n\nAmong the miscellaneous items are:\nFreestanding heartpieces, overworld chests, (hidden) grotto chests, Tingle's maps and bank heartpiece.");
            TooltipBuilder.SetTooltip(cEnemy, "Enable randomization of enemies. May cause softlocks in some circumstances, use at your own risk.");
            TooltipBuilder.SetTooltip(cMoonItems, "Enable moon items being placed in the randomization pool.\n\nIncludes the four Moon Trial Heart Pieces, Fierce Deity's Mask and the two Link Trial chests.");
            TooltipBuilder.SetTooltip(cFairyRewards, "Enable great fairy rewards being placed in the randomization pool.\n\nIncludes Magic Power, Great Spin Attack, Extended Magic Power, Double Defense, Great Fairy's Sword and Great Fairy's Mask.");
            TooltipBuilder.SetTooltip(cNutChest, "Enable randomization of the pre-clocktown deku nut chest. Not available when using Casual logic.");
            TooltipBuilder.SetTooltip(cCrazyStartingItems, "Enable randomization of starting Sword, Shield, and two Heart Containers.");
            TooltipBuilder.SetTooltip(cCowMilk, "Enable randomization of cow milk.\n\nOne inaccessible ranch cow is not included for Casual logic.");
            TooltipBuilder.SetTooltip(cSpiders, "Enable randomization of golden skulltula tokens. Tokens will not reset to 0 after Song of Time.");
            TooltipBuilder.SetTooltip(cStrayFairies, "Enable randomization of stray fairies. Stray fairies will not reset to 0 after Song of Time.");
            TooltipBuilder.SetTooltip(cMundaneRewards, "Enable randomization of mundane rewards. See Help > Manual (F1) > Shuffles for details.");

            // Gimmicks
            TooltipBuilder.SetTooltip(cDMult, "Select a damage mode, affecting how much damage Link takes:\n\n - Default: Link takes normal damage.\n - 2x: Link takes double damage.\n - 4x: Link takes quadruple damage.\n - 1-hit KO: Any damage kills Link.\n - Doom: Hardcore mode. Link's hearts are slowly being drained continuously.");
            TooltipBuilder.SetTooltip(cDType, "Select an effect to occur whenever Link is being damaged:\n\n - Default: Vanilla effects occur.\n - Fire: All damage burns Link.\n - Ice: All damage freezes Link.\n - Shock: All damage shocks link.\n - Knockdown: All damage knocks Link down.\n - Random: Any random effect of the above.");
            TooltipBuilder.SetTooltip(cGravity, "Select a movement modifier:\n\n - Default: No movement modifier.\n - High speed: Link moves at a much higher velocity.\n - Super low gravity: Link can jump very high.\n - Low gravity: Link can jump high.\n - High gravity: Link can barely jump.");
            TooltipBuilder.SetTooltip(cFloors, "Select a floortype for every floor ingame:\n\n - Default: Vanilla floortypes.\n - Sand: Link sinks slowly into every floor, affecting movement speed.\n - Ice: Every floor is slippery.\n - Snow: Similar to sand. \n - Random: Any random floortypes of the above.");
            TooltipBuilder.SetTooltip(cClockSpeed, "Modify the speed of time.");
            TooltipBuilder.SetTooltip(cHideClock, "Clock UI will be hidden.");
            TooltipBuilder.SetTooltip(cNoStartingItems, "You will not start with any randomized starting items.");
            TooltipBuilder.SetTooltip(cBlastCooldown, "Adjust the cooldown timer after using the Blast Mask.");
            TooltipBuilder.SetTooltip(cSunsSong, "Enable using the Sun's Song, which speeds up time to 400 units per frame (normal time speed is 3 units per frame) until dawn or dusk or a loading zone.");
            TooltipBuilder.SetTooltip(cUnderwaterOcarina, "Enable using the ocarina underwater.");

            // Comforts/cosmetics
            TooltipBuilder.SetTooltip(cCutsc, "Enable shortened cutscenes.\n\nCertain cutscenes are skipped or otherwise shortened.\nDISCLAIMER: This may cause crashing in certain emulators.");
            TooltipBuilder.SetTooltip(cQText, "Enable quick text. Dialogs are fast-forwarded to choices/end of dialog.");
            TooltipBuilder.SetTooltip(cSFX, "Randomize sound effects that are played throughout the game.");
            TooltipBuilder.SetTooltip(cMusic, "Select a music option\n\n - Default: Vanilla background music.\n - Random: Randomized background music.\n - None: No background music. Causes softlock on Frog Choir HP.");
            TooltipBuilder.SetTooltip(cFreeHints, "Enable reading gossip stone hints without requiring the Mask of Truth.");
            TooltipBuilder.SetTooltip(cClearHints, "Gossip stone hints will give clear item and location names.");
            TooltipBuilder.SetTooltip(cNoDowngrades, "Downgrading items will be prevented.");
            TooltipBuilder.SetTooltip(cShopAppearance, "Shops models and text will be updated to match the item they give.");
            TooltipBuilder.SetTooltip(cUpdateChests, "Chest appearance will be updated to match the item they contain.");
            TooltipBuilder.SetTooltip(cEponaSword, "Change Epona's B button behavior to prevent you from losing your sword if you don't have a bow.\nMay affect vanilla glitches that use Epona's B button.");
            TooltipBuilder.SetTooltip(cDrawHash, "Draw hash icons on the File Select screen.");
            TooltipBuilder.SetTooltip(cQuestItemStorage, "Enable Quest Item Storage, which allows for storing multiple quest items in their dedicated inventory slot.");
            TooltipBuilder.SetTooltip(cDisableCritWiggle, "Disable crit wiggle movement modification when 1 heart of health or less.");
            TooltipBuilder.SetTooltip(bTunic, "Select the color of Link's Tunic.");
            TooltipBuilder.SetTooltip(cLink, "Select a character model to replace Link's default model.");
            TooltipBuilder.SetTooltip(cTatl, "Select a color scheme to replace Tatl's default color scheme.");
            TooltipBuilder.SetTooltip(cGossipHints, "Select a Gossip Stone hint style\n\n - Default: Vanilla Gossip Stone hints.\n - Random: Hints will contain locations of random items.\n - Relevant: Hints will contain locations of items loosely related to the vanilla hint or the area.\n - Competitive: Guaranteed hints about time-consuming checks, 2 hints about locations with important items, 3 hints about locations with no important items.");
            TooltipBuilder.SetTooltip(cSkipBeaver, "Modify Beavers to not have to race the younger beaver.");
            TooltipBuilder.SetTooltip(cGoodDampeRNG, "Change Dampe ghost flames to always have two on the ground floor and one up the ladder.");
            TooltipBuilder.SetTooltip(cGoodDogRaceRNG, "Make Gold Dog always win if you have the Mask of Truth.");
            TooltipBuilder.SetTooltip(cFasterLabFish, "Change Lab Fish to only need to be fed one fish.");
            TooltipBuilder.SetTooltip(cFastPush, "Increase the speed of pushing and pulling blocks and faucets.");
        }

        /// <summary>
        /// Initialize components in the HUD <see cref="GroupBox"/>.
        /// </summary>
        void InitializeHUDGroupBox()
        {
            // Initialize ComboBox for hearts colors
            cHUDHeartsComboBox.Items.AddRange(ColorSelectionManager.Hearts.GetItems());
            cHUDHeartsComboBox.SelectedIndex = 0;

            // Initialize ComboBox for magic meter color
            cHUDMagicComboBox.Items.AddRange(ColorSelectionManager.MagicMeter.GetItems());
            cHUDMagicComboBox.SelectedIndex = 0;
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
            ToggleCheckBoxes();
            TogglePatchSettings(ttOutput.SelectedTab.TabIndex == 0);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TryRandomize(sender as BackgroundWorker, e);
        }

        private void bTunic_Click(object sender, EventArgs e)
        {
            _isUpdating = true;

            cTunic.ShowDialog();
            _configuration.CosmeticSettings.TunicColor = cTunic.Color;
            bTunic.BackColor = cTunic.Color;
            UpdateSettingsString();

            _isUpdating = false;
        }

        private void bopen_Click(object sender, EventArgs e)
        {
            openROM.ShowDialog();

            _configuration.OutputSettings.InputROMFilename = openROM.FileName;
            tROMName.Text = _configuration.OutputSettings.InputROMFilename;
        }

        private void bLoadLogic_Click(object sender, EventArgs e)
        {
            if(openLogic.ShowDialog() == DialogResult.OK)
            {
                _configuration.GameplaySettings.UserLogicFileName = openLogic.FileName;
                tbUserLogic.Text = Path.GetFileNameWithoutExtension(_configuration.GameplaySettings.UserLogicFileName);
            }
        }

        private void Randomize()
        {
            var validationResult = _configuration.GameplaySettings.Validate();
            if (validationResult != null)
            {
                MessageBox.Show(validationResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var defaultOutputROMFilename = FileUtils.MakeFilenameValid(DateTime.UtcNow.ToString("o"));

            saveROM.FileName = !string.IsNullOrWhiteSpace(_configuration.OutputSettings.InputPatchFilename)
                ? Path.ChangeExtension(Path.GetFileName(_configuration.OutputSettings.InputPatchFilename), "z64")
                : defaultOutputROMFilename;
            if (saveROM.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _configuration.OutputSettings.OutputROMFilename = saveROM.FileName;

            EnableAllControls(false);
            bgWorker.RunWorkerAsync();
        }

        private void bRandomise_Click(object sender, EventArgs e)
        {
            Randomize();
        }

        private void bApplyPatch_Click(object sender, EventArgs e)
        {
            Randomize();
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
                _configuration.GameplaySettings.Update(tSString.Text);
                UpdateCheckboxes();
                ToggleCheckBoxes();
                tSString.Text = _configuration.GameplaySettings.ToString();
            }
            catch
            {
                tSString.Text = _oldSettingsString;
                _configuration.GameplaySettings.Update(_oldSettingsString);
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

        public void UpdateSettingString()
        {
            try
            {
                //_configuration.GameplaySettings.Update(tSString.Text);
                UpdateCheckboxes();
                ToggleCheckBoxes();
                tSString.Text = _configuration.GameplaySettings.ToString();
                tROMName.Text = _configuration.OutputSettings.InputROMFilename;
            }
            catch
            {
                tSString.Text = _oldSettingsString;
                _configuration.GameplaySettings.Update(_oldSettingsString);
                UpdateCheckboxes();
                ToggleCheckBoxes();
                MessageBox.Show("There was an issue updating your setting string. Returning to old Setting String.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCheckboxes()
        {
            cSpoiler.Checked = _configuration.OutputSettings.GenerateSpoilerLog;
            cHTMLLog.Checked = _configuration.OutputSettings.GenerateHTMLLog;
            cN64.Checked = _configuration.OutputSettings.GenerateROM;
            cVC.Checked = _configuration.OutputSettings.OutputVC;
            cPatch.Checked = _configuration.OutputSettings.GeneratePatch;

            cUserItems.Checked = _configuration.GameplaySettings.UseCustomItemList;
            cAdditional.Checked = _configuration.GameplaySettings.AddOther;
            cSoS.Checked = _configuration.GameplaySettings.ExcludeSongOfSoaring;
            cMixSongs.Checked = _configuration.GameplaySettings.AddSongs;
            cBottled.Checked = _configuration.GameplaySettings.RandomizeBottleCatchContents;
            cDChests.Checked = _configuration.GameplaySettings.AddDungeonItems;
            cShop.Checked = _configuration.GameplaySettings.AddShopItems;
            cDEnt.Checked = _configuration.GameplaySettings.RandomizeDungeonEntrances;
            cSFX.Checked = _configuration.CosmeticSettings.RandomizeSounds;
            cEnemy.Checked = _configuration.GameplaySettings.RandomizeEnemies;
            cCutsc.Checked = _configuration.GameplaySettings.ShortenCutscenes;
            cQText.Checked = _configuration.GameplaySettings.QuickTextEnabled;
            cFreeHints.Checked = _configuration.GameplaySettings.FreeHints;
            cMoonItems.Checked = _configuration.GameplaySettings.AddMoonItems;
            cFairyRewards.Checked = _configuration.GameplaySettings.AddFairyRewards;
            cClearHints.Checked = _configuration.GameplaySettings.ClearHints;
            cHideClock.Checked = _configuration.GameplaySettings.HideClock;
            cSunsSong.Checked = _configuration.GameplaySettings.EnableSunsSong;
            cClockSpeed.SelectedIndex = (int)_configuration.GameplaySettings.ClockSpeed;
            cNoDowngrades.Checked = _configuration.GameplaySettings.PreventDowngrades;
            cShopAppearance.Checked = _configuration.GameplaySettings.UpdateShopAppearance;
            cNutChest.Checked = _configuration.GameplaySettings.AddNutChest;
            cCrazyStartingItems.Checked = _configuration.GameplaySettings.CrazyStartingItems;
            cCowMilk.Checked = _configuration.GameplaySettings.AddCowMilk;
            cSpiders.Checked = _configuration.GameplaySettings.AddSkulltulaTokens;
            cMundaneRewards.Checked = _configuration.GameplaySettings.AddMundaneRewards;
            cStrayFairies.Checked = _configuration.GameplaySettings.AddStrayFairies;
            cNoStartingItems.Checked = _configuration.GameplaySettings.NoStartingItems;
            cEponaSword.Checked = _configuration.GameplaySettings.FixEponaSword;
            cUpdateChests.Checked = _configuration.GameplaySettings.UpdateChests;
            cSkipBeaver.Checked = _configuration.GameplaySettings.SpeedupBeavers;
            cGoodDampeRNG.Checked = _configuration.GameplaySettings.SpeedupDampe;
            cGoodDogRaceRNG.Checked = _configuration.GameplaySettings.SpeedupDogRace;
            cFasterLabFish.Checked = _configuration.GameplaySettings.SpeedupLabFish;

            cDMult.SelectedIndex = (int)_configuration.GameplaySettings.DamageMode;
            cDType.SelectedIndex = (int)_configuration.GameplaySettings.DamageEffect;
            cMode.SelectedIndex = (int)_configuration.GameplaySettings.LogicMode;
            cLink.SelectedIndex = (int)_configuration.GameplaySettings.Character;
            cTatl.SelectedIndex = (int)_configuration.CosmeticSettings.TatlColorSchema;
            cGravity.SelectedIndex = (int)_configuration.GameplaySettings.MovementMode;
            cFloors.SelectedIndex = (int)_configuration.GameplaySettings.FloorType;
            cGossipHints.SelectedIndex = (int)_configuration.GameplaySettings.GossipHintStyle;
            cBlastCooldown.SelectedIndex = (int)_configuration.GameplaySettings.BlastMaskCooldown;
            cMusic.SelectedIndex = (int)_configuration.CosmeticSettings.Music;
            bTunic.BackColor = _configuration.CosmeticSettings.TunicColor;

            // Misc config options
            CritWiggleState critWiggle = _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.CritWiggle;
            cDisableCritWiggle.Checked = critWiggle == CritWiggleState.AlwaysOff ? true : false;
            cDrawHash.Checked = _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.DrawHash;
            cFastPush.Checked = _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.FastPush;
            cQuestItemStorage.Checked = _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.QuestItemStorage;
            cUnderwaterOcarina.Checked = _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.OcarinaUnderwater;

            // HUD config options
            cHUDHeartsComboBox.SelectedIndex = Array.FindIndex(ColorSelectionManager.Hearts.GetItems(), csi => csi.Name == _configuration.CosmeticSettings.HeartsSelection);
            cHUDMagicComboBox.SelectedIndex = Array.FindIndex(ColorSelectionManager.MagicMeter.GetItems(), csi => csi.Name == _configuration.CosmeticSettings.MagicSelection);
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

            cDChests.Visible = !cUserItems.Checked;

            cShop.Visible = !cUserItems.Checked;

            cBottled.Visible = !cUserItems.Checked;

            cSoS.Visible = !cUserItems.Checked;

            cAdditional.Visible = !cUserItems.Checked;

            cMoonItems.Visible = !cUserItems.Checked;

            cFairyRewards.Visible = !cUserItems.Checked;

            cNutChest.Visible = !cUserItems.Checked;

            cCrazyStartingItems.Visible = !cUserItems.Checked;

            cCowMilk.Visible = !cUserItems.Checked;

            cSpiders.Visible = !cUserItems.Checked;

            cMundaneRewards.Visible = !cUserItems.Checked;

            cStrayFairies.Visible = !cUserItems.Checked;

            bItemListEditor.Visible = cUserItems.Checked;
            tCustomItemList.Visible = cUserItems.Checked;
            lCustomItemAmount.Visible = cUserItems.Checked;

            UpdateSingleSetting(() => _configuration.GameplaySettings.UseCustomItemList = cUserItems.Checked);

        }

        private void cN64_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.OutputSettings.GenerateROM = cN64.Checked);
        }

        private void cSpoiler_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.OutputSettings.GenerateSpoilerLog = cSpoiler.Checked);
            UpdateSingleSetting(() => cHTMLLog.Enabled = cSpoiler.Checked);

            if (cHTMLLog.Checked)
            {
                cHTMLLog.Checked = false;
                UpdateSingleSetting(() => _configuration.OutputSettings.GenerateHTMLLog = false);
            }

        }

        private void cPatch_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.OutputSettings.GeneratePatch = cPatch.Checked);
        }

        private void cHTMLLog_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.OutputSettings.GenerateHTMLLog = cHTMLLog.Checked);
        }


        private void cAdditional_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddOther = cAdditional.Checked);
        }

        private void cMoonItems_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddMoonItems = cMoonItems.Checked);
        }

        private void cFairyRewards_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddFairyRewards = cFairyRewards.Checked);
        }

        private void cNutChest_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddNutChest = cNutChest.Checked);
        }

        private void cCrazyStartingItems_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.CrazyStartingItems = cCrazyStartingItems.Checked);
        }

        private void cCowMilk_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddCowMilk = cCowMilk.Checked);
        }

        private void cSpiders_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddSkulltulaTokens = cSpiders.Checked);
        }

        private void cMundaneRewards_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddMundaneRewards = cMundaneRewards.Checked);
        }

        private void cStrayFairies_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddStrayFairies = cStrayFairies.Checked);
        }

        private void cSFX_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.CosmeticSettings.RandomizeSounds = cSFX.Checked);
        }

        private void cMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.CosmeticSettings.Music = (Music)cMusic.SelectedIndex);
        }

        private void cBottled_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.RandomizeBottleCatchContents = cBottled.Checked);
        }

        private void cCutsc_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.ShortenCutscenes = cCutsc.Checked);
        }

        private void cDChests_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddDungeonItems = cDChests.Checked);
        }

        private void cDEnt_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.RandomizeDungeonEntrances = cDEnt.Checked);
        }

        private void cDMult_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.DamageMode = (DamageMode)cDMult.SelectedIndex);
        }

        private void cDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.DamageEffect = (DamageEffect)cDType.SelectedIndex);
        }

        private void cEnemy_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.RandomizeEnemies = cEnemy.Checked);
        }

        private void cFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.FloorType = (FloorType)cFloors.SelectedIndex);
        }

        private void cGravity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.MovementMode = (MovementMode)cGravity.SelectedIndex);
        }

        private void cLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.Character = (Character)cLink.SelectedIndex);
        }

        private void cMixSongs_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddSongs = cMixSongs.Checked);
        }

        private void cFreeHints_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.FreeHints = cFreeHints.Checked);
        }

        private void cClearHints_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.ClearHints = cClearHints.Checked);
        }

        private void cNoDowngrades_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.PreventDowngrades = cNoDowngrades.Checked);
        }

        private void cShopAppearance_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.UpdateShopAppearance = cShopAppearance.Checked);
        }

        private void cUpdateChests_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.UpdateChests = cUpdateChests.Checked);
        }

        private void cEponaSword_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.FixEponaSword = cEponaSword.Checked);
        }

        private void cHideClock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.HideClock = cHideClock.Checked);
        }

        private void cSunsSong_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.EnableSunsSong = cSunsSong.Checked);
        }

        private void cNoStartingItems_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.NoStartingItems = cNoStartingItems.Checked);
        }

        private void cQText_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.QuickTextEnabled = cQText.Checked);
        }

        private void cShop_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AddShopItems = cShop.Checked);
        }

        private void cSoS_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.ExcludeSongOfSoaring = cSoS.Checked);
        }

        private void cTatl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.CosmeticSettings.TatlColorSchema = (TatlColorSchema)cTatl.SelectedIndex);
        }

        private void cSkipBeaver_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.SpeedupBeavers = cSkipBeaver.Checked);
        }

        private void cGoodDampeRNG_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.SpeedupDampe = cGoodDampeRNG.Checked);
        }

        private void cGoodDogRaceRNG_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.SpeedupDogRace = cGoodDogRaceRNG.Checked);
        }

        private void cFasterLabFish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.SpeedupLabFish = cFasterLabFish.Checked);
        }

        private void cDrawHash_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.DrawHash = cDrawHash.Checked);
        }

        private void cQuestItemStorage_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.QuestItemStorage = cQuestItemStorage.Checked);
        }

        private void cDisableCritWiggle_CheckedChanged(object sender, EventArgs e)
        {
            var state = cDisableCritWiggle.Checked ? CritWiggleState.AlwaysOff : CritWiggleState.Default;
            UpdateSingleSetting(() => _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.CritWiggle = state);
        }

        private void cFastPush_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.FastPush = cFastPush.Checked);
        }

        private void cUnderwaterOcarina_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.AsmOptions.MiscConfig.Flags.OcarinaUnderwater = cUnderwaterOcarina.Checked);
        }

        private void cMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_isUpdating)
            {
                return;
            }

            var logicMode = (LogicMode)cMode.SelectedIndex;

            if (logicMode == LogicMode.UserLogic)
            {
                tbUserLogic.Enabled = true;
                bLoadLogic.Enabled = true;
            }
            else
            {
                tbUserLogic.Enabled = false;
                bLoadLogic.Enabled = false;
            }

            UpdateSingleSetting(() => _configuration.GameplaySettings.LogicMode = logicMode);
        }

        private void cClockSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.ClockSpeed = (ClockSpeed)cClockSpeed.SelectedIndex);
        }

        private void cGossipHints_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.GossipHintStyle = (GossipHintStyle)cGossipHints.SelectedIndex);
        }


        private void cBlastCooldown_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.GameplaySettings.BlastMaskCooldown = (BlastMaskCooldown)cBlastCooldown.SelectedIndex);
        }

        private void cVC_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSingleSetting(() => _configuration.OutputSettings.OutputVC = cVC.Checked);
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SaveAndClose();
        }

        private void SaveAndClose()
        {
            SaveSettings();
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

        private void mLogicEdit_Click(object sender, EventArgs e)
        {
            LogicEditor.Show();
        }

        private void bItemListEditor_Click(object sender, EventArgs e)
        {
            if (ItemEditor.ShowDialog() == DialogResult.Cancel)
            {
                tCustomItemList.Text = ItemEditor.CustomItemListString;
            }
        }

        private void tCustomItemList_TextChanged(object sender, EventArgs e)
        {
            ItemEditor.UpdateChecks(tCustomItemList.Text);
            UpdateCustomItemAmountLabel();
        }

        private void UpdateCustomItemAmountLabel()
        {
            _configuration.GameplaySettings.CustomItemList = ItemEditor.CustomItemList.ToList();
            _configuration.GameplaySettings.CustomItemListString = ItemEditor.CustomItemListString;
            if (_configuration.GameplaySettings.CustomItemList.Contains(-1))
            {
                lCustomItemAmount.Text = "Invalid custom item string";
            }
            else
            {
                lCustomItemAmount.Text = $"{_configuration.GameplaySettings.CustomItemList.Count}/{ItemUtils.AllLocations().Count()} items randomized";
            }
        }

        private void bStartingItemEditor_Click(object sender, EventArgs e)
        {
            if (StartingItemEditor.ShowDialog() == DialogResult.Cancel)
            {
                tStartingItemList.Text = StartingItemEditor.CustomStartingItemListString;
            }
        }

        private void tStartingItemList_TextChanged(object sender, EventArgs e)
        {
            StartingItemEditor.UpdateChecks(tStartingItemList.Text);
            UpdateCustomStartingItemAmountLabel();
        }

        private void UpdateCustomStartingItemAmountLabel()
        {
            _configuration.GameplaySettings.CustomStartingItemList = StartingItemEditor.CustomStartingItemList.ToList();
            _configuration.GameplaySettings.CustomStartingItemListString = StartingItemEditor.CustomStartingItemListString;
            lCustomStartingItemAmount.Text = StartingItemEditor.ExternalLabel;
        }

        private void bJunkLocationsEditor_Click(object sender, EventArgs e)
        {
            if (JunkLocationEditor.ShowDialog() == DialogResult.Cancel)
            {
                tJunkLocationsList.Text = JunkLocationEditor.CustomJunkLocationsString;
            }
        }

        private void tJunkLocationsList_TextChanged(object sender, EventArgs e)
        {
            JunkLocationEditor.UpdateChecks(tJunkLocationsList.Text);
            UpdateJunkLocationAmountLabel();
        }

        private void UpdateJunkLocationAmountLabel()
        {
            _configuration.GameplaySettings.CustomJunkLocations = JunkLocationEditor.CustomJunkLocations.ToList();
            _configuration.GameplaySettings.CustomJunkLocationsString = JunkLocationEditor.CustomJunkLocationsString;
            lJunkLocationsAmount.Text = JunkLocationEditor.ExternalLabel;
        }



        /// <summary>
        /// Checks for settings that invalidate others, and disable the checkboxes for them.
        /// </summary>
        private void ToggleCheckBoxes()
        {
            var onMainTab = ttOutput.SelectedTab.TabIndex == 0;

            if (_configuration.GameplaySettings.LogicMode == LogicMode.Vanilla)
            {
                cMixSongs.Enabled = false;
                cSoS.Enabled = false;
                cDChests.Enabled = false;
                cDEnt.Enabled = false;
                cBottled.Enabled = false;
                cShop.Enabled = false;
                cSpoiler.Enabled = false;
                cGossipHints.Enabled = false;
                cAdditional.Enabled = false;
                cUserItems.Enabled = false;
                cMoonItems.Enabled = false;
                cFairyRewards.Enabled = false;
                cNutChest.Enabled = false;
                cCrazyStartingItems.Enabled = false;
                cNoStartingItems.Enabled = false;
                cCowMilk.Enabled = false;
                cSpiders.Enabled = false;
                cStrayFairies.Enabled = false;
                cMundaneRewards.Enabled = false;

                tJunkLocationsList.Enabled = false;
                bJunkLocationsEditor.Enabled = false;
            }
            else
            {
                cMixSongs.Enabled = onMainTab;
                cDEnt.Enabled = onMainTab;
                cSpoiler.Enabled = onMainTab;
                cGossipHints.Enabled = onMainTab;
                cUserItems.Enabled = onMainTab;

                cSoS.Enabled = onMainTab;
                cDChests.Enabled = onMainTab;
                cBottled.Enabled = onMainTab;
                cShop.Enabled = onMainTab;
                cAdditional.Enabled = onMainTab;
                cMoonItems.Enabled = onMainTab;
                cFairyRewards.Enabled = onMainTab;
                cNutChest.Enabled = onMainTab && _configuration.GameplaySettings.LogicMode != LogicMode.Casual;
                cCrazyStartingItems.Enabled = onMainTab;
                cCowMilk.Enabled = onMainTab;
                cSpiders.Enabled = onMainTab;
                cStrayFairies.Enabled = onMainTab;
                cMundaneRewards.Enabled = onMainTab;

                tCustomItemList.Enabled = onMainTab;
                bItemListEditor.Enabled = onMainTab;

                tStartingItemList.Enabled = onMainTab;
                bStartingItemEditor.Enabled = onMainTab;

                tJunkLocationsList.Enabled = onMainTab && _configuration.GameplaySettings.LogicMode != LogicMode.NoLogic;
                bJunkLocationsEditor.Enabled = onMainTab && _configuration.GameplaySettings.LogicMode != LogicMode.NoLogic;

                cNoStartingItems.Enabled = onMainTab && (_configuration.GameplaySettings.AddOther || _configuration.GameplaySettings.UseCustomItemList);
                if (!cNoStartingItems.Enabled && onMainTab)
                {
                    cNoStartingItems.Checked = false;
                    _configuration.GameplaySettings.NoStartingItems = false;
                }
            }

            cHTMLLog.Enabled = onMainTab && _configuration.OutputSettings.GenerateSpoilerLog;

            if (_configuration.GameplaySettings.GossipHintStyle == GossipHintStyle.Default || _configuration.GameplaySettings.LogicMode == LogicMode.Vanilla)
            {
                cClearHints.Enabled = false;
            }
            else
            {
                cClearHints.Enabled = onMainTab;
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
            ToggleCheckBoxes();

            _isUpdating = false;
        }

        private void UpdateSettingsString()
        {
            tSString.Text = _configuration.GameplaySettings.ToString();
        }

        private void EnableAllControls(bool v)
        {
            cAdditional.Enabled = v;
            cSFX.Enabled = v;
            cMusic.Enabled = v;
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
            cClockSpeed.Enabled = v;
            cGossipHints.Enabled = v;
            cBlastCooldown.Enabled = v;
            cHideClock.Enabled = v;
            cSunsSong.Enabled = v;
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
            cFreeHints.Enabled = v;
            cClearHints.Enabled = v;
            cNoDowngrades.Enabled = v;
            cShopAppearance.Enabled = v;
            cEponaSword.Enabled = v;
            cHTMLLog.Enabled = v;
            cN64.Enabled = v;
            cMoonItems.Enabled = v;
            cFairyRewards.Enabled = v;
            cNutChest.Enabled = v;
            cCrazyStartingItems.Enabled = v;
            cNoStartingItems.Enabled = v;
            cCowMilk.Enabled = v;
            cSpiders.Enabled = v;
            cStrayFairies.Enabled = v;
            cMundaneRewards.Enabled = v;
            cPatch.Enabled = v;
            bApplyPatch.Enabled = v;
            cUpdateChests.Enabled = v;
            tStartingItemList.Enabled = v;
            bStartingItemEditor.Enabled = v;
            cSkipBeaver.Enabled = v;
            cGoodDampeRNG.Enabled = v;
            cGoodDogRaceRNG.Enabled = v;
            cFasterLabFish.Enabled = v;

            cDrawHash.Enabled = v;
            cQuestItemStorage.Enabled = v;
            cDisableCritWiggle.Enabled = v;
            cFastPush.Enabled = v;
            cUnderwaterOcarina.Enabled = v;

            bopen.Enabled = v;
            bRandomise.Enabled = v;
            bTunic.Enabled = v;

            tSeed.Enabled = v;
            tSString.Enabled = v;
        }

        private void mDPadConfig_Click(object sender, EventArgs e)
        {
            var items = DPadItem.All();
            var presets = DPadPreset.All();
            var config = _configuration.CosmeticSettings.AsmOptions.DPadConfig;

            DPadForm form = new DPadForm(presets, items, config);
            if (form.ShowDialog() == DialogResult.OK)
            {
                config.State = form.State;
                config.Pad = form.Selected;
                config.Display = form.Display;
            }
        }

        #endregion

        #region Settings

        public void InitializeSettings()
        {
            _configuration = new Configuration
            {
                OutputSettings = new OutputSettings(),
                GameplaySettings = new GameplaySettings(),
                CosmeticSettings = new CosmeticSettings(),
            };

            cDMult.SelectedIndex = 0;
            cDType.SelectedIndex = 0;
            cGravity.SelectedIndex = 0;
            cFloors.SelectedIndex = 0;
            cMode.SelectedIndex = 0;
            cLink.SelectedIndex = 0;
            cTatl.SelectedIndex = 0;
            cGossipHints.SelectedIndex = 0;
            cClockSpeed.SelectedIndex = 0;
            cBlastCooldown.SelectedIndex = 0;
            cMusic.SelectedIndex = 0;
            cSpoiler.Checked = true;
            cHTMLLog.Checked = true;
            cSoS.Checked = true;
            cNoDowngrades.Checked = true;
            cShopAppearance.Checked = true;
            cEponaSword.Checked = true;
            cCutsc.Checked = true;
            cQText.Checked = true;
            cUpdateChests.Checked = true;
            cAdditional.Checked = true;
            cNoStartingItems.Checked = true;

            cDrawHash.Checked = true;
            cQuestItemStorage.Checked = true;
            cFastPush.Checked = true;

            bTunic.BackColor = Color.FromArgb(0x1E, 0x69, 0x1B);

            _configuration.OutputSettings.GenerateROM = true;
            _configuration.OutputSettings.GenerateSpoilerLog = true;
            _configuration.GameplaySettings.ExcludeSongOfSoaring = true;
            _configuration.GameplaySettings.PreventDowngrades = true;
            _configuration.GameplaySettings.UpdateShopAppearance = true;
            _configuration.GameplaySettings.FixEponaSword = true;
            _configuration.GameplaySettings.ShortenCutscenes = true;
            _configuration.GameplaySettings.QuickTextEnabled = true;
            _configuration.GameplaySettings.UpdateChests = true;
            _configuration.GameplaySettings.AddOther = true;
            _configuration.GameplaySettings.NoStartingItems = true;
            _configuration.CosmeticSettings.TunicColor = bTunic.BackColor;

            tSeed.Text = Math.Abs(Environment.TickCount).ToString();

            tbUserLogic.Enabled = false;
            bLoadLogic.Enabled = false;

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
            var seed = Convert.ToInt32(tSeed.Text);
            var result = ConfigurationProcessor.Process(_configuration, seed, new BackgroundWorkerProgressReporter(worker));
            if (result != null)
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _configuration.OutputSettings.InputPatchFilename = null;

            MessageBox.Show("Generation complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private bool ValidateSettingsFile(String[] lines)
        {
            return lines.Length > 0 && (lines[0].Equals("#MMR Settings File [" + AssemblyVersion + "]") || lines[0].Equals("#MMR Settings File [dev]"));
        }

        private bool CheckLogicFileExists()
        {
            if (_configuration.GameplaySettings.LogicMode == LogicMode.UserLogic && !File.Exists(_configuration.GameplaySettings.UserLogicFileName))
            {
                MessageBox.Show("User Logic not found or invalid, please load User Logic or change logic mode.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        private void BLoadPatch_Click(object sender, EventArgs e)
        {
            openPatch.ShowDialog();
            _configuration.OutputSettings.InputPatchFilename = openPatch.FileName;
            tPatch.Text = _configuration.OutputSettings.InputPatchFilename;
        }

        private void ttOutput_Changed(object sender, EventArgs e)
        {
            ToggleCheckBoxes();

            TogglePatchSettings(ttOutput.SelectedTab.TabIndex == 0);
        }


        private void TogglePatchSettings(bool v)
        {
            // ROM Settings
            cPatch.Enabled = v;

            // Main Settings
            cMode.Enabled = v;
            cEnemy.Enabled = v;

            //Gimmicks
            cDMult.Enabled = v;
            cDType.Enabled = v;
            cGravity.Enabled = v;
            cFloors.Enabled = v;
            cClockSpeed.Enabled = v;
            cHideClock.Enabled = v;
            cSunsSong.Enabled = v;
            cBlastCooldown.Enabled = v;
            cUnderwaterOcarina.Enabled = v;


            // Comfort/Cosmetics
            cCutsc.Enabled = v;
            cQText.Enabled = v;
            cFreeHints.Enabled = v;
            cNoDowngrades.Enabled = v;
            cShopAppearance.Enabled = v;
            cUpdateChests.Enabled = v;
            cEponaSword.Enabled = v;
            cClearHints.Enabled = _configuration.GameplaySettings.LogicMode != LogicMode.Vanilla && _configuration.GameplaySettings.GossipHintStyle != GossipHintStyle.Default && v;
            cGossipHints.Enabled = _configuration.GameplaySettings.LogicMode != LogicMode.Vanilla && v;
            cDisableCritWiggle.Enabled = v;
            cDrawHash.Enabled = v;
            cQuestItemStorage.Enabled = v;

            cSkipBeaver.Enabled = v;
            cGoodDampeRNG.Enabled = v;
            cGoodDogRaceRNG.Enabled = v;
            cFasterLabFish.Enabled = v;
            cFastPush.Enabled = v;

            cLink.Enabled = v;

            // Other..?
            cDummy.Enabled = v;

            _configuration.OutputSettings.InputPatchFilename = v ? null : string.Empty;
            tPatch.Text = v ? null : string.Empty;
        }

        private const string DEFAULT_SETTINGS_FILENAME = "settings";
        private void SaveSettings(string filename = null)
        {
            var path = Path.ChangeExtension(filename ?? DEFAULT_SETTINGS_FILENAME, SETTINGS_EXTENSION);
            string logicFilePath = null;
            string inputROMFilename = null;
            if (filename != null)
            {
                logicFilePath = _configuration.GameplaySettings.UserLogicFileName;
                _configuration.GameplaySettings.UserLogicFileName = null;
                inputROMFilename = _configuration.OutputSettings.InputROMFilename;
                _configuration.OutputSettings.InputROMFilename = null;
                if (_configuration.GameplaySettings.LogicMode == LogicMode.UserLogic && logicFilePath != null && File.Exists(logicFilePath))
                {
                    using (StreamReader Req = new StreamReader(File.Open(logicFilePath, FileMode.Open)))
                    {
                        _configuration.Logic = Req.ReadToEnd();
                        if (_configuration.Logic.StartsWith("{"))
                        {
                            var logicConfiguration = Configuration.FromJson(_configuration.Logic);
                            _configuration.Logic = logicConfiguration.Logic;
                        }
                    }
                }
            }
            using (var settingsFile = new StreamWriter(File.Open(path, FileMode.Create)))
            {
                settingsFile.Write(_configuration.ToString());
            }
            if (logicFilePath != null)
            {
                _configuration.GameplaySettings.UserLogicFileName = logicFilePath;
                _configuration.Logic = null;
            }
            if (inputROMFilename != null)
            {
                _configuration.OutputSettings.InputROMFilename = inputROMFilename;
            }
        }
        
        private void LoadSettings(string filename = null)
        {
            var path = Path.ChangeExtension(filename ?? DEFAULT_SETTINGS_FILENAME, SETTINGS_EXTENSION);
            if (File.Exists(path))
            {
                using (StreamReader Req = new StreamReader(File.Open(path, FileMode.Open)))
                {
                    _configuration = Configuration.FromJson(Req.ReadToEnd());
                }

                tCustomItemList.Text = _configuration.GameplaySettings.CustomItemListString;
                ItemEditor.UpdateChecks(tCustomItemList.Text);

                tStartingItemList.Text = _configuration.GameplaySettings.CustomStartingItemListString;
                StartingItemEditor.UpdateChecks(tStartingItemList.Text);

                tJunkLocationsList.Text = _configuration.GameplaySettings.CustomJunkLocationsString;
                JunkLocationEditor.UpdateChecks(tJunkLocationsList.Text);

                if (_configuration.Logic != null)
                {
                    _configuration.GameplaySettings.UserLogicFileName = path;
                    _configuration.Logic = null;
                }
                if (File.Exists(_configuration.GameplaySettings.UserLogicFileName))
                {
                    tbUserLogic.Text = Path.GetFileNameWithoutExtension(_configuration.GameplaySettings.UserLogicFileName);
                }
                else
                {
                    _configuration.GameplaySettings.UserLogicFileName = string.Empty;
                }

                HudConfig.Update(_configuration.CosmeticSettings.AsmOptions.HudColorsConfig.Colors);

                UpdateJunkLocationAmountLabel();
                UpdateCustomStartingItemAmountLabel();
                UpdateCustomItemAmountLabel();
                UpdateSettingString();
            }
        }

        private void SaveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_configuration.GameplaySettings.LogicMode != LogicMode.UserLogic || (_configuration.GameplaySettings.LogicMode == LogicMode.UserLogic && CheckLogicFileExists()))
            {
                if (saveSettings.ShowDialog() == DialogResult.OK)
                {
                    SaveSettings(saveSettings.FileName);
                }
            }
        }

        private void LoadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSettings.Filter = "Config Files|*.cfg";
            if (loadSettings.ShowDialog() == DialogResult.OK)
            {
                LoadSettings(loadSettings.FileName);
            }
        }

        private void btn_hud_Click(object sender, EventArgs e)
        {
            var config = _configuration.CosmeticSettings.AsmOptions.HudColorsConfig;
            if (HudConfig.ShowDialog(this, config) == DialogResult.Cancel)
            {
                var colors = HudConfig.ToColors();
                config.Colors = colors;
            }
        }

        private void cHUDHeartsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combobox = (ComboBox)sender;
            var selected = (ColorSelectionItem)combobox.SelectedItem;
            _configuration.CosmeticSettings.HeartsSelection = selected.Name;
        }

        private void cHUDMagicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combobox = (ComboBox)sender;
            var selected = (ColorSelectionItem)combobox.SelectedItem;
            _configuration.CosmeticSettings.MagicSelection = selected.Name;
        }
    }
}
