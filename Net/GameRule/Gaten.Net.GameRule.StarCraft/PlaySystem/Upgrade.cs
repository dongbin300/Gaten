using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public enum UpgradeID
    {
        TerranInfantryArmor = 0,
        TerranVehiclePlating = 1,
        TerranShipPlating = 2,
        ZergCarapace = 3,
        ZergFlyerCaparace = 4,
        ProtossArmor = 5,
        ProtossPlating = 6,
        TerranInfantryWeapons = 7,
        TerranVehicleWeapons = 8,
        TerranShipWeapons = 9,
        ZergMeleeAttacks = 10,
        ZergMissileAttacks = 11,
        ZergFlyerAttacks = 12,
        ProtossGroundWeapons = 13,
        ProtossAirWeapons = 14,
        ProtossPlasmaShields = 15,
        U238Shells = 16,
        IonThrusters = 17,
        BurstLasers = 18,
        TitanReactor = 19,
        OcularImplants = 20,
        MoebiusReactor = 21,
        ApolloReactor = 22,
        ColossusReactor = 23,
        VentralSacs = 24,
        Antennae = 25,
        PneumatizedCarapace = 26,
        MetabolicBoost = 27,
        AdrenalGlands = 28,
        MuscularAugments = 29,
        GroovedSpines = 30,
        GameteMeiosis = 31,
        MetasynapticNode = 32,
        SingularityCharge = 33,
        LegEnhancements = 34,
        ScarabDamage = 35,
        ReaverCapacity = 36,
        GraviticDrive = 37,
        SensorArray = 38,
        GraviticBoosters = 39,
        KhaydarinAmulet = 40,
        ApialSensors = 41,
        GraviticThrusters = 42,
        CarrierCapacity = 43,
        KhaydarinCore = 44,
        UnknownUpgrade45 = 45,
        UnknownUpgrade46 = 46,
        ArgusJewel = 47,
        UnknownUpgrade48 = 48,
        ArgusTalisman = 49,
        UnknownUpgrade50 = 50,
        CaduceusReactor = 51,
        ChitinousPlating = 52,
        AnabolicSynthesis = 53,
        CharonBooster = 54,
        UnknownUpgrade55 = 55,
        UnknownUpgrade56 = 56,
        UnknownUpgrade57 = 57,
        UnknownUpgrade58 = 58,
        UnknownUpgrade59 = 59,
        UnknownUpgrade60 = 60
    }

    public class Upgrade
    {
        public static string[] IdString =
        {
            "TerranInfantryArmor",
            "TerranVehiclePlating",
            "TerranShipPlating",
            "ZergCarapace",
            "ZergFlyerCaparace",
            "ProtossArmor",
            "ProtossPlating",
            "TerranInfantryWeapons",
            "TerranVehicleWeapons",
            "TerranShipWeapons",
            "ZergMeleeAttacks",
            "ZergMissileAttacks",
            "ZergFlyerAttacks",
            "ProtossGroundWeapons",
            "ProtossAirWeapons",
            "ProtossPlasmaShields",
            "U238Shells",
            "IonThrusters",
            "BurstLasers",
            "TitanReactor",
            "OcularImplants",
            "MoebiusReactor",
            "ApolloReactor",
            "ColossusReactor",
            "VentralSacs",
            "Antennae",
            "PneumatizedCarapace",
            "MetabolicBoost",
            "AdrenalGlands",
            "MuscularAugments",
            "GroovedSpines",
            "GameteMeiosis",
            "MetasynapticNode",
            "SingularityCharge",
            "LegEnhancements",
            "ScarabDamage",
            "ReaverCapacity",
            "GraviticDrive",
            "SensorArray",
            "GraviticBoosters",
            "KhaydarinAmulet",
            "ApialSensors",
            "GraviticThrusters",
            "CarrierCapacity",
            "KhaydarinCore",
            "UnknownUpgrade45",
            "UnknownUpgrade46",
            "ArgusJewel",
            "UnknownUpgrade48",
            "ArgusTalisman",
            "UnknownUpgrade50",
            "CaduceusReactor",
            "ChitinousPlating",
            "AnabolicSynthesis",
            "CharonBooster",
            "UnknownUpgrade55",
            "UnknownUpgrade56",
            "UnknownUpgrade57",
            "UnknownUpgrade58",
            "UnknownUpgrade59",
            "UnknownUpgrade60"
        };

        public UpgradeID ID { get; set; }
        public Rule.Setting SettingRule { get; set; }
        public ushort Mineral { get; set; }
        public ushort MineralBonus { get; set; }
        public ushort Gas { get; set; }
        public ushort GasBonus { get; set; }
        public ushort Time { get; set; }
        public ushort TimeBonus { get; set; }

        /// <summary>
        /// 플레이어별 업글 최고레벨
        /// Default규칙을 사용하지 않는 플레이어에게 적용됨.
        /// 크기: [12]
        /// </summary>
        public byte[] PlayerMaxLevels { get; set; }

        /// <summary>
        /// 플레이어별 업글 시작레벨
        /// Default규칙을 사용하지 않는 플레이어에게 적용됨.
        /// 크기: [12]
        /// </summary>
        public byte[] PlayerStartLevels { get; set; }

        /// <summary>
        /// 글로벌 최고레벨
        /// Default규칙을 사용하는 플레이어에게 적용됨.
        /// </summary>
        public byte GlobalMaxLevel { get; set; }

        /// <summary>
        /// 글로벌 시작레벨
        /// Default규칙을 사용하는 플레이어에게 적용됨.
        /// </summary>
        public byte GlobalStartLevel { get; set; }

        /// <summary>
        /// 플레이어별 업글 규칙
        /// 크기: [12]
        /// 경우:
        /// Default(01): 글로벌 규칙을 따라간다.
        /// Override(00): 글로벌 규칙을 무시하고 플레이어별 규칙을 따라간다.
        /// </summary>
        public byte[] UseDefaults { get; set; }

        public Upgrade(UpgradeID id)
        {
            ID = id;

            PlayerMaxLevels = new byte[12];
            PlayerStartLevels = new byte[12];
            UseDefaults = new byte[12];

            switch (id)
            {
                case UpgradeID.TerranInfantryArmor:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.TerranVehiclePlating:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.TerranShipPlating:
                    Init(3, 150, 75, 150, 75, 3990, 480);
                    break;
                case UpgradeID.ZergCarapace:
                    Init(3, 150, 75, 150, 75, 3990, 480);
                    break;
                case UpgradeID.ZergFlyerCaparace:
                    Init(3, 150, 75, 150, 75, 3990, 480);
                    break;
                case UpgradeID.ProtossArmor:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.ProtossPlating:
                    Init(3, 150, 75, 150, 75, 3990, 480);
                    break;
                case UpgradeID.TerranInfantryWeapons:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.TerranVehicleWeapons:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.TerranShipWeapons:
                    Init(3, 100, 50, 100, 50, 3990, 480);
                    break;
                case UpgradeID.ZergMeleeAttacks:
                    Init(3, 100, 50, 100, 50, 3990, 480);
                    break;
                case UpgradeID.ZergMissileAttacks:
                    Init(3, 100, 50, 100, 50, 3990, 480);
                    break;
                case UpgradeID.ZergFlyerAttacks:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.ProtossGroundWeapons:
                    Init(3, 100, 50, 100, 50, 3990, 480);
                    break;
                case UpgradeID.ProtossAirWeapons:
                    Init(3, 100, 75, 100, 75, 3990, 480);
                    break;
                case UpgradeID.ProtossPlasmaShields:
                    Init(3, 200, 100, 200, 100, 3990, 480);
                    break;
                case UpgradeID.U238Shells:
                    Init(1, 150, 0, 150, 0, 1500, 0);
                    break;
                case UpgradeID.IonThrusters:
                    Init(1, 100, 0, 100, 0, 1500, 0);
                    break;
                case UpgradeID.BurstLasers:
                    Init(0, 200, 0, 200, 0, 2490, 0);
                    break;
                case UpgradeID.TitanReactor:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.OcularImplants:
                    Init(1, 100, 0, 100, 0, 2490, 0);
                    break;
                case UpgradeID.MoebiusReactor:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.ApolloReactor:
                    Init(1, 200, 0, 200, 0, 2490, 0);
                    break;
                case UpgradeID.ColossusReactor:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.VentralSacs:
                    Init(1, 200, 0, 200, 0, 2400, 0);
                    break;
                case UpgradeID.Antennae:
                    Init(1, 150, 0, 150, 0, 1995, 0);
                    break;
                case UpgradeID.PneumatizedCarapace:
                    Init(1, 150, 0, 150, 0, 1995, 0);
                    break;
                case UpgradeID.MetabolicBoost:
                    Init(1, 100, 0, 100, 0, 1500, 0);
                    break;
                case UpgradeID.AdrenalGlands:
                    Init(1, 200, 0, 200, 0, 1500, 0);
                    break;
                case UpgradeID.MuscularAugments:
                    Init(1, 150, 0, 150, 0, 1500, 0);
                    break;
                case UpgradeID.GroovedSpines:
                    Init(1, 150, 0, 150, 0, 1500, 0);
                    break;
                case UpgradeID.GameteMeiosis:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.MetasynapticNode:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.SingularityCharge:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.LegEnhancements:
                    Init(1, 150, 0, 150, 0, 1995, 0);
                    break;
                case UpgradeID.ScarabDamage:
                    Init(1, 200, 0, 200, 0, 2490, 0);
                    break;
                case UpgradeID.ReaverCapacity:
                    Init(1, 200, 0, 200, 0, 2490, 0);
                    break;
                case UpgradeID.GraviticDrive:
                    Init(1, 200, 0, 200, 0, 2490, 0);
                    break;
                case UpgradeID.SensorArray:
                    Init(1, 150, 0, 150, 0, 1995, 0);
                    break;
                case UpgradeID.GraviticBoosters:
                    Init(1, 150, 0, 150, 0, 1995, 0);
                    break;
                case UpgradeID.KhaydarinAmulet:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.ApialSensors:
                    Init(1, 100, 0, 100, 0, 2490, 0);
                    break;
                case UpgradeID.GraviticThrusters:
                    Init(1, 200, 0, 200, 0, 2490, 0);
                    break;
                case UpgradeID.CarrierCapacity:
                    Init(1, 100, 0, 100, 0, 1500, 0);
                    break;
                case UpgradeID.KhaydarinCore:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.UnknownUpgrade45:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.UnknownUpgrade46:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.ArgusJewel:
                    Init(1, 100, 0, 100, 0, 2490, 0);
                    break;
                case UpgradeID.UnknownUpgrade48:
                    Init(0, 100, 0, 100, 0, 2490, 0);
                    break;
                case UpgradeID.ArgusTalisman:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.UnknownUpgrade50:
                    Init(0, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.CaduceusReactor:
                    Init(1, 150, 0, 150, 0, 2490, 0);
                    break;
                case UpgradeID.ChitinousPlating:
                    Init(1, 150, 0, 150, 0, 1995, 0);
                    break;
                case UpgradeID.AnabolicSynthesis:
                    Init(1, 200, 0, 200, 0, 1995, 0);
                    break;
                case UpgradeID.CharonBooster:
                    Init(1, 100, 0, 100, 0, 1995, 0);
                    break;
                case UpgradeID.UnknownUpgrade55:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.UnknownUpgrade56:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.UnknownUpgrade57:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.UnknownUpgrade58:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.UnknownUpgrade59:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
                case UpgradeID.UnknownUpgrade60:
                    Init(0, 0, 0, 0, 0, 0, 0);
                    break;
            }
        }

        public void Init(byte maxLevel, ushort mineral, ushort mineralBonus, ushort gas, ushort gasBonus, ushort time, ushort timeBonus)
        {
            SettingRule = Rule.Setting.Default;

            Mineral = mineral;
            MineralBonus = mineralBonus;
            Gas = gas;
            GasBonus = gasBonus;
            Time = time;
            TimeBonus = timeBonus;

            PlayerMaxLevels.Fill(maxLevel);
            PlayerStartLevels.Fill((byte)0);
            GlobalMaxLevel = maxLevel;
            GlobalStartLevel = 0;
            UseDefaults.Fill((byte)1);
        }
    }
}
