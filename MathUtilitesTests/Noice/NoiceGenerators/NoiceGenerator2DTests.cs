using MathUtilites.Noice.NoiceGenerators;

namespace MathUtilitesTests.Noice.NoiceGenerators
{
    public class NoiceGenerator2DTests
    {
        private readonly NoiceGenerator2D _generator;

        public NoiceGenerator2DTests()
        {
            _generator = new NoiceGenerator2D();
        }

        [Fact]
        public void Generate_HaveNotNullValues()
        {
            var res = _generator.Generate(123456);

            foreach (var item in res.Noice)
            {
                Assert.NotNull(item);
            }
        }
    }
}
