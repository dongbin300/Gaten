namespace Gaten.Net.GameRule.GITADORA
{
    public class Path
    {
        public enum Type
        {
            Boundary,
            BigPhrase,
            SmallPhrase,
            Note
        }

        // path의 타입
        // 경계선, 대절선, 소절선, 노트
        public Type type;

        // [노트 타입]
        // 노트의 종류
        // *Drum
        // 1~9 : CrashSymbol~RideSymbol
        // *Guitar / *Bass
        // 1~5 : RGBYP
        // 6~10 : RGBYP Hold
        // 11 : Open
        // 12/13/14 : Up/Down/Hold(미구현)
        public int noteNum;

        // 라인넘버
        // x좌표
        public int lineNum;

        // 타이밍
        // y좌표
        public double timing;

        // 기타/베이스 홀드노트 길이
        public double holdLength = 0;
    }
}