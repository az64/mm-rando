using MMRando.Models.Settings;
using System;
using System.Collections.Generic;

namespace MMRando.Models
{
    public class RandomizedResult
    {
        public SettingsObject Settings { get; private set; }
        public Random Random { get; private set; }
        public List<ItemObject> ItemList { get; set; }
        public List<string> GossipQuotes { get; set; }


        public int[] NewEntrances = new int[] { -1, -1, -1, -1 };
        public int[] NewExits = new int[] { -1, -1, -1, -1 };

        public int[] NewExitIndices = new int[] { -1, -1, -1, -1 };
        public int[] NewDCFlags = new int[] { -1, -1, -1, -1 };
        public int[] NewDCMasks = new int[] { -1, -1, -1, -1 };
        public int[] NewDestinationIndices = new int[] { -1, -1, -1, -1 };

        public RandomizedResult(SettingsObject settings, Random random)
        {
            Settings = settings;
            Random = random;
        }

    }
}
