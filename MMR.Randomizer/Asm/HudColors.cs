using MMR.Randomizer.Models.Colors;
using MMR.Randomizer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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

        public HudColors()
        {
        }

        public HudColors(Color[] colors)
        {
            From(colors);
        }

        public HudColors(byte[] bytes)
        {
            FromBytes(bytes);
        }

        /// <summary>
        /// Clone to a new <see cref="HudColors"/>.
        /// </summary>
        /// <returns>Cloned colors</returns>
        public HudColors Clone()
        {
            return new HudColors(this.All);
        }

        /// <summary>
        /// Apply colors from array.
        /// </summary>
        /// <param name="colors">Colors array</param>
        void From(Color[] colors)
        {
            ButtonA = colors[0];
            ButtonB = colors[1];
            ButtonC = colors[2];
            ButtonStart = colors[3];
            ClockEmblem = colors[4];
            ClockEmblemInverted1 = colors[5];
            ClockEmblemInverted2 = colors[6];
            ClockEmblemSun = colors[7];
            ClockMoon = colors[8];
            ClockSun = colors[9];
            Heart = colors[10];
            HeartDD = colors[11];
            Magic = colors[12];
            MagicInf = colors[13];
            Map = colors[14];
            MapEntranceCursor = colors[15];
            MapPlayerCursor = colors[16];
            RupeeIcon1 = colors[17];
            RupeeIcon2 = colors[18];
            RupeeIcon3 = colors[19];
        }

        /// <summary>
        /// Decode a <see cref="HudColors"/> from a Base36 encoded string.
        /// </summary>
        /// <param name="value">Encoded string</param>
        /// <returns>HudColors</returns>
        public static HudColors FromBase36String(string value)
        {
            var bytes = Base36Utils.DecodeBytes(value);
            return new HudColors(bytes);
        }

        /// <summary>
        /// Deserialize from bytes.
        /// </summary>
        /// <param name="bytes">Bytes</param>
        void FromBytes(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            using (var reader = new BinaryReader(memoryStream))
            {
                var list = new List<Color>();
                var count = bytes.Length / 3;
                for (var i = 0; i < count; i++)
                {
                    var c = reader.ReadBytes(3);
                    var color = Color.FromArgb(c[0], c[1], c[2]);
                    list.Add(color);
                }
                From(list.ToArray());
            }
        }

        /// <summary>
        /// Encode into a Base36 encoded string.
        /// </summary>
        /// <returns>Encoded string</returns>
        public string ToBase36String()
        {
            return Base36Utils.EncodeBytes(this.ToBytes());
        }

        /// <summary>
        /// Serialize to bytes.
        /// </summary>
        /// <returns>Bytes</returns>
        public byte[] ToBytes()
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new BinaryWriter(memoryStream))
            {
                foreach (var color in this.All)
                {
                    writer.Write(color.R);
                    writer.Write(color.G);
                    writer.Write(color.B);
                }

                return memoryStream.ToArray();
            }
        }
    }

    /// <summary>
    /// HUD colors configuration.
    /// </summary>
    public class HudColorsConfig : AsmConfig
    {
        /// <summary>
        /// HUD color values.
        /// </summary>
        public HudColors Colors { get; set; } = new HudColors();

        /// <summary>
        /// Optional color overrides for hearts.
        /// </summary>
        [JsonIgnore]
        public Tuple<Color, Color> HeartsOverride { get; set; } = null;

        /// <summary>
        /// Optional color overrides for magic meter.
        /// </summary>
        [JsonIgnore]
        public Tuple<Color, Color> MagicOverride { get; set; } = null;

        /// <summary>
        /// Get the finalized <see cref="HudColors"/> after applying color overrides.
        /// </summary>
        /// <returns>Finalized colors</returns>
        public HudColors FinalizedColors()
        {
            var colors = this.Colors.Clone();

            if (this.HeartsOverride != null)
            {
                colors.Heart = this.HeartsOverride.Item1;
                colors.HeartDD = this.HeartsOverride.Item2;
            }

            if (this.MagicOverride != null)
            {
                colors.Magic = this.MagicOverride.Item1;
                colors.MagicInf = this.MagicOverride.Item2;
            }

            return colors;
        }

        /// <summary>
        /// Convert to a <see cref="HudColorsConfigStruct"/> structure.
        /// </summary>
        /// <param name="version">Structure version</param>
        /// <returns>Structure</returns>
        public override IAsmConfigStruct ToStruct(uint version)
        {
            return new HudColorsConfigStruct
            {
                Version = version,
                Colors = this.FinalizedColors().All,
            };
        }
    }

    /// <summary>
    /// HUD colors configuration structure.
    /// </summary>
    public struct HudColorsConfigStruct : IAsmConfigStruct
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
                ReadWriteUtils.WriteU32(writer, this.Version);

                foreach (var color in this.Colors)
                {
                    writer.Write(ColorUtils.GetBytesRGBA(color));
                }
                return memStream.ToArray();
            }
        }
    }

    /// <summary>
    /// Preset HUD colors.
    /// </summary>
    public static class HudColorPresets
    {
        /// <summary>
        /// Standard color pairings, with first element as "darker" and second as "lighter".
        /// </summary>
        /// <returns>Array of pairs</returns>
        public static NamedColorPair[] StandardPairs()
        {
            return new NamedColorPair[]
            {
                new NamedColorPair("Red", Color.FromArgb(0xFF, 0x33, 0x00), Color.FromArgb(0xCC, 0x00, 0x66)),
                new NamedColorPair("Orange", Color.FromArgb(0xFF, 0x99, 0x00), Color.FromArgb(0xFF, 0xC2, 0x66)),
                new NamedColorPair("Yellow", Color.FromArgb(0xFF, 0xFF, 0x00), Color.FromArgb(0xFF, 0xFF, 0x66)),
                new NamedColorPair("Green", Color.FromArgb(0x00, 0x66, 0x00), Color.FromArgb(0x33, 0xCC, 0x33)),
                new NamedColorPair("Blue", Color.FromArgb(0x33, 0x66, 0xCC), Color.FromArgb(0x33, 0xCC, 0xFF)),
                new NamedColorPair("Purple", Color.FromArgb(0x99, 0x00, 0xFF), Color.FromArgb(0x99, 0x66, 0xFF)),
                new NamedColorPair("Pink", Color.FromArgb(0xFF, 0x66, 0xD9), Color.FromArgb(0xFF, 0xB3, 0xEC)),
            };
        }

        /// <summary>
        /// Get <see cref="NamedColorPair"/> pairings for magic meter color selection.
        /// </summary>
        /// <returns>Pairs</returns>
        public static NamedColorPair[] MagicMeter()
        {
            var pairs = new NamedColorPair[]
            {
                new NamedColorPair("Classic", Color.FromArgb(0x00, 0xC8, 0x00), Color.FromArgb(0x00, 0x00, 0xC8)),
                new NamedColorPair("Orange Yoshi", Color.FromArgb(0xFF, 0xAE, 0x1A), Color.FromArgb(0x6F, 0xD2, 0x51)),
                new NamedColorPair("Vaporwave", Color.FromArgb(0xFF, 0x71, 0xCE), Color.FromArgb(0x01, 0xCD, 0xFE)),
            };

            return new List<NamedColorPair>()
                .Concat(pairs)
                .Concat(StandardPairs())
                .ToArray();
        }

        /// <summary>
        /// Get <see cref="NamedColorPair"/> pairings for hearts color selection.
        /// </summary>
        /// <returns>Pairs</returns>
        public static NamedColorPair[] Hearts()
        {
            return StandardPairs().Select((pair) => pair.Reverse()).ToArray();
        }
    }
}
