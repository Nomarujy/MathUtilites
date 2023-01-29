using MathUtilites.Geometry;

namespace MathUtilitesTests.Geometry
{
    public class TriangleTests
    {
        [Fact]
        public void IsRightAngled_ForRightAndledTriangle_True()
        {
            var triangle = new Triangle(3, 4, 5);

            var result = triangle.IsRightAngled;

            Assert.True(result);
        }

        [Fact]
        public void IsRightAngled_ForAnyTriangle_False()
        {
            var triangle = new Triangle(3, 4, 10);

            var result = triangle.IsRightAngled;

            Assert.False(result);
        }

        [Fact]
        public void Perimetr()
        {
            var triangle = new Triangle(1, 2, 3);

            var result = triangle.Perimetr;

            Assert.Equal(6, result);
        }

        [Fact]
        public void Area()
        {
            var triangle = new Triangle(3, 4, 5);

            var expected = Math.Sqrt(6 * (6 - 3) * (6 - 4) * (6 - 5));

            var result = triangle.Area;

            Assert.Equal(expected, result);
        }
    }
}
