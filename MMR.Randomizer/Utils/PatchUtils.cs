using System;

namespace MMR.Randomizer.Utils
{
    /// <summary>
    /// Patch format version Id.
    /// </summary>
    public enum PatchVersion : uint
    {
        V1 = 1,
        V2 = 2,
        V3 = 3,
    }

    public static class PatchUtils
    {
        /// <summary>
        /// Patch file magic number ("MMRP").
        /// </summary>
        public static readonly uint PATCH_MAGIC = 0x4D4D5250;

        /// <summary>
        /// Least recent <see cref="PatchVersion"/> value which is acceptable.
        /// </summary>
        public static readonly PatchVersion PATCH_PREVIOUS = PatchVersion.V3;

        /// <summary>
        /// Most recent <see cref="PatchVersion"/> value.
        /// </summary>
        public static readonly PatchVersion PATCH_VERSION = PatchVersion.V3;

        /// <summary>
        /// Range of acceptable <see cref="PatchVersion"/> values.
        /// </summary>
        /// <remarks>Use Range struct when it becomes available</remarks>
        public static Tuple<uint, uint> AcceptableRange => new Tuple<uint, uint>((uint)PATCH_PREVIOUS, (uint)PATCH_VERSION);

        /// <summary>
        /// Check if a patch with a specific <see cref="PatchVersion"/> value can be applied.
        /// </summary>
        /// <param name="version"><see cref="PatchVersion"/> value</param>
        /// <returns>True if can be applied, false if not</returns>
        public static bool CanApplyVersion(uint version)
        {
            var acceptable = AcceptableRange;
            var inRange = (acceptable.Item1 <= version) && (version <= acceptable.Item2);
            return inRange;
        }

        /// <summary>
        /// Validate values found in a patch file.
        /// </summary>
        /// <param name="magic">Found magic value</param>
        /// <param name="version">Found version value</param>
        public static void Validate(uint magic, uint version)
        {
            // Make sure this is a patch file by checking the magic value
            ValidateMagic(magic);

            // Check that this patch version is supported
            ValidateVersion(version);
        }

        /// <summary>
        /// Validate magic value and throw a <see cref="PatchMagicException"/> if invalid.
        /// </summary>
        /// <param name="magic">Magic value</param>
        public static void ValidateMagic(uint magic)
        {
            if (magic != PATCH_MAGIC)
            {
                throw new PatchMagicException(magic);
            }
        }

        /// <summary>
        /// Validate <see cref="PatchVersion"/> value and throw a <see cref="PatchVersionException"/> if invalid.
        /// </summary>
        /// <param name="version"><see cref="PatchVersion"/> value</param>
        public static void ValidateVersion(uint version)
        {
            if (!CanApplyVersion(version))
            {
                throw PatchVersionException.From((PatchVersion)version);
            }
        }
    }

    public class PatchMagicException : Exception
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

    public class PatchVersionException : Exception
    {
        /// <summary>
        /// Current <see cref="PatchVersion"/> value.
        /// </summary>
        public PatchVersion Current { get; }

        /// <summary>
        /// <see cref="PatchVersion"/> value found in file.
        /// </summary>
        public PatchVersion Found { get; }

        /// <summary>
        /// Least recent acceptable <see cref="PatchVersion"/> value.
        /// </summary>
        public PatchVersion Previous { get; }

        public override string Message => String.Format("Incompatible patch versions: expected version in range [{0}, {1}], but found version {2}",
            (uint)this.Previous, (uint)this.Current, (uint)this.Found);

        public PatchVersionException(PatchVersion current, PatchVersion previous, PatchVersion found)
        {
            this.Current = current;
            this.Found = found;
            this.Previous = previous;
        }

        /// <summary>
        /// Get a <see cref="PatchVersionException"/> from a <see cref="PatchVersion"/> value found in a patch file.
        /// </summary>
        /// <param name="found">Value</param>
        /// <returns>PatchVersionException</returns>
        public static PatchVersionException From(PatchVersion found)
        {
            return new PatchVersionException(PatchUtils.PATCH_VERSION, PatchUtils.PATCH_PREVIOUS, found);
        }
    }
}
