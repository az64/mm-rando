using System;

namespace MMRando.Attributes
{
    public class GossipAlreadyAcquiredTextIdAttribute : Attribute
    {
        public ushort AlreadyAcquiredTextId { get; private set; }

        public GossipAlreadyAcquiredTextIdAttribute(ushort alreadyAcquiredTextId)
        {
            AlreadyAcquiredTextId = alreadyAcquiredTextId;
        }
    }
}
