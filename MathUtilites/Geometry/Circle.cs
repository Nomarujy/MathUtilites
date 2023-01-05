using MathUtilites.Geometry.Entity;

namespace MathUtilites.Geometry
{
    public class Circle : IFigure
    {
        public Vector2D Center { get; private set; }
        public double Radius { get; private set; }

        public Circle(double radius = 1)
        {
            Center = Vector2D.Zero;
            Radius = radius;
        }

        public Circle(Vector2D center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public double Area => Radius * Math.PI * Radius;
        public double Perimetr => 2 * Math.PI * Radius;

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
