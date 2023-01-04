using MathUtilites;
using MathUtilites.Parametors;

namespace MathUtilitesTests
{
    public class InterpolationTests
    {
        #region Liniar

        [Fact]
        public void Liniar_decimal_CorrectResult()
        {
            decimal x0 = 0;
            decimal x1 = 10;
            decimal step = 0.5m;

            var result = Interpolation.Liniar(x0, x1, step);
            decimal expected = Interpolate(x0, x1, step);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Liniar_int_CorrectResult()
        {
            int x0 = 0;
            int x1 = 100;
            double step = 0.5;

            var result = Interpolation.Liniar(x0, x1, step);
            var expected = (double)Interpolate(x0, x1, (decimal)step);

            Assert.Equal(expected, result);
        }

        #endregion Liniar

        #region Bilinar

        private decimal Interpolate(decimal x0, decimal x1, decimal step)
        {
            return x0 + step * (x1 - x0);
        }

        
       private BiliniarParametors GetBiliniarParametrs()
        {
            return new BiliniarParametors()
            {
                TopLeftValue = 0,
                TopRightValue = 100,
                BottomLeftValue = 100,
                BottomRightValue = 200,
                StepX = 0.5m,
                StepY = 0.5m,
            };
        }

        [Fact]
        public void Biliniar_correctResult()
        {
            var param = GetBiliniarParametrs();

            var result = Interpolation.Biliniar(param);

            var topValue = Interpolate(param.TopLeftValue, param.BottomLeftValue, param.StepY);
            var bottomValue = Interpolate(param.TopRightValue, param.BottomRightValue, param.StepY);
            var expected = Interpolate(topValue, bottomValue, param.StepX);

            Assert.Equal(expected, result);
        }

        #endregion Biliniar
    }
}
