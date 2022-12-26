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

        private static decimal[] ConvertArray<T>(T[] values)
        {
            decimal[] array = new decimal[values.Length];
            values.CopyTo(array, 0);

            return array;
        }

        #region Median

        public static decimal Median(decimal[] values)
        {
            var count = values.Count();
            var skip = count / 2;

            IOrderedEnumerable<decimal> orderedArray = values.OrderBy(x => x);

            if (skip % 2 == 0)
            {
                orderedArray = (IOrderedEnumerable<decimal>)orderedArray
                    .Skip(skip - 1)
                    .Take(2);
            }
            else
            {
                orderedArray = (IOrderedEnumerable<decimal>)orderedArray
                    .Skip(skip)
                    .Take(1);
            }
            return orderedArray.Average();
        }

        public static double Median(double[] values)
        {
            var array = ConvertArray(values);

            return (double)Median(array);
        }

        public static double Median(float[] values)
        {
            var array = ConvertArray(values);

            return (double)Median(array);
        }

        public static double Median(int[] values)
        {
            var array = ConvertArray(values);

            return (double)Median(array);
        }

        #endregion Median

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
            var array = ConvertArray(values);

            return (double)Percentile(array, (decimal)percent);
        }

        public static double Percentile(float[] values, float percent)
        {
            var array = ConvertArray(values);

            return (double)Percentile(array, (decimal)percent);
        }

        public static double Percentile(int[] values, float percent)
        {
            var array = ConvertArray(values);

            return (double)Percentile(array, (decimal)percent);
        }

        #endregion Percentile
    }
}
