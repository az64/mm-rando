using MMR.Randomizer.Models;
using MMR.Randomizer.Models.Settings;
using MMR.Randomizer.Utils;
using System;

namespace MMR.Randomizer
{
    public static class SettingsProcessor
    {
        public static string Process(SettingsObject settings, IProgressReporter progressReporter)
        {
            var randomizer = new Randomizer(settings);
            RandomizedResult randomized;
            if (string.IsNullOrWhiteSpace(settings.InputPatchFilename))
            {
                try
                {
                    randomized = randomizer.Randomize(progressReporter);
                }
                catch (RandomizationException ex)
                {
                    string nl = Environment.NewLine;
                    return $"Error randomizing logic: {ex.Message}{nl}{nl}Please try a different seed";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                if (settings.GenerateSpoilerLog
                    && settings.LogicMode != LogicMode.Vanilla)
                {
                    SpoilerUtils.CreateSpoilerLog(randomized, settings);
                }
            }
            else
            {
                randomized = new RandomizedResult(settings, null);
            }

            if (settings.GenerateROM || settings.OutputVC || settings.GeneratePatch)
            {
                if (!RomUtils.ValidateROM(settings.InputROMFilename))
                {
                    return "Cannot verify input ROM is Majora's Mask (U).";
                }

                var builder = new Builder(randomized);

                try
                {
                    builder.MakeROM(settings.InputROMFilename, settings.OutputROMFilename, progressReporter);
                }
                catch (PatchMagicException)
                {
                    return $"Error applying patch: Not a valid patch file";
                }
                catch (PatchVersionException ex)
                {
                    return $"Error applying patch: {ex.Message}";
                }
                catch (Exception ex)
                {
                    string nl = Environment.NewLine;
                    return $"Error building ROM: {ex.Message}{nl}{nl}Please contact the development team and provide them more information";
                }
            }

            //settings.InputPatchFilename = null;

            return null;
            //return "Generation complete!";
        }
    }

    public interface IProgressReporter
    {
        void ReportProgress(int percentProgress, string message);
    }
}
