
namespace MMR.Randomizer.Models.Rom
{
    public class InstrumentSetInfo
    {
        public byte[] BankBinary { get; set; } = null;
        public int BankSlot { get; set; }
        public byte[] BankMetaData { get; set; } = null;
        public bool Modified = false;

    }
}
