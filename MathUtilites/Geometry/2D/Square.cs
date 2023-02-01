using MathUtilites.Geometry.Entity;

namespace MathUtilites.Geometry
{
    public class Square : Rectangle
    {
        public Square(double size = 1) : base(size, size)
        {

        }

        public Square(double size, Vector2D center, double angle = 0) : base(size, size, center, angle)
        {

        }

        public override double Height
        {
            get => base.Height;
            set
            {
                if (value > 0)
                {
                    base.Height = value;
                    base.Width = value;
                }
            }
        }

        public override double Width
        {
            get => base.Width;
            set => Height = value;
        }
    }
}
