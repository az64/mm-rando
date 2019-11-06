using System;

namespace MMRando.Utils
{
    /// <summary>
    /// Patch format version Id.
    /// </summary>
    public enum PatchVersion : uint
    {
        V1 = 1,
    }

    public class PatchUtil
    {
        /// <summary>
        /// Patch file magic number ("MMRP").
        /// </summary>
        public static readonly uint PATCH_MAGIC = 0x4D4D5250;

        /// <summary>
        /// Most recent <see cref="PatchVersion"/> value.
        /// </summary>
        public static readonly PatchVersion PATCH_VERSION = PatchVersion.V1;
    }

    class PatchMagicException : Exception
    {
        /// <summary>
        /// Magic value found in patch file.
        /// </summary>
        public uint Found { get; }

        public override string Message => String.Format("Bad patch magic: 0x{0:X8}", this.Found);

        public PatchMagicException(uint found)
        {
            this.Found = found;

        }
    }

    class PatchVersionException : Exception
    {
        /// <summary>
        /// Current <see cref="PatchVersion"/> value.
        /// </summary>
        public PatchVersion Current { get; }

        /// <summary>
        /// <see cref="PatchVersion"/> value found in file.
        /// </summary>
        public PatchVersion Found { get; }

        public override string Message => String.Format("Incompatible patch versions: expected version {0}, but found version {1}",
            (uint)this.Current, (uint)this.Found);

        public PatchVersionException(PatchVersion current, PatchVersion found)
        {
            this.Current = current;
            this.Found = found;
        }
    }
}
