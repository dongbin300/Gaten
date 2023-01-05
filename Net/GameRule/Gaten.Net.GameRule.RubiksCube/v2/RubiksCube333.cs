using System.Runtime.InteropServices;

namespace Gaten.Net.GameRule.RubiksCube.v2
{
    [StructLayout(LayoutKind.Sequential)]
    public class RubiksCube333
    {
        public List<RubiksCubeSticker> Stickers { get; set; }
        #region Stickers
        //public RubiksCubeSticker F { get; set; } = new RubiksCubeSticker(LocationCode.F, StickerCode.F);
        //public RubiksCubeSticker FL { get; set; } = new RubiksCubeSticker(LocationCode.FL, StickerCode.F);
        //public RubiksCubeSticker FU { get; set; } = new RubiksCubeSticker(LocationCode.FU, StickerCode.F);
        //public RubiksCubeSticker FR { get; set; } = new RubiksCubeSticker(LocationCode.FR, StickerCode.F);
        //public RubiksCubeSticker FD { get; set; } = new RubiksCubeSticker(LocationCode.FD, StickerCode.F);
        //public RubiksCubeSticker FLU { get; set; } = new RubiksCubeSticker(LocationCode.FLU, StickerCode.F);
        //public RubiksCubeSticker FUR { get; set; } = new RubiksCubeSticker(LocationCode.FUR, StickerCode.F);
        //public RubiksCubeSticker FRD { get; set; } = new RubiksCubeSticker(LocationCode.FRD, StickerCode.F);
        //public RubiksCubeSticker FDL { get; set; } = new RubiksCubeSticker(LocationCode.FDL, StickerCode.F);
        //public RubiksCubeSticker L { get; set; } = new RubiksCubeSticker(LocationCode.L, StickerCode.L);
        //public RubiksCubeSticker LB { get; set; } = new RubiksCubeSticker(LocationCode.LB, StickerCode.L);
        //public RubiksCubeSticker LU { get; set; } = new RubiksCubeSticker(LocationCode.LU, StickerCode.L);
        //public RubiksCubeSticker LF { get; set; } = new RubiksCubeSticker(LocationCode.LF, StickerCode.L);
        //public RubiksCubeSticker LD { get; set; } = new RubiksCubeSticker(LocationCode.LD, StickerCode.L);
        //public RubiksCubeSticker LBU { get; set; } = new RubiksCubeSticker(LocationCode.LBU, StickerCode.L);
        //public RubiksCubeSticker LUF { get; set; } = new RubiksCubeSticker(LocationCode.LUF, StickerCode.L);
        //public RubiksCubeSticker LFD { get; set; } = new RubiksCubeSticker(LocationCode.LFD, StickerCode.L);
        //public RubiksCubeSticker LDB { get; set; } = new RubiksCubeSticker(LocationCode.LDB, StickerCode.L);
        //public RubiksCubeSticker U { get; set; } = new RubiksCubeSticker(LocationCode.U, StickerCode.U);
        //public RubiksCubeSticker UL { get; set; } = new RubiksCubeSticker(LocationCode.UL, StickerCode.U);
        //public RubiksCubeSticker UB { get; set; } = new RubiksCubeSticker(LocationCode.UB, StickerCode.U);
        //public RubiksCubeSticker UR { get; set; } = new RubiksCubeSticker(LocationCode.UR, StickerCode.U);
        //public RubiksCubeSticker UF { get; set; } = new RubiksCubeSticker(LocationCode.UF, StickerCode.U);
        //public RubiksCubeSticker ULB { get; set; } = new RubiksCubeSticker(LocationCode.ULB, StickerCode.U);
        //public RubiksCubeSticker UBR { get; set; } = new RubiksCubeSticker(LocationCode.UBR, StickerCode.U);
        //public RubiksCubeSticker URF { get; set; } = new RubiksCubeSticker(LocationCode.URF, StickerCode.U);
        //public RubiksCubeSticker UFL { get; set; } = new RubiksCubeSticker(LocationCode.UFL, StickerCode.U);
        //public RubiksCubeSticker R { get; set; } = new RubiksCubeSticker(LocationCode.R, StickerCode.R);
        //public RubiksCubeSticker RF { get; set; } = new RubiksCubeSticker(LocationCode.RF, StickerCode.R);
        //public RubiksCubeSticker RU { get; set; } = new RubiksCubeSticker(LocationCode.RU, StickerCode.R);
        //public RubiksCubeSticker RB { get; set; } = new RubiksCubeSticker(LocationCode.RB, StickerCode.R);
        //public RubiksCubeSticker RD { get; set; } = new RubiksCubeSticker(LocationCode.RD, StickerCode.R);
        //public RubiksCubeSticker RFU { get; set; } = new RubiksCubeSticker(LocationCode.RFU, StickerCode.R);
        //public RubiksCubeSticker RUB { get; set; } = new RubiksCubeSticker(LocationCode.RUB, StickerCode.R);
        //public RubiksCubeSticker RBD { get; set; } = new RubiksCubeSticker(LocationCode.RBD, StickerCode.R);
        //public RubiksCubeSticker RDF { get; set; } = new RubiksCubeSticker(LocationCode.RDF, StickerCode.R);
        //public RubiksCubeSticker D { get; set; } = new RubiksCubeSticker(LocationCode.D, StickerCode.D);
        //public RubiksCubeSticker DL { get; set; } = new RubiksCubeSticker(LocationCode.DL, StickerCode.D);
        //public RubiksCubeSticker DF { get; set; } = new RubiksCubeSticker(LocationCode.DF, StickerCode.D);
        //public RubiksCubeSticker DR { get; set; } = new RubiksCubeSticker(LocationCode.DR, StickerCode.D);
        //public RubiksCubeSticker DB { get; set; } = new RubiksCubeSticker(LocationCode.DB, StickerCode.D);
        //public RubiksCubeSticker DLF { get; set; } = new RubiksCubeSticker(LocationCode.DLF, StickerCode.D);
        //public RubiksCubeSticker DFR { get; set; } = new RubiksCubeSticker(LocationCode.DFR, StickerCode.D);
        //public RubiksCubeSticker DRB { get; set; } = new RubiksCubeSticker(LocationCode.DRB, StickerCode.D);
        //public RubiksCubeSticker DBL { get; set; } = new RubiksCubeSticker(LocationCode.DBL, StickerCode.D);
        //public RubiksCubeSticker B { get; set; } = new RubiksCubeSticker(LocationCode.B, StickerCode.B);
        //public RubiksCubeSticker BR { get; set; } = new RubiksCubeSticker(LocationCode.BR, StickerCode.B);
        //public RubiksCubeSticker BU { get; set; } = new RubiksCubeSticker(LocationCode.BU, StickerCode.B);
        //public RubiksCubeSticker BL { get; set; } = new RubiksCubeSticker(LocationCode.BL, StickerCode.B);
        //public RubiksCubeSticker BD { get; set; } = new RubiksCubeSticker(LocationCode.BD, StickerCode.B);
        //public RubiksCubeSticker BRU { get; set; } = new RubiksCubeSticker(LocationCode.BRU, StickerCode.B);
        //public RubiksCubeSticker BUL { get; set; } = new RubiksCubeSticker(LocationCode.BUL, StickerCode.B);
        //public RubiksCubeSticker BLD { get; set; } = new RubiksCubeSticker(LocationCode.BLD, StickerCode.B);
        //public RubiksCubeSticker BDR { get; set; } = new RubiksCubeSticker(LocationCode.BDR, StickerCode.B);
        #endregion

        public RubiksCube333()
        {
            Reset();
        }

        public RubiksCube333(List<RubiksCubeSticker> stickers)
        {
            Stickers = stickers;
        }

        public void Reset()
        {
            Stickers = new List<RubiksCubeSticker>()
            {
                new RubiksCubeSticker(LocationCode.FLU, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FU, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FUR, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FL, StickerCode.F),
                new RubiksCubeSticker(LocationCode.F, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FR, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FDL, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FD, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FRD, StickerCode.F),

                new RubiksCubeSticker(LocationCode.LBU, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LU, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LUF, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LB, StickerCode.L),
                new RubiksCubeSticker(LocationCode.L, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LF, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LDB, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LD, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LFD, StickerCode.L),

                new RubiksCubeSticker(LocationCode.ULB, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UB, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UBR, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UL, StickerCode.U),
                new RubiksCubeSticker(LocationCode.U, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UR, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UFL, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UF, StickerCode.U),
                new RubiksCubeSticker(LocationCode.URF, StickerCode.U),

                new RubiksCubeSticker(LocationCode.RFU, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RU, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RUB, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RF, StickerCode.R),
                new RubiksCubeSticker(LocationCode.R, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RB, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RDF, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RD, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RBD, StickerCode.R),

                new RubiksCubeSticker(LocationCode.DLF, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DF, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DFR, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DL, StickerCode.D),
                new RubiksCubeSticker(LocationCode.D, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DR, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DBL, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DB, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DRB, StickerCode.D),

                new RubiksCubeSticker(LocationCode.BRU, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BU, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BUL, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BR, StickerCode.B),
                new RubiksCubeSticker(LocationCode.B, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BL, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BDR, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BD, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BLD, StickerCode.B)
            };
        }

        public RubiksCubeSticker? GetSticker(string locationCode)
        {
            return Enum.TryParse(typeof(LocationCode), locationCode, out var location) ? GetSticker((LocationCode)location) : null;
        }

        public RubiksCubeSticker? GetSticker(LocationCode locationCode)
        {
            return Stickers.Find(x => x.Location.Equals(locationCode));
        }

        public List<RubiksCubeSticker>? GetBlock(string locationCode)
        {
            var result = new List<RubiksCubeSticker>();

            return Stickers.FindAll(x => Enumerable.SequenceEqual(x.Location.ToString().OrderBy(e => e), locationCode.OrderBy(e => e)));
        }

        public List<RubiksCubeSticker>? GetStickers(string locationCode)
        {
            var result = new List<RubiksCubeSticker>();

            return Stickers.FindAll(x => x.Sticker.ToString().StartsWith(locationCode));
        }

        public List<RubiksCubeSticker>? GetMultiBlocks(string locationCode)
        {
            var result = new List<RubiksCubeSticker>();
            var locationCodes = locationCode.Select(c => c.ToString()).ToList();
            foreach (var code in locationCodes)
            {
                result = result.Union(Stickers.FindAll(x => x.Location.ToString().Contains(code))).ToList();
            }

            return result;
        }

        public StickerCode GetStickerCode(string stickerCode)
        {
            return Enum.TryParse(typeof(StickerCode), stickerCode, out var sticker) ? (StickerCode)sticker : StickerCode.Unknown;
        }

        /// <summary>
        /// 1. NEW - All stickers set to unknown
        /// 2. RE - All stickers set to default
        /// 3. {Sticker} - This sticker set to unknown
        /// 4. {Sticker} {StickerCode} - This sticker set to this sticker code
        /// 5. .{Sticker} - This block set to unknown
        /// 6. .{Sticker}+ - This block set to default
        /// 7. .#{Sticker} - This blocks set to unknown
        /// 8. .#{Sticker}+ - This blocks set to default
        /// 9. #{Sticker} - This stickers starts with this sticker set to unknown
        /// 10. #{Sticker}+ - This stickers starts with this sticker set to default
        /// 11. @{RotationCode} - Rotate cube
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Run(string command)
        {
            try
            {
                command = command.ToUpper();

                switch (command)
                {
                    case "NEW":
                        foreach (var sticker in Stickers)
                        {
                            sticker.Sticker = StickerCode.Unknown;
                        }
                        return true;

                    case "RE":
                        Reset();
                        return true;

                    default:
                        break;
                }

                var commands = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commands.Length)
                {
                    case 1:
                        if (commands[0].StartsWith("."))
                        {
                            var command2 = commands[0].Replace(".", "");
                            if (command2.StartsWith("#"))
                            {
                                var command3 = command2.Replace("#", "");
                                if (command3.EndsWith("+"))
                                {
                                    var command4 = command3.Replace("+", "");
                                    var stickers = GetMultiBlocks(command4);
                                    if (stickers == null)
                                    {
                                        return false;
                                    }
                                    foreach (var sticker in stickers)
                                    {
                                        sticker.Sticker = GetStickerCode(sticker.Location.ToString()[0].ToString());
                                    }
                                    return true;
                                }
                                else
                                {
                                    var stickers = GetMultiBlocks(command3);
                                    if (stickers == null)
                                    {
                                        return false;
                                    }
                                    foreach (var sticker in stickers)
                                    {
                                        sticker.Sticker = StickerCode.Unknown;
                                    }
                                    return true;
                                }
                            }
                            else
                            {
                                if (command2.EndsWith("+"))
                                {
                                    var command3 = command2.Replace("+", "");
                                    var stickers = GetBlock(command3);
                                    if (stickers == null)
                                    {
                                        return false;
                                    }
                                    foreach (var sticker in stickers)
                                    {
                                        sticker.Sticker = GetStickerCode(sticker.Location.ToString()[0].ToString());
                                    }
                                    return true;
                                }
                                else
                                {
                                    var stickers = GetBlock(command2);
                                    if (stickers == null)
                                    {
                                        return false;
                                    }
                                    foreach (var sticker in stickers)
                                    {
                                        sticker.Sticker = StickerCode.Unknown;
                                    }
                                    return true;
                                }
                            }
                        }
                        else if (commands[0].StartsWith("#"))
                        {
                            var command2 = commands[0].Replace("#", "");
                            if (command2.EndsWith("+"))
                            {
                                var command3 = command2.Replace("+", "");
                                var stickers = GetStickers(command3);
                                if (stickers == null)
                                {
                                    return false;
                                }
                                foreach (var sticker in stickers)
                                {
                                    sticker.Sticker = GetStickerCode(sticker.Location.ToString()[0].ToString());
                                }
                                return true;
                            }
                            else
                            {
                                var stickers = GetStickers(command2);
                                if (stickers == null)
                                {
                                    return false;
                                }
                                foreach (var sticker in stickers)
                                {
                                    sticker.Sticker = GetStickerCode(sticker.Location.ToString()[0].ToString());
                                }
                                return true;
                            }
                        }
                        else if (commands[0].StartsWith("@"))
                        {
                            var command2 = commands[0].Replace("@", "");
                            Rotate(command2);
                            return true;
                        }
                        else
                        {
                            var sticker = GetSticker(commands[0]);
                            if (sticker == null)
                            {
                                return false;
                            }
                            sticker.Sticker = StickerCode.Unknown;
                            return true;
                        }

                    case 2:
                        var sticker2 = GetSticker(commands[0]);
                        var stickerCode2 = GetStickerCode(commands[1]);
                        if (sticker2 == null)
                        {
                            return false;
                        }
                        sticker2.Sticker = stickerCode2;
                        return true;

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Draw(int offsetX = 0, int offsetY = 0)
        {
            Console.SetCursorPosition(21 + offsetX, 3 + offsetY);
            Console.Write("F");
            Console.SetCursorPosition(27 + offsetX, 3 + offsetY);
            Console.Write("L");
            Console.SetCursorPosition(33 + offsetX, 3 + offsetY);
            Console.Write("U");
            Console.SetCursorPosition(39 + offsetX, 3 + offsetY);
            Console.Write("R");
            Console.SetCursorPosition(45 + offsetX, 3 + offsetY);
            Console.Write("D");
            Console.SetCursorPosition(51 + offsetX, 3 + offsetY);
            Console.Write("B");

            Draw(0, 20 + offsetX, 5 + offsetY);
            Draw(9, 26 + offsetX, 5 + offsetY);
            Draw(18, 32 + offsetX, 5 + offsetY);
            Draw(27, 38 + offsetX, 5 + offsetY);
            Draw(36, 44 + offsetX, 5 + offsetY);
            Draw(45, 50 + offsetX, 5 + offsetY);

            //Console.SetCursorPosition(20, 10);
            //Console.Write("F [Q]  L [W]  U [E]  R [R]  D [T]  B [Y]");
            //Console.SetCursorPosition(20, 11);
            //Console.Write("F'[A]  L'[S]  U'[D]  R'[F]  D'[G]  B'[H]");
            //Console.SetCursorPosition(20, 12);
            //Console.Write("F2[Z]  L2[X]  U2[C]  R2[V]  D2[B]  B2[N]");
        }

        public void Draw(int _base, int x, int y)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 3; j++)
                {
                    switch (Stickers[_base + i * 3 + j].Sticker)
                    {
                        case StickerCode.Unknown:
                            Console.Write("-");
                            break;
                        default:
                            Console.Write(Stickers[_base + i * 3 + j].Sticker);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// RFULDBR'F'U'L2D2B2
        /// </summary>
        /// <param name="rotationString"></param>
        public void Rotate(string rotationString)
        {
            var con = rotationString.ToUpper();
            for (int i = 0; i < con.Length; i++)
            {
                if (i + 1 < con.Length)
                {
                    if (con[i + 1] == '2')
                    {
                        switch (con[i])
                        {
                            default:
                            case 'F':
                                Rotate(RotationCode.DoubleFront);
                                break;
                            case 'L':
                                Rotate(RotationCode.DoubleLeft);
                                break;
                            case 'U':
                                Rotate(RotationCode.DoubleUp);
                                break;
                            case 'R':
                                Rotate(RotationCode.DoubleRight);
                                break;
                            case 'D':
                                Rotate(RotationCode.DoubleDown);
                                break;
                            case 'B':
                                Rotate(RotationCode.DoubleBack);
                                break;
                        }
                        i++;
                        continue;
                    }
                    else if (con[i + 1] == '\'')
                    {
                        switch (con[i])
                        {
                            default:
                            case 'F':
                                Rotate(RotationCode.CounterFront);
                                break;
                            case 'L':
                                Rotate(RotationCode.CounterLeft);
                                break;
                            case 'U':
                                Rotate(RotationCode.CounterUp);
                                break;
                            case 'R':
                                Rotate(RotationCode.CounterRight);
                                break;
                            case 'D':
                                Rotate(RotationCode.CounterDown);
                                break;
                            case 'B':
                                Rotate(RotationCode.CounterBack);
                                break;
                        }
                        i++;
                        continue;
                    }
                }

                switch (con[i])
                {
                    default:
                    case 'F':
                        Rotate(RotationCode.Front);
                        break;
                    case 'L':
                        Rotate(RotationCode.Left);
                        break;
                    case 'U':
                        Rotate(RotationCode.Up);
                        break;
                    case 'R':
                        Rotate(RotationCode.Right);
                        break;
                    case 'D':
                        Rotate(RotationCode.Down);
                        break;
                    case 'B':
                        Rotate(RotationCode.Back);
                        break;
                }
            }
        }

        public void Rotate(RotationCode rotationCode)
        {
            switch (rotationCode)
            {
                default:
                case RotationCode.Front:
                    RightSwap("FU", "FR", "FD", "FL");
                    RightSwap("FLU", "FUR", "FRD", "FDL");
                    RightSwap("UF", "RF", "DF", "LF");
                    RightSwap("UFL", "RFU", "DFR", "LFD");
                    RightSwap("URF", "RDF", "DLF", "LUF");
                    break;
                case RotationCode.Left:
                    RightSwap("LU", "LF", "LD", "LB");
                    RightSwap("LBU", "LUF", "LFD", "LDB");
                    RightSwap("UL", "FL", "DL", "BL");
                    RightSwap("ULB", "FLU", "DLF", "BLD");
                    RightSwap("UFL", "FDL", "DBL", "BUL");
                    break;
                case RotationCode.Up:
                    RightSwap("UB", "UR", "UF", "UL");
                    RightSwap("ULB", "UBR", "URF", "UFL");
                    RightSwap("BU", "RU", "FU", "LU");
                    RightSwap("BUL", "RUB", "FUR", "LUF");
                    RightSwap("BRU", "RFU", "FLU", "LBU");
                    break;
                case RotationCode.Right:
                    RightSwap("RU", "RB", "RD", "RF");
                    RightSwap("RFU", "RUB", "RBD", "RDF");
                    RightSwap("UR", "BR", "DR", "FR");
                    RightSwap("URF", "BRU", "DRB", "FRD");
                    RightSwap("UBR", "BDR", "DFR", "FUR");
                    break;
                case RotationCode.Down:
                    RightSwap("DF", "DR", "DB", "DL");
                    RightSwap("DLF", "DFR", "DRB", "DBL");
                    RightSwap("FD", "RD", "BD", "LD");
                    RightSwap("FDL", "RDF", "BDR", "LDB");
                    RightSwap("FRD", "RBD", "BLD", "LFD");
                    break;
                case RotationCode.Back:
                    RightSwap("BU", "BL", "BD", "BF");
                    RightSwap("BFU", "BUL", "BLD", "BDF");
                    RightSwap("UB", "LB", "DB", "FB");
                    RightSwap("UBF", "LBU", "DBL", "FBD");
                    RightSwap("ULB", "LDB", "DFB", "FUB");
                    break;

                case RotationCode.CounterFront:
                    LeftSwap("FU", "FR", "FD", "FL");
                    LeftSwap("FLU", "FUR", "FRD", "FDL");
                    LeftSwap("UF", "RF", "DF", "LF");
                    LeftSwap("UFL", "RFU", "DFR", "LFD");
                    LeftSwap("URF", "RDF", "DLF", "LUF");
                    break;
                case RotationCode.CounterLeft:
                    LeftSwap("LU", "LF", "LD", "LB");
                    LeftSwap("LBU", "LUF", "LFD", "LDB");
                    LeftSwap("UL", "FL", "DL", "BL");
                    LeftSwap("ULB", "FLU", "DLF", "BLD");
                    LeftSwap("UFL", "FDL", "DBL", "BUL");
                    break;
                case RotationCode.CounterUp:
                    LeftSwap("UB", "UR", "UF", "UL");
                    LeftSwap("ULB", "UBR", "URF", "UFL");
                    LeftSwap("BU", "RU", "FU", "LU");
                    LeftSwap("BUL", "RUB", "FUR", "LUF");
                    LeftSwap("BRU", "RFU", "FLU", "LBU");
                    break;
                case RotationCode.CounterRight:
                    LeftSwap("RU", "RB", "RD", "RF");
                    LeftSwap("RFU", "RUB", "RBD", "RDF");
                    LeftSwap("UR", "BR", "DR", "FR");
                    LeftSwap("URF", "BRU", "DRB", "FRD");
                    LeftSwap("UBR", "BDR", "DFR", "FUR");
                    break;
                case RotationCode.CounterDown:
                    LeftSwap("DF", "DR", "DB", "DL");
                    LeftSwap("DLF", "DFR", "DRB", "DBL");
                    LeftSwap("FD", "RD", "BD", "LD");
                    LeftSwap("FDL", "RDF", "BDR", "LDB");
                    LeftSwap("FRD", "RBD", "BLD", "LFD");
                    break;
                case RotationCode.CounterBack:
                    LeftSwap("BU", "BL", "BD", "BF");
                    LeftSwap("BFU", "BUL", "BLD", "BDF");
                    LeftSwap("UB", "LB", "DB", "FB");
                    LeftSwap("UBF", "LBU", "DBL", "FBD");
                    LeftSwap("ULB", "LDB", "DFB", "FUB");
                    break;

                case RotationCode.DoubleFront:
                    Rotate(RotationCode.Front);
                    Rotate(RotationCode.Front);
                    break;

                case RotationCode.DoubleLeft:
                    Rotate(RotationCode.Left);
                    Rotate(RotationCode.Left);
                    break;

                case RotationCode.DoubleUp:
                    Rotate(RotationCode.Up);
                    Rotate(RotationCode.Up);
                    break;

                case RotationCode.DoubleRight:
                    Rotate(RotationCode.Right);
                    Rotate(RotationCode.Right);
                    break;

                case RotationCode.DoubleDown:
                    Rotate(RotationCode.Down);
                    Rotate(RotationCode.Down);
                    break;

                case RotationCode.DoubleBack:
                    Rotate(RotationCode.Back);
                    Rotate(RotationCode.Back);
                    break;
            }
        }

        private void RightSwap(string c1, string c2, string c3, string c4)
        {
            var s1 = GetSticker(c1);
            var s2 = GetSticker(c2);
            var s3 = GetSticker(c3);
            var s4 = GetSticker(c4);

            if (s1 == null || s2 == null || s3 == null || s4 == null)
            {
                return;
            }

            var temp = s4.Sticker;
            s4.Sticker = s3.Sticker;
            s3.Sticker = s2.Sticker;
            s2.Sticker = s1.Sticker;
            s1.Sticker = temp;
        }

        private void LeftSwap(string c1, string c2, string c3, string c4)
        {
            var s1 = GetSticker(c1);
            var s2 = GetSticker(c2);
            var s3 = GetSticker(c3);
            var s4 = GetSticker(c4);

            if (s1 == null || s2 == null || s3 == null || s4 == null)
            {
                return;
            }

            var temp = s1.Sticker;
            s1.Sticker = s2.Sticker;
            s2.Sticker = s3.Sticker;
            s3.Sticker = s4.Sticker;
            s4.Sticker = temp;
        }

        public RubiksCube333 Clone()
        {
            return new RubiksCube333(Stickers.Select(x => x.Clone()).ToList());
        }
    }
}
