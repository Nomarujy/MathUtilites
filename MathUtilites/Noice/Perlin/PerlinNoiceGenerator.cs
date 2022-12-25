using MathUtilites.Noice.NoiceGenerators;
using MathUtilites.Noice.Perlin.Entity;

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
            result = IncreaseReesolution(result, 
                () => generator.Generate(random.Next()));

            return result.Noice[0];
        }

        public double[][][] Generate3D(int seed)
        {
            Random random = new(seed);
            NoiceGenerator3D generator = new(NoiceGeneratorOptions);

            Octave result = generator.Generate(random.Next());
            result = IncreaseReesolution(result, 
                () => generator.Generate(random.Next()));

            return result.Noice;
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
