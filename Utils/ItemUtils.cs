namespace MMRando.Utils
{
    public static class ItemUtils
    {
        public static bool IsAreaOrOther(int itemId)
        {
            return (itemId >= Items.AreaSouthAccess && itemId <= Items.AreaInvertedStoneTowerNew);
        }

        public static bool IsOutOfRange(int itemId)
        {
            return itemId > Items.GrottoToGoronRace;
        }

        public static bool IsShopItem(int itemIndex)
        {
            return itemIndex >= Items.ShopItemTradingPostRedPotion
                    && itemIndex <= Items.ShopItemZoraRedPotion;
        }

        public static bool IsFakeItem(int itemId)
        {
            return IsAreaOrOther(itemId) || IsOutOfRange(itemId);
        }

        public static bool IsTemporaryItem(int itemId)
        {
            return IsTradeItem(itemId) || IsKey(itemId);
        }

        public static bool IsKey(int itemId)
        {
            return itemId == Items.ItemWoodfallKey1
                || (itemId >= Items.ItemSnowheadKey1
                    && itemId <= Items.ItemSnowheadKey3)
                || itemId == Items.ItemGreatBayKey1
                || (itemId >= Items.ItemStoneTowerKey1
                    && itemId <= Items.ItemStoneTowerKey4);
        }

        private static bool IsTradeItem(int itemId)
        {
            return itemId >= Items.TradeItemMoonTear
                   && itemId <= Items.TradeItemMamaLetter;
        }

        public static bool IsItemDefinedPastAreas(int itemId)
        {
            return itemId > Items.AreaInvertedStoneTowerNew;
        }

        public static bool IsDungeonItem(int itemIndex)
        {
            return itemIndex >= Items.ItemWoodfallMap
                    && itemIndex <= Items.ItemStoneTowerKey4;
        }

        public static bool IsBottleCatchContent(int itemIndex)
        {
            return itemIndex >= Items.BottleCatchFairy
                   && itemIndex <= Items.BottleCatchMushroom;
        }

        internal static bool IsDeed(int item)
        {
            return item >= Items.TradeItemLandDeed
                    && item <= Items.TradeItemOceanDeed;
        }
    }
}
