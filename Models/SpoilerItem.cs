using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMRando.Models
{
    public class SpoilerItem
    {
        public int Id { get; set; }
        public string Name => Items.ITEM_NAMES[Id];

        public int NewLocationId { get; set; }
        public string NewLocationName => Items.ITEM_NAMES[NewLocationId];

        public int ReplacedById { get; set; }
        public string ReplacedByName => Items.ITEM_NAMES[ReplacedById];

        public SpoilerItem(ItemObject itemObject)
        {
            Id = itemObject.ID;
            NewLocationId = itemObject.ReplacesItemId;
        }
    }
}
