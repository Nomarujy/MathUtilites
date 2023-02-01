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

        private double _width = 1;
        public virtual double Width
        {
            get { return _width; }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
            }

        }

        private double _height = 1;
        public virtual double Height
        { 
            get { return _height; }
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
            }
        
        }

        private double _angle = 0;

        public double Angle
        {
            get { return _angle; }
            set
            {
                if (value >= 0)
                {
                    _angle = value % 360;
                }
            }
        }

        public double Area => Width * Height;

        public double Perimetr => 2 * (Width + Height);

        public Vector2D[] GetCoordinates()
        {
            Vector2D[] result = new Vector2D[4];
            Circle circle = new(Math.Sqrt(Width * Width + Height * Height));

            circle.Radius /= 2;

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
