namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Asm context.
    /// </summary>
    public class AsmContext
    {
        /// <summary>
        /// Patcher.
        /// </summary>
        public Patcher Patcher { get; private set; }

        /// <summary>
        /// Symbols.
        /// </summary>
        public Symbols Symbols { get; private set; }

        public AsmContext(Symbols symbols)
            : this(null, symbols)
        {
        }

        public AsmContext(Patcher patcher, Symbols symbols)
        {
            this.Patcher = patcher;
            this.Symbols = symbols;
        }

        /// <summary>
        /// Apply and write patch data.
        /// </summary>
        /// <param name="options">Options</param>
        public void ApplyPatch(AsmOptionsGameplay options)
        {
            this.Patcher.Apply(this.Symbols, options);
        }

        /// <summary>
        /// Apply configuration after the patch file has been created (or applied) and the hash calculated.
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="patch">Whether or not a patch file was applied</param>
        public void ApplyPostConfiguration(AsmOptionsCosmetic options, bool patch = false)
        {
            if (patch)
            {
                // If applying post-configuration after applying a patch file, it may be an older
                // patch file which does not support newer features (and thus would not have the
                // necessary symbols). Thus, "try" and apply it without throwing an exception if
                // symbols are not found.
                this.Symbols.TryApplyConfigurationPostPatch(options);
            }
            else
            {
                // If applying post-configuration from the internal patch & symbols data, all
                // expected symbols should be present. Thus, an exception should be thrown if any
                // cannot be found.
                this.Symbols.ApplyConfigurationPostPatch(options);
            }
        }

        /// <summary>
        /// Load from ROM, <see cref="Asm.Symbols"/> only.
        /// </summary>
        /// <returns>AsmContext</returns>
        public static AsmContext LoadFromROM()
        {
            var symbols = Symbols.FromROM();
            return new AsmContext(symbols);
        }

        /// <summary>
        /// Load from internal resource files.
        /// </summary>
        /// <returns>AsmContext</returns>
        public static AsmContext LoadInternal()
        {
            var patcher = Patcher.Load();
            var symbols = Symbols.Load();
            return new AsmContext(patcher, symbols);
        }
    }
}
