using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MMRando
{

    public partial class mmrMain
    {

        private void WriteAudioSeq()
        {
            if (!cBGM.Checked)
            {
                return;
            }
            foreach (SeqInfo s in SeqList)
            {
                s.Name = MusicDir + s.Name;
            }
            ROMFuncs.ApplyHack(ModsDir + "fix-music");
            ROMFuncs.ApplyHack(ModsDir + "inst24-swap-guitar");
            ROMFuncs.RebuildAudioSeq(SeqList);
        }

        private void WriteLinkAppearance()
        {
            if (cLink.SelectedIndex == 0)
            {
                WriteTunicColour();
            }
            else if (cLink.SelectedIndex < 4)
            {
                int i = cLink.SelectedIndex;
                BinaryReader b = new BinaryReader(File.Open(ObjsDir + "link-" + i.ToString(), FileMode.Open));
                byte[] obj = new byte[b.BaseStream.Length];
                b.Read(obj, 0, obj.Length);
                b.Close();
                if (i < 3)
                {
                    WriteTunicColour(obj, i);
                }
                ROMFuncs.ApplyHack(ModsDir + "fix-link-" + i.ToString());
                ROMFuncs.InsertObj(obj, 0x11);
                if (i == 3)
                {
                    b = new BinaryReader(File.Open(ObjsDir + "kafei", FileMode.Open));
                    obj = new byte[b.BaseStream.Length];
                    b.Read(obj, 0, obj.Length);
                    b.Close();
                    WriteTunicColour(obj, i);
                    ROMFuncs.InsertObj(obj, 0x1C);
                    ROMFuncs.ApplyHack(ModsDir + "fix-kafei");
                }
            }
            List<int[]> Others = ROMFuncs.GetAddresses(AddrsDir + "tunic-forms");
            ROMFuncs.UpdateFormTunics(Others, bTunic.BackColor);
        }

        private void WriteTunicColour()
        {
            Color t = bTunic.BackColor;
            byte[] c = { t.R, t.G, t.B };
            List<int[]> locs = ROMFuncs.GetAddresses(AddrsDir + "tunic-colour");
            for (int i = 0; i < locs.Count; i++)
            {
                ROMFuncs.WriteROMAddr(locs[i], c);
            }
        }

        private void WriteTunicColour(byte[] obj, int i)
        {
            Color t = bTunic.BackColor;
            byte[] c = { t.R, t.G, t.B };
            List<int[]> locs = ROMFuncs.GetAddresses(AddrsDir + "tunic-" + i.ToString());
            for (int j = 0; j < locs.Count; j++)
            {
                ROMFuncs.WriteFileAddr(locs[j], c, obj);
            }
        }

        private void WriteTatlColour()
        {
            if (cTatl.SelectedIndex != 5)
            {
                byte[] c = new byte[8];
                List<int[]> locs = ROMFuncs.GetAddresses(AddrsDir + "tatl-colour");
                for (int i = 0; i < locs.Count; i++)
                {
                    ROMFuncs.Arr_WriteU32(c, 0, TATL_COLOURS[cTatl.SelectedIndex, i << 1]);
                    ROMFuncs.Arr_WriteU32(c, 4, TATL_COLOURS[cTatl.SelectedIndex, (i << 1) + 1]);
                    ROMFuncs.WriteROMAddr(locs[i], c);
                }
            }
            else
            {
                ROMFuncs.ApplyHack(ModsDir + "rainbow-tatl");
            }
        }

        private void WriteQuickText()
        {
            if (cQText.Checked)
            {
                ROMFuncs.ApplyHack(ModsDir + "quick-text");
            }
        }

        private void WriteCutscenes()
        {
            if (cCutsc.Checked)
            {
                ROMFuncs.ApplyHack(ModsDir + "short-cutscenes");
            }
        }

        private void WriteDungeons()
        {
            if ((cMode.SelectedIndex == 2) || (!cDEnt.Checked))
            {
                return;
            }
            ROMFuncs.WriteEntrances(ENTRANCE_OLD, ENTRANCE_NEW);
            ROMFuncs.WriteEntrances(EXIT_OLD, EXIT_NEW);
            byte[] li = new byte[] { 0x24, 0x02, 0x00, 0x00 };
            List<int[]> addr = new List<int[]>();
            addr = ROMFuncs.GetAddresses(AddrsDir + "d-check");
            for (int i = 0; i < addr.Count; i++)
            {
                li[3] = (byte)NewExts[i];
                ROMFuncs.WriteROMAddr(addr[i], li);
            }
            ROMFuncs.ApplyHack(ModsDir + "fix-dungeons");
            addr = ROMFuncs.GetAddresses(AddrsDir + "d-exit");
            for (int i = 0; i < addr.Count; i++)
            {
                if (i == 2)
                {
                    ROMFuncs.WriteROMAddr(addr[i], new byte[] { (byte)((EXIT_OLD[NewEnts[i + 1]] & 0xFF00) >> 8), (byte)(EXIT_OLD[NewEnts[i + 1]] & 0xFF) });
                }
                else
                {
                    ROMFuncs.WriteROMAddr(addr[i], new byte[] { (byte)((EXIT_OLD[NewEnts[i]] & 0xFF00) >> 8), (byte)(EXIT_OLD[NewEnts[i]] & 0xFF) });
                }
            }
            addr = ROMFuncs.GetAddresses(AddrsDir + "dc-flagload");
            for (int i = 0; i < addr.Count; i++)
            {
                ROMFuncs.WriteROMAddr(addr[i], new byte[] { (byte)((DC_FLAG_NEW[i] & 0xFF00) >> 8), (byte)(DC_FLAG_NEW[i] & 0xFF) });
            }
            addr = ROMFuncs.GetAddresses(AddrsDir + "dc-flagmask");
            for (int i = 0; i < addr.Count; i++)
            {
                ROMFuncs.WriteROMAddr(addr[i], new byte[] { (byte)((DC_MASK_NEW[i] & 0xFF00) >> 8), (byte)(DC_MASK_NEW[i] & 0xFF) });
            }
        }

        private void WriteGimmicks()
        {
            int i = cDMult.SelectedIndex;
            if (i > 0)
            {
                ROMFuncs.ApplyHack(ModsDir + "dm-" + i.ToString());
            }
            i = cDType.SelectedIndex;
            if (i > 0)
            {
                ROMFuncs.ApplyHack(ModsDir + "de-" + i.ToString());
            }
            i = cGravity.SelectedIndex;
            if (i > 0)
            {
                ROMFuncs.ApplyHack(ModsDir + "movement-" + i.ToString());
            }
            i = cFloors.SelectedIndex;
            if (i > 0)
            {
                ROMFuncs.ApplyHack(ModsDir + "floor-" + i.ToString());
            }
        }

        private void WriteEnemies()
        {
            if (cEnemy.Checked)
            {
                SeedRNG();
                ROMFuncs.ShuffleEnemies(RNG);
            }
        }

        private void WriteFreeItem(int Item)
        {
            ROMFuncs.WriteToROM(ITEM_ADDRS[Item], ITEM_VALUES[Item]);
            switch (Item)
            {
                case 1: //bow
                    ROMFuncs.WriteToROM(0xC5CE6F, (byte)0x01);
                    break;
                case 5: //bomb bag
                    ROMFuncs.WriteToROM(0xC5CE6F, (byte)0x08);
                    break;
                case 19: //sword upgrade
                    ROMFuncs.WriteToROM(0xC5CE00, (byte)0x4E);
                    break;
                case 20:
                    ROMFuncs.WriteToROM(0xC5CE00, (byte)0x4F);
                    break;
                case 22: //quiver upgrade
                    ROMFuncs.WriteToROM(0xC5CE6F, (byte)0x02);
                    break;
                case 23:
                    ROMFuncs.WriteToROM(0xC5CE6F, (byte)0x03);
                    break;
                case 24://bomb bag upgrade
                    ROMFuncs.WriteToROM(0xC5CE6F, (byte)0x10);
                    break;
                case 25:
                    ROMFuncs.WriteToROM(0xC5CE6F, (byte)0x18);
                    break;
                default:
                    break;
            }
        }

        private void WriteItems()
        {
            if (cMode.SelectedIndex == 2)
            {
                WriteFreeItem(Deku_Mask);
                if (cCutsc.Checked)
                {
                    //giants cs were removed
                    WriteFreeItem(Song_Oath);
                }
                return;
            }
            //write free item
            int j = ItemList.FindIndex(u => u.Replaces == 0);
            WriteFreeItem(ItemList[j].ID);
            //write everything else
            ROMFuncs.ReplaceGetItemTable(ModsDir);
            ROMFuncs.InitItems();
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].Replaces == -1)
                {
                    continue;
                }
                j = ItemList[i].ID;
                bool repeat = REPEATABLE.Contains(j);
                bool cycle = CYCLE_REPEATABLE.Contains(j);
                int r = ItemList[i].Replaces;
                if (j > IST_NEW) { j -= 23; }
                if (r > IST_NEW) { r -= 23; }
                if ((i >= B_Fairy) && (i <= B_Mushroom))
                {
                    ROMFuncs.WriteNewBottle(r, j);
                }
                else
                {
                    ROMFuncs.WriteNewItem(r, j, repeat, cycle);
                }
            }
            if (Shops)
            {
                ROMFuncs.ApplyHack(ModsDir + "fix-shop-checks");
            }
        }

        private void WriteGossipQuotes()
        {
            if (cMode.SelectedIndex == 2)
            {
                return;
            }
            if (cGossip.Checked)
            {
                SeedRNG();
                ROMFuncs.WriteGossipMsg(GossipQuotes, RNG);
            }
        }

        private void WriteSpoilerLog()
        {
            if (cMode.SelectedIndex == 2)
            {
                return;
            }
            if (cSpoiler.Checked)
            {
                MakeSpoilerLog();
            }
        }

        private void WriteFileSelect()
        {
            if (cMode.SelectedIndex == 2)
            {
                return;
            }
            ROMFuncs.ApplyHack(ModsDir + "file-select");
            byte[] SkyboxDefault = new byte[] { 0x91, 0x78, 0x9B, 0x28, 0x00, 0x28 };
            List<int[]> Addrs = ROMFuncs.GetAddresses(AddrsDir + "skybox-init");
            Random R = new Random();
            int rot = R.Next(360);
            for (int i = 0; i < 2; i++)
            {
                Color c = Color.FromArgb(SkyboxDefault[i * 3], SkyboxDefault[i * 3 + 1], SkyboxDefault[i * 3 + 2]);
                float h = c.GetHue();
                h += rot;
                h %= 360f;
                c = ROMFuncs.FromAHSB(c.A, h, c.GetSaturation(), c.GetBrightness());
                SkyboxDefault[i * 3] = c.R;
                SkyboxDefault[i * 3 + 1] = c.G;
                SkyboxDefault[i * 3 + 2] = c.B;
            }
            for (int i = 0; i < 3; i++)
            {
                ROMFuncs.WriteROMAddr(Addrs[i], new byte[] { SkyboxDefault[i * 2], SkyboxDefault[i * 2 + 1] });
            }
            rot = R.Next(360);
            byte[] FSDefault = new byte[] { 0x64, 0x96, 0xFF, 0x96, 0xFF, 0xFF, 0x64, 0xFF, 0xFF };
            Addrs = ROMFuncs.GetAddresses(AddrsDir + "fs-colour");
            for (int i = 0; i < 3; i++)
            {
                Color c = Color.FromArgb(FSDefault[i * 3], FSDefault[i * 3 + 1], FSDefault[i * 3 + 2]);
                float h = c.GetHue();
                h += rot;
                h %= 360f;
                c = ROMFuncs.FromAHSB(c.A, h, c.GetSaturation(), c.GetBrightness());
                FSDefault[i * 3] = c.R;
                FSDefault[i * 3 + 1] = c.G;
                FSDefault[i * 3 + 2] = c.B;
            }
            for (int i = 0; i < 9; i++)
            {
                if (i < 6)
                {
                    ROMFuncs.WriteROMAddr(Addrs[i], new byte[] { 0x00, FSDefault[i]});
                }
                else
                {
                    ROMFuncs.WriteROMAddr(Addrs[i], new byte[] { FSDefault[i] });
                }
            }
        }

        private void WriteStartupStrings()
        {
            if (cMode.SelectedIndex == 2)
            {
                //ROMFuncs.ApplyHack(ModsDir + "postman-testing");
                return;
            }
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            ROMFuncs.SetStrings(ModsDir + "logo-text", $"v{v.Major}.{v.Minor}b", tSString.Text);
        }

        private bool ValidateROM(string FileName)
        {
            bool res = false;
            using (BinaryReader ROM = new BinaryReader(File.Open(FileName, FileMode.Open, FileAccess.Read)))
            {
                if (ROM.BaseStream.Length == 0x2000000)
                {
                    res = ROMFuncs.CheckOldCRC(ROM);
                }
            }
            return res;
        }

        private void MakeROM(string InFile, string FileName)
        {
            using (BinaryReader OldROM = new BinaryReader(File.Open(InFile, FileMode.Open, FileAccess.Read)))
            {
                ROMFuncs.ReadFileTable(OldROM);
            }
            WriteAudioSeq();
            WriteLinkAppearance();
            if (cMode.SelectedIndex != 2)
            {
                ROMFuncs.ApplyHack(ModsDir + "title-screen");
                ROMFuncs.ApplyHack(ModsDir + "misc-changes");
                ROMFuncs.ApplyHack(ModsDir + "cm-cs");
                WriteFileSelect();
            }
            ROMFuncs.ApplyHack(ModsDir + "init-file");
            WriteQuickText();
            WriteCutscenes();
            WriteTatlColour();
            WriteDungeons();
            WriteGimmicks();
            WriteEnemies();
            WriteItems();
            WriteGossipQuotes();
            WriteStartupStrings();
            WriteSpoilerLog();
            byte[] ROM = ROMFuncs.BuildROM(FileName);
            if (Output_VC)
            {
                string VCFileName = saveWad.FileName;
                ROMFuncs.BuildVC(ROM, VCDir, VCFileName);
            }
        }

    }

}