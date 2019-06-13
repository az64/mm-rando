using MMRando.Attributes;
using MMRando.GameObjects;

namespace MMRando.Extensions
{
    public static class GossipQuoteExtensions
    {
        public static int? ItemId(this GossipQuote gossipQuote)
        {
            return gossipQuote.GetAttribute<GossipRestrictAttribute>()?.Id;
        }

        public static int? AlreadyAcquiredTextId(this GossipQuote gossipQuote)
        {
            return gossipQuote.GetAttribute<GossipAlreadyAcquiredTextIdAttribute>()?.AlreadyAcquiredTextId;
        }
    }
}
