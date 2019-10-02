using System;

namespace MMRando.GameObjects
{
    public enum MessageShopText
    {
        [MessageShop(MessageShopStyle.Tingle, Item.ItemTingleMapTown, 5, Item.ItemTingleMapWoodfall, 40)]
        Town = 0x1D11,

        [MessageShop(MessageShopStyle.Tingle, Item.ItemTingleMapWoodfall, 20, Item.ItemTingleMapSnowhead, 40)]
        Swamp = 0x1D12,

        [MessageShop(MessageShopStyle.Tingle, Item.ItemTingleMapSnowhead, 20, Item.ItemTingleMapRanch, 40)]
        Mountain = 0x1D13,

        [MessageShop(MessageShopStyle.Tingle, Item.ItemTingleMapRanch, 20, Item.ItemTingleMapGreatBay, 40)]
        Ranch = 0x1D14,

        [MessageShop(MessageShopStyle.Tingle, Item.ItemTingleMapGreatBay, 20, Item.ItemTingleMapStoneTower, 40)]
        Ocean = 0x1D15,

        [MessageShop(MessageShopStyle.Tingle, Item.ItemTingleMapStoneTower, 20, Item.ItemTingleMapTown, 40)]
        Canyon = 0x1D16,

        [MessageShop(MessageShopStyle.MilkBar, Item.ShopItemMilkBarMilk, 20, Item.ShopItemMilkBarChateau, 200)]
        MilkBar = 0x2B0B,
    }

    public static class MessageShopStyle
    {
        public const string Tingle = "\u0002\u00C3{0,-22}\u0001{1,2} Rupees\u0011\u0002{2,-22}\u0001{3,2} Rupees\u0011\u0002No Thanks\u00BF";
        public const string MilkBar = "What'll it be?\u0011\u0013\u0013\u0012\u0002\u00C3{0}: \u0006{1} Rupees\u0011\u0002{2}: \u0006{3} Rupees\u0011\u0002Nothing\u00BF";
    }

    public class MessageShopAttribute : Attribute
    {
        public string MessageFormat { get; private set; }
        public Item[] Items { get; private set; }
        public int[] Prices { get; private set; }

        public MessageShopAttribute(string messageFormat, Item item1, int price1, Item item2, int price2)
        {
            MessageFormat = messageFormat;
            Items = new Item[] { item1, item2 };
            Prices = new int[] { price1, price2 };
        }
    }
}
