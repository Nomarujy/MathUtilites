using MathUtilites.Noice.NoiceGenerators;

namespace MathUtilitesTests.Noice.NoiceGenerators
{
    public class NoiceGenerator3DTests
    {
        private readonly NoiceGenerator3D _generator;

        public NoiceGenerator3DTests()
        {
            _generator = new NoiceGenerator3D();
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
