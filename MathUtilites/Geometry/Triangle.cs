namespace MathUtilites.Geometry
{
    public class Triangle : IFigure
    {
        public Triangle(double a = 0, double b = 0, double c = 0)
        {
            _sideA = a;
            _sideB = b;
            _sideC = c;
        }

        private double _sideA = 0;
        private double _sideB = 0;
        private double _sideC = 0;

        public bool IsRightAngled => IsRightAndled();

        private bool IsRightAndled()
        {
            var maxSide = Math.Max(_sideA, Math.Max(_sideB, _sideC));
            var minSide = Math.Min(_sideA, Math.Min(_sideB, _sideC));
            var avgSide = Math.Max(_sideA, Math.Min(_sideB, _sideC));

            return Math.Pow(maxSide, 2) == Math.Pow(minSide, 2) + Math.Pow(avgSide, 2);
        }

        public override double Area => FindArea();

        private double FindArea()
        {
            double haldPerimetr = 0.5 * Perimetr;
            var SqrArea = haldPerimetr * (haldPerimetr - _sideA) * (haldPerimetr - _sideB) * (haldPerimetr - _sideC);
            return Math.Sqrt(SqrArea);
        }

        public override double Perimetr => _sideA + _sideB + _sideC;
    }
}
