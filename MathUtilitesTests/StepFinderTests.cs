using MathUtilites;

namespace MathUtilitesTests
{
    public class StepFinderTests
    {
        [Fact]
        public void Step_decimal_correctResult()
        {
            decimal x0 = 0;
            decimal x1 = 100;
            decimal x = 50;

            var result = StepFinder.Step(x0, x1, x);
            var expected = Step(x0, x1, x);

            Assert.Equal(expected, result);
        }

        private decimal Step(decimal x0, decimal x1, decimal x)
        {
            if (x < x0) return x0;
            if (x > x1) return x1;

            return (x - x0) / (x1 - x0);
        }

        [Fact]
        public void SmothStep_decimal_correctResult()
        {
            decimal x0 = 0;
            decimal x1 = 100;
            decimal x = 50;


            var result = StepFinder.SmothStep(x0, x1, x);

            var step = Step(x0, x1, x);
            var expected = step * step * (3 - 2 * step);

            Assert.Equal(expected, result);
        }
    }
}
