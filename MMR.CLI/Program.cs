using MMR.Randomizer.Models.Settings;
using MMR.Randomizer;
using MMR.Randomizer.GameObjects;
using System.Collections.Generic;
using System;
using MMR.Randomizer.Utils;
using System.Linq;
using MMR.Randomizer.Extensions;
using MMR.Common.Utils;
using System.IO;

namespace MMR.CLI
{
    partial class Program
    {
        static int Main(string[] args)
        {
            var argsDictionary = DictionaryHelper.FromProgramArguments(args);
            var settings = new GameplaySettings();
            var outputSettings = new OutputSettings();
            settings.Update("fz1mr--16psr-lc-f");
            settings.CustomItemListString = "81-80000000----3fff-ffffffff-ffffffff-fe000000-6619ff-7fffffff-f378ffff-ffffffff";
            settings.CustomItemList = ConvertIntString(settings.CustomItemListString);
            settings.CustomStartingItemListString = "-3fc04000-";
            settings.CustomStartingItemList = ConvertItemString(ItemUtils.StartingItems().Where(item => !item.Name().Contains("Heart")).ToList(), settings.CustomStartingItemListString);
            settings.CustomJunkLocationsString = "----------200000--f000";
            settings.CustomJunkLocations = ConvertItemString(ItemUtils.AllLocations().ToList(), settings.CustomJunkLocationsString);

            outputSettings.GeneratePatch = argsDictionary.ContainsKey("-patch");
            outputSettings.GenerateSpoilerLog = argsDictionary.ContainsKey("-spoiler");
            outputSettings.GenerateHTMLLog = argsDictionary.ContainsKey("-html");
            outputSettings.GenerateROM = argsDictionary.ContainsKey("-rom");

            int seed;
            if (argsDictionary.ContainsKey("-seed"))
            {
                seed = int.Parse(argsDictionary["-seed"][0]);
            }
            else
            {
                seed = new Random().Next();
            }

            var outputArg = argsDictionary.GetValueOrDefault("-output");
            if (outputArg != null)
            {
                if (outputArg.Count > 1)
                {
                    throw new ArgumentException("Invalid argument.", "-output");
                }
                outputSettings.OutputROMFilename = outputArg.SingleOrDefault();
            }
            outputSettings.OutputROMFilename ??= Path.Combine("output", FileUtils.MakeFilenameValid(DateTime.UtcNow.ToString("o")));

            var inputArg = argsDictionary.GetValueOrDefault("-input");
            if (inputArg != null)
            {
                if (inputArg.Count > 1)
                {
                    throw new ArgumentException("Invalid argument.", "-input");
                }
                outputSettings.InputROMFilename = inputArg.SingleOrDefault();
            }
            outputSettings.InputROMFilename ??= "input.z64";

            var validationResult = settings.Validate();
            if (validationResult != null)
            {
                Console.WriteLine(validationResult);
                return -1;
            }

            try
            {
                string result;
                using (var progressBar = new ProgressBar())
                {
                    //var progressReporter = new TextWriterProgressReporter(Console.Out);
                    var progressReporter = new ProgressBarProgressReporter(progressBar);
                    result = ConfigurationProcessor.Process(new Configuration
                    {
                        GameplaySettings = settings,
                        OutputSettings = outputSettings,
                    }, seed, progressReporter);
                }
                if (result != null)
                {
                    Console.Error.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Generation complete!");
                }
                return result == null ? 0 : -1;
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                Console.Error.Write(e.StackTrace);
                return -1;
            }
        }

        private static List<int> ConvertIntString(string c)
        {
            var result = new List<int>();
            try
            {
                result.Clear();
                string[] v = c.Split('-');
                int[] vi = new int[13];
                if (v.Length != vi.Length)
                {
                    result.Add(-1);
                    return null;
                }
                for (int i = 0; i < 13; i++)
                {
                    if (v[12 - i] != "")
                    {
                        vi[i] = Convert.ToInt32(v[12 - i], 16);
                    }
                }
                for (int i = 0; i < 32 * 13; i++)
                {
                    int j = i / 32;
                    int k = i % 32;
                    if (((vi[j] >> k) & 1) > 0)
                    {
                        if (i >= ItemUtils.AllLocations().Count())
                        {
                            throw new IndexOutOfRangeException();
                        }
                        result.Add(i);
                    }
                }
            }
            catch
            {
                result.Clear();
                result.Add(-1);
            }
            return result;
        }

        private static List<Item> ConvertItemString(List<Item> items, string c)
        {
            var sectionCount = (int)Math.Ceiling(items.Count / 32.0);
            var result = new List<Item>();
            try
            {
                result.Clear();
                string[] v = c.Split('-');
                int[] vi = new int[sectionCount];
                if (v.Length != vi.Length)
                {
                    //result.Add(-1);
                    return null;
                }
                for (int i = 0; i < sectionCount; i++)
                {
                    if (v[sectionCount - 1 - i] != "")
                    {
                        vi[i] = Convert.ToInt32(v[sectionCount - 1 - i], 16);
                    }
                }
                for (int i = 0; i < 32 * sectionCount; i++)
                {
                    int j = i / 32;
                    int k = i % 32;
                    if (((vi[j] >> k) & 1) > 0)
                    {
                        if (i >= items.Count)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        result.Add(items[i]);
                    }
                }
            }
            catch
            {
                result.Clear();
                //result.Add(-1);
            }
            return result;
        }
    }
}
