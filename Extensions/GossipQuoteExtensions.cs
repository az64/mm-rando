using MMRando.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
