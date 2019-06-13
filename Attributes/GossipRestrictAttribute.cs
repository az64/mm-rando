using System;

namespace MMRando.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class GossipRestrictAttribute : Attribute
    {
        public int Id { get; private set; }
        public RestrictionType Type { get; private set; }

        public GossipRestrictAttribute(RestrictionType type, int id)
        {
            Type = type;
            Id = id;
        }

        public enum RestrictionType
        {
            Item,
            Location
        }
    }
}
