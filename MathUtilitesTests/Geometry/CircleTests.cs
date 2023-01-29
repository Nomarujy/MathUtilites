using MathUtilites.Geometry;
using MathUtilites.Geometry.Entity;

namespace MathUtilitesTests.Geometry
{
    public class CircleTests
    {
        [Fact]
        public void PointByAnglge_ZeroAngle()
        {
            var circle = new Circle(1, Vector2D.Zero);
           
            var result = circle.PointByDegrees(0);

            Assert.Equal(1, result.X);
            Assert.Equal(0, result.Y);
        }

        [Fact]
        public static void Area_WithSingleCircle()
        {
            var circle = new Circle(10);
            var expected = Math.PI * 100;

            var result = circle.Area;
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void Periment_WithSingleCircle()
        {
            var circle = new Circle(10);
            var expected = 10 * Math.PI * 2;

            var result = circle.Perimetr;

            Assert.Equal(expected, result);
        }
    }
}
