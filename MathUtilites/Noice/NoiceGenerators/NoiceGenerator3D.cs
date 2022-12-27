using MathUtilites.Noice.Perlin.Entity;

namespace MathUtilites.Noice.NoiceGenerators
{
    internal class NoiceGenerator3D
    {
        private readonly NoiceGeneratorOptions _options;
        private readonly NoiceGenerator2D _generator;

        public NoiceGenerator3D(NoiceGeneratorOptions options)
        {
            _options = options;
            _generator = new NoiceGenerator2D(options);
        }

        public Octave Generate(int seed)
        {
            double[][][] noice = new double[_options.ArraySize][][];

            GenerateBasePlates(seed, noice);
            InitArray(noice);
            InterpolateDepth(noice);

            return new Octave(noice);
        }

        private void GenerateBasePlates(int seed, double[][][] noice)
        {
            Random random = new(seed);
            var step = _options.InterpolatedValuesPerGenerated + 1;


            for (int z = 0; z < _options.ArraySize; z += step)
            {
                noice[z] = _generator.Generate(random.Next()).Noice[0];
            }
        }

        private void InitArray(double[][][] array)
        {
            for (int z = 0; z < _options.ArraySize; z++)
            {
                if (array[z] is null)
                {
                    array[z] = new double[array.Length][];
                    InitArray(array[z]);
                }
            }
        }

        private void InitArray(double[][] array)
        {
            for (int y = 0; y < _options.ArraySize; y++)
            {
                array[y] = new double[_options.ArraySize];
            }
        }

        private void InterpolateDepth(double[][][] noice)
        {
            for (int y = 0; y < _options.ArraySize; y++)
            {
                Parallel.For(0, _options.ArraySize, (x) => Interpolate(x, y, noice));
            }
        }

        private void Interpolate(int x, int y, double[][][] noice)
        {
            var step = _options.InterpolatedValuesPerGenerated + 1;

            for (int z = step; z < _options.ArraySize; z++)
            {
                var leftIndex = z - step;
                var rightIndex = z;

                var leftValue = noice[leftIndex][y][x];
                var rightValue = noice[rightIndex][y][x];

                for (int i = leftIndex + 1; i < rightIndex; i++)
                {
                    var smothStep = StepFinder.Step(leftIndex, z, i);

                    noice[i][y][x] = Interpolation.Liniar(leftValue, rightValue, smothStep);
                }
            }
        }
    }
}
