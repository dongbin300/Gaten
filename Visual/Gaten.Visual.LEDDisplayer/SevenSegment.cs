namespace Gaten.Visual.LEDDisplayer
{
    public class SevenSegment
    {
        public Block[] Block = new Block[10];

        public SevenSegment()
        {
            Block[0] = new Block("3,5," +
                "111" +
                "101" +
                "101" +
                "101" +
                "111");

            Block[1] = new Block("3,5," +
                "001" +
                "001" +
                "001" +
                "001" +
                "001");

            Block[2] = new Block("3,5," +
                "111" +
                "001" +
                "111" +
                "100" +
                "111");

            Block[3] = new Block("3,5," +
                "111" +
                "001" +
                "111" +
                "001" +
                "111");

            Block[4] = new Block("3,5," +
                "101" +
                "101" +
                "111" +
                "001" +
                "001");

            Block[5] = new Block("3,5," +
                "111" +
                "100" +
                "111" +
                "001" +
                "111");

            Block[6] = new Block("3,5," +
                "111" +
                "100" +
                "111" +
                "101" +
                "111");

            Block[7] = new Block("3,5," +
                "111" +
                "001" +
                "001" +
                "001" +
                "001");

            Block[8] = new Block("3,5," +
                "111" +
                "101" +
                "111" +
                "101" +
                "111");

            Block[9] = new Block("3,5," +
                "111" +
                "101" +
                "111" +
                "001" +
                "111");
        }

        public Block Make(int num)
        {
            Block b = new Block();

            string numStr = num.ToString();
            for (int i = 0; i < numStr.Length; i++)
            {
                b.Add(Block[int.Parse(numStr[i].ToString())], i * 4, 0);
            }

            return b;
        }
    }
}
