namespace MathUtilites.Geometry
{
    public class Triangle : IFigure
    {
        public Triangle(double a = 0, double b = 0, double c = 0)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public double SideA = 0;
        public double SideB = 0;
        public double SideC = 0;

        public bool IsRightAngled => IsRightAndled();

        private bool IsRightAndled()
        {
            var maxSide = Math.Max(SideA, Math.Max(SideB, SideC));
            var minSide = Math.Min(SideA, Math.Min(SideB, SideC));
            var avgSide = Math.Max(SideA, Math.Min(SideB, SideC));

            return Math.Pow(maxSide, 2) == Math.Pow(minSide, 2) + Math.Pow(avgSide, 2);
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
