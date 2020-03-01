using MMR.Randomizer.Utils;
using Newtonsoft.Json;
using System.IO;

namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Crit wiggle state value.
    /// </summary>
    public enum CritWiggleState : byte
    {
        Default,
        AlwaysOn,
        AlwaysOff,
    }

    /// <summary>
    /// Miscellaneous flags.
    /// </summary>
    public class MiscFlags
    {
        /// <summary>
        /// Behaviour of crit wiggle.
        /// </summary>
        public CritWiggleState CritWiggle { get; set; }

        /// <summary>
        /// Whether or not to disable crit wiggle (alternative state is default behaviour).
        /// </summary>
        public bool CritWiggleDisable {
            get { return (this.CritWiggle == CritWiggleState.AlwaysOff) ? true : false; }
            set { this.CritWiggle = (value ? CritWiggleState.AlwaysOff : CritWiggleState.Default); }
        }

        /// <summary>
        /// Whether or not to draw hash icons on the file select screen.
        /// </summary>
        public bool DrawHash { get; set; } = true;

        /// <summary>
        /// Whether or not to enable faster pushing and pulling speeds.
        /// </summary>
        public bool FastPush { get; set; }

        /// <summary>
        /// Whether or not to allow using the ocarina underwater.
        /// </summary>
        public bool OcarinaUnderwater { get; set; }

        /// <summary>
        /// Whether or not to enable Quest Item Storage.
        /// </summary>
        public bool QuestItemStorage { get; set; } = true;

        public MiscFlags()
        {
        }

        public MiscFlags(uint flags)
        {
            Load(flags);
        }

        /// <summary>
        /// Load from a <see cref="uint"/> integer.
        /// </summary>
        /// <param name="flags">Flags integer</param>
        void Load(uint flags)
        {
            this.CritWiggle = (CritWiggleState)(flags >> 30);
            this.DrawHash = ((flags >> 29) & 1) == 1;
            this.FastPush = ((flags >> 28) & 1) == 1;
            this.OcarinaUnderwater = ((flags >> 27) & 1) == 1;
            this.QuestItemStorage = ((flags >> 26) & 1) == 1;
        }

        /// <summary>
        /// Convert to a <see cref="uint"/> integer.
        /// </summary>
        /// <returns>Integer</returns>
        public uint ToInt()
        {
            uint flags = 0;
            flags |= (((uint)this.CritWiggle) & 3) << 30;
            flags |= (this.DrawHash ? (uint)1 : 0) << 29;
            flags |= (this.FastPush ? (uint)1 : 0) << 28;
            flags |= (this.OcarinaUnderwater ? (uint)1 : 0) << 27;
            flags |= (this.QuestItemStorage ? (uint)1 : 0) << 26;
            return flags;
        }
    }

    /// <summary>
    /// Miscellaneous configuration structure.
    /// </summary>
    public struct MiscConfigStruct : IAsmConfigStruct
    {
        public uint Version;
        public byte[] Hash;
        public uint Flags;

        /// <summary>
        /// Convert to bytes.
        /// </summary>
        /// <returns>Bytes</returns>
        public byte[] ToBytes()
        {
            using (var memStream = new MemoryStream())
            using (var writer = new BinaryWriter(memStream))
            {
                writer.Write(this.Version);

                // Version 0
                writer.Write(this.Hash);
                writer.Write(ReadWriteUtils.Byteswap32(this.Flags));

                return memStream.ToArray();
            }
        }
    }

    /// <summary>
    /// Miscellaneous configuration.
    /// </summary>
    public class MiscConfig : AsmConfig
    {
        /// <summary>
        /// Hash bytes.
        /// </summary>
        public byte[] Hash { get; set; }

        /// <summary>
        /// Flags.
        /// </summary>
        public MiscFlags Flags { get; set; }

        public MiscConfig()
            : this(new byte[0], new MiscFlags())
        {
        }

        public MiscConfig(byte[] hash, MiscFlags flags)
        {
            this.Hash = hash;
            this.Flags = flags;
        }

        /// <summary>
        /// Get a <see cref="MiscConfigStruct"/> representation.
        /// </summary>
        /// <param name="version">Structure version</param>
        /// <returns>Configuration structure</returns>
        public override IAsmConfigStruct ToStruct(uint version)
        {
            var hash = ReadWriteUtils.CopyBytes(this.Hash, 0x10);

            return new MiscConfigStruct
            {
                Version = version,
                Hash = hash,
                Flags = this.Flags.ToInt(),
            };
        }
    }
}
