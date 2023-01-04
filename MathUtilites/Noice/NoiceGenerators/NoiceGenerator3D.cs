using MathUtilites.Noice.Perlin.Entity;
using MathUtilites.Parametors;

namespace MathUtilites.Noice.NoiceGenerators
{
    public class NoiceGenerator3D
    {
        private readonly NoiceGeneratorOptions _options;
        private readonly NoiceGenerator2D _generator;

        private int GenerationInterval { get; set; }

        public NoiceGenerator3D(NoiceGeneratorOptions options)
        {
            _options = options;
            _generator = new NoiceGenerator2D(options);
        }

        public Octave Generate(int seed)
        {
            return GenerateOctave(seed, Generate2D, FindDepthsForRow);
        }

        public Octave GenerateParalel(int seed)
        {
            return GenerateOctave(seed, Generate2DParalel, FindDepthsForRowParalel);
        }

        private Octave GenerateOctave(int seed, Func<int, double[][]> generate2D, Action<int, double[][][]> findDepthsForRow)
        {
            double[][][] noice = new double[_options.ArraySize][][];
            GenerationInterval = _options.InterpolatedValuesPerGenerated + 1;

            GenerateBasePlates(seed, noice, generate2D);
            InitNullArray(noice);
            GenerateInterpolatedValues(noice, findDepthsForRow);

            return new Octave(noice);
        }

        private void GenerateBasePlates(int seed, double[][][] noice, Func<int, double[][]> generate2D)
        {
            Random random = new(seed);

            for (int z = 0; z < _options.ArraySize; z += GenerationInterval)
            {
                noice[z] = generate2D.Invoke(random.Next());
            }
        }

        private double[][] Generate2D(int seed)
        {
            return _generator.Generate(seed).Noice[0];
        }

        private double[][] Generate2DParalel(int seed)
        {
            return _generator.GenerateParalel(seed).Noice[0];
        }

        private void InitNullArray(double[][][] array)
        {
            for (int z = 0; z < _options.ArraySize; z++)
            {
                if (array[z] is null)
                {
                    array[z] = new double[array.Length][];

                    for (int y = 0; y < _options.ArraySize; y++)
                    {
                        array[z][y] = new double[_options.ArraySize];
                    }
                }
            }
        }

        private void GenerateInterpolatedValues(double[][][] noice, Action<int, double[][][]> findDepthsForRow)
        {
            for (int y = 0; y < _options.ArraySize; y++)
            {
                findDepthsForRow.Invoke(y, noice);
            }
        }

        private void FindDepthsForRow(int y, double[][][] noice)
        {
            for (int x = 0; x < _options.ArraySize; x++)
            {
                InterpolateDepth(x, y, noice);
            }
        }

        private void FindDepthsForRowParalel(int y, double[][][] noice)
        {
            Parallel.For(0, _options.ArraySize,
                x => InterpolateDepth(x, y, noice));
        }

        private void InterpolateDepth(int x, int y, double[][][] noice)
        {
            for (int topIndex = GenerationInterval; topIndex < _options.ArraySize; topIndex += GenerationInterval)
            {
                var bottomIndex = topIndex - GenerationInterval;

                InterpolationParametors param = new()
                {
                    StartIndex = bottomIndex,
                    EndIndex = topIndex,
                    StartValue = noice[bottomIndex][y][x],
                    EndValue = noice[topIndex][y][x]
                };
                InterpolateZone(x, y, noice, param);
            }
        }

        private static void InterpolateZone(int x, int y, double[][][] noice, InterpolationParametors param)
        {
            for (int z = param.StartIndex + 1; z < param.EndIndex; z++)
            {
                noice[z][y][x] = Interpolation.Liniar(param, z);
            }
        }
    }
}
