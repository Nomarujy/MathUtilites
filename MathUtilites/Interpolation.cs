using MathUtilites.Parametors;

namespace MathUtilites
{
    public class Interpolation
    {

        #region Liniar

        public static decimal Liniar(decimal startValue, decimal endValue, decimal step)
        {
            return startValue + (endValue - startValue) * step;
        }

        public static double Liniar(double startValue, double endValue, double step)
            => (double)Liniar((decimal)startValue, (decimal)endValue, (decimal)step);

        public static double Liniar(float startValue, float endValue, float step)
           => (double)Liniar((decimal)startValue, (decimal)endValue, (decimal)step);

        public static double Liniar(int startValue, int endValue, double step)
           => (double)Liniar(startValue, endValue, (decimal)step);

        // index excluse parametors, cause: paralel race
        public static double Liniar(InterpolationParametors param, int index)
        {
            var smothStep = (double)StepFinder.SmothStep(param.StartIndex, param.EndIndex, index);

            return Liniar(param.StartValue, param.EndValue, smothStep);
        }

        #endregion Liniar

        #region Biliniar

        public static decimal Biliniar(BiliniarParametors parametrs)
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
