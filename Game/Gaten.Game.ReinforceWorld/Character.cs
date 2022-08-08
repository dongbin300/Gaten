using System.Text;

namespace Gaten.Game.ReinforceWorld
{
    public class Character
    {
        public static string[] GradeDisplayName = { "없음", "18급", "17급", "16급", "15급", "14급", "13급", "12급", "11급", "10급", "9급", "8급", "7급", "6급", "5급", "4급", "3급", "2급", "1급", "1단", "2단", "3단", "4단", "5단", "6단", "7단", "8단", "9단" };
        public enum Grade
        {
            None,
            Kyu18,
            Kyu17,
            Kyu16,
            Kyu15,
            Kyu14,
            Kyu13,
            Kyu12,
            Kyu11,
            Kyu10,
            Kyu9,
            Kyu8,
            Kyu7,
            Kyu6,
            Kyu5,
            Kyu4,
            Kyu3,
            Kyu2,
            Kyu1,
            Dan1,
            Dan2,
            Dan3,
            Dan4,
            Dan5,
            Dan6,
            Dan7,
            Dan8,
            Dan9
        }

        public static string[] TierDisplayName = { "없음", "아이언5", "아이언4", "아이언3", "아이언2", "아이언1", "브론즈5", "브론즈4", "브론즈3", "브론즈2", "브론즈1", "실버5", "실버4", "실버3", "실버2", "실버1", "골드5", "골드4", "골드3", "골드2", "골드1", "플래티넘5", "플래티넘4", "플래티넘3", "플래티넘2", "플래티넘1", "다이아몬드5", "다이아몬드4", "다이아몬드3", "다이아몬드2", "다이아몬드1", "마스터5", "마스터4", "마스터3", "마스터2", "마스터1", "그랜드마스터5", "그랜드마스터4", "그랜드마스터3", "그랜드마스터2", "그랜드마스터1", "챌린저5", "챌린저4", "챌린저3", "챌린저2", "챌린저1", "갓5", "갓4", "갓3", "갓2", "갓1" };
        public enum Tier
        {
            None,
            Iron5,
            Iron4,
            Iron3,
            Iron2,
            Iron1,
            Bronze5,
            Bronze4,
            Bronze3,
            Bronze2,
            Bronze1,
            Silver5,
            Silver4,
            Silver3,
            Silver2,
            Silver1,
            Gold5,
            Gold4,
            Gold3,
            Gold2,
            Gold1,
            Platinum5,
            Platinum4,
            Platinum3,
            Platinum2,
            Platinum1,
            Diamond5,
            Diamond4,
            Diamond3,
            Diamond2,
            Diamond1,
            Master5,
            Master4,
            Master3,
            Master2,
            Master1,
            GrandMaster5,
            GrandMaster4,
            GrandMaster3,
            GrandMaster2,
            GrandMaster1,
            Challenger5,
            Challenger4,
            Challenger3,
            Challenger2,
            Challenger1,
            God5,
            God4,
            God3,
            God2,
            God1
        }


        public static string ID = string.Empty;
        public static string Name = string.Empty;
        public static string WeaponName = string.Empty;
        public static long Money;
        public static int CurrentValue;
        public static Grade _Grade;
        public static Tier _Tier;
        public static Log _Log = new();
        public static Upgrade _Upgrade = new();

        public static void Load()
        {
            using FileStream? stream = new("1.txt", FileMode.Open);
            using StreamReader? reader = new(stream, Encoding.UTF8);
            WeaponName = reader.ReadLine() ?? string.Empty;
            Money = long.Parse(reader.ReadLine() ?? string.Empty);
            CurrentValue = int.Parse(reader.ReadLine() ?? string.Empty);
            _Grade = (Grade)Enum.Parse(typeof(Grade), reader.ReadLine() ?? string.Empty);
            _Tier = (Tier)Enum.Parse(typeof(Tier), reader.ReadLine() ?? string.Empty);
            //string[] temp = reader.ReadLine().Split(':');
            //foreach(string str in temp)
            //{
            //    Log.SuccessCount.Add(int.Parse(str));
            //}
            //temp = reader.ReadLine().Split(':');
            //foreach (string str in temp)
            //{
            //    Log.FailureCount.Add(int.Parse(str));
            //}
            //Log.MaxReinforcementValue = int.Parse(reader.ReadLine());
            //Log.MaxMoneyValue = long.Parse(reader.ReadLine());
            //Log.GainMoney = long.Parse(reader.ReadLine());
            //reader.ReadLine();
            Upgrade.IncreaseSuccessProbability = int.Parse(reader.ReadLine() ?? string.Empty);
            Upgrade.DecreaseReinforcementTime = int.Parse(reader.ReadLine() ?? string.Empty);
            Upgrade.DecreaseReinforcementCost = int.Parse(reader.ReadLine() ?? string.Empty);
            Upgrade.IncreaseProfit = int.Parse(reader.ReadLine() ?? string.Empty);
            Upgrade.IncreaseClearThreshold = int.Parse(reader.ReadLine() ?? string.Empty);
            Upgrade.IncreaseClearValue = int.Parse(reader.ReadLine() ?? string.Empty);
        }

        public static void Save()
        {
            using FileStream? stream = new("1.txt", FileMode.OpenOrCreate);
            using StreamWriter? writer = new(stream, Encoding.UTF8);
            writer.WriteLine(WeaponName);
            writer.WriteLine(Money);
            writer.WriteLine(CurrentValue);
            writer.WriteLine(_Grade);
            writer.WriteLine(_Tier);
            writer.WriteLine(Upgrade.IncreaseSuccessProbability);
            writer.WriteLine(Upgrade.DecreaseReinforcementTime);
            writer.WriteLine(Upgrade.DecreaseReinforcementCost);
            writer.WriteLine(Upgrade.IncreaseProfit);
            writer.WriteLine(Upgrade.IncreaseClearThreshold);
            writer.WriteLine(Upgrade.IncreaseClearValue);
        }
    }
}
