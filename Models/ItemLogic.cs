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
        }
    }
}
