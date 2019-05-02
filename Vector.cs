using System;
using System.Collections.Generic;

namespace MMRando
{

    public partial class ROMFuncs
    {

        private class vecf32
        {
            public float x = new float();
            public float y = new float();
            public float z = new float();
        }

        private class vec16
        {
            public short x = new short();
            public short y = new short();
            public short z = new short();
        }

        private static vecf32 CrossProduct(vecf32 A, vecf32 B)
        {
            return new vecf32
            {
                x = (A.y * B.z) - (A.z * B.y),
                y = (A.z * B.x) - (A.x * B.z),
                z = (A.x * B.y) - (A.y * B.x)
            };
        }

        private static vecf32 Subtract(vecf32 A, vecf32 B)
        {
            return new vecf32
            {
                x = A.x - B.x,
                y = A.y - B.y,
                z = A.z - B.z
            };
        }

        private static vecf32 Subtract(vec16 A, vec16 B)
        {
            return new vecf32
            {
                x = A.x - B.x,
                y = A.y - B.y,
                z = A.z - B.z
            };
        }

        private static float Length(vecf32 A)
        {
            return (float)Math.Sqrt((A.x * A.x) + (A.y * A.y) + (A.z * A.z));
        }

        private static vecf32 Normalise(vecf32 A)
        {
            float a = Length(A);
            return new vecf32
            {
                x = A.x / a,
                y = A.y / a,
                z = A.z / a
            };
        }

        private static float PlaneDist(vecf32 n, vec16 p)
        {
            return - ((n.x * p.x) + (n.y * p.y) + (n.z * p.z));
        }

    }

}