using MMRando.Extensions;
using MMRando.GameObjects;

namespace MMRando.Models
{
    public class SpoilerItem
    {
        public Item Item { get; private set; }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public int NewLocationId { get; private set; }
        public string NewLocationName { get; private set; }

        public bool IsJunk { get; private set; }

        public SpoilerItem(ItemObject itemObject, string locationName)
        {
            Item = itemObject.Item;
            Id = itemObject.ID;
            Name = itemObject.Item.Name() ?? itemObject.Name;
            NewLocationId = itemObject.NewLocation.HasValue ? (int)itemObject.NewLocation : Id;
            NewLocationName = itemObject.NewLocation?.Location() ?? locationName;
            IsJunk = Name.Contains("Rupee") || Name.Contains("Heart");
        }
    }
}
