namespace Gaten.Visual.LEDDisplayer
{
    public class StandardCharacter
    {
        public Dictionary<char, Block> Block = new Dictionary<char, Block>();

        public StandardCharacter()
        {
            Block.Add('A', new Block("5,5," +
                "01110" +
                "10001" +
                "11111" +
                "10001" +
                "10001"));
            Block.Add('B', new Block("5,5," +
                "11110" +
                "10001" +
                "11110" +
                "10001" +
                "11110"));
            Block.Add('C', new Block("5,5," +
                "11111" +
                "10000" +
                "10000" +
                "10000" +
                "11111"));
            Block.Add('D', new Block("5,5," +
                "11110" +
                "10001" +
                "10001" +
                "10001" +
                "11110"));
            Block.Add('E', new Block("5,5," +
                "11111" +
                "10000" +
                "11111" +
                "10000" +
                "11111"));
            Block.Add('F', new Block("5,5," +
                "11111" +
                "10000" +
                "11111" +
                "10000" +
                "10000"));
            Block.Add('G', new Block("5,5," +
                "11111" +
                "10000" +
                "10111" +
                "10001" +
                "11111"));
            Block.Add('H', new Block("5,5," +
                "10001" +
                "10001" +
                "11111" +
                "10001" +
                "10001"));
            Block.Add('I', new Block("5,5," +
                "11111" +
                "00100" +
                "00100" +
                "00100" +
                "11111"));
            Block.Add('J', new Block("5,5," +
                "11111" +
                "00010" +
                "00010" +
                "10010" +
                "01100"));
            Block.Add('K', new Block("5,5," +
                "10011" +
                "10100" +
                "11000" +
                "10100" +
                "10011"));
            Block.Add('L', new Block("5,5," +
                "10000" +
                "10000" +
                "10000" +
                "10000" +
                "11111"));
            Block.Add('M', new Block("5,5," +
                "11011" +
                "10101" +
                "10101" +
                "10001" +
                "10001"));
            Block.Add('N', new Block("5,5," +
                "11001" +
                "10101" +
                "10101" +
                "10101" +
                "10011"));
            Block.Add('O', new Block("5,5," +
                "01110" +
                "10001" +
                "10001" +
                "10001" +
                "01110"));
            Block.Add('P', new Block("5,5," +
                "11110" +
                "10001" +
                "11110" +
                "10000" +
                "10000"));
            Block.Add('Q', new Block("5,5," +
                "01110" +
                "10001" +
                "10001" +
                "10101" +
                "01111"));
            Block.Add('R', new Block("5,5," +
                "11110" +
                "10001" +
                "11110" +
                "10100" +
                "10011"));
            Block.Add('S', new Block("5,5," +
                "01110" +
                "10000" +
                "01110" +
                "00001" +
                "01110"));
            Block.Add('T', new Block("5,5," +
                "11111" +
                "00100" +
                "00100" +
                "00100" +
                "00100"));
            Block.Add('U', new Block("5,5," +
                "10001" +
                "10001" +
                "10001" +
                "10001" +
                "01110"));
            Block.Add('V', new Block("5,5," +
                "10001" +
                "01010" +
                "01010" +
                "01010" +
                "00100"));
            Block.Add('W', new Block("5,5," +
                "10001" +
                "10001" +
                "10101" +
                "10101" +
                "01010"));
            Block.Add('X', new Block("5,5," +
                "10001" +
                "01010" +
                "00100" +
                "01010" +
                "10001"));
            Block.Add('Y', new Block("5,5," +
                "10001" +
                "01010" +
                "00100" +
                "00100" +
                "00100"));
            Block.Add('Z', new Block("5,5," +
                "11111" +
                "00010" +
                "00100" +
                "01000" +
                "11111"));
        }

        public Block Make(string str)
        {
            Block b = new Block();

            for (int i = 0; i < str.Length; i++)
            {
                b.Add(Block[str[i]], i * 6, 0);
            }
            return b;
        }
    }
}
