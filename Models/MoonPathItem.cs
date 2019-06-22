namespace MMRando.Models
{
    public class MoonPathItem
    {
        public int Depth { get; private set; }
        public int ItemId { get; private set; }

        public MoonPathItem(int depth, int itemId)
        {
            Depth = depth;
            ItemId = itemId;
        }
    }
}
