using System;

namespace MMR.Randomizer.Attributes
{
    public class GetBottleItemIndicesAttribute : Attribute
    {
        public int[] Indices { get; private set; }

        public GetBottleItemIndicesAttribute(params int[] indices)
        {
            Indices = indices;
        }
    }
}
