namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Options used for Asm.
    /// </summary>
    public class AsmOptions
    {
        /// <summary>
        /// D-Pad configuration.
        /// </summary>
        public DPadConfig DPadConfig { get; set; } = new DPadConfig();

        /// <summary>
        /// HUD colors configuration.
        /// </summary>
        public HudColorsConfig HudColorsConfig { get; set; } = new HudColorsConfig();

        /// <summary>
        /// Miscellaneous configuration.
        /// </summary>
        public MiscConfig MiscConfig { get; set; } = new MiscConfig();
    }
}
