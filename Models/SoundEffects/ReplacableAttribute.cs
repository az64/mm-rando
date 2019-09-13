using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMRando.Models.SoundEffects
{
    /// <summary>
    /// Marks a sound effect as replacable, requiring a base instruction and at least one address
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class ReplacableAttribute : Attribute
    {
        public ReadOnlyCollection<int> Addresses { get; private set; }

        public ReplacableAttribute(int address, params int[] additionalAddresses)
        {
            var addresses = new List<int> { address };
            if (additionalAddresses?.Length > 0)
            {
                addresses.AddRange(additionalAddresses);
            }

            Addresses = new ReadOnlyCollection<int>(addresses);
        }
    }
}
