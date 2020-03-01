using System;

namespace MMR.Randomizer.Models.SoundEffects
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