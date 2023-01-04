using MathUtilites.Noice.Perlin.Entity;
using MathUtilites.Parametors;

namespace MathUtilites.Noice.NoiceGenerators
{
    public class NoiceGenerator2D
    {
        private readonly NoiceGeneratorOptions _options;
        private readonly NoiceGenerator1D _generator1D;

        private int GenerationInterval { get; set; }

        public NoiceGenerator2D(NoiceGeneratorOptions options)
        {
            _options = options;
            _generator1D = new(options);
        }

        public Octave Generate(int seed)
        {
            return GenerateOctave(seed, Generate1D, InterpolateRow);
        }

        public Octave GenerateParalel(int seed)
        {
            return GenerateOctave(seed, Generate1DParalel, InterpolateRowParalel);
        }

        private Octave GenerateOctave(int seed, Func<int, double[]> generate1D, Action<double[][], int> interpolateRow)
        {
            double[][] noice = new double[_options.ArraySize][];
            GenerationInterval = _options.InterpolatedValuesPerGenerated + 1;

            GenerateRandomLines(seed, noice, generate1D);
            InitNullArrays(noice);
            GenerateInterpolatedLines(noice, interpolateRow);

            return new Octave(noice);
        }

        private void GenerateRandomLines(int seed, double[][] noice, Func<int, double[]> generator1D)
        {
            Random random = new(seed);

            for (int y = 0; y < noice.Length; y+= GenerationInterval)
            {
                noice[y] = generator1D.Invoke(random.Next());
            }
        }

        private double[] Generate1D(int seed)
        {
            return _generator1D.Generate(seed).Noice[0][0];
        }

        private double[] Generate1DParalel(int seed)
        {
            return _generator1D.GenerateParalel(seed).Noice[0][0];
        }

        private void InitNullArrays(double[][] array)
        {
            for (int i = 0; i < _options.ArraySize; i++)
            {
                if (array[i] is null)
                {
                    array[i] = new double[_options.ArraySize];
                }
            }
        }

        private void GenerateInterpolatedLines(double[][] noice, Action<double[][], int> interpolateRow)
        {
            for (int y = 1; y < noice.Length; y += GenerationInterval)
            {
                interpolateRow.Invoke(noice, y);
            }
        }

        private void InterpolateRow(double[][] noice, int y)
        {
            for (int x = 0; x < _options.ArraySize; x++)
            {
                InterpolateColumn(noice, x, y);
            }
        }

        private void InterpolateRowParalel(double[][] noice, int y)
        {
            Parallel.For(0, _options.ArraySize,
                x => InterpolateColumn(noice, x, y));
        }

        private void InterpolateColumn(double[][] noice, int x, int y)
        {
            var startY = y - 1;
            var endY = startY + GenerationInterval;

            InterpolationParametors param = new()
            {
                StartIndex = startY,
                EndIndex = endY,
                StartValue = noice[startY][x],
                EndValue = noice[endY][x],
            };

            for (int i = y; i < endY; i++)
            {
                noice[i][x] = Interpolation.Liniar(param, i);
            }
        }
    }
}
