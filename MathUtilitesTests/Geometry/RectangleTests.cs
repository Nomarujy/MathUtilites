using MathUtilites.Geometry;
using MathUtilites.Geometry.Entity;

namespace MathUtilitesTests.Geometry
{
    public class RectangleTests
    {
        [Fact]
        public void Perimetr()
        {
            var rec = new Rectangle(1, 4);
            var expected = 10;

            var result = rec.Perimetr;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Area()
        {
            var rec = new Rectangle(4, 4);
            var expected = 16;

            var result = rec.Area;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCoordinates_4Points()
        {
            var rec = new Rectangle(2, 2);

            var result = rec.GetCoordinates();

            Assert.Equal(4, result.Length);

            Assert.True(result[0].Equals(new Vector2D(1, 1), 0.00001));
            Assert.True(result[1].Equals(new Vector2D(-1, 1), 0.00001));
            Assert.True(result[2].Equals(new Vector2D(-1, -1), 0.00001));
            Assert.True(result[3].Equals(new Vector2D(1, -1), 0.00001));
        }

        [Fact]
        public void Width_NegativeValue_NotApplied()
        {
            var rec = new Rectangle(1, 1);

            rec.Width = -1;

            Assert.NotEqual(-1, rec.Width);
        }

        [Fact]
        public void Height_NegativeValue_NotApplied()
        {
            var rec = new Rectangle(1, 1);

            rec.Height = -1;

            Assert.NotEqual(-1, rec.Width);
        }
    }
}
