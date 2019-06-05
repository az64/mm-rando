using System.Collections.Generic;

namespace MMRando.Models
{
    public class ItemObject
    {
        public int ID { get; set; }
        public List<int> DependsOnItems { get; set; } = new List<int>();
        public List<List<int>> Conditionals { get; set; } = new List<List<int>>();
        public List<int> CannotRequireItems { get; set; } = new List<int>();
        public int TimeNeeded { get; set; }
        public int TimeAvailable { get; set; }
        public int ReplacesItemId { get; set; } = -1;

        public bool ReplacesAnotherItem => ReplacesItemId != -1;
        public bool HasConditionals => Conditionals != null && Conditionals.Count > 0;
        public bool HasDependencies => DependsOnItems != null
            && DependsOnItems.Count > 0;
        public bool HasCannotRequireItems => CannotRequireItems != null
            && CannotRequireItems.Count > 0;
    }
}
