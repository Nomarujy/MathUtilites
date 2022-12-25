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
    }
}
