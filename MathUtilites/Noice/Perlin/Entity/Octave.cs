namespace MathUtilites.Noice.Perlin.Entity
{
    public class Octave
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

        public Octave Copy()
        {
            Octave result = new(Array.Empty<double>());
            Copy(result);

            return result;
        }

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

            var result = ActionFor3D(smaller.Noice, biger.Noice, (x, y) => x + y);

            return new(result);
        }

        public static Octave operator / (Octave octave, double value)
        {
            var result = octave.Copy();
            for (int z = 0; z < octave.Noice.Length; z++)
            {
                for (int y = 0; y < octave.Noice[0].Length; y++)
                {
                    for (int x = 0; x < octave.Noice[0][0].Length; x++)
                    {
                        result.Noice[z][y][x] /= value;
                    }
                }
            }
            return result;
        }

        public static Octave operator /(Octave left, Octave right)
        {
            var res = ActionFor3D(left.Noice, right.Noice, (x, y) => x / y);
            return new Octave(res);
        }

        private static double[][][] ActionFor3D(double[][][] smaller, double[][][] bigger, Func<double, double, double> func)
        {
            return ActionForDimension(smaller, bigger,
                (small, big) => ActionFor2D(small, big, func));
        }

        private static double[][] ActionFor2D(double[][] smaller, double[][] bigger, Func<double, double, double> func)
        {
            return ActionForDimension(smaller, bigger,
                (small, big) => ActionFor1D(small, big, func));
        }

        private static double[] ActionFor1D(double[] smaller, double[] bigger, Func<double, double, double> func)
        {
            return ActionForDimension(smaller, bigger,
                func);
        }

        public static T[] ActionForDimension<T>(T[] smaller, T[] bigger, Func<T, T, T> action)
        {
            var bigElementsPerSmall = bigger.Length / smaller.Length;
            var result = new T[bigger.Length];

            for (int smallIndex = 0; smallIndex < smaller.Length; smallIndex++)
            {
                var smallOctaveValue = smaller[smallIndex];
                var lastBigArrayIndex = (smallIndex + 1) * bigElementsPerSmall;
                for (int bigIndex = smallIndex * bigElementsPerSmall; bigIndex < lastBigArrayIndex; bigIndex++)
                {
                    var bigOctaveValue = bigger[bigIndex];
                    result[bigIndex] = action.Invoke(smallOctaveValue, bigOctaveValue);
                }
            }

            // Must be cause BigElementsPerSmall is Int and maybe (bigElementsPerSmall * smaller.Lenght) < bigger.Lenght
            for (int i = bigElementsPerSmall * smaller.Length; i < bigger.Length; i++)
            {
                result[i] = action.Invoke(smaller[^1], bigger[i]);
            }

            return result;
        }
    }
}
