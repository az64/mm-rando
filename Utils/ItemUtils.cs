using MMRando.Constants;

namespace MMRando.Utils
{
    public static class ItemUtils
    {
        public static bool IsAreaOrOther(int itemId)
        {
            return (itemId >= Items.AreaSouthAccess && itemId <= Items.AreaInvertedStoneTowerNew)
                || (itemId >= Items.OtherOneMask && itemId <= Items.AreaMoonAccess);
        }

        public static bool IsOutOfRange(int itemId)
        {
            return itemId > Items.MaskFierceDeity;
        }

        public static bool IsShopItem(int itemIndex)
        {
            return (itemIndex >= Items.ShopItemTradingPostRedPotion
                    && itemIndex <= Items.ShopItemZoraRedPotion)
                    || itemIndex == Items.ItemBombBag
                    || itemIndex == Items.UpgradeBigBombBag
                    || itemIndex == Items.MaskAllNight;
        }

        public static bool IsFakeItem(int itemId)
        {
            return IsAreaOrOther(itemId) || IsOutOfRange(itemId);
        }

        public static bool IsTemporaryItem(int itemId)
        {
            return IsTradeItem(itemId) || IsKey(itemId) || itemId == Items.ItemGoldDust;
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

        public static int AddItemOffset(int itemId)
        {
            if (itemId >= Items.AreaSouthAccess)
            {
                itemId += Items.NumberOfAreasAndOther;
            }
            if (itemId >= Items.OtherOneMask)
            {
                itemId += 5;
            }
            return itemId;
        }

        public static int SubtractItemOffset(int itemId)
        {
            if (itemId >= Items.OtherOneMask)
            {
                itemId -= 5;
            }
            if (itemId >= Items.AreaSouthAccess)
            {
                itemId -= Items.NumberOfAreasAndOther;
            }
            return itemId;
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

        public static bool IsMoonItem(int itemIndex)
        {
            return itemIndex >= Items.HeartPieceDekuTrial && itemIndex <= Items.MaskFierceDeity;
        }

        public static bool IsOtherItem(int itemIndex)
        {
            return itemIndex >= Items.ChestLensCaveRedRupee && itemIndex <= Items.IkanaScrubGoldRupee;
        }

        internal static bool IsDeed(int item)
        {
            return item >= Items.TradeItemLandDeed
                    && item <= Items.TradeItemOceanDeed;
        }

        public static bool IsHeartPiece(int itemIndex)
        {
            return (itemIndex >= Items.HeartPieceNotebookMayor && itemIndex <= Items.HeartPieceKnuckle)
                || (itemIndex >= Items.HeartPieceSouthClockTown && itemIndex <= Items.HeartContainerStoneTower)
                || (itemIndex >= Items.HeartPieceDekuTrial && itemIndex <= Items.HeartPieceLinkTrial)
                || itemIndex == Items.ChestSecretShrineHeartPiece
                || itemIndex == Items.HeartPieceBank;
        }

        public static bool IsStartingItem(int itemIndex)
        {
            return itemIndex == Items.MaskDeku || itemIndex == Items.SongHealing;
        }
    }
}
