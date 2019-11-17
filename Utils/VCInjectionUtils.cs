using MMRando.Asm;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MMRando.Utils
{
    /// <summary>
    /// Controller button flags for Virtual Console.
    /// </summary>
    public enum VCControllerButton : ushort
    {
        DPadUp = 0x800,
        DPadDown = 0x400,
        DPadLeft = 0x200,
        DPadRight = 0x100,
        L = 0x20,
    }

    public class VCInjectionUtils
    {
        /// <summary>
        /// Offset into decompressed App1 file which contains the D-Pad mapping.
        /// </summary>
        static readonly int DPAD_MAPPING_OFFSET = 0x148512;

        private static void GetApp5(byte[] ROM, string VCDir)
        {
            BinaryReader a50 = new BinaryReader(File.Open(VCDir + "5-0", FileMode.Open));
            BinaryReader a51 = new BinaryReader(File.Open(VCDir + "5-1", FileMode.Open));
            BinaryWriter app5 = new BinaryWriter(File.Open(VCDir + "00000005.app", FileMode.Create));
            byte[] buffer = new byte[a50.BaseStream.Length];
            a50.Read(buffer, 0, buffer.Length);
            app5.Write(buffer);
            app5.Write(ROM);
            buffer = new byte[a51.BaseStream.Length];
            a51.Read(buffer, 0, buffer.Length);
            app5.Write(buffer);
            a50.Close();
            a51.Close();
            app5.Close();
        }

        private static byte[] AddVCHeader(byte[] ROM)
        {
            byte[] Header = new byte[] { 0x08, 0x00, 0x00, 0x00 };
            return Header.Concat(ROM).ToArray();
        }

        public static void BuildVC(byte[] ROM, PatcherOptions options, string VCDir, string FileName)
        {
            ROM = AddVCHeader(ROM);
            GetApp5(ROM, VCDir);
            PatchApp1(options.DPadConfig, VCDir);
            ProcessStartInfo p = new ProcessStartInfo
            {
                FileName = "wadpacker.exe",
                Arguments = "mm.tik mm.tmd mm.cert \"" + FileName + "\" -i NMRE",
                WorkingDirectory = VCDir
            };
            Process.Start(p);
        }

        /// <summary>
        /// Patch app file to map D-Pad directions. This assumes the app file is decompressed.
        /// </summary>
        /// <param name="config">D-Pad configuration</param>
        /// <param name="VCDir">VC directory</param>
        private static void PatchApp1(DPadConfig config, string VCDir)
        {
            using (var app1 = new BinaryWriter(File.Open(VCDir + "00000001.app", FileMode.Open)))
            {
                var used = config.InUse;
                var buttons = new VCControllerButton[]
                {
                    VCControllerButton.DPadUp,
                    VCControllerButton.DPadDown,
                    VCControllerButton.DPadLeft,
                    VCControllerButton.DPadRight,
                };

                // Fix array for ordering of the fields in app file: Up, Down, Left, Right
                used = new bool[] { used[0], used[2], used[3], used[1] };

                for (int i = 0; i < used.Length; i++)
                {
                    int offset = DPAD_MAPPING_OFFSET + (i * 4);
                    app1.Seek(offset, SeekOrigin.Begin);

                    if (used[i])
                    {
                        // If using this D-Pad direction, write its button flag
                        ReadWriteUtils.WriteU32(app1, (uint)buttons[i]);
                    }
                    else
                    {
                        // Otherwise write the button flag for the L button
                        ReadWriteUtils.WriteU32(app1, (uint)VCControllerButton.L);
                    }
                }
            }
        }
    }
}
