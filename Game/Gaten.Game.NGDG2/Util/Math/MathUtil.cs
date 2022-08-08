namespace Gaten.Game.NGDG2.Util.Math
{
    /// <summary>
    /// 산술 혹은 수학과 관련된 유틸리티
    /// </summary>
    public class MathUtil
    {
        /// <summary>
        /// 수치 비율 증가 메서드
        /// ex) 현재 수치 100에서 증가시킬 비율 20을 넣으면 120이 나온다
        /// </summary>
        /// <param name="currentValue">현재 수치</param>
        /// <param name="increaseValue">증가시킬 비율</param>
        /// <returns>증가된 수치</returns>
        public static long Percentage(long currentValue, double increaseValue)
        {
            return (long)(currentValue * (1 + (increaseValue / 100)));
        }
    }
}
