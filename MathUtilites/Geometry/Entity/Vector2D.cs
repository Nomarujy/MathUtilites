namespace MathUtilites.Geometry.Entity
{
    public struct Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D() { }
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double SqrLenght => X * X + Y * Y;
        public double Lenght => Math.Sqrt(SqrLenght);

        #region Static

        public static Vector2D Zero => new(0, 0);

        #endregion

        #region operators

        public static bool operator ==(Vector2D a, Vector2D b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector2D a, Vector2D b)
        {
            return !(a == b);
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            var result = new Vector2D()
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };

            return result;
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y
            };
        }

        public static Vector2D operator *(Vector2D a, Vector2D b)
        {
            return new Vector2D()
            {
                X = a.X * b.X,
                Y = a.Y * b.Y
            };
        }

        public static Vector2D operator /(Vector2D a, Vector2D b)
        {
            return new Vector2D()
            {
                X = a.X / b.X,
                Y = a.Y / b.Y
            };
        }

        public static Vector2D operator +(Vector2D a, double b)
        {
            return new Vector2D()
            {
                X = a.X + b,
                Y = a.Y + b
            };
        }

        public static Vector2D operator -(Vector2D a, double b)
        {
            return new Vector2D()
            {
                X = a.X - b,
                Y = a.Y - b
            };
        }

        public static Vector2D operator *(Vector2D a, double b)
        {
            return new Vector2D()
            {
                X = a.X * b,
                Y = a.Y * b
            };
        }

        public static Vector2D operator /(Vector2D a, double b)
        {
            return new Vector2D()
            {
                X = a.X / b,
                Y = a.Y / b
            };
        }

        #endregion operators

        public override bool Equals(object? obj)
        {
            if (obj is Vector2D vector)
            {
                return this == vector;
            }

            return false;
        }

        public bool Equals(Vector2D vector2D)
        {
            return this == vector2D;
        }

        public bool Equals(Vector2D vector2D, double toolerance)
        {
            var differenceX = X - vector2D.X;
            var differenceY = Y - vector2D.Y;

            return differenceX <= toolerance && differenceY <= toolerance;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
}
