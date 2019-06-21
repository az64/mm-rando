namespace MMRando.Models
{
    public class SpoilerItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int NewLocationId { get; private set; }
        public string NewLocationName { get; private set; }

        public bool IsJunk { get; private set; }

        public SpoilerItem(ItemObject itemObject, string locationName)
        {
            Id = itemObject.ID;
            Name = Id < Items.ITEM_NAMES.Count ? Items.ITEM_NAMES[Id] : itemObject.Name;
            NewLocationId = itemObject.ReplacesAnotherItem ? itemObject.ReplacesItemId : Id;
            NewLocationName = NewLocationId < Items.LOCATION_NAMES.Count ? Items.LOCATION_NAMES[NewLocationId] : locationName;
            IsJunk = Name.Contains("Rupee") || Name.Contains("Heart");
        }
    }
}
