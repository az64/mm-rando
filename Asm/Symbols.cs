using MMRando.Utils;
using System;
using System.Collections.Generic;

namespace MMRando.Asm
{
    /// <summary>
    /// Symbols used in the ASM patch.
    /// </summary>
    public class Symbols
    {
        private Dictionary<string, uint> _symbols = new Dictionary<string, uint>();

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
        /// Write a <see cref="DPadState"/> to the ROM.
        /// </summary>
        /// <remarks>Assumes <see cref="Patcher"/> file has been inserted.</remarks>
        /// <param name="state">D-Pad state</param>
        private void WriteDPadState(DPadState state)
        {
            // Write DPad state byte.
            var addr = this["DPAD_STATE"];
            ReadWriteUtils.WriteToROM((int)addr, (byte)state);
        }

        /// <summary>
        /// Write a <see cref="DPadConfig"/> to the ROM.
        /// </summary>
        /// <remarks>Assumes <see cref="Patcher"/> file has been inserted.</remarks>
        /// <param name="config">D-Pad config</param>
        public void WriteDPadConfig(DPadConfig config)
        {
            // Write DPad config bytes.
            var addr = this["DPAD_CONFIG"];
            ReadWriteUtils.WriteToROM((int)addr, config.Pad.Bytes);

            // Write DPad state
            WriteDPadState(config.State);
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
        /// Load <see cref="Symbols"/> from the default resource file.
        /// </summary>
        /// <returns>Symbols</returns>
        public static Symbols Load()
        {
            return FromJSON(Properties.Resources.ASM_SYMBOLS);
        }
    }
}
