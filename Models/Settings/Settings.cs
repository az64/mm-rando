
using MMRando.Utils;
using System.Collections.Generic;
using System.Drawing;

namespace MMRando.Models
{

    public class Settings
    {
        // TODO make base36-string from settings
        // TODO make settings from base36-string

        // General

        /// <summary>
        ///  Outputs n64 rom if true (default: true)
        /// </summary>
        public bool GenerateROM { get; set; } = true;

        /// <summary>
        ///  Outputs virtual channel if true
        /// </summary>
        public bool OutputVC { get; set; }

        /// <summary>
        /// Filepath to the input ROM
        /// </summary>
        public string InputROMFilename { get; set; }

        /// <summary>
        /// Filepath to the input logic file
        /// </summary>
        public string UserLogicFileName { get; set; }

        /// <summary>
        /// Default Filename for the output ROM
        /// </summary>
        public string DefaultOutputROMFilename { get; set; }

        /// <summary>
        /// Filepath to the output ROM
        /// </summary>
        public string OutputROMFilename { get; set; }

        /// <summary>
        /// Generate spoiler log on randomizing
        /// </summary>
        public bool GenerateSpoilerLog { get; set; }

        /// <summary>
        /// Generate HTML spoiler log on randomizing
        /// </summary>
        public bool GenerateHTMLLog { get; set; }

        /// <summary>
        /// Generate spoiler log only on randomizing
        /// </summary>
        public bool LogOnly { get; set; }

        /// <summary>
        /// Use Custom Item list for the logic.
        /// </summary>
        public bool UseCustomItemList { get; set; }


        // Random Elements

        private int _seed;

        /// <summary>
        /// The randomizer seed
        /// </summary>
        public int Seed {
            get => _seed;
            set {
                _seed = value;
                UpdateOutputFilenames();
            }
        }

        /// <summary>
        /// Selected mode of logic (affects randomization rules)
        /// </summary>
        public LogicMode LogicMode { get; set; }

        /// <summary>
        /// Add songs to the randomization pool
        /// </summary>
        public bool AddSongs { get; set; }

        /// <summary>
        /// (KeySanity) Add dungeon items (maps, compasses, keys) to the randomization pool
        /// </summary>
        public bool AddDungeonItems { get; set; }

        /// <summary>
        /// Add shop items to the randomization pool
        /// </summary>
        public bool AddShopItems { get; set; }

        /// <summary>
        /// Add everything else to the randomization pool
        /// </summary>
        public bool AddOther { get; set; }

        /// <summary>
        /// Randomize the content of a bottle when catching (e.g. catching a fairy puts poe in bottle)
        /// </summary>
        public bool RandomizeBottleCatchContents { get; set; }

        /// <summary>
        /// Exclude song of soaring from randomization (it will be found in vanilla location)
        /// </summary>
        public bool ExcludeSongOfSoaring { get; set; }

        /// <summary>
        /// Gossip stones give hints on where to find items, and sometimes junk
        /// </summary>
        public bool EnableGossipHints { get; set; }

        /// <summary>
        /// Randomize which dungeon you appear in when entering one
        /// </summary>
        public bool RandomizeDungeonEntrances { get; set; }

        /// <summary>
        /// (Beta) Randomize enemies
        /// </summary>
        public bool RandomizeEnemies { get; set; }

        /// <summary>
        /// Randomize background music (includes bgm from other video games)
        /// </summary>
        public bool RandomizeBGM { get; set; }

        /// <summary>
        /// FrEe HiNtS FoR WeNiEs
        /// </summary>
        public bool FreeHints { get; set; }



        // Gimmicks

        /// <summary>
        /// Modifies the damage value when Link is damaged
        /// </summary>
        public DamageMode DamageMode { get; set; }

        /// <summary>
        /// Adds an additional effect when Link is damaged
        /// </summary>
        public DamageEffect DamageEffect { get; set; }

        /// <summary>
        /// Modifies Link's movement
        /// </summary>
        public MovementMode MovementMode { get; set; }

        /// <summary>
        /// Sets the type of floor globally
        /// </summary>
        public FloorType FloorType { get; set; }

        // Comfort / Cosmetics

        /// <summary>
        /// Certain cutscenes will play shorter, or will be skipped
        /// </summary>
        public bool ShortenCutscenes { get; set; }

        /// <summary>
        /// Text is fast-forwarded
        /// </summary>
        public bool QuickTextEnabled { get; set; }

        /// <summary>
        /// The color of Link's tunic
        /// </summary>
        public Color TunicColor { get; set; }

        /// <summary>
        /// Replaces Link's default model
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// Replaces Tatl's colors
        /// </summary>
        public TatlColorSchema TatlColorSchema { get; set; }


        /// <summary>
        ///  Custom item list selections
        /// </summary>
        public List<int> CustomItemList { get; set; } = new List<int>();

        // Functions

        public void Update(string settings)
        {
            var bits = settings.Split('-');
            int checks = (int)Base36Utils.Decode(bits[0]);
            int combos = (int)Base36Utils.Decode(bits[1]);
            int colourAndMisc = (int)Base36Utils.Decode(bits[2]);

            FreeHints = (checks & 16384) > 0;
            UseCustomItemList = (checks & 8192) > 0;
            AddOther = (checks & 4096) > 0;
            EnableGossipHints = (checks & 2048) > 0;
            ExcludeSongOfSoaring = (checks & 1024) > 0;
            GenerateSpoilerLog = (checks & 512) > 0;
            AddSongs = (checks & 256) > 0;
            RandomizeBottleCatchContents = (checks & 128) > 0;
            AddDungeonItems = (checks & 64) > 0;
            AddShopItems = (checks & 32) > 0;
            RandomizeDungeonEntrances = (checks & 16) > 0;
            RandomizeBGM = (checks & 8) > 0;
            RandomizeEnemies = (checks & 4) > 0;
            ShortenCutscenes = (checks & 2) > 0;
            QuickTextEnabled = (checks & 1) > 0;

            var damageMultiplierIndex = (int)((combos & 0xF0000000) >> 28);
            var damageTypeIndex = (combos & 0xF000000) >> 24;
            var modeIndex = (combos & 0xFF0000) >> 16;
            var characterIndex = (combos & 0xFF00) >> 8;
            var tatlColorIndex = combos & 0xFF;
            var gravityTypeIndex = (int)((colourAndMisc & 0xF0000000) >> 28);
            var floorTypeIndex = (colourAndMisc & 0xF000000) >> 24;
            var tunicColor = Color.FromArgb(
                (colourAndMisc & 0xFF0000) >> 16,
                (colourAndMisc & 0xFF00) >> 8,
                colourAndMisc & 0xFF);

            DamageMode = (DamageMode)damageMultiplierIndex;
            DamageEffect = (DamageEffect)damageTypeIndex;
            LogicMode = (LogicMode)modeIndex;
            Character = (Character)characterIndex;
            TatlColorSchema = (TatlColorSchema)tatlColorIndex;
            MovementMode = (MovementMode)gravityTypeIndex;
            FloorType = (FloorType)floorTypeIndex;
            TunicColor = tunicColor;

        }


        private int[] BuildSettingsBytes()
        {
            int[] bits = new int[3];

            if (FreeHints) { bits[0] += 16384; };
            if (UseCustomItemList) { bits[0] += 8192; };
            if (AddOther) { bits[0] += 4096; };
            if (EnableGossipHints) { bits[0] += 2048; };
            if (ExcludeSongOfSoaring) { bits[0] += 1024; };
            if (GenerateSpoilerLog) { bits[0] += 512; };
            if (AddSongs) { bits[0] += 256; };
            if (RandomizeBottleCatchContents) { bits[0] += 128; };
            if (AddDungeonItems) { bits[0] += 64; };
            if (AddShopItems) { bits[0] += 32; };
            if (RandomizeDungeonEntrances) { bits[0] += 16; };
            if (RandomizeBGM) { bits[0] += 8; };
            if (RandomizeEnemies) { bits[0] += 4; };
            if (ShortenCutscenes) { bits[0] += 2; };
            if (QuickTextEnabled) { bits[0] += 1; };

            bits[1] = ((byte)LogicMode << 16)
                | ((byte)Character << 8)
                | ((byte)TatlColorSchema)
                | ((byte)DamageEffect << 24)
                    | ((byte)DamageMode << 28);

            bits[2] = (TunicColor.R << 16)
                | (TunicColor.G << 8)
                | (TunicColor.B)
                | ((byte)FloorType << 24)
                    | ((byte)MovementMode << 28);

            return bits;
        }

        private void UpdateOutputFilenames()
        {
            string settings = this.ToString();
            string appendSeed = GenerateSpoilerLog ? $"{Seed}_" : "";
            string filename = $"MMR_{appendSeed}{settings}";

            DefaultOutputROMFilename = filename + ".z64";
        }

        private string EncodeSettings()
        {
            int[] options = BuildSettingsBytes();

            return $"{Base36Utils.Encode(options[0])}-{Base36Utils.Encode(options[1])}-{Base36Utils.Encode(options[2])}";
        }

        public override string ToString()
        {
            return EncodeSettings();
        }
    }
}
