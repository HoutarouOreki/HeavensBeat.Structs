using System;

namespace HeavensBeat.Structs
{
    public struct Vector4Decimal
    {
        public decimal X;
        public decimal Y;
        public decimal Z;
        public decimal W;

        public Vector4Decimal(decimal value) => X = Y = Z = W = value;

        public Vector4Decimal(decimal x, decimal y, decimal z, decimal w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4Decimal(Vector4Decimal v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        public decimal DistanceSquaredTo(Vector4Decimal v)
        {
            var dx = X - v.X;
            var dy = Y - v.Y;
            var dz = Z - v.Z;
            var dw = W - v.W;
            return (dx * dx) + (dy * dy) + (dz * dz) + (dw * dw);
        }

        public decimal LengthSquared() => (X * X) + (Y * Y) + (Z * Z);

        public Vector4Decimal RoundedToOne() => new Vector4Decimal(Normalized1D(X), Normalized1D(Y), Normalized1D(Z), Normalized1D(W));

        public Vector3Decimal ToVector3Decimal() => new Vector3Decimal(X, Y, Z);

        private int Normalized1D(decimal value)
        {
            if (value <= -0.5m)
                return -1;
            if (value >= 0.5m)
                return 1;
            return 0;
        }

        public static Vector4Decimal operator +(Vector4Decimal a, Vector4Decimal b) => new Vector4Decimal(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);

        public static Vector4Decimal operator -(Vector4Decimal a) => new Vector4Decimal(-a.X, -a.Y, -a.Z, -a.W);

        public static Vector4Decimal operator *(Vector4Decimal a, Vector4Decimal b) => new Vector4Decimal(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);

        public static Vector4Decimal operator *(Vector4Decimal v, decimal scale) => new Vector4Decimal(v.X * scale, v.Y * scale, v.Z * scale, v.W * scale);

        public static Vector4Decimal operator *(decimal scale, Vector4Decimal v) => new Vector4Decimal(v.X * scale, v.Y * scale, v.Z * scale, v.W * scale);

        public static Vector4Decimal operator /(Vector4Decimal v, decimal scale) => new Vector4Decimal(v.X / scale, v.Y / scale, v.Z / scale, v.W / scale);

        public static bool operator ==(Vector4Decimal a, Vector4Decimal b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;

        public static bool operator !=(Vector4Decimal a, Vector4Decimal b) => !(a == b);

        public override bool Equals(object? obj)
        {
            if (!(obj is Vector4Decimal v))
                return false;
            return v.X.Equals(X) && v.Y.Equals(Y) && v.Z.Equals(Z) && v.W.Equals(W);
        }

        public override int GetHashCode() => X.GetHashCode() + (Y.GetHashCode() * Z.GetHashCode()) + W.GetHashCode();

        public override string ToString() => $"[{X}; {Y}; {Z}; {W}]";
    }
}
