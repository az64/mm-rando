using MMRando.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MMRando.Models
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

        public ItemLogic(ItemObject itemObject)
        {
            ItemId = itemObject.ID;
            RequiredItemIds = itemObject.DependsOnItems?.ToList();
            ConditionalItemIds = itemObject.Conditionals?.Select(c => c.ToList()).ToList();
            IsFakeItem = ItemUtils.IsFakeItem(ItemId);

            // Remove fake requirements
            switch (ItemId)
            {
                case Items.UpgradeBigBombBag:
                case Items.MaskBlast:
                    RequiredItemIds = null;
                    break;
                case Items.BottleCatchPrincess:
                case Items.BottleCatchBigPoe:
                    RequiredItemIds?.Remove(Items.BottleCatchEgg);
                    RequiredItemIds?.Remove(Items.BottleCatchBug);
                    RequiredItemIds?.Remove(Items.BottleCatchFish);
                    break;
                case Items.BottleCatchEgg:
                    RequiredItemIds?.Remove(Items.BottleCatchFish);
                    break;
            }
        }
    }
}
