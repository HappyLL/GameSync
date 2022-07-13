using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public struct GVector3
    {
        public int x;
        public int y;
        public int z;

        public static GVector3 operator+ (GVector3 lhs, GVector3 rhs)
        {
            GVector3 gVector3 = new GVector3();
            gVector3.x = lhs.x + rhs.x;
            gVector3.y = lhs.y + rhs.y;
            gVector3.z = lhs.z + rhs.z;
            return gVector3;
        }
        public static GVector3 operator -(GVector3 lhs, GVector3 rhs)
        {
            GVector3 gVector3 = new GVector3();
            gVector3.x = lhs.x - rhs.x;
            gVector3.y = lhs.y - rhs.y;
            gVector3.z = lhs.z - rhs.z;
            return gVector3;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", x, y, z);
        }
    }
}
