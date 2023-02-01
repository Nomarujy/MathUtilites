using MathUtilites;

namespace MathUtilitesTests
{
    public class StatisticTests
    {
        [Fact]
        public void Average_correctResult()
        {
            decimal[] values = { 0m, 10m };

            var result = Statistic.Average(values[0], values[1]);
            var expected = values.Average();

            Assert.Equal(expected, result);
        }

        #region Median

        [Fact]
        public void Median_decimal_correctResult()
        {
            decimal[] values = { 0, 15, 156, 432635, 345, 12, 1 };
            decimal expected = 15;

            var result = Statistic.Median(values);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Median_int_correctResult()
        {
            int[] values = { 0, 15, 156, 432635, 345, 12, 1 };
            int expected = 15;

            var result = Statistic.Median(values);

            Assert.Equal(expected, result);
        }

        #endregion Median

        [Theory, MemberData(nameof(PercetileTestParametors))]
        public void Percentile_correctResult(decimal percent, decimal expected)
        {
            var result = Statistic.Percentile(PercentileTestData, percent);

            Assert.Equal(expected, result);
        }

        private readonly decimal[] PercentileTestData = { 0, 65415, 156, 432635, 345, 1214, 1 };

        public static IEnumerable<object[]> PercetileTestParametors()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, 432635 };
            yield return new object[] { 0.5, 345 };
        }
    }
}
