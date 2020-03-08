using System.Collections.Generic;
using System.IO;
using MMR.Randomizer.Constants;

namespace MMR.Randomizer.Models.Rom
{

    public class SequenceInfo
    {
        public string Name { get; set; }
        public string Filename => Path.Combine(Values.MusicDirectory, Name);
        public int Replaces { get; set; } = -1;
        public int MM_seq { get; set; } = -1;
        public List<int> Type { get; set; } = new List<int>();
        public int Instrument { get; set; }
        public List<SequenceBinaryData> SequenceBinaryList { get; set; }
        public int PreviousSlot { get; set; } = -1;
    }
}
