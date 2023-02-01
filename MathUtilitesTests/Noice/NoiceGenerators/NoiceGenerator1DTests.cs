using MathUtilites.Noice.NoiceGenerators;

namespace MathUtilitesTests.Noice.NoiceGenerators
{
    public class NoiceGenerator1DTests
    {
        private readonly NoiceGenerator1D _generator;

        public NoiceGenerator1DTests()
        {
            _generator = new NoiceGenerator1D();
        }

        [Fact]
        public void Generate_HaveNotNullValues()
        {
            var res = _generator.Generate(123456);

            foreach (var v in res.Noice)
            {
                Assert.NotNull(v);
            }
        }
    }
}
