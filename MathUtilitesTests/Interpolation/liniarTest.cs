using MathUtilites.Interpolation;

namespace MathUtilitesTests.Interpolation
{
    
    public class liniarTes
    {
        [Fact]
        public void Interpolate_returnCorrectValue()
        {
            decimal val0 = 0;
            decimal val1 = 10;
            decimal step = 0.5M;

            var expected = val0 + (val1 - val0) * step;
            var result = Liniar.Interpolate(val0, val1, step);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Interpolate_int_ReturnCorrectValue()
        {
            int val0 = 0;
            int val1 = 10;
            double step = 0.5f;

            var expected = val0 + (val1 -val0) * step;
            var result = Liniar.Interpolate(val0, val1, step);

            Assert.Equal(expected, result);
        }
    }
}
