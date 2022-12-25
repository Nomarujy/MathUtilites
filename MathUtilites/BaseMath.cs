namespace MathUtilites
{
    public static class BaseMath
    {
        public static decimal Average(decimal x, decimal y)
        {
            return (x + y) / 2;
        }

        public static double Average(double x, double y)
            => (double)Average((decimal)x, (decimal)y);

        public static float Average(float x, float y)
            => (float)Average((decimal)x, (decimal)y);

        public static double Average(int x, int y)
            => (float)Average(x, (decimal)y);
    }
}
