namespace MathUtilites
{
    public static class StepFinder
    {
        #region Step

        public static decimal Step(decimal x0, decimal x1, decimal x)
        {
            if (x < x0) return x0;
            if (x > x1) return x1;

            return (x - x0) / (x1 - x0);
        }

        public static double Step(double x0, double x1, double x)
            => (double)Step((decimal)x0, (decimal)x1, (decimal)x);

        public static double Step(float x0, float x1, float x)
            => (double)Step((decimal)x0, (decimal)x1, (decimal)x);

        public static double Step(int x0, int x1, int x)
            => (double)Step(x0, x1, (decimal)x);

        #endregion Step

        #region SmothStep

        public static decimal SmothStep(decimal firstIndex, decimal secondIndex, decimal indexBetween)
        {
            var step = Step(firstIndex, secondIndex, indexBetween);

            if (step == firstIndex || step == secondIndex) return step;

            return step * step * (3 - 2 * step);
        }

        public static double SmothStep(double firstIndex, double secondIndex, double indexBetween)
            => (double)SmothStep((decimal)firstIndex, (decimal)secondIndex, (decimal)indexBetween);

        public static double SmothStep(float firstIndex, float secondIndex, float indexBetween)
            => (double)SmothStep((decimal)firstIndex, (decimal)secondIndex, (decimal)indexBetween);

        public static double SmothStep(int firstIndex, int secondIndex, int indexBetween)
            => (double)SmothStep(firstIndex, secondIndex, (decimal)indexBetween);

        #endregion SmothStep
    }
}
