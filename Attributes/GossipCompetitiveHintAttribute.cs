using System;

namespace MMRando.Attributes
{
    public class GossipCompetitiveHintAttribute : Attribute
    {
        public int Priority { get; private set; }
        public bool IsOnlyForUsefulItems { get; private set; }

        public GossipCompetitiveHintAttribute(int priority = 0, bool onlyForUsefulItems = false)
        {
            Priority = priority;
            IsOnlyForUsefulItems = onlyForUsefulItems;
        }
    }
}
