using System;
using System.Numerics;

namespace HeavensBeat.Structs
{
    public struct Vector3Decimal
    {
        public decimal X;
        public decimal Y;
        public decimal Z;

        public Vector3Decimal(decimal value) => X = Y = Z = value;

        public Vector3Decimal(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3Decimal(Vector3Decimal v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public decimal DistanceSquaredTo(Vector3Decimal v)
        {
            var dx = X - v.X;
            var dy = Y - v.Y;
            var dz = Z - v.Z;
            return (dx * dx) + (dy * dy) + (dz * dz);
        }

        public decimal LengthSquared() => (X * X) + (Y * Y) + (Z * Z);

        public Vector3Decimal RoundedToOne() => new Vector3Decimal(Normalized1D(X), Normalized1D(Y), Normalized1D(Z));

        public Vector3Decimal Normalized()
        {
            if (X == 0 && Y == 0 && Z == 0)
                return this;
            var floatingVector = new Vector3((float)X, (float)Y, (float)Z);
            floatingVector = Vector3.Normalize(floatingVector);
            return new Vector3Decimal((decimal)floatingVector.X, (decimal)floatingVector.Y, (decimal)floatingVector.Z);
        }

        private int Normalized1D(decimal value)
        {
            if (value <= -0.5m)
                return -1;
            if (value >= 0.5m)
                return 1;
            return 0;
        }

        public static Vector3Decimal Zero => new Vector3Decimal();
        public static Vector3Decimal One => new Vector3Decimal(1);

        public Vector3Decimal RotatedAroundY(decimal angle, bool radians = false)
        {
            var a = (double)angle;
            if (!radians)
                a *= Math.PI / 180;
            if (LengthSquared() == 0)
                return this;
            while (a < 0)
                a += 360;
            while (a > 360)
                a -= 360;
            return angle switch
            {
                0 => this,
                //90 => new Vector3Decimal(Z, Y, X),
                //180 => new Vector3Decimal(-X, Y, -Z),
                //270 => new Vector3Decimal(-Z, Y, -X),
                _ => new Vector3Decimal((X * ((decimal)Math.Cos(a))) - (Z * ((decimal)Math.Sin(a))), Y, (X * ((decimal)Math.Sin(a))) + (Z * ((decimal)Math.Cos(a)))),
            };
        }

        public static Vector3Decimal Left => new Vector3Decimal(-1, 0, 0);
        public static Vector3Decimal Right => new Vector3Decimal(1, 0, 0);
        public static Vector3Decimal Up => new Vector3Decimal(0, 1, 0);
        public static Vector3Decimal Down => new Vector3Decimal(0, -1, 0);
        public static Vector3Decimal Forward => new Vector3Decimal(0, 0, -1);
        public static Vector3Decimal Back => new Vector3Decimal(0, 0, 1);

        public static Vector3Decimal FlipX => new Vector3Decimal(-1, 1, 1);
        public static Vector3Decimal FlipY => new Vector3Decimal(1, -1, 1);
        public static Vector3Decimal FlipZ => new Vector3Decimal(1, 1, -1);

        public static Vector3Decimal operator +(Vector3Decimal a, Vector3Decimal b) => new Vector3Decimal(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector3Decimal operator -(Vector3Decimal a) => new Vector3Decimal(-a.X, -a.Y, -a.Z);

        public static Vector3Decimal operator -(Vector3Decimal a, Vector3Decimal b) => new Vector3Decimal(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Vector3Decimal operator *(Vector3Decimal a, Vector3Decimal b) => new Vector3Decimal(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

        public static Vector3Decimal operator *(Vector3Decimal v, decimal scale) => new Vector3Decimal(v.X * scale, v.Y * scale, v.Z * scale);

        public static Vector3Decimal operator *(decimal scale, Vector3Decimal v) => new Vector3Decimal(v.X * scale, v.Y * scale, v.Z * scale);

        public static Vector3Decimal operator /(Vector3Decimal v, decimal scale) => new Vector3Decimal(v.X / scale, v.Y / scale, v.Z / scale);

        public static Vector3Decimal operator /(Vector3Decimal a, Vector3Decimal b) => new Vector3Decimal(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

        public static bool operator ==(Vector3Decimal a, Vector3Decimal b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;

        public static bool operator !=(Vector3Decimal a, Vector3Decimal b) => !(a == b);

        public override bool Equals(object? obj)
        {
            if (!(obj is Vector3Decimal v))
                return false;
            return v.X.Equals(X) && v.Y.Equals(Y) && v.Z.Equals(Z);
        }

        public override int GetHashCode() => X.GetHashCode() + (Y.GetHashCode() * Z.GetHashCode());

        public override string ToString() => $"[{X}; {Y}; {Z}]";
    }
}
