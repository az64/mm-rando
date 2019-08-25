using System;

namespace MMRando.Models.SoundEffects
{
    public class EffectAttribute : Attribute
    {
        public int Flags { get; private set; }

        public EffectAttribute(ushort flags)
        {
            Flags = flags;
        }
    }
}