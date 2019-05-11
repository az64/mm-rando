
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
        public bool OutputRom { get; set; } = true;

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
        /// Use Custom Item list for the logic.
        /// </summary>
        public bool UseCustomItemList { get; set; }


        // Random Elements

        /// <summary>
        /// The randomizer seed
        /// </summary>
        public int Seed { get; set; }

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
            var O = settings.Split('-');
            int Checks = (int)Base36.Decode(O[0]);
            int Combos = (int)Base36.Decode(O[1]);
            int ColourAndMisc = (int)Base36.Decode(O[2]);

            UseCustomItemList = (Checks & 8192) > 0;
            AddOther = (Checks & 4096) > 0;
            EnableGossipHints = (Checks & 2048) > 0;
            ExcludeSongOfSoaring = (Checks & 1024) > 0;
            GenerateSpoilerLog = (Checks & 512) > 0;
            AddSongs = (Checks & 256) > 0;
            RandomizeBottleCatchContents = (Checks & 128) > 0;
            AddDungeonItems = (Checks & 64) > 0;
            AddShopItems = (Checks & 32) > 0;
            RandomizeDungeonEntrances = (Checks & 16) > 0;
            RandomizeBGM = (Checks & 8) > 0;
            RandomizeEnemies = (Checks & 4) > 0;
            ShortenCutscenes = (Checks & 2) > 0;
            QuickTextEnabled = (Checks & 1) > 0;

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

            DamageMode = (DamageMode)damageMultiplierIndex;
            DamageEffect = (DamageEffect)damageTypeIndex;
            LogicMode = (LogicMode)modeIndex;
            Character = (Character)characterIndex;
            TatlColorSchema = (TatlColorSchema)tatlColorIndex;
            MovementMode = (MovementMode)gravityTypeIndex;
            FloorType = (FloorType)floorTypeIndex;
            TunicColor = tunicColor;

            UpdateOutputFilenames(settings);
        }


        private int[] BuildSettingsBytes()
        {
            int[] O = new int[3];

            if (UseCustomItemList) { O[0] += 8192; };
            if (AddOther) { O[0] += 4096; };
            if (EnableGossipHints) { O[0] += 2048; };
            if (ExcludeSongOfSoaring) { O[0] += 1024; };
            if (GenerateSpoilerLog) { O[0] += 512; };
            if (AddSongs) { O[0] += 256; };
            if (RandomizeBottleCatchContents) { O[0] += 128; };
            if (AddDungeonItems) { O[0] += 64; };
            if (AddShopItems) { O[0] += 32; };
            if (RandomizeDungeonEntrances) { O[0] += 16; };
            if (RandomizeBGM) { O[0] += 8; };
            if (RandomizeEnemies) { O[0] += 4; };
            if (ShortenCutscenes) { O[0] += 2; };
            if (QuickTextEnabled) { O[0] += 1; };

            O[1] = ((byte)LogicMode << 16)
                | ((byte)Character << 8)
                | ((byte)TatlColorSchema)
                | ((byte)DamageEffect << 24)
                    | ((byte)DamageMode << 28);

            O[2] = (TunicColor.R << 16)
                | (TunicColor.G << 8)
                | (TunicColor.B)
                | ((byte)FloorType << 24)
                    | ((byte)MovementMode << 28);

            return O;
        }

        private void Update()
        {
            string settings = EncodeSettings();
            UpdateOutputFilenames(settings);
        }

        private void UpdateOutputFilenames(string settings)
        {
            string appendSeed = GenerateSpoilerLog ? $"{Seed}_" : "";
            string filename = $"MMR_{appendSeed}{settings}";

            DefaultOutputROMFilename = filename + ".z64";
        }

        private string EncodeSettings()
        {
            int[] options = BuildSettingsBytes();

            return $"{Base36.Encode(options[0])}-{Base36.Encode(options[1])}-{Base36.Encode(options[2])}";
        }

        public override string ToString()
        {
            return EncodeSettings();
        }
    }
}
