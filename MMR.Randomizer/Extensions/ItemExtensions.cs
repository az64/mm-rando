using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMR.Randomizer.Attributes;
using MMR.Randomizer.GameObjects;
using MMR.Common.Extensions;

namespace MMR.Randomizer.Extensions
{
    public static class ItemExtensions
    {
        public static int? GetItemIndex(this Item item)
        {
            return item.GetAttribute<GetItemIndexAttribute>()?.Index;
        }

        public static int[] GetBottleItemIndices(this Item item)
        {
            return item.GetAttribute<GetBottleItemIndicesAttribute>()?.Indices;
        }

        public static string Name(this Item item)
        {
            return item.GetAttribute<ItemNameAttribute>()?.Name;
        }

        public static string Location(this Item item)
        {
            return item.GetAttribute<LocationNameAttribute>()?.Name;
        }

        public static Region? Region(this Item item)
        {
            return item.GetAttribute<RegionAttribute>()?.Region;
        }

        public static string Entrance(this Item item)
        {
            return item.GetAttribute<EntranceNameAttribute>()?.Name;
        }

        public static ShopTextAttribute ShopTexts(this Item item)
        {
            return item.GetAttribute<ShopTextAttribute>();
        }

        public static string[] ItemHints(this Item item)
        {
            return item.GetAttribute<GossipItemHintAttribute>().Values;
        }

        public static string[] LocationHints(this Item item)
        {
            return item.GetAttribute<GossipLocationHintAttribute>().Values;
        }

        public static bool IsRepeatable(this Item item)
        {
            return item.HasAttribute<RepeatableAttribute>();
        }

        public static bool IsCycleRepeatable(this Item item)
        {
            return item.HasAttribute<CycleRepeatableAttribute>();
        }

        public static bool IsRupeeRepeatable(this Item item)
        {
            return item.HasAttribute<RupeeRepeatableAttribute>();
        }

        public static bool IsDowngradable(this Item item)
        {
            return item.HasAttribute<DowngradableAttribute>();
        }

        public static bool IsTemporary(this Item item)
        {
            return item.HasAttribute<TemporaryAttribute>();
        }

        public static bool IsFake(this Item item)
        {
            return item.Name() == null;
        }

        public static bool IsOverwritable(this Item item)
        {
            return item.HasAttribute<OverwritableAttribute>();
        }
    }
}
