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
    }
}
