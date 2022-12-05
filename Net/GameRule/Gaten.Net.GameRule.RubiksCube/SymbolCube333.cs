namespace Gaten.Net.GameRule.RubiksCube
{
    public class SymbolCube333
    {
        /// <summary>
        /// 0 - F
        /// 1 - L
        /// 2 - U
        /// 3 - R
        /// 4 - D
        /// 5 - B
        /// 
        ///  F   L   U   R   D   B
        /// 012 012 012 012 012 012
        /// 345 345 345 345 345 345
        /// 678 678 678 678 678 678
        /// 
        /// F 1~9
        /// L 11~19
        /// U 21~29
        /// R 31~39
        /// D 41~49
        /// B 51~59
        /// </summary>
        public string[] Symbols = new string[60];

        public SymbolCube333()
        {
            for (int i = 1; i <= 9; i++)
            {
                Symbols[i] = "F";
                Symbols[10 + i] = "L";
                Symbols[20 + i] = "U";
                Symbols[30 + i] = "R";
                Symbols[40 + i] = "D";
                Symbols[50 + i] = "B";
            }
        }

        public SymbolCube333(List<CubeSymbol> cubeSymbols)
        {
            for (int i = 1; i <= 9; i++)
            {
                Symbols[i] = "F";
                Symbols[10 + i] = "L";
                Symbols[20 + i] = "U";
                Symbols[30 + i] = "R";
                Symbols[40 + i] = "D";
                Symbols[50 + i] = "B";
            }

            foreach (var symbol in cubeSymbols)
            {
                Symbols[symbol.Index] = symbol.Symbol;
            }
        }

        public void Scramble(int length)
        {
            Rotate(GenerateScrambleCode(length));
        }

        public string GenerateScrambleCode(int length)
        {
            var r = new Random();
            string code = string.Empty;
            string codeNum = "FLURDB";
            int c1 = -1, c2;

            for (int i = 0; i < length; i++)
            {
                c2 = r.Next(6);
                if (c2 == c1)
                    i--;
                else
                {
                    c1 = c2;
                    code += codeNum[c2];
                    switch (r.Next(3))
                    {
                        case 0: break;
                        case 1: code += "'"; break;
                        case 2: code += "2"; break;
                    }
                }
            }

            return code;
        }

        /// <summary>
        /// 1. General Rotation
        /// RLUDFB
        /// R'L'U'D'F'B'
        /// R2L2U2D2F2B2
        /// 
        /// 2. Additional Rotation
        /// MES
        /// M'E'S'
        /// M2E2S2
        /// 
        /// 3. Viewpoint Rotation
        /// xyz
        /// x'y'z'
        /// x2y2z2
        /// </summary>
        /// <param name="rotationString"></param>
        public void Rotate(string rotationString)
        {
            List<string> rotationCodes = new List<string>();

            rotationString = rotationString.Replace(" ", "").ToUpper();
            for (int i = 0; i < rotationString.Length; i++)
            {
                if (i + 1 < rotationString.Length)
                {
                    if (rotationString[i + 1] == '\'')
                    {
                        rotationCodes.Add(rotationString[i] + "'");
                        i++;
                    }

                    else if (rotationString[i + 1] == '2')
                    {
                        rotationCodes.Add(rotationString[i] + "2");
                        i++;
                    }
                    else
                        rotationCodes.Add(rotationString[i].ToString());
                }
                else
                    rotationCodes.Add(rotationString[i].ToString());
            }

            foreach (string rotationCode in rotationCodes)
            {
                switch (rotationCode)
                {
                    case "R": Rotate(FaceRotation.Right); break;
                    case "L": Rotate(FaceRotation.Left); break;
                    case "U": Rotate(FaceRotation.Up); break;
                    case "D": Rotate(FaceRotation.Down); break;
                    case "F": Rotate(FaceRotation.Front); break;
                    case "B": Rotate(FaceRotation.Back); break;
                    case "R'": Rotate(FaceRotation.CounterRight); break;
                    case "L'": Rotate(FaceRotation.CounterLeft); break;
                    case "U'": Rotate(FaceRotation.CounterUp); break;
                    case "D'": Rotate(FaceRotation.CounterDown); break;
                    case "F'": Rotate(FaceRotation.CounterFront); break;
                    case "B'": Rotate(FaceRotation.CounterBack); break;
                    case "R2": Rotate(FaceRotation.DoubleRight); break;
                    case "L2": Rotate(FaceRotation.DoubleLeft); break;
                    case "U2": Rotate(FaceRotation.DoubleUp); break;
                    case "D2": Rotate(FaceRotation.DoubleDown); break;
                    case "F2": Rotate(FaceRotation.DoubleFront); break;
                    case "B2": Rotate(FaceRotation.DoubleBack); break;
                }
            }
        }

        public void Rotate(FaceRotation faceRotation)
        {
            switch (faceRotation)
            {
                case FaceRotation.Right:
                    General.SymbolRotate(RotateDirection.Left, this, 31, 33, 39, 37);
                    General.SymbolRotate(RotateDirection.Left, this, 32, 36, 38, 34);
                    General.SymbolRotate(RotateDirection.Left, this, 43, 3, 23, 59);
                    General.SymbolRotate(RotateDirection.Left, this, 46, 6, 26, 56);
                    General.SymbolRotate(RotateDirection.Left, this, 49, 9, 29, 53);
                    break;
                case FaceRotation.CounterRight:
                    General.SymbolRotate(RotateDirection.Right, this, 31, 33, 39, 37);
                    General.SymbolRotate(RotateDirection.Right, this, 32, 36, 38, 34);
                    General.SymbolRotate(RotateDirection.Right, this, 43, 3, 23, 59);
                    General.SymbolRotate(RotateDirection.Right, this, 46, 6, 26, 56);
                    General.SymbolRotate(RotateDirection.Right, this, 49, 9, 29, 53);
                    break;
                case FaceRotation.Left:
                    General.SymbolRotate(RotateDirection.Left, this, 11, 13, 19, 17);
                    General.SymbolRotate(RotateDirection.Left, this, 12, 16, 18, 14);
                    General.SymbolRotate(RotateDirection.Left, this, 21, 1, 41, 57);
                    General.SymbolRotate(RotateDirection.Left, this, 24, 4, 44, 54);
                    General.SymbolRotate(RotateDirection.Left, this, 27, 7, 47, 51);
                    break;
                case FaceRotation.CounterLeft:
                    General.SymbolRotate(RotateDirection.Right, this, 11, 13, 19, 17);
                    General.SymbolRotate(RotateDirection.Right, this, 12, 16, 18, 14);
                    General.SymbolRotate(RotateDirection.Right, this, 21, 1, 41, 57);
                    General.SymbolRotate(RotateDirection.Right, this, 24, 4, 44, 54);
                    General.SymbolRotate(RotateDirection.Right, this, 27, 7, 47, 51);
                    break;
                case FaceRotation.Up:
                    General.SymbolRotate(RotateDirection.Left, this, 21, 23, 29, 27);
                    General.SymbolRotate(RotateDirection.Left, this, 22, 26, 28, 24);
                    General.SymbolRotate(RotateDirection.Left, this, 51, 33, 3, 13);
                    General.SymbolRotate(RotateDirection.Left, this, 52, 32, 2, 12);
                    General.SymbolRotate(RotateDirection.Left, this, 53, 31, 1, 11);
                    break;
                case FaceRotation.CounterUp:
                    General.SymbolRotate(RotateDirection.Right, this, 21, 23, 29, 27);
                    General.SymbolRotate(RotateDirection.Right, this, 22, 26, 28, 24);
                    General.SymbolRotate(RotateDirection.Right, this, 51, 33, 3, 13);
                    General.SymbolRotate(RotateDirection.Right, this, 52, 32, 2, 12);
                    General.SymbolRotate(RotateDirection.Right, this, 53, 31, 1, 11);
                    break;
                case FaceRotation.Down:
                    General.SymbolRotate(RotateDirection.Left, this, 41, 43, 49, 47);
                    General.SymbolRotate(RotateDirection.Left, this, 42, 46, 48, 44);
                    General.SymbolRotate(RotateDirection.Left, this, 17, 7, 37, 59);
                    General.SymbolRotate(RotateDirection.Left, this, 18, 8, 38, 58);
                    General.SymbolRotate(RotateDirection.Left, this, 19, 9, 39, 57);
                    break;
                case FaceRotation.CounterDown:
                    General.SymbolRotate(RotateDirection.Right, this, 41, 43, 49, 47);
                    General.SymbolRotate(RotateDirection.Right, this, 42, 46, 48, 44);
                    General.SymbolRotate(RotateDirection.Right, this, 17, 7, 37, 59);
                    General.SymbolRotate(RotateDirection.Right, this, 18, 8, 38, 58);
                    General.SymbolRotate(RotateDirection.Right, this, 19, 9, 39, 57);
                    break;
                case FaceRotation.Front:
                    General.SymbolRotate(RotateDirection.Left, this, 1, 3, 9, 7);
                    General.SymbolRotate(RotateDirection.Left, this, 2, 6, 8, 4);
                    General.SymbolRotate(RotateDirection.Left, this, 27, 31, 43, 19);
                    General.SymbolRotate(RotateDirection.Left, this, 28, 34, 42, 16);
                    General.SymbolRotate(RotateDirection.Left, this, 29, 37, 41, 13);
                    break;
                case FaceRotation.CounterFront:
                    General.SymbolRotate(RotateDirection.Right, this, 1, 3, 9, 7);
                    General.SymbolRotate(RotateDirection.Right, this, 2, 6, 8, 4);
                    General.SymbolRotate(RotateDirection.Right, this, 27, 31, 43, 19);
                    General.SymbolRotate(RotateDirection.Right, this, 28, 34, 42, 16);
                    General.SymbolRotate(RotateDirection.Right, this, 29, 37, 41, 13);
                    break;
                case FaceRotation.Back:
                    General.SymbolRotate(RotateDirection.Left, this, 51, 57, 59, 53);
                    General.SymbolRotate(RotateDirection.Left, this, 52, 54, 58, 56);
                    General.SymbolRotate(RotateDirection.Left, this, 33, 21, 17, 49);
                    General.SymbolRotate(RotateDirection.Left, this, 36, 22, 14, 48);
                    General.SymbolRotate(RotateDirection.Left, this, 39, 23, 11, 47);
                    break;
                case FaceRotation.CounterBack:
                    General.SymbolRotate(RotateDirection.Right, this, 51, 57, 59, 53);
                    General.SymbolRotate(RotateDirection.Right, this, 52, 54, 58, 56);
                    General.SymbolRotate(RotateDirection.Right, this, 33, 21, 17, 49);
                    General.SymbolRotate(RotateDirection.Right, this, 36, 22, 14, 48);
                    General.SymbolRotate(RotateDirection.Right, this, 39, 23, 11, 47);
                    break;
                case FaceRotation.DoubleRight:
                    Rotate(FaceRotation.Right);
                    Rotate(FaceRotation.Right);
                    break;
                case FaceRotation.DoubleLeft:
                    Rotate(FaceRotation.Left);
                    Rotate(FaceRotation.Left);
                    break;
                case FaceRotation.DoubleUp:
                    Rotate(FaceRotation.Up);
                    Rotate(FaceRotation.Up);
                    break;
                case FaceRotation.DoubleDown:
                    Rotate(FaceRotation.Down);
                    Rotate(FaceRotation.Down);
                    break;
                case FaceRotation.DoubleFront:
                    Rotate(FaceRotation.Front);
                    Rotate(FaceRotation.Front);
                    break;
                case FaceRotation.DoubleBack:
                    Rotate(FaceRotation.Back);
                    Rotate(FaceRotation.Back);
                    break;
            }
        }

        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(21, 3);
            Console.Write("F");
            Console.SetCursorPosition(27, 3);
            Console.Write("L");
            Console.SetCursorPosition(33, 3);
            Console.Write("U");
            Console.SetCursorPosition(39, 3);
            Console.Write("R");
            Console.SetCursorPosition(45, 3);
            Console.Write("D");
            Console.SetCursorPosition(51, 3);
            Console.Write("B");

            Draw(0, 20, 5);
            Draw(10, 26, 5);
            Draw(20, 32, 5);
            Draw(30, 38, 5);
            Draw(40, 44, 5);
            Draw(50, 50, 5);

            Console.SetCursorPosition(20, 10);
            Console.Write("F [Q]  L [W]  U [E]  R [R]  D [T]  B [Y]");
            Console.SetCursorPosition(20, 11);
            Console.Write("F'[A]  L'[S]  U'[D]  R'[F]  D'[G]  B'[H]");
            Console.SetCursorPosition(20, 12);
            Console.Write("F2[Z]  L2[X]  U2[C]  R2[V]  D2[B]  B2[N]");
        }

        public void Draw(int _base, int x, int y)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Symbols[_base + i * 3 + j + 1]);
                }
            }
        }
    }
}
