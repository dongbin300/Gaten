namespace Gaten.Net.GameRule.NGD2
{
    public class Timer
    {
        /// <summary>
        /// 레벨업 했는지
        /// </summary>
        public static int LevelUp { get; set; }

        /// <summary>
        /// 무공 레벨업 했는지
        /// </summary>
        public static int MugongLevelUp { get; set; }

        /// <summary>
        /// 막대기로 표시할건지
        /// </summary>
        public static int Bar { get; set; }

        /// <summary>
        /// 스킬 사용 메시지
        /// </summary>
        public static int Display { get; set; }

        /// <summary>
        /// 저장을 하는지
        /// </summary>
        public static int Save { get; set; }

        /// <summary>
        /// 저장했다는 메시지
        /// </summary>
        public static int SaveDisplay { get; set; }

        /// <summary>
        /// 크리티컬 떴다는 메시지
        /// </summary>
        public static int CriticalDisplay { get; set; }

        /// <summary>
        /// 화면지우기 딜레이용
        /// </summary>
        public static int ClearScreen { get; set; }

        /// <summary>
        /// S,D 번갈아 누르는지
        /// </summary>
        public static int Button { get; set; }

        public Timer() { }
    }
}
