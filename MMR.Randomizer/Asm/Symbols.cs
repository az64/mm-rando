using MMR.Randomizer.Models.Rom;
using MMR.Randomizer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Symbols used in the ASM patch.
    /// </summary>
    public class Symbols
    {
        private Dictionary<string, uint> _symbols = new Dictionary<string, uint>();

        /// <summary>
        /// Virtual address of the <see cref="MMFile"/> containing serialized <see cref="Symbols"/> data.
        /// </summary>
        public static readonly uint MMFILE_START = 0x3F000000;

        /// <summary>
        /// Address of payload end.
        /// </summary>
        public uint PayloadEnd => this["PAYLOAD_END"];

        /// <summary>
        /// Address of payload start.
        /// </summary>
        public uint PayloadStart => this["PAYLOAD_START"];

        /// <summary>
        /// Get the value of a symbol by name.
        /// </summary>
        /// <param name="name">Symbol name</param>
        /// <returns>Symbol value</returns>
        public uint this[string name] {
            get {
                return this._symbols[name];
            }
        }

        /// <summary>
        /// Check if a certain symbol exists.
        /// </summary>
        /// <param name="name">Symbol name</param>
        /// <returns>True if exists, false if not</returns>
        public bool Has(string name)
        {
            return this._symbols.ContainsKey(name);
        }

        /// <summary>
        /// Create a special <see cref="MMFile"/> with serialized <see cref="Symbols"/> data.
        /// </summary>
        /// <returns>MMFile</returns>
        public MMFile CreateMMFile()
        {
            var start = MMFILE_START;
            var data = this.ToBytes();

            var file = new MMFile
            {
                Addr = (int)start,
                End = (int)start + data.Length,
                IsCompressed = false,
                IsStatic = true,
                Data = data,
            };

            return file;
        }

        /// <summary>
        /// Write an <see cref="AsmConfig"/> structure to ROM.
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="config">Config</param>
        void WriteAsmConfig(string symbol, AsmConfig config)
        {
            var addr = this[symbol];
            var version = ReadWriteUtils.ReadU32((int)(addr + 4));
            var bytes = config.ToBytes(version);
            ReadWriteUtils.WriteToROM((int)(addr + 4), bytes);
        }

        /// <summary>
        /// Write the D-Pad configuration structure to ROM.
        /// </summary>
        /// <param name="config">D-Pad config</param>
        public void WriteDPadConfig(DPadConfig config)
        {
            // If there's a DPAD_STATE symbol, use the legacy function instead.
            if (this.Has("DPAD_STATE"))
            {
                WriteDPadConfigLegacy(config);
                return;
            }

            WriteAsmConfig("DPAD_CONFIG", config);
        }

        /// <summary>
        /// Write a <see cref="DPadConfig"/> to the ROM.
        /// </summary>
        /// <remarks>Assumes <see cref="Patcher"/> file has been inserted.</remarks>
        /// <param name="config">D-Pad config</param>
        void WriteDPadConfigLegacy(DPadConfig config)
        {
            // Write DPad config bytes.
            var addr = this["DPAD_CONFIG"];
            ReadWriteUtils.WriteToROM((int)addr, config.Pad.Bytes);

            // Write DPad state byte.
            addr = this["DPAD_STATE"];
            ReadWriteUtils.WriteToROM((int)addr, (byte)config.State);
        }

        /// <summary>
        /// Write a <see cref="HudColorsConfig"/> to the ROM.
        /// </summary>
        /// <param name="config">HUD colors config</param>
        public void WriteHudColorsConfig(HudColorsConfig config)
        {
            WriteAsmConfig("HUD_COLOR_CONFIG", config);
        }

        /// <summary>
        /// Write a <see cref="MiscConfig"/> to the ROM.
        /// </summary>
        /// <param name="config">Misc config</param>
        public void WriteMiscConfig(MiscConfig config)
        {
            WriteAsmConfig("MISC_CONFIG", config);
        }

        /// <summary>
        /// Write the <see cref="MiscConfig"/> hash bytes without overwriting other parts of the structure.
        /// </summary>
        /// <param name="hash">Hash bytes</param>
        public void WriteMiscHash(byte[] hash)
        {
            var bytes = ReadWriteUtils.CopyBytes(hash, 0x10);
            var addr = this["MISC_CONFIG"];
            ReadWriteUtils.WriteToROM((int)(addr + 8), bytes);
        }

        /// <summary>
        /// Try and write a <see cref="DPadConfig"/> to the ROM.
        /// </summary>
        /// <param name="config">D-Pad config</param>
        /// <returns>True if successful, false if the <see cref="DPadConfig"/> symbol was not found.</returns>
        public bool TryWriteDPadConfig(DPadConfig config)
        {
            try
            {
                WriteDPadConfig(config);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Try and write a <see cref="HudColorsConfig"/> to the ROM.
        /// </summary>
        /// <param name="config">HUD colors config</param>
        /// <returns>True if successful, false if the <see cref="HudColorsConfig"/> symbol was not found.</returns>
        public bool TryWriteHudColorsConfig(HudColorsConfig config)
        {
            try
            {
                WriteHudColorsConfig(config);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Try and write the <see cref="MiscConfig"/> hash bytes.
        /// </summary>
        /// <param name="hash">Hash bytes</param>
        /// <returns>True if successful, false if the <see cref="MiscConfig"/> symbol was not found.</returns>
        public bool TryWriteMiscHash(byte[] hash)
        {
            try
            {
                WriteMiscHash(hash);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Load <see cref="Symbols"/> from serialized data.
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Symbols</returns>
        public static Symbols FromBytes(byte[] bytes)
        {
            var symbols = new Symbols();

            using (var memStream = new MemoryStream(bytes))
            using (var reader = new BinaryReader(memStream))
            {
                reader.ReadUInt32(); // Unused for now
                var count = reader.ReadUInt32();
                for (uint i = 0; i < count; i++)
                {
                    var namelen = reader.ReadUInt16();
                    var namebytes = reader.ReadBytes(namelen);
                    var name = Encoding.ASCII.GetString(namebytes);
                    var value = reader.ReadUInt32();
                    symbols._symbols.Add(name, value);
                }
            }

            return symbols;
        }

        /// <summary>
        /// Load <see cref="Symbols"/> from a JSON <see cref="string"/>.
        /// </summary>
        /// <param name="json">JSON string</param>
        /// <returns>Symbols</returns>
        public static Symbols FromJSON(string json)
        {
            var symbols = new Symbols();

            // This is a horrible hack for this specific JSON input
            var lines = json.Split('\n');
            foreach (var line in lines)
            {
                var trimmed = line.Trim();

                // Ignore empty line, brackets
                if (trimmed == "" || trimmed == "{" || trimmed == "}")
                    continue;

                // Get name & value fields
                var fields = trimmed.Split(':');
                var name = fields[0].Trim();
                var value = fields[1].Trim();

                // If ends with "," remove it
                if (value.EndsWith(","))
                    value = value.Substring(0, value.Length - 1).Trim();

                // Remove surrounding quotes
                name = name.Replace("\"", "");
                value = value.Replace("\"", "");

                // Add result to dictionary
                symbols._symbols.Add(name, Convert.ToUInt32(value, 16));
            }

            return symbols;
        }

        /// <summary>
        /// Load <see cref="Symbols"/> from serialized data in a <see cref="MMFile"/>.
        /// </summary>
        /// <param name="file">MMFile</param>
        /// <returns>Symbols</returns>
        public static Symbols FromMMFile(MMFile file)
        {
            return FromBytes(file.Data);
        }

        /// <summary>
        /// Load <see cref="Symbols"/> from a special <see cref="MMFile"/> already in the ROM.
        /// </summary>
        /// <returns>Symbols</returns>
        public static Symbols FromROM()
        {
            int index = RomUtils.AddrToFile((int)MMFILE_START);

            // Might be unable to find MMFile with Symbols data for older patch files
            if (index < 0)
                return null;

            var file = RomData.MMFileList[index];
            return Symbols.FromMMFile(file);
        }

        /// <summary>
        /// Load <see cref="Symbols"/> from the default resource file.
        /// </summary>
        /// <returns>Symbols</returns>
        public static Symbols Load()
        {
            return FromJSON(Properties.Resources.ASM_SYMBOLS);
        }

        /// <summary>
        /// Serialize into bytes.
        /// </summary>
        /// <returns>Bytes</returns>
        public byte[] ToBytes()
        {
            using (var memStream = new MemoryStream())
            using (var writer = new BinaryWriter(memStream))
            {
                writer.Write((uint)0); // Potentially use this as a "version" field later
                writer.Write((uint)_symbols.Count);
                foreach (var symbol in _symbols)
                {
                    // Symbols should always be ASCII encode-able
                    var name = Encoding.ASCII.GetBytes(symbol.Key);
                    writer.Write((ushort)name.Length);
                    writer.Write(name);
                    writer.Write(symbol.Value);
                }

                while (memStream.Position % 0x10 != 0)
                {
                    writer.Write((byte)0);
                }

                return memStream.ToArray();
            }
        }

        /// <summary>
        /// Apply configuration which will be hardcoded into the patch file.
        /// </summary>
        /// <param name="options">Options</param>
        public void ApplyConfiguration(AsmOptionsGameplay options)
        {
            this.WriteMiscConfig(options.MiscConfig);
        }

        /// <summary>
        /// Apply configuration using the <see cref="Symbols"/> data.
        /// </summary>
        /// <param name="options">Options</param>
        public void ApplyConfigurationPostPatch(AsmOptionsCosmetic options)
        {
            this.WriteDPadConfig(options.DPadConfig);
            this.WriteHudColorsConfig(options.HudColorsConfig);

            // Only write the MiscConfig hash (the rest should not be changeable post-patch)
            this.WriteMiscHash(options.Hash);
        }

        /// <summary>
        /// Try and apply configuration post-patch using the <see cref="Symbols"/> data.
        /// </summary>
        /// <param name="options">Options</param>
        public void TryApplyConfigurationPostPatch(AsmOptionsCosmetic options)
        {
            this.TryWriteDPadConfig(options.DPadConfig);
            this.TryWriteHudColorsConfig(options.HudColorsConfig);

            // Try and write the MiscConfig hash
            this.TryWriteMiscHash(options.Hash);
        }
    }
}
