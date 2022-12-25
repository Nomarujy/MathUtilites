using MathUtilites.Interpolation;
using MathUtilites.Noice.Perlin.Entity;

namespace MathUtilites.Noice.NoiceGenerators
{
    internal class NoiceGenerator2D
    {
        private readonly NoiceGeneratorOptions _options;
        private readonly NoiceGenerator1D _generator1D;

        public NoiceGenerator2D(NoiceGeneratorOptions options)
        {
            _options = options;
            _generator1D = new(options);
        }

        public Octave Generate(int seed)
        {
            double[][] noice = new double[_options.ArraySize][];

            GenerateBaseLines(seed, noice);
            InitNullArrays(noice);

            InterpolateVerticalLines(noice);
            return new Octave(noice);
        }

        private void GenerateBaseLines(int seed, double[][] noice)
        {
            Random random = new(seed);
            var step = _options.InterpolatedValuesPerGenerated + 1;

            List<Task> tasks = new(_options.ArraySize / step + 1);

            Parallel.For(0, _options.ArraySize, (index) => GenerateLine(ref noice[index], random.Next()));
        }

        private void InitNullArrays(double[][] noice)
        {
            for (int i = 0; i < noice.Length; i++)
            {
                if (noice[i] is null)
                {
                    noice[i] = new double[_options.ArraySize];
                }
            }
        }

        private void GenerateLine(ref double[] noice, int seed)
        {
            noice = _generator1D.Generate(seed).Noice[0][0];
        }

        private void InterpolateVerticalLines(double[][] noice)
        {
            Parallel.For(0, _options.ArraySize, (index) => Interpolate(index, noice));
        }

        private void Interpolate(int x, double[][] noice)
        {
            var step = _options.InterpolatedValuesPerGenerated + 1;

            for (int y = step; y < _options.ArraySize; y += step)
            {
                var topIndex = y - step;
                var bottomIndex = y;

                var topValue = noice[topIndex][x];
                var bottomValue = noice[bottomIndex][x];

                for (int i = topIndex + 1; i < bottomIndex; i++)
                {
                    var smothStep = SmothStep.Find(topIndex, bottomIndex, i);

                    noice[i][x] = Liniar.Interpolate(topValue, bottomValue, smothStep);
                }
            }
        }
    }
}
