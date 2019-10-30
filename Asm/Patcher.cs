using MMRando.Models.Rom;
using MMRando.Utils;
using System;
using System.Collections.Generic;

namespace MMRando.Asm
{
    /// <summary>
    /// Address with bytes to patch.
    /// </summary>
    public class PatchData
    {
        public uint Address;
        public byte[] Bytes;

        private PatchData(uint address, byte[] bytes)
        {
            this.Address = address;
            this.Bytes = bytes;
        }

        /// <summary>
        /// Parse a <see cref="PatchData"/> from a line in the patch file.
        /// </summary>
        /// <param name="line">Line</param>
        /// <returns>PatchData</returns>
        public static PatchData FromLine(string line)
        {
            line = line.Trim();

            // Check if comment or blank line
            if (line.StartsWith(";") || line == "")
                return null;

            var fields = line.Split(',');
            if (fields.Length != 2)
                throw new Exception(String.Format("PatchData line must be two fields separated by a comma: {0}", line));

            var address = Convert.ToUInt32(fields[0], 16);
            var dataValue = Convert.ToUInt32(fields[1], 16);
            var bytes = BitConverter.GetBytes(dataValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return new PatchData(address, bytes);
        }
    }

    /// <summary>
    /// Options used when patching.
    /// </summary>
    public class PatcherOptions
    {
        /// <summary>
        /// D-Pad configuration.
        /// </summary>
        public DPadConfig DPadConfig { get; set; } = new DPadConfig();
    }

    /// <summary>
    /// Patcher for assembly patch file.
    /// </summary>
    public class Patcher
    {
        private PatchData[] _data;

        /// <summary>
        /// Address of the end of the MMFile table.
        /// </summary>
        const uint TABLE_END = 0x20700;

        /// <summary>
        /// Apply patches using <see cref="Symbols"/> loaded from the internal resource.
        /// </summary>
        /// <param name="options">Options</param>
        public void Apply(PatcherOptions options)
        {
            Apply(Symbols.Load(), options);
        }

        /// <summary>
        /// Apply patches.
        /// </summary>
        /// <param name="symbols">Symbols</param>
        /// <param name="options">Options</param>
        public void Apply(Symbols symbols, PatcherOptions options)
        {
            // Write patch data to existing MMFiles
            WriteToROM(symbols);

            // For our custom data, create and insert our own MMFile
            var file = CreateMMFile(symbols);
            RomData.MMFileList.Add(file);

            // Write our D-Pad config
            symbols.WriteDPadConfig(options.DPadConfig);
        }

        /// <summary>
        /// Generate the bytes for the <see cref="MMFile"/>.
        /// </summary>
        /// <param name="start">Start of virtual file</param>
        /// <returns>Bytes</returns>
        public byte[] GetFileData(uint start, uint length)
        {
            var bytes = new byte[length];

            // Zero out file bytes
            Array.Clear(bytes, 0, bytes.Length);

            foreach (var data in _data)
                if (start <= data.Address)
                {
                    // Get address relative to our MMFile
                    var addr = data.Address - start;
                    ReadWriteUtils.Arr_Insert(data.Bytes, 0, data.Bytes.Length, bytes, (int)addr);
                }

            return bytes;
        }

        /// <summary>
        /// Create a <see cref="MMFile"/> from patch data.
        /// </summary>
        /// <param name="symbols">Symbols</param>
        /// <returns>MMFile</returns>
        public MMFile CreateMMFile(Symbols symbols)
        {
            var start = symbols.PayloadStart;
            var end = symbols.PayloadEnd;

            var data = GetFileData(start, end - start);

            var file = new MMFile
            {
                Addr = (int)start,
                End = (int)start + data.Length,
                IsCompressed = false,
                Data = data,
            };

            return file;
        }

        /// <summary>
        /// Load a <see cref="Patcher"/> from lines.
        /// </summary>
        /// <param name="lines">Lines</param>
        /// <returns>Patcher</returns>
        public static Patcher FromLines(string[] lines)
        {
            // Parse each line of patch data into a list
            var list = new List<PatchData>();
            foreach (var line in lines)
            {
                var data = PatchData.FromLine(line);
                if (data == null)
                    continue;

                // If patch address is before or within MMFile table, ignore
                if (TABLE_END <= data.Address)
                    list.Add(data);
            }

            var patcher = new Patcher();
            patcher._data = list.ToArray();
            return patcher;
        }

        /// <summary>
        /// Load a <see cref="Patcher"/> from a <see cref="string"/>.
        /// </summary>
        /// <param name="full">String</param>
        /// <returns>Patcher</returns>
        public static Patcher FromString(string full)
        {
            var lines = full.Split('\n');
            return FromLines(lines);
        }

        /// <summary>
        /// Load a <see cref="Patcher"/> from the default resource file.
        /// </summary>
        /// <returns>Patcher</returns>
        public static Patcher Load()
        {
            return FromString(Properties.Resources.ASM_PATCH);
        }

        /// <summary>
        /// Patch existing <see cref="MMFile"/> files.
        /// </summary>
        public void WriteToROM(Symbols symbols)
        {
            foreach (var data in _data)
                if (TABLE_END <= data.Address && data.Address < symbols.PayloadStart)
                    ReadWriteUtils.WriteToROM((int)data.Address, data.Bytes);
        }
    }
}
