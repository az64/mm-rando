using System;

namespace MMRando.Attributes
{
    public class GetItemAttribute : Attribute
    {
        public byte ItemGained { get; private set; }
        public byte Flag { get; private set; }
        public byte Index { get; private set; }
        public byte Type { get; private set; }
        public short Message { get; private set; }
        public ushort Object { get; private set; }

        public GetItemAttribute(byte index, ushort objectId)
        {
            Index = index;
            Object = objectId;
        }
    }
}
