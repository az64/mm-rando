namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Versioned Asm configuration structure.
    /// </summary>
    public interface IAsmConfigStruct
    {
        byte[] ToBytes();
    }

    /// <summary>
    /// Versioned Asm configuration container.
    /// </summary>
    public abstract class AsmConfig
    {
        public abstract IAsmConfigStruct ToStruct(uint version);

        /// <summary>
        /// Convert to bytes.
        /// </summary>
        /// <param name="version">Structure version</param>
        /// <returns>Bytes</returns>
        public byte[] ToBytes(uint version)
        {
            return ToStruct(version).ToBytes();
        }
    }
}
