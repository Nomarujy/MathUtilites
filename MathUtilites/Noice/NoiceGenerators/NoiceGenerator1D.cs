using MathUtilites.Noice.Perlin.Entity;
using MathUtilites.Parametors;

namespace MathUtilites.Noice.NoiceGenerators
{
    public class NoiceGenerator1D
    {
        private readonly NoiceGeneratorOptions _options;

        private int GenerationInterval { get; set; }

        public NoiceGenerator1D() : this(new NoiceGeneratorOptions()) { }

        public NoiceGenerator1D(NoiceGeneratorOptions options)
        {
            _options = options;
        }

        public Octave Generate(int seed)
        {
            return GenerateOctave(seed, GenerateInterpolatedValues);
        }

        public Octave GenerateParalel(int seed)
        {
            return GenerateOctave(seed, GenerateInterpolatedValuesParalel);
        }

        private Octave GenerateOctave(int seed, Action<double[]> InterpolationGenerator)
        {
            double[] noice = new double[_options.ArraySize];

            GenerationInterval = _options.InterpolatedValuesPerGenerated + 1;

            GenerateRandomValues(seed, noice);
            InterpolationGenerator.Invoke(noice);

            return new(noice);
        }

        private void GenerateRandomValues(int seed, double[] noice)
        {
            Random random = new(seed);

            for (int i = 0; i < noice.Length; i += GenerationInterval)
            {
                noice[i] = random.NextDouble();
            }
        }

        private void GenerateInterpolatedValues(double[] noice)
        {
            for (int i = 0; i < _options.GeneratedCount - 1; i++)
            {
                InterpolateZone(i, noice);
            }
        }
        private void GenerateInterpolatedValuesParalel(double[] noice)
        {
            Parallel.For(0, _options.GeneratedCount, 
                i => InterpolateZone(i, noice));
        }

        private void InterpolateZone(int generatedIndex, double[] noice)
        {
            var startIndex = generatedIndex * GenerationInterval;
            var endIndex = startIndex + GenerationInterval;

            InterpolationParametors param = new()
            {
                StartIndex = startIndex,
                EndIndex = endIndex,
                StartValue = noice[startIndex],
                EndValue = noice[endIndex],
            };

            for (int x = param.StartIndex + 1; x < param.EndIndex; x++)
            {
                noice[x] = Interpolation.Liniar(param, x);
            }
        }
    }
}
