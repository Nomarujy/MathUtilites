using MathUtilites.Geometry.Entity;

namespace MathUtilites.Geometry
{
    public class Circle : Figure
    {
        public Vector2D Center { get; set; }

        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set
            {
                _radius = Math.Abs(value);
            }
        }

        public Circle(double radius = 1) : this(radius, Vector2D.Zero) { }

        public Circle(double radius, Vector2D center)
        {
            Center = center;
            Radius = radius;
        }

        public override double Area => Radius * Math.PI * Radius;
        public override double Perimetr => 2 * Math.PI * Radius;

        public Vector2D PointByDegrees(double degrees)
        {
            var radian = ConvertToRadian(degrees);

            return PointByRadian(radian);
        }

        public Vector2D PointByRadian(double radian)
        {
            var cos = Math.Cos(radian); 
            var si = Math.Sin(radian); 

            return new Vector2D()
            {
                X = Center.X + Math.Cos(radian) * Radius,
                Y = Center.X + Math.Sin(radian) * Radius,
            };
        }

        public static double ConvertToRadian(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
    }
}
