namespace MathUtilites.Interpolation
{
    public static class Liniar
    {
        public static decimal Interpolate(decimal leftValue, decimal rightValue, decimal step)
        {
            return leftValue + (rightValue - leftValue) * step;
        }

        public static double Interpolate(double leftValue, double rightValue, double step)
            => (double)Interpolate((decimal)leftValue, (decimal)rightValue, (decimal)step);

        public static float Interpolate(float leftValue, float rightValue, float step)
           => (float)Interpolate((decimal)leftValue, (decimal)rightValue, (decimal)step);

        public static double Interpolate(int leftValue, int rightValue, int step)
           => (double)Interpolate(leftValue, rightValue, (decimal)step);
    }
}
