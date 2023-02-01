using MathUtilites.Geometry;

namespace MathUtilitesTests.Geometry
{
    public class SquareTests
    {
        [Fact]
        public void Width_Negative_NotApplied()
        {
            var square = new Square(2);

            square.Width = -1;

            Assert.NotEqual(-1, square.Width);
        }

        [Fact]
        public void Height_Negative_NotApplied()
        {
            var square = new Square(2);

            square.Height = -1;

            Assert.NotEqual(-1, square.Height);
        }

        [Fact]
        public void Height_ChangeAllSides()
        {
            var square = new Square(2);

            square.Height = 10;

            Assert.Equal(10, square.Width);
            Assert.Equal(10, square.Height);
        }

        [Fact]
        public void Width_ChangeAllSides()
        {
            var square = new Square(2);

            square.Width = 10;

            Assert.Equal(10, square.Width);
            Assert.Equal(10, square.Height);
        }
    }
}
