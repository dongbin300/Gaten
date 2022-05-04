using Gaten.Net.GameRule.NGD2.AbilitySystem;

namespace Gaten.Net.GameRule.NGD2
{
    public class NGDManager
    {
        public static void GameStart()
        {
            Spirit.Init();

            // 설정 불러오기
            var odata = Data.IO.File.ReadToDictionary("option.ini");

            // 캐릭터 불러오기
            var cdata = Data.IO.File.ReadToDictionary("stats.txt");

            Character.Level = int.Parse(cdata["Level"]);
            Character.Xp = int.Parse(cdata["Xp"]);
            Spirit.Value = int.Parse(cdata["Spirit"]);
            Spirit.Power.Level = int.Parse(cdata["SPower"]);
            Spirit.MpMax.Level = int.Parse(cdata["SMpMax"]);
            Spirit.MpRegen.Level = int.Parse(cdata["SMpRegen"]);
            Spirit.CriticalRate.Level = int.Parse(cdata["SCriticalRate"]);
            Spirit.CriticalDamage.Level = int.Parse(cdata["SCriticalDamage"]);
        }
    }
}
