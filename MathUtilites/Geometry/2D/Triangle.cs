using MathUtilites.Geometry.Entity;

namespace MathUtilites.Geometry
{
    public class Triangle : IFigure
    {
        public Triangle(double sideA = 3, double sideB = 4, double sideC = 5)
        {
            UpdateSides(sideA, sideB, sideC);
        }

        public Triangle(double sideA, double sideB, double sideC, Vector2D center) : this(sideA, sideB, sideC)
        {
            Center= center;
        }

        public Vector2D Center { get; set; }

        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA => _sideA;
        public double SideB => _sideB;
        public double SideC => _sideC;

        public static bool SidesPossible(double sideA, double sideB, double sideC)
        {
            if (sideA + sideB > sideC &&
                sideB + sideC > sideA &&
                sideC + sideA > sideB)
            {
                return true;
            }
            return false;
        }


        public void UpdateSides(double sideA, double sideB, double sideC)
        {
            if (!SidesPossible(sideA, sideB, sideC))
            {
                throw new ArgumentException($"Triangle with sides {sideA} {sideB} {sideC} can`t exist");
            }

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }


        public bool IsRightAngled => IsRightAngledBySides(SideA, SideB, SideC);

        public static bool IsRightAngledBySides(double sideA, double sideB, double sideC)
        {
            var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
            var minSide = Math.Min(sideA, Math.Min(sideB, sideC));
            var avgSide = Math.Max(sideA, Math.Min(sideB, sideC));

            return Math.Pow(maxSide, 2) == Math.Pow(minSide, 2) + Math.Pow(avgSide, 2);
        }

        public double Area => FindArea(SideA, SideB, SideC);

        public static double FindArea(double sideA, double sideB, double sideC)
        {
            double halfPerimetr = 0.5 * (sideA + sideB + sideC);
            var SqrArea = halfPerimetr * (halfPerimetr - sideA) * (halfPerimetr - sideB) * (halfPerimetr - sideC);
            return Math.Sqrt(SqrArea);
        }

        public double Perimetr => SideA + SideB + SideC;
    }
}
