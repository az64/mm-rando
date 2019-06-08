namespace MMRando.Models
{
    public class SpoilerItem
    {
        public int Id { get; set; }
        public string Name => Items.ITEM_NAMES[Id];

        public int NewLocationId { get; set; }
        public string NewLocationName => Items.LOCATION_NAMES[NewLocationId];

        public bool IsJunk { get; set; }

        public SpoilerItem(ItemObject itemObject)
        {
            Id = itemObject.ID;
            NewLocationId = itemObject.ReplacesItemId;
            IsJunk = Name.Contains("Rupee") || Name.Contains("Heart");
        }
    }
}
