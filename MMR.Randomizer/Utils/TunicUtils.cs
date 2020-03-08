using System;
using System.Collections.Generic;
using System.Drawing;

namespace MMR.Randomizer.Utils
{

    public class TunicUtils
    {

        static int[] paletteSize = new int[] { 14, 128, 33, 512, 16 };
        static bool[] isGradientImage = new bool[] { false, false, false, true, false };
        static bool[] isZora = new bool[] { false, false, true, true, false };
        static bool[] isFierceDeity = new bool[] { false, false, false, false, true };

        /// <summary>
        /// Perform a linear interpolation of a function's value between two known points.
        /// </summary>
        /// <param name="y0">Value of function at position x0</param>
        /// <param name="y1">Value of function at position x1</param>
        /// <param name="x0">Position of x0</param>
        /// <param name="x1">Position of x1</param>
        /// <param name="x">Position to interpolate at</param>
        /// <returns>Interpolated function value at x</returns>
        private static float Interpolate(float y0, float y1, float x0, float x1, float x)
        {
            if (x0 == x1)
            {
                return y0;
            }
            else
            {
                return y0 * ((x1 - x) / (x1 - x0)) + y1 * ((x - x0) / (x1 - x0));
            }
        }

        private static Color[] ShiftHue(Color[] colorArray, Color targetColor, int count, Color averageColor)
        {
            Color[] shiftedColors = new Color[count];
            float targetHue = targetColor.GetHue();
            float hueRotation = targetHue - averageColor.GetHue();
            float averageBrightness = averageColor.GetBrightness();
            float averageSaturation = averageColor.GetSaturation();
            for (int i = 0; i < count; i++)
            {
                float hue = colorArray[i].GetHue();
                float brightness = colorArray[i].GetBrightness();
                float saturation = colorArray[i].GetSaturation();
                brightness -= averageBrightness;
                saturation -= averageSaturation;
                brightness += targetColor.GetBrightness();
                saturation += targetColor.GetSaturation();
                hue += hueRotation;
                ColorUtils.ValidateHSB(ref hue, ref saturation, ref brightness);
                float hueDifference = Math.Abs(targetHue - hue);
                if (hueDifference >= 90f)
                {
                    hue = targetHue;
                }
                shiftedColors[i] = ColorUtils.FromAHSB(colorArray[i].A, hue, saturation, brightness);
            }
            return shiftedColors;
        }

        private static Color[] ShiftHue(Color[] colorArray, Color targetColor, int count, bool isZora, bool isGradient, bool isFierceDeity)
        {
            Color[] shiftedColors = new Color[count];
            Color averageColor;
            if (isZora && !isGradient)
            {
                averageColor = ColorUtils.GetAverageColour(colorArray, 16);
            }
            else
            {
                averageColor = ColorUtils.GetAverageColour(colorArray, count);
            }
            float hueRotation = targetColor.GetHue() - averageColor.GetHue();
            float averageBrightness = averageColor.GetBrightness();
            float averageSaturation = averageColor.GetSaturation();
            for (int i = 0; i < count; i++)
            {
                if ((i == 12) && (count == 14))
                {
                    shiftedColors[i] = colorArray[i];
                    continue;
                }
                float hue = colorArray[i].GetHue();
                float brightness = colorArray[i].GetBrightness();
                float saturation = colorArray[i].GetSaturation();
                brightness -= averageBrightness;
                saturation -= averageSaturation;
                brightness += targetColor.GetBrightness();
                saturation += targetColor.GetSaturation();
                hue += hueRotation;
                if (isFierceDeity)
                {
                    saturation = targetColor.GetSaturation();
                    hue = targetColor.GetHue();
                }
                if (isZora && isGradient)
                {
                    if (i > 351)
                    {
                        float x0 = colorArray[352].GetBrightness();
                        float x1 = colorArray[511].GetBrightness();
                        float x = colorArray[i].GetBrightness();
                        hue = targetColor.GetHue();
                        saturation = targetColor.GetSaturation();
                        brightness = Interpolate(targetColor.GetBrightness(), colorArray[511].GetBrightness(), x0, x1, x);
                    }
                }
                ColorUtils.ValidateHSB(ref hue, ref saturation, ref brightness);
                shiftedColors[i] = ColorUtils.FromAHSB(colorArray[i].A, hue, saturation, brightness);
                //this code is a mess
                if (isZora && isGradient)
                {
                    if (i < 96)
                    {
                        shiftedColors[i] = colorArray[i];
                    }
                    else if (i < 352)
                    {
                        float x0 = colorArray[95].GetBrightness();
                        float x1 = colorArray[352].GetBrightness();
                        float x = colorArray[i].GetBrightness();
                        int rr = (int)Interpolate(colorArray[95].R, targetColor.R, x0, x1, x);
                        int gg = (int)Interpolate(colorArray[95].G, targetColor.G, x0, x1, x);
                        int bb = (int)Interpolate(colorArray[95].B, targetColor.B, x0, x1, x);
                        ColorUtils.ValidateRGB(ref rr, ref gg, ref bb);
                        shiftedColors[i] = Color.FromArgb(rr, gg, bb);
                    }
                }
                else if (isZora)
                {
                    if (i > 15)
                    {
                        float x0 = colorArray[14].GetBrightness();
                        float x1 = colorArray[31].GetBrightness();
                        float x = colorArray[i].GetBrightness();
                        int rr = (int)Interpolate(shiftedColors[14].R, colorArray[31].R, x0, x1, x);
                        int gg = (int)Interpolate(shiftedColors[14].G, colorArray[31].G, x0, x1, x);
                        int bb = (int)Interpolate(shiftedColors[14].B, colorArray[31].B, x0, x1, x);
                        ColorUtils.ValidateRGB(ref rr, ref gg, ref bb);
                        shiftedColors[i] = Color.FromArgb(rr, gg, bb);
                    }
                }
            }
            return shiftedColors;
        }

        private static Color[] ReadColours(int fileNumber, int addressInFile, int count)
        {
            Color[] colorArray = new Color[count];
            for (int i = 0; i < count; i++)
            {
                int colorAddress = addressInFile + (i * 2);
                ushort rgba = ReadWriteUtils.Arr_ReadU16(RomData.MMFileList[fileNumber].Data, colorAddress);
                colorArray[i] = ColorUtils.FromRGBA5551(rgba);
            }
            return colorArray;
        }

        private static void WriteColours(int fileNumber, int addressInFile, int count, Color[] colorArray)
        {
            for (int i = 0; i < count; i++)
            {
                int colorAddress = addressInFile + (i * 2);
                ushort rgba = ColorUtils.ToRGBA5551(colorArray[i]);
                var data = new byte[]
                {
                    (byte)(rgba >> 8),
                    (byte)(rgba & 0xFF),
                };
                ReadWriteUtils.Arr_Insert(data, 0, data.Length, RomData.MMFileList[fileNumber].Data, colorAddress);
            }
        }

        public static void UpdateFormTunics(List<int[]> addresses, Color targetColor)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                for (int j = 0; j < addresses[i].Length; j++)
                {
                    int fileInRom = RomUtils.GetFileIndexForWriting(addresses[i][j]);
                    int addressInFile = addresses[i][j] - RomData.MMFileList[fileInRom].Addr;
                    Color[] colorArray = ReadColours(fileInRom, addressInFile, paletteSize[i]);
                    colorArray = ShiftHue(colorArray, targetColor, paletteSize[i], isZora[i], isGradientImage[i], isFierceDeity[i]);
                    WriteColours(fileInRom, addressInFile, paletteSize[i], colorArray);
                }
            }
        }

        public static void UpdateKafeiTunic(ref byte[] objectData, Color targetColor)
        {
            int[] kafeiPaletteAddress = new int[] { 0xB538, 0xDF68, 0xDF68, 0xD1B0 };
            int[] hairPaletteAvoid = new int[] { 0, 4, 5, 6, 7, 9, 0xB, 0x14, 0x17, 0x18, 0x22, 0x23, 0x31, 0x32, 0x3E, 0x6B, 0x71, 0x8E, 0x100};
            var averageColour = new Color();
            for (int i = 0; i < 4; i++)
            {
                var colourMask = new bool[0x100];
                var coloursFound = new Color[0x100];
                var k = 0;
                for (int j = 0; j < 0x100; j++)
                {
                    var thisColour = ColorUtils.FromRGBA5551(ReadWriteUtils.Arr_ReadU16(objectData, kafeiPaletteAddress[i] + (j << 1)));
                    // separate palette colours used for hair/clothes or they won't adjust very well
                    if (i == 1)
                    {
                        if (j == hairPaletteAvoid[k])
                        {
                            colourMask[j] = true;
                            coloursFound[k] = thisColour;
                            k++;
                        };
                    }
                    else if (i == 2)
                    {
                        if (j != hairPaletteAvoid[j - k])
                        {
                            colourMask[j] = true;
                            coloursFound[k] = thisColour;
                            k++;
                        };
                    }
                    else if ((thisColour.B != 0) && ((thisColour.G == 0) || ((i != 0) && (thisColour.B > thisColour.G) && 
                            (thisColour.B > thisColour.R) && (thisColour.B + thisColour.R > 2.2 * thisColour.G))))
                    {
                        colourMask[j] = true;
                        coloursFound[k] = thisColour;
                        k++;
                    };
                };                
                if (i != 1)
                {
                    averageColour = ColorUtils.GetAverageColour(coloursFound, k);
                };
                coloursFound = ShiftHue(coloursFound, targetColor, k, averageColour);
                k = 0;
                for (int j = 0; j < 0x100; j++)
                {
                    if (colourMask[j])
                    {
                        ReadWriteUtils.Arr_WriteU16(objectData, kafeiPaletteAddress[i] + (j << 1), ColorUtils.ToRGBA5551(coloursFound[k]));
                        k++;
                    }
                }
            }
        }

    }

}