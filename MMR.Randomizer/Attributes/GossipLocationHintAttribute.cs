using System;

namespace MMR.Randomizer.Attributes
{
    public class GossipLocationHintAttribute : Attribute
    {
        public string[] Values { get; private set; }

        public GossipLocationHintAttribute(params string[] values)
        {
            Values = values;
        }
    }
}
