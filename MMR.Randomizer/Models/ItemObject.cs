using System.Collections.Generic;
using MMR.Randomizer.GameObjects;

namespace MMR.Randomizer.Models
{
    public class ItemObject
    {
        public int ID { get; set; }
        public Item Item => (Item)ID; // todo?
        public string Name { get; set; }
        public List<Item> DependsOnItems { get; set; } = new List<Item>();
        public List<List<Item>> Conditionals { get; set; } = new List<List<Item>>();
        public List<Item> CannotRequireItems { get; set; } = new List<Item>();
        public int TimeNeeded { get; set; }
        public int TimeAvailable { get; set; }
        public Item? NewLocation { get; set; }

        public bool IsRandomized { get; set; }
    }
}
