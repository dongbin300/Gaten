using System.Runtime.CompilerServices;

namespace Gaten.Net.GameRule.RubiksCube.v2
{
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

        public void Reset()
        {
            Stickers = new List<RubiksCubeSticker>()
            {
                new RubiksCubeSticker(LocationCode.F, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FL, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FU, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FR, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FD, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FLU, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FUR, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FRD, StickerCode.F),
                new RubiksCubeSticker(LocationCode.FDL, StickerCode.F),
                new RubiksCubeSticker(LocationCode.L, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LB, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LU, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LF, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LD, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LBU, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LUF, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LFD, StickerCode.L),
                new RubiksCubeSticker(LocationCode.LDB, StickerCode.L),
                new RubiksCubeSticker(LocationCode.U, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UL, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UB, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UR, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UF, StickerCode.U),
                new RubiksCubeSticker(LocationCode.ULB, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UBR, StickerCode.U),
                new RubiksCubeSticker(LocationCode.URF, StickerCode.U),
                new RubiksCubeSticker(LocationCode.UFL, StickerCode.U),
                new RubiksCubeSticker(LocationCode.R, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RF, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RU, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RB, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RD, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RFU, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RUB, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RBD, StickerCode.R),
                new RubiksCubeSticker(LocationCode.RDF, StickerCode.R),
                new RubiksCubeSticker(LocationCode.D, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DL, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DF, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DR, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DB, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DLF, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DFR, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DRB, StickerCode.D),
                new RubiksCubeSticker(LocationCode.DBL, StickerCode.D),
                new RubiksCubeSticker(LocationCode.B, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BR, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BU, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BL, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BD, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BRU, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BUL, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BLD, StickerCode.B),
                new RubiksCubeSticker(LocationCode.BDR, StickerCode.B)
            };
        }

        public RubiksCubeSticker? GetSticker(string locationCode)
        {
            return Enum.TryParse(typeof(LocationCode), locationCode, out var location) ? GetSticker((LocationCode)location) : null;
        }

        public RubiksCubeSticker? GetSticker(LocationCode locationCode)
        {
            return Stickers.Find(x => x.Equals(locationCode));
        }

        public StickerCode GetStickerCode(string stickerCode)
        {
            return Enum.TryParse(typeof(StickerCode), stickerCode, out var sticker) ? (StickerCode)sticker : StickerCode.Unknown;
        }

        public bool Run(string command)
        {
            command = command.ToUpper();

            switch (command)
            {
                case "NEW":
                    foreach(var sticker in Stickers)
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
                case 1: // Set Unknown
                    var sticker = GetSticker(commands[0]);
                    if (sticker == null)
                    {
                        return false;
                    }
                    sticker.Sticker = StickerCode.Unknown;
                    return true;

                case 2: // Set Sticker
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
    }
}
