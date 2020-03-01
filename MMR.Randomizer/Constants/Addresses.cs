namespace MMR.Randomizer.Constants
{
    public static class Addresses
    {
        // these are addresses for tables that point to the specific objects for audio


        // not sure where DB got the instrument set map pointer, its not in seq64
        //  looks like its part of the Sequence Banks Map file, as that starts C77960 and has len 210
        public const int InstSetMap         = 0xC77A60; // pointer table: sequence -> instrumentset
        public const int SeqTable           = 0xC77B80; // audioseq table (70 + 0x10)
        public const int AudiobankTable     = 0xC776D0; // audiobank index (c0 + 0x10)
        public const int Audiobank          = 0x020700;
        // TODO add audiobank and soundbank pointers
    }
}