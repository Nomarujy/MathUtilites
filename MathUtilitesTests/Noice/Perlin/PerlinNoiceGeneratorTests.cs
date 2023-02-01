using MathUtilites.Noice.Perlin;

namespace MathUtilitesTests.Noice.Perlin
{
    public class PerlinNoiceGeneratorTests
    {
        private readonly PerlinNoiceGenerator _generator;

        public PerlinNoiceGeneratorTests()
        {
            _generator= new PerlinNoiceGenerator();
        }

        [Fact]
        public void Generate_WithoutDepth_HaveNotNullValues()
        {
            _generator.PerlinNoiceOptions.OctaveDepth = 1;

            var res = _generator.Generate2D(123456);

            foreach(var item in res)
            {
                Assert.NotNull(item);
            }
        }

        [Fact]
        public void Generate_WithDepth_HaveNotNullValues()
        {
            _generator.PerlinNoiceOptions.OctaveDepth = 2;
            var res = _generator.Generate2D(123456);

            foreach (var item in res)
            {
                Assert.NotNull(item);
            }
        }
    }
}
