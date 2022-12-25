namespace MathUtilites.Interpolation
{
    public static class Step
    {
        public static decimal Find(decimal x0, decimal x1, decimal x)
        {
            if (x < x0) return x0;
            if (x > x1) return x1;

            return (x - x0) / (x1 - x0);
        }

        public static double Find(double x0, double x1, double x) 
            => (double)Find((decimal)x0, (decimal)x1, (decimal)x);

        public static double Find(float x0, float x1, float x)
            => (double)Find((decimal)x0, (decimal)x1, (decimal)x);

        public static double Find(int x0, int x1, int x)
            => (double)Find((decimal)x0, (decimal)x1, (decimal)x);
    }
}
