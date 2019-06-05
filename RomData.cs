using MMRando.Models.Rom;
using System.Collections.Generic;

namespace MMRando
{
    public static class RomData
    {
        public static List<SequenceInfo> SequenceList { get; set; }
        public static List<SequenceInfo> TargetSequences { get; set; }
        public static List<MMFile> MMFileList { get; set; }
        public static List<Scene> SceneList { get; set; }
        public static List<GetItemEntry> GetItemList { get; set; }
        public static List<BottleCatchEntry[]> BottleList { get; set; }
        public static List<int> GetItemIndices { get; set; }
        public static List<int[]> BottleIndices { get; set; }
    }
}