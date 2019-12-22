using MMRando.GameObjects;

namespace MMRando.Extensions
{
    public static class GossipQuoteExtensions
    {
        public static bool IsMoonGossipStone(this GossipQuote gossipQuote)
        {
            return gossipQuote.ToString().StartsWith("Moon");
        }
    }
}
