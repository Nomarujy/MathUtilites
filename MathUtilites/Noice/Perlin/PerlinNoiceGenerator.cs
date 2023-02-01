using MathUtilites.Noice.NoiceGenerators;
using MathUtilites.Noice.Perlin.Entity;
using System;

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

        private Octave GenerateOctave(int seed, Func<int, Octave> generateFunc)
        {
            Random random = new(seed);

            Octave octave = generateFunc.Invoke(random.Next());

            octave = IncreaseReesolution(octave,
                () => generateFunc.Invoke(random.Next()));

            return octave;
        }

        private Octave IncreaseReesolution(Octave octave, Func<Octave> generator)
        {
            Octave result = octave;

            for (int i = 1; i < PerlinNoiceOptions.OctaveDepth; i++)
            {
                NoiceGeneratorOptions.GeneratedCount *= 2;

                Octave lastOctave = generator.Invoke();

                result = (result + lastOctave) / 2f;
            }
            return result;
        }

        public double[] Generate1D(int seed)
        {
            NoiceGenerator1D generator = new(NoiceGeneratorOptions);

            return GenerateOctave(seed,
                generator.Generate).Noice[0][0];
        }

        public double[] Generate1DParalel(int seed)
        {
            NoiceGenerator1D generator = new(NoiceGeneratorOptions);

            return GenerateOctave(seed,
                generator.GenerateParalel).Noice[0][0];
        }

        public double[][] Generate2D(int seed)
        {
            NoiceGenerator2D generator = new(NoiceGeneratorOptions);

            return GenerateOctave(seed, 
                generator.Generate)
                .Noice[0];
        }

        public double[][] Generate2DParalel(int seed)
        {
            NoiceGenerator2D generator = new(NoiceGeneratorOptions);

            return GenerateOctave(seed,
                generator.GenerateParalel)
                .Noice[0];
        }

        public double[][][] Generate3D(int seed)
        {
            NoiceGenerator3D generator = new(NoiceGeneratorOptions);

            return GenerateOctave(seed,
                generator.Generate)
                .Noice;
        }

        public double[][][] Generate3DParalel(int seed)
        {
            NoiceGenerator3D generator = new(NoiceGeneratorOptions);

            return GenerateOctave(seed,
                generator.GenerateParalel)
                .Noice;
        }

    }
}
