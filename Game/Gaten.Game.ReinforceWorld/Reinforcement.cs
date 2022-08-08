using Gaten.Net.Math;

namespace Gaten.Game.ReinforceWorld
{
    /// <summary>
    /// 강화 사전
    /// 
    /// *무기 판매 시 강화 수치는 +0으로 바뀜
    /// *16강 시도 부터는 실패 시 강화 수치가 +0으로 바뀜
    /// 
    /// 시도강화/성공확률/실패시/강화비용/강화시간(s)/판매가격
    /// +0/-/-/-/-/0
    /// +1/100/-/3/3/4
    /// +2/95/-/12/4/20
    /// +3/90/-/34/5/70
    /// +4/85/-/71/6/168
    /// +5/80/-/152/7/383
    /// +6/75/-/360/8/925
    /// +7/70/-/975/9/2411
    /// +8/65/-/2710/10/7008
    /// +9/60/-/8098/12/22179
    /// +10/50/-/24583/15/72083
    /// +11/40/-1/77182/18/268023
    /// +12/30/-1/250837/21/999284
    /// +13/25/-1/1002834/24/4292738
    /// +14/20/-1/5028367/27/24389876
    /// +15/20/-1/25102837/30/125838274
    /// +16/15/[0]/125989384/40/629487473
    /// +17/15/[0]/628736263/50/3139472320
    /// +18/15/[0]/3204857663/60/15912737465
    /// </summary>
    public class Reinforcement
    {
        public static double[] SuccessProbability = { 100, 100, 95, 90, 85, 80, 75, 70, 65, 60, 50, 40, 30, 25, 20, 20, 15, 15, 15 };
        public static int[] Time = { 0, 3, 4, 5, 6, 7, 8, 9, 10, 12, 15, 18, 21, 24, 27, 30, 40, 50, 60 };
        public static long[] Cost = { 0, 3, 12, 34, 71, 152, 360, 975, 2710, 8098, 24583, 77182, 250837, 1002834, 5028367, 25102837, 125989384, 628736263, 3204857663 };
        public static long[] Price = { 0, 4, 20, 70, 168, 383, 925, 2411, 7008, 22179, 72083, 268023, 999284, 4292738, 24389876, 125838274, 629487473, 3139472320, 15912737465 };

        public static bool Delay;

        /// <summary>
        /// 강화 시도
        /// 강화 시도에 실패하면 오류 메시지, 성공하면 string.Empty를 반환
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Try()
        {
            _ = await Task.Factory.StartNew(() =>
            {
                SmartRandom r = new();

                int num = Character.CurrentValue;

                if (Character.Money < Cost[num + 1])
                {
                    return "강화 비용이 부족합니다.";
                }

                MainForm.StartDelay(Time[num + 1] * 100);
                Delay = true;

                while (Delay)
                {

                }

                int ran = r.Next(100);

                if (ran < SuccessProbability[num + 1]) // 강화 성공
                {
                    Character.CurrentValue++;
                    Character.Money -= Cost[num + 1];
                }
                else // 강화 실패
                {
                    if (num >= 15)
                    {
                        Character.CurrentValue = 0;
                    }
                    else if (num >= 10)
                    {
                        Character.CurrentValue--;
                    }
                    Character.Money -= Cost[num + 1];
                }

                return string.Empty;
            });

            return string.Empty;
        }
    }
}
