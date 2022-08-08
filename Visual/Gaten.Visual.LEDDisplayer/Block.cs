namespace Gaten.Visual.LEDDisplayer
{
    public class Block : Pixel
    {
        public List<Pixel> Pixels { get; set; } = new();
        public Block()
        {
            X = 0;
            Y = 0;
            Color = ConsoleColor.Black;
        }

        public Block(List<Pixel> pixels)
        {
            Pixels = pixels;
        }

        public Block(string blockStr)
        {
            int w = int.Parse(blockStr.Split(',')[0]);
            int h = int.Parse(blockStr.Split(',')[1]);
            string pixelStr = blockStr.Split(',')[2];
            int p = 0;

            Pixels = new List<Pixel>();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if(pixelStr[p++] != '0')
                        Pixels.Add(new Pixel(j, i));
                }
            }
        }

        public Block(int x, int y, ConsoleColor color) : base(x, y, color)
        {

        }

        public void SetPixelColor(ConsoleColor color)
        {
            foreach (Pixel p in Pixels)
            {
                p.Color = color;
            }
        }

        public void SetPixelColor(int index, ConsoleColor color)
        {
            Pixels[index].Color = color;
        }

        public void Add(Block b)
        {
            Pixels.AddRange(b.Pixels);
            Pixels = Pixels.Distinct(new PixelEqualityComparer()).ToList();
        }

        public void Add(Block b, int x, int y)
        {
            for (int i = 0; i < b.Pixels.Count; i++)
            {
                b.Pixels[i].X += x;
                b.Pixels[i].Y += y;
            }

            Add(b);
        }

        public new void Move(int dx, int dy, int duration)
        {
            Thread.Sleep(duration);
            X += dx;
            Y += dy;
        }
    }
}
