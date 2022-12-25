namespace MathUtilites.Interpolation
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
                _stepX = Step.Find(0, 1, value);
            }
        }

        private decimal _stepY = 0;
        public decimal StepY
        {
            get { return _stepY; }
            set
            {
                _stepY = Step.Find(0, 1, value);
            }
        }
    }
}
