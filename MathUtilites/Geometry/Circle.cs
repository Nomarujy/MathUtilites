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

        public Circle(double radius = 1) : this(Vector2D.Zero, radius) { }

        public Circle(Vector2D center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override double Area => Radius * Math.PI * Radius;
        public override double Perimetr => 2 * Math.PI * Radius;

        public Vector2D PointByAnglge(double angle)
        {
            return new Vector2D()
            {
                X = Center.X + Math.Cos(angle) * Radius,
                Y = Center.X + Math.Sin(angle) * Radius,
            };
        }
    }
}
