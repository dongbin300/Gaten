namespace Gaten.Net.GameRule.osu
{
    public enum GameMode 
    { 
        Osu,
        Taiko, 
        CatchTheBeat, 
        Mania 
    }

    [Flags]
    public enum Modes
    {
        None,
        Easy = 1,
        HalfTime = 2,
        NoFail = 4,
        HardRock = 8,
        SuddenDeath = 16,
        Perfect = 32,
        DoubleTime = 64,
        NightCore = 128,
        Hidden = 256,
        FlashLight = 512
    }

    public enum GradeRank 
    {
        SilverSS, 
        GoldSS,
        SilverS,
        GoldS,
        A,
        B, 
        C, 
        D
    }
    
    public class General
    {
        public static List<string> TaikoDifficultyStrings => new()
        {
            "Taiko", "Kantan", "Futsuu", "Muzukashii", "Oni"
        };
        public static List<string> CatchTheBeatDifficultyStrings => new()
        {
            "CatchTheBeat", "CTB", "Cup", "Salad", "Platter", "Rain", "Overdose"
        };
        public static List<string> ManiaDifficultyStrings => new()
        {
            "1K", "2K", "3K", "4K", "5K", "6K", "7K", "8K", "9K", "10K", "11K", "12K", "13K", "14K", "15K", "16K"
        };
    }
}
