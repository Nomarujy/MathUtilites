namespace MathUtilites.Interpolation
{
    public static class Biliniar
    {
        public static decimal Interpolate(BiliniarParametrs parametrs)
        {
            var topInterpolatedValue = Liniar
                .Interpolate(parametrs.TopLeftValue, parametrs.TopRightValue, parametrs.StepX);

            var bottomInterpolatedValue = Liniar
                .Interpolate(parametrs.BottomLeftValue, parametrs.BottomRightValue, parametrs.StepX);

            return Liniar
                .Interpolate(topInterpolatedValue, bottomInterpolatedValue, parametrs.StepY);
        }
    }
}
