using MMR.Randomizer.Utils;
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
    /// Gameplay flags.
    /// </summary>
    public class GameplayFlags
    {
        /// <summary>
        /// Behaviour of crit wiggle.
        /// </summary>
        public CritWiggleState CritWiggle { get; set; }

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
        public bool QuestItemStorage { get; set; }

        public GameplayFlags()
        {
            this.CritWiggle = CritWiggleState.Default;
            this.FastPush = true;
            this.OcarinaUnderwater = false;
            this.QuestItemStorage = true;
        }

        public GameplayFlags(uint flags)
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
            this.QuestItemStorage = ((flags >> 29) & 1) == 1;
            this.FastPush = ((flags >> 28) & 1) == 1;
            this.OcarinaUnderwater = ((flags >> 27) & 1) == 1;
        }

        /// <summary>
        /// Convert to a <see cref="uint"/> integer.
        /// </summary>
        /// <returns>Integer</returns>
        public uint ToInt()
        {
            uint flags = 0;
            flags |= (((uint)this.CritWiggle) & 3) << 30;
            flags |= (this.QuestItemStorage ? (uint)1 : 0) << 29;
            flags |= (this.FastPush ? (uint)1 : 0) << 28;
            flags |= (this.OcarinaUnderwater ? (uint)1 : 0) << 27;
            return flags;
        }
    }

    /// <summary>
    /// Gameplay configuration structure.
    /// </summary>
    public struct GameplayConfigStruct : IAsmConfigStruct
    {
        public uint Version;
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
                writer.Write(ReadWriteUtils.Byteswap32(this.Flags));

                return memStream.ToArray();
            }
        }
    }

    /// <summary>
    /// Gameplay configuration.
    /// </summary>
    public class GameplayConfig : AsmConfig
    {
        /// <summary>
        /// Flags.
        /// </summary>
        public GameplayFlags Flags { get; set; }

        public GameplayConfig()
            : this(new byte[0], new GameplayFlags())
        {
        }

        public GameplayConfig(byte[] hash, GameplayFlags flags)
        {
            this.Flags = flags;
        }

        /// <summary>
        /// Get a <see cref="GameplayConfigStruct"/> representation.
        /// </summary>
        /// <param name="version">Structure version</param>
        /// <returns>Configuration structure</returns>
        public override IAsmConfigStruct ToStruct(uint version)
        {
            return new GameplayConfigStruct
            {
                Version = version,
                Flags = this.Flags.ToInt(),
            };
        }
    }
}
