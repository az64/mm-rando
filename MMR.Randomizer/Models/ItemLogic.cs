using MMR.Randomizer.Extensions;
using MMR.Randomizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MMR.Randomizer.GameObjects;

namespace MMR.Randomizer.Models
{
    [DataContract]
    public class ItemLogic
    {
        [DataMember]
        public int ItemId;

        [DataMember]
        public List<int> RequiredItemIds;

        [DataMember]
        public List<List<int>> ConditionalItemIds;

        [DataMember]
        public bool Acquired;

        [DataMember]
        public bool IsFakeItem;

        public ItemLogic(ItemLogic copyFrom)
        {
            ItemId = copyFrom.ItemId;
            RequiredItemIds = copyFrom.RequiredItemIds?.ToList();
            ConditionalItemIds = copyFrom.ConditionalItemIds?.Select(c => c.ToList()).ToList();
            Acquired = copyFrom.Acquired;
            IsFakeItem = copyFrom.IsFakeItem;
        }

        public ItemLogic(ItemObject itemObject)
        {
            ItemId = itemObject.ID;
            RequiredItemIds = itemObject.DependsOnItems?.Cast<int>().ToList();
            ConditionalItemIds = itemObject.Conditionals?.Select(c => c.Cast<int>().ToList()).ToList();
            IsFakeItem = itemObject.Item.IsFake() && (itemObject.Item.Entrance() == null || !itemObject.IsRandomized);

            // Remove fake requirements
            switch (itemObject.Item)
            {
                case Item.UpgradeBigBombBag:
                case Item.MaskBlast:
                    RequiredItemIds?.Remove((int)Item.TradeItemKafeiLetter);
                    RequiredItemIds?.Remove((int)Item.TradeItemPendant);
                    break;
                case Item.BottleCatchPrincess:
                case Item.BottleCatchBigPoe:
                    RequiredItemIds?.Remove((int)Item.BottleCatchEgg);
                    RequiredItemIds?.Remove((int)Item.BottleCatchBug);
                    RequiredItemIds?.Remove((int)Item.BottleCatchFish);
                    break;
                case Item.BottleCatchEgg:
                    RequiredItemIds?.Remove((int)Item.BottleCatchFish);
                    break;
            }
        }
    }
}
