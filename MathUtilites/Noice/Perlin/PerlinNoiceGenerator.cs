using MathUtilites.Noice.Perlin.Entity;
using MathUtilites.Noice.Perlin.NoiceGenerators;
using MathUtilites.Noice.Perlin.Options;

namespace MathUtilites.Noice.Perlin
{
    public class PerlinNoiceGenerator
    {
        public PerlinNoiceGenerator()
        {
            NoiceGeneratorOptions = new NoiceGeneratorOptions();
            PerlinNoiceOptions = new PerlinNoiceOptions();
        }

        public NoiceGeneratorOptions NoiceGeneratorOptions { get; private set; }
        public PerlinNoiceOptions PerlinNoiceOptions { get; private set; }

        public double[] Generate1D(int seed)
        {
            Random random = new(seed);

            NoiceGenerator1D generator = new(NoiceGeneratorOptions);

            Octave result = generator.Generate(random.Next());

            result = IncreaseReesolution(result,
                () => generator.Generate(random.Next()));

            return result.Noice[0][0];
        }

        public double[][] Generate2D(int seed)
        {
            Random random = new(seed);

            NoiceGenerator2D generator = new(NoiceGeneratorOptions);
            Octave result = generator.Generate(random.Next());

            result = IncreaseReesolution(result, () => generator.Generate(random.Next()));

            return result.Noice[0];
        }

        private Octave IncreaseReesolution(Octave octave, Func<Octave> generator)
        {
            Octave result = octave;

            for (int i = 1; i < PerlinNoiceOptions.OctaveDepth; i++)
            {
                NoiceGeneratorOptions.NumbersOfGenerated *= 2;

                Octave lastOctave = generator.Invoke();

                result += lastOctave;
            }
            return result;
        }

    }
}
