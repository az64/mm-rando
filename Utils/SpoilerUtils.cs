using MMRando.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MMRando.Utils
{
    public static class SpoilerUtils
    {
        public static void CreateSpoilerLog(RandomizedResult randomized, Settings settings)
        {
            var itemList = randomized.ItemList
                .Where(u => u.ReplacesAnotherItem)
                .Select(u => new SpoilerItem(u)
                {
                    ReplacedById = randomized.ItemList.Single(i => i.ReplacesItemId == u.ID).ID
                })
                .ToList();
            var settingsString = settings.ToString();

            var directory = Path.GetDirectoryName(settings.OutputROMFilename);
            var filename = $"{Path.GetFileNameWithoutExtension(settings.OutputROMFilename)}";

            Spoiler spoiler = new Spoiler()
            {
                Version = MainForm.AssemblyVersion.Substring(26),
                SettingsString = settingsString,
                Seed = settings.Seed,
                RandomizeDungeonEntrances = settings.RandomizeDungeonEntrances,
                ItemList = itemList,
                NewDestinationIndices = randomized.NewDestinationIndices,
                Logic = randomized.Logic
            };

            if (settings.GenerateHTMLLog)
            {
                filename += "_SpoilerLog.html";
                using (StreamWriter newlog = new StreamWriter(Path.Combine(directory, filename)))
                {
                    Templates.HtmlSpoiler htmlspoiler = new Templates.HtmlSpoiler(spoiler);
                    newlog.Write(htmlspoiler.TransformText());
                }
            }
            else
            {
                filename += "_SpoilerLog.txt";
                CreateTextSpoilerLog(spoiler, Path.Combine(directory, filename));
            }
        }

        private static void CreateTextSpoilerLog(Spoiler spoiler, string path)
        {
            StringBuilder log = new StringBuilder();
            log.AppendLine($"{"Version:",-17} {spoiler.Version}");
            log.AppendLine($"{"Settings String:",-17} {spoiler.SettingsString}");
            log.AppendLine($"{"Seed:",-17} {spoiler.Seed}");
            log.AppendLine();

            if (spoiler.RandomizeDungeonEntrances)
            {
                log.AppendLine($" {"Entrance",-21}    {"Destination"}");
                log.AppendLine();
                string[] destinations = new string[] { "Woodfall", "Snowhead", "Inverted Stone Tower", "Great Bay" };
                for (int i = 0; i < 4; i++)
                {
                    log.AppendLine($"{destinations[i],-21} >> {destinations[spoiler.NewDestinationIndices[i]]}");
                }
                log.AppendLine("");
            }

            log.AppendLine($" {"Item",-40}    {"Location"}");
            foreach (var item in spoiler.ItemList)
            {
                log.AppendLine($"{item.Name,-40} >> {item.NewLocationName}");
            }

            log.AppendLine();
            log.AppendLine();

            log.AppendLine($" {"Item",-40}    {"Location"}");
            foreach (var item in spoiler.ItemList.OrderBy(i => i.NewLocationId))
            {
                log.AppendLine($"{item.Name,-40} >> {item.NewLocationName}");
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(log.ToString());
            }
        }
    }
}
