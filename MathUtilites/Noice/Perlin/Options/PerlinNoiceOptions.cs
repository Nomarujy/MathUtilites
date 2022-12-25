namespace MathUtilites.Noice.Perlin.Options
{
    public class PerlinNoiceOptions
    {
        private int _octaveDepth = 1;
        public int OctaveDepth
        {
            get { return _octaveDepth; }
            set
            {
                if (value > 0)
                {
                    _octaveDepth = value;
                }
            }
        }
    }
}
