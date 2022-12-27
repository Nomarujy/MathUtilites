namespace MathUtilites.Parametors
{
    public class BiliniarParametrs
    {
        public decimal TopLeftValue { get; set; }
        public decimal TopRightValue { get; set; }

        public decimal BottomLeftValue { get; set; }
        public decimal BottomRightValue { get; set; }


        private decimal _stepX = 0;
        public decimal StepX
        {
            get { return _stepX; }
            set
            {
                _stepX = ValueAtRange(value);
            }
        }

        private decimal _stepY = 0;
        public decimal StepY
        {
            get { return _stepY; }
            set
            {
                _stepY = ValueAtRange(value);
            }
        }

        private decimal ValueAtRange(decimal value, decimal min = 0, decimal max = 1)
        {
            if (value < min) return min;
            if (value > max) return max;

            return value;
        }
    }
}
