namespace MathUtilites.Noice.Perlin.Entity
{
    internal class Octave
    {
        public Octave(double[] noice)
        {
            Noice = new double[1][][];
            Noice[0] = new double[1][];
            Noice[0][0] = noice;
        }

        public Octave(double[][] noice)
        {
            Noice = new double[1][][];
            Noice[0] = noice;
        }

        public Octave(double[][][] noice)
        {
            Noice = noice;
        }

        public Octave(Octave octave)
        {
            Noice = null!;
            octave.Copy(this);
        }

        public double[][][] Noice { get; private set; }

        public int Resolution
        {
            get
            {
                var size = XLenght * YLenght * ZLenght;
                return size;
            }
        }

        public int XLenght => Noice[0][0].Length;
        public int YLenght => Noice[0].Length;
        public int ZLenght => Noice.Length;

        public void Copy(Octave Destination)
        {
            Destination.Noice = new double[ZLenght][][];

            for (int z = 0; z < ZLenght; z++)
            {
                Destination.Noice[z] = new double[YLenght][];
                for (int y = 0; y < YLenght; y++)
                {
                    Destination.Noice[z][y] = new double[XLenght];
                    for (int x = 0; x < XLenght; x++)
                    {
                        Destination.Noice[z][y][x] = Noice[z][y][x];
                    }
                }
            }
        }

        public static Octave operator +(Octave left, Octave right)
        {
            Octave smaller, biger;
            if (left.Resolution < right.Resolution)
            {
                smaller = left;
                biger = right;
            }
            else
            {
                biger = left;
                smaller = right;
            }

            var result = AverageForZDimension(smaller.Noice, biger.Noice);

            return new(result);
        }

        private static double[][][] AverageForZDimension(double[][][] smaller, double[][][] biger)
        {
            var BigElementsPerSmall = biger.Length / smaller.Length;

            var result = new double[biger.Length][][];

            for (int z = 0; z < smaller.Length; z++)
            {
                for (int Z = z * BigElementsPerSmall; Z < (z + 1) * BigElementsPerSmall; Z++)
                {
                    var ySmallDimension = smaller[z];
                    var yBigDimension = biger[Z];

                    result[Z] = AverageForYDimension(ySmallDimension, yBigDimension);
                }
            }

            var lastOctaveValue = smaller[^1];

            for (int z = smaller.Length * BigElementsPerSmall; z < biger.Length; z++)
            {
                var bigOctaveValue = biger[z];

                result[z] = AverageForYDimension(lastOctaveValue, bigOctaveValue);
            }

            return result;
        }

        private static double[][] AverageForYDimension(double[][] smaller, double[][] biger)
        {
            var BigElementsPerSmall = biger.Length / smaller.Length;

            var result = new double[biger.Length][];

            Parallel.For(0, smaller.Length, (y) =>
            {
                for (int Y = y * BigElementsPerSmall; Y < (y + 1) * BigElementsPerSmall; Y++)
                {
                    var xSmallDimesion = smaller[y];
                    var xBiggerDimesion = biger[Y];

                    result[Y] = AverageForXDimension(xSmallDimesion, xBiggerDimesion);
                }
            });

            var lastOctaveValue = smaller[^1];

            for (int y = smaller.Length * BigElementsPerSmall; y < biger.Length; y++)
            {
                var bigOctaveValue = biger[y];

                result[y] = AverageForXDimension(lastOctaveValue, bigOctaveValue);
            }

            return result;
        }

        private static double[] AverageForXDimension(double[] smaller, double[] biger)
        {
            var BigElementsPerSmall = biger.Length / smaller.Length;

            var result = new double[biger.Length];

            for (int x = 0; x < smaller.Length; x++)
            {
                var smallOctaveValue = smaller[x];
                for (int X = x * BigElementsPerSmall; X < (x + 1) * BigElementsPerSmall; X++)
                {
                    var bigOctaveValue = biger[X];
                    result[X] = Statistic.Average(smallOctaveValue, bigOctaveValue);
                }
            }

            var lastOctaveValue = smaller[^1];

            for (int x = smaller.Length * BigElementsPerSmall; x < biger.Length; x++)
            {
                var bigOctaveValue = biger[x];

                result[x] = Statistic.Average(lastOctaveValue, bigOctaveValue);
            }

            return result;
        }
    }
}
