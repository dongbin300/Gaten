namespace Gaten.Net.GameRule.RubiksCube
{
    /// <summary>
    /// 3*3*3 큐브
    /// </summary>
    public class RubiksCube333
    {
        private const int SideCount = 6;
        public List<RubiksCube333Side> Sides;

        public RubiksCube333()
        {
            Sides = new List<RubiksCube333Side>(SideCount);
            for (int i = 0; i < SideCount; i++)
                Sides.Add(new RubiksCube333Side((PieceColor)(i + 1)));
        }

        public void Scramble(int length)
        {
            Rotate(GenerateScrambleCode(length));
        }

        public string GenerateScrambleCode(int length)
        {
            Random r = new Random();
            string code = string.Empty;
            string codeNum = "RLUDFB";
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
                    case "R2": Rotate(FaceRotation.Right); Rotate(FaceRotation.Right); break;
                    case "L2": Rotate(FaceRotation.Left); Rotate(FaceRotation.Left); break;
                    case "U2": Rotate(FaceRotation.Up); Rotate(FaceRotation.Up); break;
                    case "D2": Rotate(FaceRotation.Down); Rotate(FaceRotation.Down); break;
                    case "F2": Rotate(FaceRotation.Front); Rotate(FaceRotation.Front); break;
                    case "B2": Rotate(FaceRotation.Back); Rotate(FaceRotation.Back); break;
                }
            }
        }

        public void Rotate(FaceRotation faceRotation)
        {
            List<PieceColor> temps = new List<PieceColor>();
            switch (faceRotation)
            {
                case FaceRotation.Right:
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 2, 5, 2, 4, 6, 0, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 5, 5, 5, 4, 3, 0, 5);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 8, 5, 8, 4, 0, 0, 8);
                    General.PieceColorRotate(RotateDirection.Left, this, 3, 0, 3, 6, 3, 8, 3, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 3, 3, 3, 7, 3, 5, 3, 1);
                    break;
                case FaceRotation.CounterRight:
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 2, 5, 2, 4, 6, 0, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 5, 5, 5, 4, 3, 0, 5);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 8, 5, 8, 4, 0, 0, 8);
                    General.PieceColorRotate(RotateDirection.Right, this, 3, 0, 3, 6, 3, 8, 3, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 3, 3, 3, 7, 3, 5, 3, 1);
                    break;
                case FaceRotation.Left:
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 0, 0, 0, 4, 8, 5, 0);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 3, 0, 3, 4, 5, 5, 3);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 6, 0, 6, 4, 2, 5, 6);
                    General.PieceColorRotate(RotateDirection.Left, this, 1, 0, 1, 6, 1, 8, 1, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 1, 3, 1, 7, 1, 5, 1, 1);
                    break;
                case FaceRotation.CounterLeft:
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 0, 0, 0, 4, 8, 5, 0);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 3, 0, 3, 4, 5, 5, 3);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 6, 0, 6, 4, 2, 5, 6);
                    General.PieceColorRotate(RotateDirection.Right, this, 1, 0, 1, 6, 1, 8, 1, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 1, 3, 1, 7, 1, 5, 1, 1);
                    break;
                case FaceRotation.Up:
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 6, 3, 0, 5, 2, 1, 8);
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 7, 3, 3, 5, 1, 1, 5);
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 8, 3, 6, 5, 0, 1, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 0, 2, 2, 2, 8, 2, 6);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 1, 2, 5, 2, 7, 2, 3);
                    break;
                case FaceRotation.CounterUp:
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 6, 3, 0, 5, 2, 1, 8);
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 7, 3, 3, 5, 1, 1, 5);
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 8, 3, 6, 5, 0, 1, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 0, 2, 2, 2, 8, 2, 6);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 1, 2, 5, 2, 7, 2, 3);
                    break;
                case FaceRotation.Down:
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 0, 3, 2, 5, 8, 1, 6);
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 1, 3, 5, 5, 7, 1, 3);
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 2, 3, 8, 5, 6, 1, 0);
                    General.PieceColorRotate(RotateDirection.Left, this, 4, 0, 4, 6, 4, 8, 4, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 4, 1, 4, 3, 4, 7, 4, 5);
                    break;
                case FaceRotation.CounterDown:
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 0, 3, 2, 5, 8, 1, 6);
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 1, 3, 5, 5, 7, 1, 3);
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 2, 3, 8, 5, 6, 1, 0);
                    General.PieceColorRotate(RotateDirection.Right, this, 4, 0, 4, 6, 4, 8, 4, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 4, 1, 4, 3, 4, 7, 4, 5);
                    break;
                case FaceRotation.Front:
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 6, 3, 6, 4, 6, 1, 6);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 7, 3, 7, 4, 7, 1, 7);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 8, 3, 8, 4, 8, 1, 8);
                    General.PieceColorRotate(RotateDirection.Right, this, 5, 0, 5, 2, 5, 8, 5, 6);
                    General.PieceColorRotate(RotateDirection.Right, this, 5, 1, 5, 5, 5, 7, 5, 3);
                    break;
                case FaceRotation.CounterFront:
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 6, 3, 6, 4, 6, 1, 6);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 7, 3, 7, 4, 7, 1, 7);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 8, 3, 8, 4, 8, 1, 8);
                    General.PieceColorRotate(RotateDirection.Left, this, 5, 0, 5, 2, 5, 8, 5, 6);
                    General.PieceColorRotate(RotateDirection.Left, this, 5, 1, 5, 5, 5, 7, 5, 3);
                    break;
                case FaceRotation.Back:
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 0, 3, 0, 4, 0, 1, 0);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 1, 3, 1, 4, 1, 1, 1);
                    General.PieceColorRotate(RotateDirection.Left, this, 2, 2, 3, 2, 4, 2, 1, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 0, 0, 6, 0, 8, 0, 2);
                    General.PieceColorRotate(RotateDirection.Left, this, 0, 1, 0, 3, 0, 7, 0, 5);
                    break;
                case FaceRotation.CounterBack:
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 0, 3, 0, 4, 0, 1, 0);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 1, 3, 1, 4, 1, 1, 1);
                    General.PieceColorRotate(RotateDirection.Right, this, 2, 2, 3, 2, 4, 2, 1, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 0, 0, 6, 0, 8, 0, 2);
                    General.PieceColorRotate(RotateDirection.Right, this, 0, 1, 0, 3, 0, 7, 0, 5);
                    break;
            }
        }

        public void Draw()
        {
            Sides[0].Draw(20, 2);
            Sides[1].Draw(14, 5);
            Sides[2].Draw(20, 5);
            Sides[3].Draw(26, 5);
            Sides[4].Draw(32, 5);
            Sides[5].Draw(20, 8);
            Console.SetCursorPosition(40, 10);
        }
    }
}