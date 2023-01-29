using MathUtilites.Geometry.Entity;

namespace MathUtilites.Geometry
{
    public class Triangle : IFigure
    {
        public Triangle(double sideA = 3, double sideB = 4, double sideC = 5)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public Triangle(double sideA, double sideB, double sideC, Vector2D center) : this(sideA, sideB, sideC)
        {
            Center= center;
        }

        public Vector2D Center { get; set; }

        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get => _sideA;
            set
            {
                if (value > 0)
                {
                    _sideA = value;
                }
            }
        }

        public double SideB
        {
            get => _sideB;
            set
            {
                if (value > 0)
                {
                    _sideB = value;
                }
            }
        }

        public double SideC
        {
            get => _sideC;
            set
            {
                if (value > 0)
                {
                    _sideC = value;
                }
            }
        }

        public bool IsRightAngled
        {
            get
            {
                var maxSide = Math.Max(SideA, Math.Max(SideB, SideC));
                var minSide = Math.Min(SideA, Math.Min(SideB, SideC));
                var avgSide = Math.Max(SideA, Math.Min(SideB, SideC));

                return Math.Pow(maxSide, 2) == Math.Pow(minSide, 2) + Math.Pow(avgSide, 2);
            }
        }

        public double Area => FindArea();

        private double FindArea()
        {
            double haldPerimetr = 0.5 * Perimetr;
            var SqrArea = haldPerimetr * (haldPerimetr - SideA) * (haldPerimetr - SideB) * (haldPerimetr - SideC);
            return Math.Sqrt(SqrArea);
        }

        public double Perimetr => SideA + SideB + SideC;
    }
}
