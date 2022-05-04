namespace Gaten.Game.NemoNemoLogic
{
    public class BoardNumberList
    {
        public List<int> numbers = new List<int>();

        /// <summary>
        /// 합리적인 숫자인지 확인
        /// 한 리스트의 숫자들의 합 + 숫자 개수 - 1 은 전체 넓이보다 작거나 같아야 한다
        /// </summary>
        /// <param name="mainNumber">넓이 or 높이</param>
        /// <returns></returns>
        public bool IsRationalNumbers(int mainNumber)
        {
            return mainNumber >= numbers.Sum() + numbers.Count - 1;
        }
    }
}
