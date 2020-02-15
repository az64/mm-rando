using MMR.Randomizer.Utils;
using System.Drawing;
using System.IO;

namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Color values to use for various HUD elements.
    /// </summary>
    public class HudColors
    {
        public Color ButtonA { get; set; } = Color.FromArgb(0x64, 0xC8, 0xFF);
        public Color ButtonB { get; set; } = Color.FromArgb(0x64, 0xFF, 0x78);
        public Color ButtonC { get; set; } = Color.FromArgb(0xFF, 0xF0, 0x00);
        public Color ButtonStart { get; set; } = Color.FromArgb(0xFF, 0x82, 0x3C);
        public Color ClockEmblem { get; set; } = Color.FromArgb(0x00, 0xAA, 0x64);
        public Color ClockEmblemInverted1 { get; set; } = Color.FromArgb(0x64, 0xCD, 0xFF);
        public Color ClockEmblemInverted2 { get; set; } = Color.FromArgb(0x00, 0x9B, 0xFF);
        public Color ClockEmblemSun { get; set; } = Color.FromArgb(0xFF, 0xFF, 0x6E);
        public Color ClockMoon { get; set; } = Color.FromArgb(0xFF, 0xFF, 0x37);
        public Color ClockSun { get; set; } = Color.FromArgb(0xFF, 0x64, 0x6E);
        public Color Heart { get; set; } = Color.FromArgb(0xFF, 0x46, 0x32);
        public Color HeartDD { get; set; } = Color.FromArgb(0xC8, 0x00, 0x00);
        public Color Magic { get; set; } = Color.FromArgb(0x00, 0xC8, 0x00);
        public Color MagicInf { get; set; } = Color.FromArgb(0x00, 0x00, 0xC8);
        public Color Map { get; set; } = Color.FromArgb(0x00, 0xFF, 0xFF);
        public Color MapEntranceCursor { get; set; } = Color.FromArgb(0xC8, 0x00, 0x00);
        public Color MapPlayerCursor { get; set; } = Color.FromArgb(0xC8, 0xFF, 0x00);
        public Color RupeeIcon1 { get; set; } = Color.FromArgb(0xC8, 0xFF, 0x64);
        public Color RupeeIcon2 { get; set; } = Color.FromArgb(0xAA, 0xAA, 0xFF);
        public Color RupeeIcon3 { get; set; } = Color.FromArgb(0xFF, 0x69, 0x69);

        /// <summary>
        /// Get all colors in the order of serialization.
        /// </summary>
        public Color[] All => new Color[]
        {
            ButtonA,
            ButtonB,
            ButtonC,
            ButtonStart,
            ClockEmblem,
            ClockEmblemInverted1,
            ClockEmblemInverted2,
            ClockEmblemSun,
            ClockMoon,
            ClockSun,
            Heart,
            HeartDD,
            Magic,
            MagicInf,
            Map,
            MapEntranceCursor,
            MapPlayerCursor,
            RupeeIcon1,
            RupeeIcon2,
            RupeeIcon3,
        };
    }

    /// <summary>
    /// HUD colors configuration.
    /// </summary>
    public class HudColorsConfig
    {
        /// <summary>
        /// HUD color values.
        /// </summary>
        public HudColors Colors { get; set; } = new HudColors();

        /// <summary>
        /// Convert to a <see cref="HudColorsConfigStruct"/> structure.
        /// </summary>
        /// <param name="version">Structure version</param>
        /// <returns>Structure</returns>
        public HudColorsConfigStruct ToStruct(uint version)
        {
            return new HudColorsConfigStruct
            {
                Version = version,
                Colors = this.Colors.All,
            };
        }
    }

    /// <summary>
    /// HUD colors configuration structure.
    /// </summary>
    public struct HudColorsConfigStruct
    {
        public uint Version;
        public Color[] Colors;

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

                foreach (var color in this.Colors)
                {
                    writer.Write(ColorUtils.GetBytesRGBA(color));
                }
                return memStream.ToArray();
            }
        }
    }
}
