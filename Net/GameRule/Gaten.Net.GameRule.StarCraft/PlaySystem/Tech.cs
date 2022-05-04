using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public enum TechID
    {
        StimPacks = 0,
        Lockdown = 1,
        EMPShockwave = 2,
        SpiderMines = 3,
        ScannerSweep = 4,
        SiegeMode = 5,
        DefensiveMatrix = 6,
        Irradiate = 7,
        YamatoGun = 8,
        CloakingField = 9,
        PersonnelCloaking = 10,
        Burrowing = 11,
        Infestation = 12,
        SpawnBroodling = 13,
        DarkSwarm = 14,
        Plague = 15,
        Consume = 16,
        Ensnare = 17,
        Parasite = 18,
        PsionicStorm = 19,
        Hallucination = 20,
        Recall = 21,
        StasisField = 22,
        ArchonWarp = 23,
        Restoration = 24,
        DisruptionWeb = 25,
        Unused26 = 26,
        MindControl = 27,
        DarkArchonMeld = 28,
        Feedback = 29,
        OpticalFlare = 30,
        Maelstorm = 31,
        LurkerAspect = 32,
        Unused33 = 33,
        Healing = 34,
        Unused35 = 35,
        Unused36 = 36,
        Unused37 = 37,
        Unused38 = 38,
        Unused39 = 39,
        Unused40 = 40,
        Unused41 = 41,
        Unused42 = 42,
        Unused43 = 43
    }

    public class Tech
    {
        public static string[] IdString = {
            "StimPacks",
            "Lockdown",
            "EMPShockwave",
            "SpiderMines",
            "ScannerSweep",
            "SiegeMode",
            "DefensiveMatrix",
            "Irradiate",
            "YamatoGun",
            "CloakingField",
            "PersonnelCloaking",
            "Burrowing",
            "Infestation",
            "SpawnBroodling",
            "DarkSwarm",
            "Plague",
            "Consume",
            "Ensnare",
            "Parasite",
            "PsionicStorm",
            "Hallucination",
            "Recall",
            "StasisField",
            "ArchonWarp",
            "Restoration",
            "DisruptionWeb",
            "Unused26",
            "MindControl",
            "DarkArchonMeld",
            "Feedback",
            "OpticalFlare",
            "Maelstorm",
            "LurkerAspect",
            "Unused33",
            "Healing",
            "Unused35",
            "Unused36",
            "Unused37",
            "Unused38",
            "Unused39",
            "Unused40",
            "Unused41",
            "Unused42",
            "Unused43"
        };

        public TechID ID { get; set; }
        public Rule.Setting SettingRule { get; set; }
        public ushort Mineral { get; set; }
        public ushort Gas { get; set; }
        public ushort Time { get; set; }
        public ushort Energy { get; set; }

        public byte[] PlayerAvailables { get; set; }
        public byte[] PlayerResearched { get; set; }
        public byte GlobalAvailable { get; set; }
        public byte GlobalResearched { get; set; }
        public byte[] UseDefaults { get; set; }

        public Tech(TechID id)
        {
            ID = id;

            PlayerAvailables = new byte[12];
            PlayerResearched = new byte[12];
            UseDefaults = new byte[12];

            switch (id)
            {
                case TechID.StimPacks:
                    Init(100, 100, 1200, 0);
                    break;
                case TechID.Lockdown:
                    Init(200, 200, 1500, 100);
                    break;
                case TechID.EMPShockwave:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.SpiderMines:
                    Init(100, 100, 1200, 0);
                    break;
                case TechID.ScannerSweep:
                    Init(0, 0, 0, 50);
                    break;
                case TechID.SiegeMode:
                    Init(150, 150, 1200, 0);
                    break;
                case TechID.DefensiveMatrix:
                    Init(150, 150, 1500, 100);
                    break;
                case TechID.Irradiate:
                    Init(200, 200, 1200, 75);
                    break;
                case TechID.YamatoGun:
                    Init(100, 100, 1800, 150);
                    break;
                case TechID.CloakingField:
                    Init(150, 150, 1500, 25);
                    break;
                case TechID.PersonnelCloaking:
                    Init(100, 100, 1200, 25);
                    break;
                case TechID.Burrowing:
                    Init(100, 100, 1200, 0);
                    break;
                case TechID.Infestation:
                    Init(100, 100, 1200, 0);
                    break;
                case TechID.SpawnBroodling:
                    Init(100, 100, 1200, 150);
                    break;
                case TechID.DarkSwarm:
                    Init(100, 100, 1200, 100);
                    break;
                case TechID.Plague:
                    Init(200, 200, 1500, 150);
                    break;
                case TechID.Consume:
                    Init(100, 100, 1500, 0);
                    break;
                case TechID.Ensnare:
                    Init(100, 100, 1200, 75);
                    break;
                case TechID.Parasite:
                    Init(100, 100, 1200, 75);
                    break;
                case TechID.PsionicStorm:
                    Init(200, 200, 1800, 75);
                    break;
                case TechID.Hallucination:
                    Init(150, 150, 1200, 100);
                    break;
                case TechID.Recall:
                    Init(150, 150, 1800, 150);
                    break;
                case TechID.StasisField:
                    Init(150, 150, 1500, 100);
                    break;
                case TechID.ArchonWarp:
                    Init(150, 150, 1500, 0);
                    break;
                case TechID.Restoration:
                    Init(100, 100, 1200, 50);
                    break;
                case TechID.DisruptionWeb:
                    Init(200, 200, 1200, 125);
                    break;
                case TechID.Unused26:
                    Init(150, 150, 1800, 50);
                    break;
                case TechID.MindControl:
                    Init(200, 200, 1800, 150);
                    break;
                case TechID.DarkArchonMeld:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Feedback:
                    Init(100, 100, 1800, 50);
                    break;
                case TechID.OpticalFlare:
                    Init(100, 100, 1800, 75);
                    break;
                case TechID.Maelstorm:
                    Init(100, 100, 1500, 100);
                    break;
                case TechID.LurkerAspect:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused33:
                    Init(0, 0, 0, 0);
                    break;
                case TechID.Healing:
                    Init(0, 0, 0, 1);
                    break;
                case TechID.Unused35:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused36:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused37:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused38:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused39:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused40:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused41:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused42:
                    Init(200, 200, 1800, 100);
                    break;
                case TechID.Unused43:
                    Init(200, 200, 1800, 100);
                    break;

            }
        }

        public void Init(ushort mineral, ushort gas, ushort time, ushort energy)
        {
            SettingRule = Rule.Setting.Default;

            Mineral = mineral;
            Gas = gas;
            Time = time;
            Energy = energy;

            PlayerAvailables.Fill<byte>(1);
            PlayerResearched.Fill<byte>(0);
            GlobalAvailable = 1;
            UseDefaults.Fill<byte>(1);

            GlobalResearched = ID switch
            {
                TechID.ScannerSweep or TechID.DefensiveMatrix or TechID.Infestation or TechID.DarkSwarm or 
                TechID.Parasite or TechID.ArchonWarp or TechID.DarkArchonMeld or TechID.Feedback or 
                TechID.Unused33 or TechID.Healing => 1,
                _ => 0,
            };
        }
    }
}
