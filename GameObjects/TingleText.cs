using System;

namespace MMRando.GameObjects
{
    public enum TingleText
    {
        [TingleShop(Item.ItemTingleMapTown, Item.ItemTingleMapWoodfall)]
        Town,

        [TingleShop(Item.ItemTingleMapWoodfall, Item.ItemTingleMapSnowhead)]
        Swamp,

        [TingleShop(Item.ItemTingleMapSnowhead, Item.ItemTingleMapRanch)]
        Mountain,

        [TingleShop(Item.ItemTingleMapRanch, Item.ItemTingleMapGreatBay)]
        Ranch,

        [TingleShop(Item.ItemTingleMapGreatBay, Item.ItemTingleMapStoneTower)]
        Ocean,

        [TingleShop(Item.ItemTingleMapStoneTower, Item.ItemTingleMapTown)]
        Canyon
    }

    public class TingleShopAttribute : Attribute
    {
        public Item[] Items { get; private set; }

        public TingleShopAttribute(Item item1, Item item2)
        {
            Items = new Item[] { item1, item2 };
        }
    }
}
