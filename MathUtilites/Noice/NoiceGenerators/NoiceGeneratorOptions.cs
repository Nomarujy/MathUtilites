namespace MathUtilites.Noice.NoiceGenerators
{
    public class NoiceGeneratorOptions
    {
        private int _numbersOfGenerated = 6;
        public int NumbersOfGenerated
        {
            get { return _numbersOfGenerated; }
            set
            {
                if (value > 1)
                {
                    _numbersOfGenerated = value;
                }
            }
        }

        private int _interpolatedValuesPerGenerated = 5;
        public int InterpolatedValuesPerGenerated
        {
            get { return _interpolatedValuesPerGenerated; }
            set
            {
                if (value >= 0)
                {
                    _interpolatedValuesPerGenerated = value;
                }
            }
        }

        public int ArraySize
        {
            get
            {
                return NumbersOfGenerated + (NumbersOfGenerated - 1) * InterpolatedValuesPerGenerated;
            }
        }
    }
}
