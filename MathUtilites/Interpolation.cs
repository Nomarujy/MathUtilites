using MathUtilites.Parametors;

namespace MathUtilites
{
    public class Interpolation
    {

        #region Liniar

        public static decimal Liniar(decimal leftValue, decimal rightValue, decimal step)
        {
            return leftValue + (rightValue - leftValue) * step;
        }

        public static double Liniar(double leftValue, double rightValue, double step)
            => (double)Liniar((decimal)leftValue, (decimal)rightValue, (decimal)step);

        public static double Liniar(float leftValue, float rightValue, float step)
           => (double)Liniar((decimal)leftValue, (decimal)rightValue, (decimal)step);

        public static double Liniar(int leftValue, int rightValue, int step)
           => (double)Liniar(leftValue, rightValue, (decimal)step);

        #endregion Liniar

        #region Biliniar

        public static decimal Biliniar(BiliniarParametrs parametrs)
        {
            var topInterpolatedValue = 
                Liniar(parametrs.TopLeftValue, parametrs.TopRightValue, parametrs.StepX);

            var bottomInterpolatedValue = 
                Liniar(parametrs.BottomLeftValue, parametrs.BottomRightValue, parametrs.StepX);

            return Liniar(topInterpolatedValue, bottomInterpolatedValue, parametrs.StepY);
        }

        #endregion Biliniar
    }
}
