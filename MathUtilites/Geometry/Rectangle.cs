using MathUtilites.Geometry.Entity;

namespace MathUtilites.Geometry
{
    public class Rectangle : IFigure
    {
        public Rectangle(double widht = 1, double height = 1) : this(widht, height, Vector2D.Zero, 0) { }

        public Rectangle(double widht, double height, Vector2D center, double angle)
        {
            Center = center;
            Width = widht;
            Height = height;
            Angle = angle;
        }

        public Vector2D Center { get; set; }

        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = Math.Abs(value);
            }

        }

        private double _height;
        public double Height
        { 
            get { return _height; }
            set
            {
                _height = Math.Abs(value);
            }
        
        }

        private double _angle;

        public double Angle
        {
            get { return _angle; }
            set
            {
                _angle = Math.Abs(value) % 360;
            }
        }

        public override double Area => Width * Height;

        public override double Perimetr => 2 * (Width + Height);

        public Vector2D[] GetCoordinates()
        {
            Vector2D[] result = new Vector2D[4];
            Circle circle = new(Math.Sqrt(Width * Width + Height * Height));

            double angle = 45 + Angle;
            for (int i = 0; i < 4; i += 45)
            {
                result[i] = circle.PointByDegrees(angle);

                angle += 90;
            }
            return result;
        }
    }
}
