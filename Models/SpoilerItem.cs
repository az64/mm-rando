using MMRando.Extensions;
using MMRando.GameObjects;

namespace MMRando.Models
{
    public class SpoilerItem
    {
        public Item Item { get; }

        public int Id { get; }
        public string Name { get; }

        public int NewLocationId { get; }
        public string NewLocationName { get; }

        public Region Region { get; }

        public bool IsJunk { get; }

        public bool IsImportant { get; }

        public bool IsRequired { get; }

        public SpoilerItem(ItemObject itemObject, bool isRequired, bool isImportant)
        {
            Item = itemObject.Item;
            Id = itemObject.ID;
            Name = itemObject.Item.Name() ?? itemObject.Name;
            NewLocationId = (int)itemObject.NewLocation.Value;
            NewLocationName = itemObject.NewLocation.Value.Location();
            Region = itemObject.NewLocation.Value.Region().Value;
            IsJunk = Name.Contains("Rupee") || Name.Contains("Heart");
            IsImportant = isImportant;
            IsRequired = isRequired;
        }
    }
}
