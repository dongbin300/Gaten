namespace Gaten.Game.NGDG2
{
    public class HighlightEffect
    {
        /// <summary>
        /// 원래 색상
        /// </summary>
        public ConsoleColor OriginalColor;

        /// <summary>
        /// 하이라이트 색상
        /// </summary>
        public ConsoleColor HighlightColor;

        /// <summary>
        /// 하이라이트 유지 틱 수
        /// </summary>
        public int Duration;

        /// <summary>
        /// 현재 틱
        /// </summary>
        public int Timer;

        public HighlightEffect(ConsoleColor original, ConsoleColor highlight, int duration)
        {
            OriginalColor = original;
            HighlightColor = highlight;
            Duration = duration;
        }

        /// <summary>
        /// 하이라이트 이펙트를 시작한다.
        /// </summary>
        public void Start()
        {
            Timer = 0;
        }

        /// <summary>
        /// 하이라이트 이펙트 틱
        /// 1프레임마다 이 메서드를 호출한다.
        /// </summary>
        public ConsoleColor Tick()
        {
            if (Timer < Duration)
            {
                Timer++;

                return HighlightColor;
            }
            else
            {
                return OriginalColor;
            }
        }
    }
}
