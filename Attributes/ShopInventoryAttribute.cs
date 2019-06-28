using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMRando.Attributes
{
    public class ShopInventoryAttribute : Attribute
    {
        private const int BaseShopInventoryDataAddress = 0x00CDDC60;
        private int[] _shopAddresses;

        public int RoomObjectAddress { get; private set; }
        public IEnumerable<int> ShopAddresses => _shopAddresses.Select(a => BaseShopInventoryDataAddress + a);

        public ShopInventoryAttribute(Room room, int roomObjectOffset, params int[] shopAddresses)
        {
            _shopAddresses = shopAddresses;
            RoomObjectAddress = (int)room + roomObjectOffset;
        }

        public enum Room
        {
            TradingPost = 0x02683000
        }
    }
}
