namespace Gaten.Visual.LEDDisplayer
{
    public class Graphic
    {
       //public Block[] Block = new Block[10];

        public Graphic()
        {

        }

        public static Block Line(int lx, int ly, int th = 1)
        {
            double d = (double)lx/ly;
            Block b = new Block();
            for (int i = 0; i < ly; i++)
            {
                for (int j = 0; j < lx; j++)
                {
                    if (Math.Abs(d/(i+j) - (double)j/i) < th * 0.2)
                    {
                        b.Pixels.Add(new Pixel(j, i));
                    }
                }
            }
            return b;
        }
    }
}
