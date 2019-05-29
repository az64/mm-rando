using MMRando.Constants;
using MMRando.Models;
using MMRando.Models.Rom;
using MMRando.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MMRando
{

    public class Builder
    {
        private RandomizedResult _randomized;
        private Settings _settings;

        public Builder(RandomizedResult randomized)
        {
            _randomized = randomized;
            _settings = randomized.Settings;
        }

        private void WriteAudioSeq()
        {
            if (!_settings.RandomizeBGM)
            {
                return;
            }

            foreach (SequenceInfo s in RomData.SequenceList)
            {
                s.Name = Values.MusicDirectory + s.Name;
            }

            ResourceUtils.ApplyHack(Values.ModsDirectory + "fix-music");
            ResourceUtils.ApplyHack(Values.ModsDirectory + "inst24-swap-guitar");
            SequenceUtils.RebuildAudioSeq(RomData.SequenceList);
        }

        private void WritePlayerModel()
        {
            if (_settings.Character == Character.LinkMM)
            {
                return;
            }

            int characterIndex = (int)_settings.Character;

            using (var b = new BinaryReader(File.Open($"{Values.ObjsDirectory}link-{characterIndex}", FileMode.Open)))
            {
                var obj = new byte[b.BaseStream.Length];
                b.Read(obj, 0, obj.Length);

                ResourceUtils.ApplyHack($"{Values.ModsDirectory}fix-link-{characterIndex}");
                ObjUtils.InsertObj(obj, 0x11);
            }

            if (_settings.Character == Character.Kafei)
            {
                using (var b = new BinaryReader(File.Open($"{Values.ObjsDirectory}kafei", FileMode.Open)))
                {
                    var obj = new byte[b.BaseStream.Length];
                    b.Read(obj, 0, obj.Length);

                    ObjUtils.InsertObj(obj, 0x1C);
                    ResourceUtils.ApplyHack(Values.ModsDirectory + "fix-kafei");
                }
            }
        }

        private void WriteTunicColor()
        {
            Color t = _settings.TunicColor;
            byte[] color = { t.R, t.G, t.B };

            var otherTunics = ResourceUtils.GetAddresses(Values.AddrsDirectory + "tunic-forms");
            TunicUtils.UpdateFormTunics(otherTunics, _settings.TunicColor);

            var playerModel = DeterminePlayerModel();
            var characterIndex = (int)playerModel;
            var locations = ResourceUtils.GetAddresses($"{Values.AddrsDirectory}tunic-{characterIndex}");
            var objectIndex = playerModel == Character.Kafei ? 0x1C : 0x11;
            var objectData = ObjUtils.GetObjectData(objectIndex);
            for (int j = 0; j < locations.Count; j++)
            {
                ReadWriteUtils.WriteFileAddr(locations[j], color, objectData);
            }
            ObjUtils.InsertObj(objectData, objectIndex);
        }

        private Character DeterminePlayerModel()
        {
            var data = ObjUtils.GetObjectData(0x11);
            if (data[0x107] == 0x05)
            {
                return Character.LinkMM;
            }
            if (data[0x107] == 0x07)
            {
                return Character.LinkOOT;
            }
            if (data[0xC6] == 0x02)
            {
                return Character.AdultLink;
            }
            if (data[0xC5] == 0x15)
            {
                return Character.Kafei;
            }
            throw new InvalidOperationException("Unable to determine player's model.");
        }

        private void WriteTatlColour()
        {
            if (_settings.TatlColorSchema != TatlColorSchema.Random)
            {
                var selectedColorSchemaIndex = (int)_settings.TatlColorSchema;
                byte[] c = new byte[8];
                List<int[]> locs = ResourceUtils.GetAddresses(Values.AddrsDirectory + "tatl-colour");
                for (int i = 0; i < locs.Count; i++)
                {
                    ReadWriteUtils.Arr_WriteU32(c, 0, Values.TatlColours[selectedColorSchemaIndex, i << 1]);
                    ReadWriteUtils.Arr_WriteU32(c, 4, Values.TatlColours[selectedColorSchemaIndex, (i << 1) + 1]);
                    ReadWriteUtils.WriteROMAddr(locs[i], c);
                }
            }
            else
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "rainbow-tatl");
            }
        }

        private void WriteQuickText()
        {
            if (_settings.QuickTextEnabled)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "quick-text");
            }
        }

        private void WriteCutscenes()
        {
            if (_settings.ShortenCutscenes)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "short-cutscenes");
            }
        }

        private void WriteDungeons()
        {
            if ((_settings.LogicMode == LogicMode.Vanilla) || (!_settings.RandomizeDungeonEntrances))
            {
                return;
            }

            EntranceUtils.WriteEntrances(Values.OldEntrances.ToArray(), _randomized.NewEntrances);
            EntranceUtils.WriteEntrances(Values.OldExits.ToArray(), _randomized.NewExits);
            byte[] li = new byte[] { 0x24, 0x02, 0x00, 0x00 };
            List<int[]> addr = new List<int[]>();
            addr = ResourceUtils.GetAddresses(Values.AddrsDirectory + "d-check");
            for (int i = 0; i < addr.Count; i++)
            {
                li[3] = (byte)_randomized.NewExitIndices[i];
                ReadWriteUtils.WriteROMAddr(addr[i], li);
            }

            ResourceUtils.ApplyHack(Values.ModsDirectory + "fix-dungeons");
            addr = ResourceUtils.GetAddresses(Values.AddrsDirectory + "d-exit");

            for (int i = 0; i < addr.Count; i++)
            {
                if (i == 2)
                {
                    ReadWriteUtils.WriteROMAddr(addr[i], new byte[] {
                        (byte)((Values.OldExits[_randomized.NewDestinationIndices[i + 1]] & 0xFF00) >> 8),
                        (byte)(Values.OldExits[_randomized.NewDestinationIndices[i + 1]] & 0xFF) });
                }
                else
                {
                    ReadWriteUtils.WriteROMAddr(addr[i], new byte[] {
                        (byte)((Values.OldExits[_randomized.NewDestinationIndices[i]] & 0xFF00) >> 8),
                        (byte)(Values.OldExits[_randomized.NewDestinationIndices[i]] & 0xFF) });
                }
            }

            addr = ResourceUtils.GetAddresses(Values.AddrsDirectory + "dc-flagload");
            for (int i = 0; i < addr.Count; i++)
            {
                ReadWriteUtils.WriteROMAddr(addr[i], new byte[] { (byte)((_randomized.NewDCFlags[i] & 0xFF00) >> 8), (byte)(_randomized.NewDCFlags[i] & 0xFF) });
            }

            addr = ResourceUtils.GetAddresses(Values.AddrsDirectory + "dc-flagmask");
            for (int i = 0; i < addr.Count; i++)
            {
                ReadWriteUtils.WriteROMAddr(addr[i], new byte[] {
                    (byte)((_randomized.NewDCMasks[i] & 0xFF00) >> 8),
                    (byte)(_randomized.NewDCMasks[i] & 0xFF) });
            }
        }

        private void WriteGimmicks()
        {
            int damageMultiplier = (int)_settings.DamageMode;
            if (damageMultiplier > 0)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "dm-" + damageMultiplier.ToString());
            }

            int damageEffect = (int)_settings.DamageEffect;
            if (damageEffect > 0)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "de-" + damageEffect.ToString());
            }

            int gravityType = (int)_settings.MovementMode;
            if (gravityType > 0)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "movement-" + gravityType.ToString());
            }

            int floorType = (int)_settings.FloorType;
            if (floorType > 0)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "floor-" + floorType.ToString());
            }

            if(_settings.ClockSpeed != Values.VanillaClockSpeed)
            {
                WriteClockSpeed(_settings.ClockSpeed);
            }
        }

        /// <summary>
        /// Overwrite the clockspeed (see Settings.ClockSpeed for details)
        /// </summary>
        /// <param name="clockSpeed"></param>
        private void WriteClockSpeed(byte clockSpeed)
        {
            var addr = 0x00BC66D4;
            uint val = 0x240B0000 + (uint)clockSpeed;
            ReadWriteUtils.WriteToROM(addr, val);
        }

        /// <summary>
        /// Update the gossip stone actor to not check mask of truth
        /// </summary>
        private void WriteFreeHints()
        {
            int address = 0x00E0A810 + 0x378;
            byte val = 0x00;
            ReadWriteUtils.WriteToROM(address, val);
        }

        private void WriteEnemies()
        {
            if (_settings.RandomizeEnemies)
            {
                Enemies.ShuffleEnemies(_randomized.Random);
            }
        }

        private void WriteFreeItem(int Item)
        {
            ReadWriteUtils.WriteToROM(Items.ITEM_ADDRS[Item], Items.ITEM_VALUES[Item]);
            switch (Item)
            {
                case Items.ItemBow:
                    ReadWriteUtils.WriteToROM(0xC5CE6F, (byte)0x01);
                    break;
                case Items.ItemBombBag:
                    ReadWriteUtils.WriteToROM(0xC5CE6F, (byte)0x08);
                    break;
                case Items.UpgradeRazorSword: //sword upgrade
                    ReadWriteUtils.WriteToROM(0xC5CE00, (byte)0x4E);
                    break;
                case Items.UpgradeGildedSword:
                    ReadWriteUtils.WriteToROM(0xC5CE00, (byte)0x4F);
                    break;
                case Items.UpgradeBigQuiver: //quiver upgrade
                    ReadWriteUtils.WriteToROM(0xC5CE6F, (byte)0x02);
                    break;
                case Items.UpgradeBiggestQuiver:
                    ReadWriteUtils.WriteToROM(0xC5CE6F, (byte)0x03);
                    break;
                case Items.UpgradeBigBombBag://bomb bag upgrade
                    ReadWriteUtils.WriteToROM(0xC5CE6F, (byte)0x10);
                    break;
                case Items.UpgradeBiggestBombBag:
                    ReadWriteUtils.WriteToROM(0xC5CE6F, (byte)0x18);
                    break;
                default:
                    break;
            }
        }

        private void WriteItems()
        {
            if (_settings.LogicMode == LogicMode.Vanilla)
            {
                WriteFreeItem(Items.MaskDeku);

                if (_settings.ShortenCutscenes)
                {
                    //giants cs were removed
                    WriteFreeItem(Items.SongOath);
                }

                return;
            }

            //write free item (start item default = Deku Mask)
            var freeItemIndex = _randomized.ItemList.FindIndex(u => u.ReplacesItemId == Items.MaskDeku);
            WriteFreeItem(_randomized.ItemList[freeItemIndex].ID);

            //write everything else
            ItemSwapUtils.ReplaceGetItemTable(Values.ModsDirectory);
            ItemSwapUtils.InitItems();

            for (int i = 0; i < _randomized.ItemList.Count; i++)
            {
                var itemId = _randomized.ItemList[i].ID;

                // Unused item
                if (_randomized.ItemList[i].ReplacesItemId == -1)
                {
                    continue;
                };

                bool isRepeatable = Items.REPEATABLE.Contains(itemId);
                bool isCycleRepeatable = Items.CYCLE_REPEATABLE.Contains(itemId);
                int replacesItemId = _randomized.ItemList[i].ReplacesItemId;

                Debug.WriteLine($"Writing {Items.ITEM_NAMES[itemId]} --> {Items.ITEM_NAMES[replacesItemId]}");

                itemId = ItemUtils.SubtractItemOffset(itemId);

                replacesItemId = ItemUtils.SubtractItemOffset(replacesItemId);

                if (ItemUtils.IsBottleCatchContent(i))
                {
                    ItemSwapUtils.WriteNewBottle(replacesItemId, itemId);
                }
                else
                {
                    ItemSwapUtils.WriteNewItem(replacesItemId, itemId, isRepeatable, isCycleRepeatable);
                }
            }

            if (_settings.AddShopItems)
            {
                ResourceUtils.ApplyHack(Values.ModsDirectory + "fix-shop-checks");
            }
        }

        private void WriteGossipQuotes()
        {
            if (_settings.LogicMode == LogicMode.Vanilla)
            {
                return;
            }

            if (_settings.FreeHints)
            {
                WriteFreeHints();
            }

            if (_settings.EnableGossipHints)
            {
                MessageUtils.WriteGossipHints(_randomized.GossipQuotes, _randomized.Random);
            }
        }


        private void WriteFileSelect()
        {
            ResourceUtils.ApplyHack(Values.ModsDirectory + "file-select");
            byte[] SkyboxDefault = new byte[] { 0x91, 0x78, 0x9B, 0x28, 0x00, 0x28 };
            List<int[]> Addrs = ResourceUtils.GetAddresses(Values.AddrsDirectory + "skybox-init");
            Random R = new Random();
            int rot = R.Next(360);
            for (int i = 0; i < 2; i++)
            {
                Color c = Color.FromArgb(SkyboxDefault[i * 3], SkyboxDefault[i * 3 + 1], SkyboxDefault[i * 3 + 2]);
                float h = c.GetHue();
                h += rot;
                h %= 360f;
                c = ColorUtils.FromAHSB(c.A, h, c.GetSaturation(), c.GetBrightness());
                SkyboxDefault[i * 3] = c.R;
                SkyboxDefault[i * 3 + 1] = c.G;
                SkyboxDefault[i * 3 + 2] = c.B;
            }

            for (int i = 0; i < 3; i++)
            {
                ReadWriteUtils.WriteROMAddr(Addrs[i], new byte[] { SkyboxDefault[i * 2], SkyboxDefault[i * 2 + 1] });
            }

            rot = R.Next(360);
            byte[] FSDefault = new byte[] { 0x64, 0x96, 0xFF, 0x96, 0xFF, 0xFF, 0x64, 0xFF, 0xFF };
            Addrs = ResourceUtils.GetAddresses(Values.AddrsDirectory + "fs-colour");
            for (int i = 0; i < 3; i++)
            {
                Color c = Color.FromArgb(FSDefault[i * 3], FSDefault[i * 3 + 1], FSDefault[i * 3 + 2]);
                float h = c.GetHue();
                h += rot;
                h %= 360f;
                c = ColorUtils.FromAHSB(c.A, h, c.GetSaturation(), c.GetBrightness());
                FSDefault[i * 3] = c.R;
                FSDefault[i * 3 + 1] = c.G;
                FSDefault[i * 3 + 2] = c.B;
            }
            for (int i = 0; i < 9; i++)
            {
                if (i < 6)
                {
                    ReadWriteUtils.WriteROMAddr(Addrs[i], new byte[] { 0x00, FSDefault[i] });
                }
                else
                {
                    ReadWriteUtils.WriteROMAddr(Addrs[i], new byte[] { FSDefault[i] });
                }
            }
        }

        private void WriteStartupStrings()
        {
            if (_settings.LogicMode == LogicMode.Vanilla)
            {
                //ResourceUtils.ApplyHack(ModsDir + "postman-testing");
                return;
            }
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            RomUtils.SetStrings(Values.ModsDirectory + "logo-text", $"v{v}", _settings.ToString());
        }

        public void MakeROM(string InFile, string FileName, BackgroundWorker worker)
        {
            using (BinaryReader OldROM = new BinaryReader(File.Open(InFile, FileMode.Open, FileAccess.Read)))
            {
                RomUtils.ReadFileTable(OldROM);
            }

            List<MMFile> originalMMFileList = null;
            if (_settings.GeneratePatch)
            {
                originalMMFileList = RomData.MMFileList.Select(file => file.Clone()).ToList();
            }

            if (!string.IsNullOrWhiteSpace(_settings.InputPatchFilename))
            {
                worker.ReportProgress(50, "Applying patch...");
                RomUtils.ApplyPatch(_settings.InputPatchFilename);
            }
            else
            {
                // todo music randomizer doesn't work if this is called after WriteItems(); because the reloc-audio hack is hardcoded
                worker.ReportProgress(50, "Writing audio...");
                WriteAudioSeq();

                worker.ReportProgress(55, "Writing player model...");
                WritePlayerModel();

                if (_settings.LogicMode != LogicMode.Vanilla)
                {
                    worker.ReportProgress(60, "Applying hacks...");
                    ResourceUtils.ApplyHack(Values.ModsDirectory + "title-screen");
                    ResourceUtils.ApplyHack(Values.ModsDirectory + "misc-changes");
                    ResourceUtils.ApplyHack(Values.ModsDirectory + "cm-cs");
                    WriteFileSelect();
                }
                ResourceUtils.ApplyHack(Values.ModsDirectory + "init-file");

                worker.ReportProgress(61, "Writing quick text...");
                WriteQuickText();

                worker.ReportProgress(62, "Writing cutscenes...");
                WriteCutscenes();

                worker.ReportProgress(63, "Writing dungeons...");
                WriteDungeons();

                worker.ReportProgress(64, "Writing gimmicks...");
                WriteGimmicks();

                worker.ReportProgress(65, "Writing enemies...");
                WriteEnemies();

                worker.ReportProgress(66, "Writing items...");
                WriteItems();

                worker.ReportProgress(67, "Writing gossip...");
                WriteGossipQuotes();

                worker.ReportProgress(68, "Writing startup...");
                WriteStartupStrings();

                ResourceUtils.ApplyHack(Values.ModsDirectory + "fierce-deity-anywhere");

                if (_settings.GeneratePatch)
                {
                    worker.ReportProgress(70, "Generating patch...");
                    RomUtils.CreatePatch(FileName, originalMMFileList);
                }
            }

            worker.ReportProgress(72, "Writing Tatl color...");
            WriteTatlColour();

            worker.ReportProgress(73, "Writing tunic color...");
            WriteTunicColor();

            if (_settings.GenerateROM)
            {
                worker.ReportProgress(75, "Building ROM...");

                byte[] ROM = RomUtils.BuildROM(FileName);
                if (_settings.OutputVC)
                {
                    worker.ReportProgress(90, "Building VC...");
                    VCInjectionUtils.BuildVC(ROM, Values.VCDirectory, Path.ChangeExtension(FileName, "wad"));
                }
            }
            worker.ReportProgress(100, "Done!");

        }

    }

}