using MMRandomizer.Models.Rom;
using System.Collections.Generic;

namespace MMRandomizer
{
    public static class RomData
    {
        public static List<MMFile> MMFileList { get; set; }
        public static List<Scene> SceneList { get; set; }
        public static List<GetItemEntry> GetItemList { get; set; }
        public static List<BottleCatchEntry[]> BottleList { get; set; }
        public static List<int> GetItemIndices { get; set; }
        public static List<int[]> BottleIndices { get; set; }
    }
}