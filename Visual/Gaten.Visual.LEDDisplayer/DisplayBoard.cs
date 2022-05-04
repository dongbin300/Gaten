namespace Gaten.Visual.LEDDisplayer
{
    public class DisplayBoard
    {
        public List<Block> Blocks { get; set; }
        public bool AfterImage { get; set; }
        public DisplayBoard()
        {
            Blocks = new List<Block>();
            AfterImage = false;
        }

        public void Display()
        {
            if (!AfterImage)
                Console.Clear();
            foreach (Block b in Blocks)
            {
                foreach (Pixel p in b.Pixels)
                {
                    Console.SetCursorPosition((b.X + p.X) * 2, b.Y + p.Y);
                    Console.BackgroundColor = b.Color;
                    Console.ForegroundColor = p.Color;
                    Console.Write("■");
                }
            }
        }
    }
}
