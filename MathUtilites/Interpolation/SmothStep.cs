using MathUtilites.Interpolation;

namespace MathUtilites.Utilites
{
    public static class SmothStep
    {
        public static decimal Find(decimal firstIndex, decimal secondIndex, decimal indexBetween)
        {
            var step = Step.Find(firstIndex, secondIndex, indexBetween);

            if (step == firstIndex || step == secondIndex) return step;

            return step * step * (3 - 2 * step);
        }

        public static double Find(double firstIndex, double secondIndex, double indexBetween)
            => (double)Find((decimal)firstIndex, (decimal)secondIndex, (decimal)indexBetween);

        public static float Find(float firstIndex, float secondIndex, float indexBetween)
            => (float)Find((decimal)firstIndex, (decimal)secondIndex, (decimal)indexBetween);

        public static double Find(int firstIndex, int secondIndex, int indexBetween)
            => (double)Find(firstIndex, secondIndex, (decimal)indexBetween);
    }
}
