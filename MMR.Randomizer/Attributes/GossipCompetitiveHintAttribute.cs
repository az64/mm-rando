using MMR.Randomizer.Models.Settings;
using System;
using System.Linq.Expressions;

namespace MMR.Randomizer.Attributes
{
    public class GossipCompetitiveHintAttribute : Attribute
    {
        public int Priority { get; private set; }
        public Func<SettingsObject, bool> Condition { get; private set; }

        public GossipCompetitiveHintAttribute(int priority = 0, string condition = null)
        {
            Priority = priority;

            if (condition != null)
            {
                typeof(SettingsObject).GetProperty(condition);
                var parameter = Expression.Parameter(typeof(SettingsObject));
                Condition = Expression.Lambda<Func<SettingsObject, bool>>(Expression.Property(parameter, condition), parameter).Compile();
            }
        }
    }
}
