namespace MathUtilites
{
    public static class Statistic
    {
        #region Average
        public static decimal Average(decimal x, decimal y)
        {
            return (x + y) / 2;
        }

        public static double Average(double x, double y)
            => (double)Average((decimal)x, (decimal)y);

        public static double Average(float x, float y)
            => (double)Average((decimal)x, (decimal)y);

        public static double Average(int x, int y)
            => (float)Average(x, (decimal)y);

        #endregion Average

        #region Median

        public static decimal Median(decimal[] values)
        {
            var count = values.Count();
            var skip = count / 2;

            IOrderedEnumerable<decimal> orderedArray = values.OrderBy(x => x);
            decimal result;

            if (skip % 2 == 0)
            {
                result = orderedArray
                    .Skip(skip - 1)
                    .Take(2).Average();
            }
            else
            {
                result = orderedArray
                    .Skip(skip)
                    .Take(1)
                    .Average();
            }
            return result;
        }

        public static double Median(double[] values)
        {
            var array = ConvertDoubleToDecimal(values);

            return (double)Median(array);
        }

        public static double Median(float[] values)
        {
            var array = ConvertFloatToDecimal(values);

            return (double)Median(array);
        }

        public static double Median(int[] values)
        {
            var array = ConvertIntToDecimal(values);

            return (double)Median(array);
        }

        #endregion Median

        private static decimal[] ConvertDoubleToDecimal(double[] values)
        {
            return Array.ConvertAll(values, x => (decimal)x);
        }

        private static decimal[] ConvertFloatToDecimal(float[] values)
        {
            return Array.ConvertAll(values, x => (decimal)x);
        }

        private static decimal[] ConvertIntToDecimal(int[] values)
        {
            return Array.ConvertAll(values, x => (decimal)x);
        }

        #region Percentile

        public static decimal Percentile(decimal[] values, decimal percent)
        {
            if (percent > 1 || percent < 0) throw new ArgumentOutOfRangeException(nameof(percent), "Percent Out of 0 and 1");

            int requiredElement = (int)Math.Round(percent * values.Length);

            // Translate to array Index
            if (requiredElement > 0)
            {
                requiredElement--;
            }

            return values
                .OrderBy(x=>x)
                .Skip(requiredElement)
                .First();
        }

        public static double Percentile(double[] values, double percent)
        {
            decimal[] array = ConvertDoubleToDecimal(values);

            return (double)Percentile(array, (decimal)percent);
        }

        public static double Percentile(float[] values, float percent)
        {
            var array = ConvertFloatToDecimal(values);

            return (double)Percentile(array, (decimal)percent);
        }

        public static double Percentile(int[] values, float percent)
        {
            var array = ConvertIntToDecimal(values);

            return (double)Percentile(array, (decimal)percent);
        }

        #endregion Percentile
    }
}
