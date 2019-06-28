﻿using MMRando.Constants;
using System.Collections.Generic;
using MMRando.GameObjects;
using System;
using System.Linq;
using MMRando.Extensions;
using MMRando.Attributes;

namespace MMRando.Utils
{
    public static class ItemUtils
    {
        public static bool IsShopItem(Item item)
        {
            return (item >= Item.ShopItemTradingPostRedPotion
                    && item <= Item.ShopItemZoraRedPotion)
                    || item == Item.ItemBombBag
                    || item == Item.UpgradeBigBombBag
                    || item == Item.MaskAllNight;
        }

        public static int AddItemOffset(int itemId)
        {
            if (itemId >= (int)Item.AreaSouthAccess)
            {
                itemId += Items.NumberOfAreasAndOther;
            }
            if (itemId >= (int)Item.OtherOneMask)
            {
                itemId += 5;
            }
            return itemId;
        }

        public static int SubtractItemOffset(int itemId)
        {
            if (itemId >= (int)Item.OtherOneMask)
            {
                itemId -= 5;
            }
            if (itemId >= (int)Item.AreaSouthAccess)
            {
                itemId -= Items.NumberOfAreasAndOther;
            }
            return itemId;
        }

        // todo make this only dungoen keys. dumb name
        public static bool IsDungeonItem(Item item)
        {
            return item >= Item.ItemWoodfallMap
                    && item <= Item.ItemStoneTowerKey4;
        }

        public static bool IsBottleCatchContent(Item item)
        {
            return item >= Item.BottleCatchFairy
                   && item <= Item.BottleCatchMushroom;
        }

        public static bool IsMoonLocation(Item location)
        {
            return location >= Item.HeartPieceDekuTrial && location <= Item.MaskFierceDeity;
        }

        public static bool IsOtherItem(Item item)
        {
            return item >= Item.ChestLensCaveRedRupee && item <= Item.IkanaScrubGoldRupee;
        }

        public static bool IsHeartPiece(Item item)
        {
            return (item >= Item.HeartPieceNotebookMayor && item <= Item.HeartPieceKnuckle)
                || (item >= Item.HeartPieceSouthClockTown && item <= Item.HeartContainerStoneTower)
                || (item >= Item.HeartPieceDekuTrial && item <= Item.HeartPieceLinkTrial)
                || item == Item.ChestSecretShrineHeartPiece
                || item == Item.HeartPieceBank;
        }

        public static bool IsStartingLocation(Item location)
        {
            return location == Item.MaskDeku || location == Item.SongHealing;
        }

        public static bool IsSong(Item item)
        {
            return item >= Item.SongHealing
                && item <= Item.SongOath;
        }

        // todo cache
        public static IEnumerable<Item> DowngradableItems()
        {
            return Enum.GetValues(typeof(Item))
                .Cast<Item>()
                .Where(item => item.IsDowngradable());
        }

        // todo cache
        public static IEnumerable<Item> StartingItems()
        {
            return Enum.GetValues(typeof(Item))
                .Cast<Item>()
                .Where(item => item.HasAttribute<StartingItemAttribute>());
        }

        // todo cache
        public static IEnumerable<Item> AllLocations()
        {
            return Enum.GetValues(typeof(Item))
                .Cast<Item>()
                .Where(item => item.Location() != null);
        }

        // todo cache
        public static IEnumerable<int> AllGetItemIndices()
        {
            return Enum.GetValues(typeof(Item))
                .Cast<Item>()
                .Where(item => item.HasAttribute<GetItemIndexAttribute>())
                .Select(item => item.GetAttribute<GetItemIndexAttribute>().Index);
        }

        // todo cache
        public static IEnumerable<int> AllGetBottleItemIndices()
        {
            return Enum.GetValues(typeof(Item))
                .Cast<Item>()
                .Where(item => item.HasAttribute<GetBottleItemIndicesAttribute>())
                .SelectMany(item => item.GetAttribute<GetBottleItemIndicesAttribute>().Indices);
        }
    }
}
