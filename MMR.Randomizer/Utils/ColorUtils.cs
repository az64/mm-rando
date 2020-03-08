using System;
using System.Drawing;

namespace MMR.Randomizer.Utils
{

    public class ColorUtils
    {
        /// <summary>
        /// Creates a <see cref="Color"/> from alpha, hue, saturation and brightness.
        /// </summary>
        /// <param name="alpha">The alpha channel value.</param>
        /// <param name="hue">The hue value.</param>
        /// <param name="saturation">The saturation value.</param>
        /// <param name="brightness">The brightness value.</param>
        /// <returns>A Color with the given values.</returns>
        public static Color FromAHSB(int alpha, float hue, float saturation, float brightness)
        {

            if (0 > alpha || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException("alpha", alpha,
                  "Value must be within a range of 0 - 255.");
            }
            if (0f > hue || 360f < hue)
            {
                throw new ArgumentOutOfRangeException("hue", hue,
                  "Value must be within a range of 0 - 360.");
            }
            if (0f > saturation || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException("saturation", saturation,
                  "Value must be within a range of 0 - 1.");
            }
            if (0f > brightness || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException("brightness", brightness,
                  "Value must be within a range of 0 - 1.");
            }

            if (0 == saturation)
            {
                return Color.FromArgb(alpha, Convert.ToInt32(brightness * 255),
                  Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }
            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = hue * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - hue * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(alpha, iMax, iMid, iMin);
            }
        }

        /// <summary>
        /// Get a <see cref="Color"/> as bytes in RGBA order.
        /// </summary>
        /// <param name="color">Color</param>
        /// <returns>Bytes</returns>
        public static byte[] GetBytesRGBA(Color color)
        {
            return new byte[] { color.R, color.G, color.B, color.A };
        }

        /// <summary>
        /// Check if the supplied <see cref="int"/>s are in the allowable range for 8-bit colour channels. If not, update them.
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        public static void ValidateRGB(ref int r, ref int g, ref int b)
        {
            if (r < 0)
            {
                r = 0;
            }
            else if (r > 255)
            {
                r = 255;
            }
            if (g < 0)
            {
                g = 0;
            }
            else if (g > 255)
            {
                g = 255;
            }
            if (b < 0)
            {
                b = 0;
            }
            else if (b > 255)
            {
                b = 255;
            }
        }

        /// <summary>
        /// Check if the supplied <see cref="float"/>s are in the allowable ranges for HSB channels. If not, update them.
        /// </summary>
        /// <param name="h">Hue</param>
        /// <param name="s">Saturation</param>
        /// <param name="b">Brightness</param>
        public static void ValidateHSB(ref float h, ref float s, ref float b)
        {
            h %= 360f;
            if (h < 0f)
            {
                h += 360f;
            }
            if (b < 0.0f)
            {
                b = 0.0f;
            }
            else if (b > 1.0f)
            {
                b = 1.0f;
            }
            if (s < 0.0f)
            {
                s = 0.0f;
            }
            else if (s > 1.0f)
            {
                s = 1.0f;
            }
        }

        /// <summary>
        /// Calculate the average of an array of <see cref="Color"/>s.
        /// </summary>
        /// <param name="c">Color array</param>
        /// <param name="count">Number of elements to average over</param>
        /// <returns>Color</returns>
        public static Color GetAverageColour(Color[] c, int count)
        {
            float r = 0f;
            float g = 0f;
            float b = 0f;
            float d = 1.0f / count;
            for (int i = 0; i < count; i++)
            {
                r += c[i].R * d;
                g += c[i].G * d;
                b += c[i].B * d;
            }
            return Color.FromArgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b));
        }

        /// <summary>
        /// Convert a <see cref="Color"/> to RGBA5551 format.
        /// </summary>
        /// <param name="c">Color</param>
        /// <returns>RGBA5551 format color</returns>
        public static ushort ToRGBA5551(Color c)
        {
            byte r = (byte)((c.R >> 3) & 0x1F);
            byte g = (byte)((c.G >> 3) & 0x1F);
            byte b = (byte)((c.B >> 3) & 0x1F);
            byte a;
            if (c.A > 0x7F)
            {
                a = 1;
            }
            else
            {
                a = 0;
            }
            return (ushort)((r << 11) | (g << 6) | (b << 1) | a);
        }

        /// <summary>
        /// Convert a RGBA5551 to <see cref="Color"/> format.
        /// </summary>
        /// <param name="c">RGBA5551 color</param>
        /// <returns>Color</returns>
        public static Color FromRGBA5551(ushort c)
        {
            float r = (c & 0xF800) >> 11;
            float g = (c & 0x7C0) >> 6;
            float b = (c & 0x3E) >> 1;
            int a = (c & 1) * 255;
            return Color.FromArgb(a, (int)(r * 255.0f / 31.0f), (int)(g * 255.0f / 31.0f), (int)(b * 255.0f / 31.0f));
        }

    }

}