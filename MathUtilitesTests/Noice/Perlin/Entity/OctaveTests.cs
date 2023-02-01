using MathUtilites.Noice.Perlin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtilitesTests.Noice.Perlin.Entity
{
    public class OctaveTests
    {
        private static double[][] smallArray => new double[][] 
        {
                new double[] { 1 , 2},
                new double[] { 3 , 4},
        };

        private static double[][] bigArray = new double[][]
        {
            new double[] { 1 , 1, 1, 1},
            new double[] { 1 , 1, 1, 1},
            new double[] { 1 , 1, 1, 1},
            new double[] { 1 , 1, 1, 1},
            new double[] { 1 , 1, 1, 1},
        };

        [Fact]
        public void Addition_HaveNotNullValues()
        {
            Octave octave1 = new(smallArray);
            Octave octave2 = new(bigArray);

            var res = octave1 + octave2;

            foreach(var item in res.Noice)
            {
                Assert.NotNull(item);
            } 
        }
    }
}
