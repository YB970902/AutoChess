using UnityEngine;

namespace FixMath.NET
{
    public struct FixVector3
    {
        private Fix64 _x;
        private Fix64 _y;
        private Fix64 _z;

        public Fix64 x => _x;
        public Fix64 y => _y;
        public Fix64 z => _z;

        /// <summary> 벡터의 크기. 제곱근 연산까지 되어 정확하다. </summary>
        private Fix64 mag;
        /// <summary> 벡터의 크기. 제곱근 연산이 되지 않아 정확하지 않다. </summary>
        private Fix64 sqrtMag;

        public static readonly FixVector3 Zero = new FixVector3(0, 0, 0);
        public static readonly FixVector3 Forward = new FixVector3(0, 0, 1);
        public static readonly FixVector3 Back = new FixVector3(0, 0, -1);
        public static readonly FixVector3 Left = new FixVector3(-1, 0, 0);
        public static readonly FixVector3 Right = new FixVector3(1, 0, 0);
        public static readonly FixVector3 Up = new FixVector3(0, 1, 0);
        public static readonly FixVector3 Down = new FixVector3(0, -1, 0);

        public FixVector3(Fix64 x, Fix64 y, Fix64 z)
        {
            _x = x;
            _y = y;
            _z = z;

            mag = Fix64.Zero;
            sqrtMag = Fix64.Zero;
        }

        public FixVector3(int x, int y, int z)
        {
            _x = (Fix64)x;
            _y = (Fix64)y;
            _z = (Fix64)z;

            mag = Fix64.Zero;
            sqrtMag = Fix64.Zero;
        }

        public static FixVector3 operator + (FixVector3 lhs, FixVector3 rhs)
        {
            return new FixVector3(lhs._x + rhs._x, lhs._y + rhs._y, lhs._z + rhs._z);
        }

        public static FixVector3 operator - (FixVector3 lhs, FixVector3 rhs)
        {
            return new FixVector3(lhs._x - rhs._x, lhs._y - rhs._y, lhs._z - rhs._z);
        }

        public static FixVector3 operator * (FixVector3 vec, Fix64 val)
        {
            return new FixVector3(vec.x * val, vec.y * val, vec.z * val);
        }

        public Fix64 Magnitude()
        {
            if(sqrtMag <= Fix64.Zero)
            {
                sqrtMag = Fix64.Pow2(_x) + Fix64.Pow2(_y) + Fix64.Pow2(_z);
                mag = Fix64.Sqrt(sqrtMag);
            }
            else if(mag <= Fix64.Zero)
            {
                mag = Fix64.Sqrt(sqrtMag);
            }
            
            return mag;
        }

        public Fix64 SqrtMagnitude()
        {
            if (sqrtMag <= Fix64.Zero)
            {
                sqrtMag = Fix64.Pow2(_x) + Fix64.Pow2(_y) + Fix64.Pow2(_z);
            }

            return sqrtMag;
        }

        public static Fix64 GetSqrtDisatnce(in FixVector3 lhs, in FixVector3 rhs)
        {
            return Fix64.Pow2(lhs._x - rhs._x) + Fix64.Pow2(lhs._y - rhs._y) + Fix64.Pow2(lhs._z - rhs._z);
        }

        public static Fix64 GetDistance(in FixVector3 lhs, in FixVector3 rhs)
        {
            return Fix64.Sqrt(GetSqrtDisatnce(lhs, rhs));
        }

        public static Fix64 Dot(in FixVector3 lhs, in FixVector3 rhs)
        {
            return lhs._x * rhs._x + lhs._y * rhs._y + lhs._z * rhs._z;
        }

        public static FixVector3 Cross(in FixVector3 lhs, in FixVector3 rhs)
        {
            return new FixVector3(
                lhs._y * rhs._z - lhs._z * rhs._y,
                lhs._z * rhs._x - lhs._x * rhs._z,
                lhs._x * rhs._y - lhs._y * rhs._x);
        }

        public Vector3 ToVector3()
        {
            return new Vector3((float)_x, (float)_y, (float)_z);
        }
    }
}