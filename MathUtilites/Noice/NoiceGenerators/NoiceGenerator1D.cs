using MathUtilites.Interpolation;
using MathUtilites.Noice.Perlin.Entity;

namespace MathUtilites.Noice.NoiceGenerators
{
    internal class NoiceGenerator1D
    {
        private readonly NoiceGeneratorOptions _options;

        public NoiceGenerator1D(NoiceGeneratorOptions options)
        {
            _options = options;
        }

        public Octave Generate(int seed)
        {
            double[] noice = new double[_options.ArraySize];

            GenerateRandomValues(seed, noice);
            InterpolateValues(noice);

            return new(noice);
        }

        private void GenerateRandomValues(int seed, double[] noice)
        {
            Random random = new(seed);

            var step = _options.InterpolatedValuesPerGenerated + 1;

            for (int i = 0; i < noice.Length; i += step)
            {
                noice[i] = random.NextDouble();
            }
        }

        private void InterpolateValues(double[] noice)
        {
            var step = _options.InterpolatedValuesPerGenerated + 1;

            for (int secondIndex = step; secondIndex < noice.Length; secondIndex += step)
            {
                var firstIndex = secondIndex - step;

                var firstValue = noice[firstIndex];
                var secondValue = noice[secondIndex];

                for (int i = firstIndex + 1; i < secondIndex; i++)
                {
                    var smothStep = (double)SmothStep.Find(firstIndex, secondIndex, i);

                    noice[i] = Liniar.Interpolate(firstValue, secondValue, smothStep);
                }
            }

        }
    }
}
