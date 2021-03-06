﻿using System.Collections.Generic;

namespace MMR.Randomizer.Models.Rom
{

    public class SequenceInfo
    {
        public string Name { get; set; }
        public int Replaces { get; set; } = -1;
        public int MM_seq { get; set; } = -1;
        public List<int> Type { get; set; } = new List<int>();
        public int Instrument { get; set; }
        public List<SequenceBinaryData> SequenceBinaryList { get; set; }
        public int PreviousSlot { get; set; } = -1;
    }
}
