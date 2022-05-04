using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public enum UnitID
    {
        TerranMarine = 0,
        TerranGhost = 1,
        TerranVulture = 2,
        TerranGoliath = 3,
        GoliathTurret = 4, // 무적
        TerranSiegeTankTankMode = 5,
        TankTurretTankMode = 6, // 무적
        TerranSCV = 7,
        TerranWraith = 8,
        TerranScienceVessel = 9,
        GuiMontangFirebat = 10,
        TerranDropship = 11,
        TerranBattlecruiser = 12,
        VultureSpiderMine = 13,
        NuclearMissile = 14,
        TerranCivilian = 15,
        SarahKerriganGhost = 16,
        AlanSchezarGoliath = 17,
        AlanSchezarTurret = 18, // 무적
        JimRaynorVulture = 19,
        JimRaynorMarine = 20,
        TomKazanskyWraith = 21,
        MagellanScienceVessel = 22,
        EdmundDukeSiegeTank = 23,
        EdmundDukeTurret1 = 24, // 무적
        EdmundDukeSiegeMode = 25,
        EdmundDukeTurret2 = 26, // 무적
        ArcturusMengskBattlecruiser = 27,
        HyperionBattlecruiser = 28,
        NoradIIBattlecruiser = 29,
        TerranSiegeTankSiegeMode = 30,
        TankTurretSiegeMode = 31, // 무적
        Firebat = 32,
        ScannerSweep = 33, // 무적
        TerranMedic = 34,
        ZergLarva = 35,
        ZergEgg = 36,
        ZergZergling = 37,
        ZergHydralisk = 38,
        ZergUltralisk = 39,
        ZergBroodling = 40,
        ZergDrone = 41,
        ZergOverlord = 42,
        ZergMutalisk = 43,
        ZergGuardian = 44,
        ZergQueen = 45,
        ZergDefiler = 46,
        ZergScourge = 47,
        TorrarsqueUltralisk = 48,
        MatriarchQueen = 49,
        InfestedTerran = 50,
        InfestedKerrigan = 51,
        UncleanOneDefiler = 52,
        HunterKillerHydralisk = 53,
        DevouringOneZergling = 54,
        KukulzaMutalisk = 55,
        KukulzaGuardian = 56,
        YggdrasillOverlord = 57,
        TerranValkyrieFrigate = 58,
        MutaliskGuardianCocoon = 59,
        ProtossCorsair = 60,
        ProtossDarkTemplarUnit = 61,
        ZergDevourer = 62,
        ProtossDarkArchon = 63,
        ProtossProbe = 64,
        ProtossZealot = 65,
        ProtossDragoon = 66,
        ProtossHighTemplar = 67,
        ProtossArchon = 68,
        ProtossShuttle = 69,
        ProtossScout = 70,
        ProtossArbiter = 71,
        ProtossCarrier = 72,
        ProtossInterceptor = 73,
        DarkTemplarHero = 74,
        ZeratulDarkTemplar = 75,
        TassadarZeratulArchon = 76,
        FenixZealot = 77,
        FenixDragoon = 78,
        TassadarTemplar = 79,
        MojoScout = 80,
        WarbringerReaver = 81,
        GantrithorCarrier = 82,
        ProtossReaver = 83,
        ProtossObserver = 84,
        ProtossScarab = 85,
        DanimothArbiter = 86,
        AldarisTemplar = 87,
        ArtanisScout = 88,
        RhynadonBadlandsCritter = 89,
        BengalaasJungleCritter = 90,
        UnusedWasCargoShip = 91,
        UnusedWasMercenaryGunship = 92,
        ScantidDesertCritter = 93,
        KakaruTwilightCritter = 94,
        RagnasaurAshworldCritter = 95,
        UrsadonIceWorldCritter = 96,
        LurkerEgg = 97,
        Raszagal = 98,
        SamirDuranGhost = 99,
        AlexeiStukovGhost = 100,
        MapRevealer = 101,
        GerardDuGalle = 102,
        ZergLurker = 103,
        InfestedDuran = 104,
        DisruptionWeb = 105,
        TerranCommandCenter = 106,
        TerranComsatStation = 107,
        TerranNuclearSilo = 108,
        TerranSupplyDepot = 109,
        TerranRefinery = 110,
        TerranBarracks = 111,
        TerranAcademy = 112,
        TerranFactory = 113,
        TerranStarport = 114,
        TerranControlTower = 115,
        TerranScienceFacility = 116,
        TerranCovertOps = 117,
        TerranPhysicsLab = 118,
        UnusedWasStarbase = 119,
        TerranMachineShop = 120,
        UnusedWasRepairBay = 121,
        TerranEngineeringBay = 122,
        TerranArmory = 123,
        TerranMissileTurret = 124,
        TerranBunker = 125,
        NoradII = 126,
        IonCannon = 127,
        UrajCrystal = 128,
        KhalisCrystal = 129,
        InfestedCommandCenter = 130,
        ZergHatchery = 131,
        ZergLair = 132,
        ZergHive = 133,
        ZergNydusCanal = 134,
        ZergHydraliskDen = 135,
        ZergDefilerMound = 136,
        ZergGreaterSpire = 137,
        ZergQueensNest = 138,
        ZergEvolutionChamber = 139,
        ZergUltraliskCavern = 140,
        ZergSpire = 141,
        ZergSpawningPool = 142,
        ZergCreepColony = 143,
        ZergSporeColony = 144,
        UnusedZergBuilding = 145,
        ZergSunkenColony = 146,
        ZergOvermindWithShell = 147,
        ZergOvermind = 148,
        ZergExtractor = 149,
        MatureChrysalis = 150,
        ZergCerebrate = 151,
        ZergCerebrateDaggoth = 152,
        UnusedZergBuilding5 = 153,
        ProtossNexus = 154,
        ProtossRoboticsFacility = 155,
        ProtossPylon = 156,
        ProtossAssimilator = 157,
        UnusedProtossBuilding1 = 158,
        ProtossObservatory = 159,
        ProtossGateway = 160,
        UnusedProtossBuilding2 = 161,
        ProtossPhotonCannon = 162,
        ProtossCitadelofAdun = 163,
        ProtossCyberneticsCore = 164,
        ProtossTemplarArchives = 165,
        ProtossForge = 166,
        ProtossStargate = 167,
        StasisCellPrison = 168,
        ProtossFleetBeacon = 169,
        ProtossArbiterTribunal = 170,
        ProtossRoboticsSupportBay = 171,
        ProtossShieldBattery = 172,
        KhaydarinCrystalFormation = 173,
        ProtossTemple = 174,
        XelNagaTemple = 175,
        MineralFieldType1 = 176,
        MineralFieldType2 = 177,
        MineralFieldType3 = 178,
        Cave = 179,
        CaveIn = 180,
        Cantina = 181,
        MiningPlatform = 182,
        IndependantCommandCenter = 183,
        IndependantStarport = 184,
        IndependantJumpGate = 185,
        Ruins = 186,
        KyadarinCrystalFormation = 187,
        VespeneGeyser = 188,
        WarpGate = 189,
        PSIDisruptor = 190,
        ZergMarker = 191,
        TerranMarker = 192,
        ProtossMarker = 193,
        ZergBeacon = 194,
        TerranBeacon = 195,
        ProtossBeacon = 196,
        ZergFlagBeacon = 197,
        TerranFlagBeacon = 198,
        ProtossFlagBeacon = 199,
        PowerGenerator = 200,
        OvermindCocoon = 201,
        DarkSwarm = 202,
        FloorMissileTrap = 203,
        FloorHatch = 204,
        LeftUpperLevelDoor = 205,
        RightUpperLevelDoor = 206,
        LeftPitDoor = 207,
        RightPitDoor = 208,
        FloorGunTrap = 209,
        LeftWallMissileTrap = 210,
        LeftWallFlameTrap = 211,
        RightWallMissileTrap = 212,
        RightWallFlameTrap = 213,
        StartLocation = 214,
        Flag = 215,
        YoungChrysalis = 216,
        PsiEmitter = 217,
        DataDisc = 218,
        KhaydarinCrystal = 219,
        MineralClusterType1 = 220,
        MineralClusterType2 = 221,
        ProtossVespeneGasOrbType1 = 222,
        ProtossVespeneGasOrbType2 = 223,
        ZergVespeneGasSacType1 = 224,
        ZergVespeneGasSacType2 = 225,
        TerranVespeneGasTankType1 = 226,
        TerranVespeneGasTankType2 = 227,

        None = 228,
        AnyUnit = 229,
        Men = 230,
        Buildings = 231,
        Factories = 232
    }

    public enum BuildingRelation
    {
        NydusLink = 9,
        AddonLink = 10
    }

    [Flags]
    public enum SpecialProperties
    {
        None = 0,
        Cloak = 1,
        Burrow = 2,
        InTransit = 4,
        Hallucinated = 8,
        Invincible = 16
    }

    [Flags]
    public enum ChangedProperties
    {
        None = 0,
        Owner = 1,
        HP = 2,
        Shield = 4,
        Energy = 8,
        Resource = 16,
        Hangar = 32
    }

    [Flags]
    public enum UnitStatus
    {
        None = 0,
        Cloaked = 1,
        Burrowed = 2,
        InTransit = 4,
        Hallucinated = 8,
        Invincible = 16
    }

    public class Unit
    {
        public static string[] IdString = {
            "TerranMarine",
            "TerranGhost",
            "TerranVulture",
            "TerranGoliath",
            "GoliathTurret",
            "TerranSiegeTankTankMode",
            "TankTurretTankMode",
            "TerranSCV",
            "TerranWraith",
            "TerranScienceVessel",
            "GuiMontangFirebat",
            "TerranDropship",
            "TerranBattlecruiser",
            "VultureSpiderMine",
            "NuclearMissile",
            "TerranCivilian",
            "SarahKerriganGhost",
            "AlanSchezarGoliath",
            "AlanSchezarTurret",
            "JimRaynorVulture",
            "JimRaynorMarine",
            "TomKazanskyWraith",
            "MagellanScienceVessel",
            "EdmundDukeSiegeTank",
            "EdmundDukeTurret1",
            "EdmundDukeSiegeMode",
            "EdmundDukeTurret2",
            "ArcturusMengskBattlecruiser",
            "HyperionBattlecruiser",
            "NoradIIBattlecruiser",
            "TerranSiegeTankSiegeMode",
            "TankTurretSiegeMode",
            "Firebat",
            "ScannerSweep",
            "TerranMedic",
            "ZergLarva",
            "ZergEgg",
            "ZergZergling",
            "ZergHydralisk",
            "ZergUltralisk",
            "ZergBroodling",
            "ZergDrone",
            "ZergOverlord",
            "ZergMutalisk",
            "ZergGuardian",
            "ZergQueen",
            "ZergDefiler",
            "ZergScourge",
            "TorrarsqueUltralisk",
            "MatriarchQueen",
            "InfestedTerran",
            "InfestedKerrigan",
            "UncleanOneDefiler",
            "HunterKillerHydralisk",
            "DevouringOneZergling",
            "KukulzaMutalisk",
            "KukulzaGuardian",
            "YggdrasillOverlord",
            "TerranValkyrieFrigate",
            "MutaliskGuardianCocoon",
            "ProtossCorsair",
            "ProtossDarkTemplarUnit",
            "ZergDevourer",
            "ProtossDarkArchon",
            "ProtossProbe",
            "ProtossZealot",
            "ProtossDragoon",
            "ProtossHighTemplar",
            "ProtossArchon",
            "ProtossShuttle",
            "ProtossScout",
            "ProtossArbiter",
            "ProtossCarrier",
            "ProtossInterceptor",
            "DarkTemplarHero",
            "ZeratulDarkTemplar",
            "TassadarZeratulArchon",
            "FenixZealot",
            "FenixDragoon",
            "TassadarTemplar",
            "MojoScout",
            "WarbringerReaver",
            "GantrithorCarrier",
            "ProtossReaver",
            "ProtossObserver",
            "ProtossScarab",
            "DanimothArbiter",
            "AldarisTemplar",
            "ArtanisScout",
            "RhynadonBadlandsCritter",
            "BengalaasJungleCritter",
            "UnusedWasCargoShip",
            "UnusedWasMercenaryGunship",
            "ScantidDesertCritter",
            "KakaruTwilightCritter",
            "RagnasaurAshworldCritter",
            "UrsadonIceWorldCritter",
            "LurkerEgg",
            "Raszagal",
            "SamirDuranGhost",
            "AlexeiStukovGhost",
            "MapRevealer",
            "GerardDuGalle",
            "ZergLurker",
            "InfestedDuran",
            "DisruptionWeb",
            "TerranCommandCenter",
            "TerranComsatStation",
            "TerranNuclearSilo",
            "TerranSupplyDepot",
            "TerranRefinery",
            "TerranBarracks",
            "TerranAcademy",
            "TerranFactory",
            "TerranStarport",
            "TerranControlTower",
            "TerranScienceFacility",
            "TerranCovertOps",
            "TerranPhysicsLab",
            "UnusedWasStarbase",
            "TerranMachineShop",
            "UnusedWasRepairBay",
            "TerranEngineeringBay",
            "TerranArmory",
            "TerranMissileTurret",
            "TerranBunker",
            "NoradII",
            "IonCannon",
            "UrajCrystal",
            "KhalisCrystal",
            "InfestedCommandCenter",
            "ZergHatchery",
            "ZergLair",
            "ZergHive",
            "ZergNydusCanal",
            "ZergHydraliskDen",
            "ZergDefilerMound",
            "ZergGreaterSpire",
            "ZergQueensNest",
            "ZergEvolutionChamber",
            "ZergUltraliskCavern",
            "ZergSpire",
            "ZergSpawningPool",
            "ZergCreepColony",
            "ZergSporeColony",
            "UnusedZergBuilding",
            "ZergSunkenColony",
            "ZergOvermindWithShell",
            "ZergOvermind",
            "ZergExtractor",
            "MatureChrysalis",
            "ZergCerebrate",
            "ZergCerebrateDaggoth",
            "UnusedZergBuilding5",
            "ProtossNexus",
            "ProtossRoboticsFacility",
            "ProtossPylon",
            "ProtossAssimilator",
            "UnusedProtossBuilding1",
            "ProtossObservatory",
            "ProtossGateway",
            "UnusedProtossBuilding2",
            "ProtossPhotonCannon",
            "ProtossCitadelofAdun",
            "ProtossCyberneticsCore",
            "ProtossTemplarArchives",
            "ProtossForge",
            "ProtossStargate",
            "StasisCellPrison",
            "ProtossFleetBeacon",
            "ProtossArbiterTribunal",
            "ProtossRoboticsSupportBay",
            "ProtossShieldBattery",
            "KhaydarinCrystalFormation",
            "ProtossTemple",
            "XelNagaTemple",
            "MineralFieldType1",
            "MineralFieldType2",
            "MineralFieldType3",
            "Cave",
            "CaveIn",
            "Cantina",
            "MiningPlatform",
            "IndependantCommandCenter",
            "IndependantStarport",
            "IndependantJumpGate",
            "Ruins",
            "KyadarinCrystalFormation",
            "VespeneGeyser",
            "WarpGate",
            "PSIDisruptor",
            "ZergMarker",
            "TerranMarker",
            "ProtossMarker",
            "ZergBeacon",
            "TerranBeacon",
            "ProtossBeacon",
            "ZergFlagBeacon",
            "TerranFlagBeacon",
            "ProtossFlagBeacon",
            "PowerGenerator",
            "OvermindCocoon",
            "DarkSwarm",
            "FloorMissileTrap",
            "FloorHatch",
            "LeftUpperLevelDoor",
            "RightUpperLevelDoor",
            "LeftPitDoor",
            "RightPitDoor",
            "FloorGunTrap",
            "LeftWallMissileTrap",
            "LeftWallFlameTrap",
            "RightWallMissileTrap",
            "RightWallFlameTrap",
            "StartLocation",
            "Flag",
            "YoungChrysalis",
            "PsiEmitter",
            "DataDisc",
            "KhaydarinCrystal",
            "MineralClusterType1",
            "MineralClusterType2",
            "ProtossVespeneGasOrbType1",
            "ProtossVespeneGasOrbType2",
            "ZergVespeneGasSacType1",
            "ZergVespeneGasSacType2",
            "TerranVespeneGasTankType1",
            "TerranVespeneGasTankType2"
        };

        public UnitID ID { get; set; }
        public Rule.Setting SettingRule { get; set; }
        public uint HP { get; set; }
        public ushort Shield { get; set; }
        public byte Armor { get; set; }
        public ushort BuildTime { get; set; }
        public ushort Mineral { get; set; }
        public ushort Gas { get; set; }
        public ushort StringNumber { get; set; }
        public WeaponID WeaponID { get; set; }

        /// <summary>
        /// 플레이어별 생산 제한
        /// 이 항목이 적용되려면 생산 제한 규칙이 Override여야함.
        /// 크기: [12]
        /// 경우:
        /// Enable(01): 해당 플레이어는 해당 유닛을 생산할 수 있음
        /// Disable(00): 해당 플레이어는 해당 유닛을 생산할 수 없음
        /// </summary>
        public byte[] PlayerAvailables { get; set; }

        /// <summary>
        /// 글로벌 생산 제한
        /// Default규칙을 사용하는 플레이어 및 유닛에게 적용됨.
        /// 경우: 
        /// Enable(01): 생산할 수 있음 규칙
        /// Disable(00): 생산할 수 없음 규칙
        /// </summary>
        public byte GlobalAvailable { get; set; }

        /// <summary>
        /// 플레이어별 생산 제한 규칙
        /// 크기: [12]
        /// 경우:
        /// Default(01): 글로벌 규칙을 따라간다.
        /// Override(00): 글로벌 규칙을 무시하고 플레이어별 규칙을 따라간다.
        /// </summary>
        public byte[] UseDefaults { get; set; }

        public Unit()
        {

        }

        public Unit(UnitID id)
        {
            ID = id;

            PlayerAvailables = new byte[12];
            UseDefaults = new byte[12];

            switch (id)
            {
                case UnitID.TerranMarine:
                    Init(40, 100, 0, 360, 50, 0, 0, WeaponID.GaussRifleNormal);
                    break;
                case UnitID.TerranGhost:
                    Init(45, 100, 0, 750, 25, 75, 0, WeaponID.C10ConcussionRifleNormal);
                    break;
                case UnitID.TerranVulture:
                    Init(80, 100, 0, 450, 75, 0, 0, WeaponID.FragmentationGrenadeNormal);
                    break;
                case UnitID.TerranGoliath:
                    Init(125, 100, 1, 600, 100, 50, 0, WeaponID.TwinAutocannonsNormal);
                    break;
                case UnitID.GoliathTurret:
                    Init(0, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.TerranSiegeTankTankMode:
                    Init(150, 100, 1, 750, 150, 100, 0);
                    break;
                case UnitID.TankTurretTankMode:
                    Init(0, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.TerranSCV:
                    Init(60, 100, 0, 300, 50, 0, 0);
                    break;
                case UnitID.TerranWraith:
                    Init(120, 100, 0, 900, 150, 100, 0);
                    break;
                case UnitID.TerranScienceVessel:
                    Init(200, 100, 1, 1200, 100, 225, 0);
                    break;
                case UnitID.GuiMontangFirebat:
                    Init(160, 100, 3, 720, 100, 50, 0);
                    break;
                case UnitID.TerranDropship:
                    Init(150, 100, 1, 750, 100, 100, 0);
                    break;
                case UnitID.TerranBattlecruiser:
                    Init(500, 100, 3, 2000, 400, 300, 0);
                    break;
                case UnitID.VultureSpiderMine:
                    Init(20, 100, 0, 1, 1, 0, 0);
                    break;
                case UnitID.NuclearMissile:
                    Init(100, 100, 0, 1500, 200, 200, 0);
                    break;
                case UnitID.TerranCivilian:
                    Init(40, 100, 0, 1, 0, 0, 0);
                    break;
                case UnitID.SarahKerriganGhost:
                    Init(250, 100, 3, 1500, 50, 150, 0);
                    break;
                case UnitID.AlanSchezarGoliath:
                    Init(300, 100, 3, 1200, 200, 100, 0);
                    break;
                case UnitID.AlanSchezarTurret:
                    Init(0, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.JimRaynorVulture:
                    Init(300, 100, 3, 900, 150, 0, 0);
                    break;
                case UnitID.JimRaynorMarine:
                    Init(200, 100, 3, 1, 50, 0, 0);
                    break;
                case UnitID.TomKazanskyWraith:
                    Init(500, 100, 4, 1800, 400, 200, 0);
                    break;
                case UnitID.MagellanScienceVessel:
                    Init(800, 100, 4, 2400, 50, 600, 0);
                    break;
                case UnitID.EdmundDukeSiegeTank:
                    Init(400, 100, 3, 1500, 300, 200, 0);
                    break;
                case UnitID.EdmundDukeTurret1:
                    Init(0, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.EdmundDukeSiegeMode:
                    Init(400, 100, 3, 1500, 300, 200, 0);
                    break;
                case UnitID.EdmundDukeTurret2:
                    Init(0, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ArcturusMengskBattlecruiser:
                    Init(1000, 100, 4, 4800, 800, 600, 0);
                    break;
                case UnitID.HyperionBattlecruiser:
                    Init(850, 100, 4, 2400, 800, 600, 0);
                    break;
                case UnitID.NoradIIBattlecruiser:
                    Init(700, 100, 4, 4800, 800, 600, 0);
                    break;
                case UnitID.TerranSiegeTankSiegeMode:
                    Init(150, 100, 1, 750, 150, 100, 0);
                    break;
                case UnitID.TankTurretSiegeMode:
                    Init(0, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.Firebat:
                    Init(50, 100, 1, 360, 50, 25, 0);
                    break;
                case UnitID.ScannerSweep:
                    Init(0, 0, 0, 1, 0, 0, 0);
                    break;
                case UnitID.TerranMedic:
                    Init(60, 100, 1, 450, 50, 25, 0);
                    break;
                case UnitID.ZergLarva:
                    Init(25, 0, 10, 1, 1, 1, 0);
                    break;
                case UnitID.ZergEgg:
                    Init(200, 0, 10, 1, 1, 1, 0);
                    break;
                case UnitID.ZergZergling:
                    Init(35, 100, 0, 420, 50, 0, 0);
                    break;
                case UnitID.ZergHydralisk:
                    Init(80, 100, 0, 420, 75, 25, 0);
                    break;
                case UnitID.ZergUltralisk:
                    Init(400, 100, 1, 900, 200, 200, 0);
                    break;
                case UnitID.ZergBroodling:
                    Init(30, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ZergDrone:
                    Init(40, 100, 0, 300, 50, 0, 0);
                    break;
                case UnitID.ZergOverlord:
                    Init(200, 100, 0, 600, 100, 0, 0);
                    break;
                case UnitID.ZergMutalisk:
                    Init(120, 100, 0, 600, 100, 100, 0);
                    break;
                case UnitID.ZergGuardian:
                    Init(150, 100, 2, 600, 50, 100, 0);
                    break;
                case UnitID.ZergQueen:
                    Init(120, 100, 0, 750, 100, 100, 0);
                    break;
                case UnitID.ZergDefiler:
                    Init(80, 100, 1, 750, 50, 150, 0);
                    break;
                case UnitID.ZergScourge:
                    Init(25, 100, 0, 450, 25, 75, 0);
                    break;
                case UnitID.TorrarsqueUltralisk:
                    Init(800, 100, 4, 1800, 400, 400, 0);
                    break;
                case UnitID.MatriarchQueen:
                    Init(300, 100, 3, 1500, 200, 300, 0);
                    break;
                case UnitID.InfestedTerran:
                    Init(60, 100, 0, 600, 100, 50, 0);
                    break;
                case UnitID.InfestedKerrigan:
                    Init(400, 100, 2, 1500, 200, 300, 0);
                    break;
                case UnitID.UncleanOneDefiler:
                    Init(250, 100, 3, 1500, 50, 200, 0);
                    break;
                case UnitID.HunterKillerHydralisk:
                    Init(160, 100, 2, 780, 150, 50, 0);
                    break;
                case UnitID.DevouringOneZergling:
                    Init(120, 100, 3, 840, 100, 0, 0);
                    break;
                case UnitID.KukulzaMutalisk:
                    Init(300, 100, 3, 1200, 200, 200, 0);
                    break;
                case UnitID.KukulzaGuardian:
                    Init(400, 100, 4, 1200, 100, 200, 0);
                    break;
                case UnitID.YggdrasillOverlord:
                    Init(1000, 100, 4, 1200, 200, 0, 0);
                    break;
                case UnitID.TerranValkyrieFrigate:
                    Init(200, 100, 2, 750, 250, 125, 0);
                    break;
                case UnitID.MutaliskGuardianCocoon:
                    Init(200, 0, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ProtossCorsair:
                    Init(100, 80, 1, 600, 150, 100, 0);
                    break;
                case UnitID.ProtossDarkTemplarUnit:
                    Init(80, 40, 1, 750, 125, 100, 0);
                    break;
                case UnitID.ZergDevourer:
                    Init(250, 100, 2, 600, 150, 50, 0);
                    break;
                case UnitID.ProtossDarkArchon:
                    Init(25, 200, 1, 300, 0, 0, 0);
                    break;
                case UnitID.ProtossProbe:
                    Init(20, 20, 0, 300, 50, 0, 0);
                    break;
                case UnitID.ProtossZealot:
                    Init(100, 60, 1, 600, 100, 0, 0);
                    break;
                case UnitID.ProtossDragoon:
                    Init(100, 80, 1, 750, 125, 50, 0);
                    break;
                case UnitID.ProtossHighTemplar:
                    Init(40, 40, 0, 750, 50, 150, 0);
                    break;
                case UnitID.ProtossArchon:
                    Init(10, 350, 0, 300, 0, 0, 0);
                    break;
                case UnitID.ProtossShuttle:
                    Init(80, 60, 1, 900, 200, 0, 0);
                    break;
                case UnitID.ProtossScout:
                    Init(150, 100, 0, 1200, 275, 125, 0);
                    break;
                case UnitID.ProtossArbiter:
                    Init(200, 150, 1, 2400, 100, 350, 0);
                    break;
                case UnitID.ProtossCarrier:
                    Init(300, 150, 4, 2100, 350, 250, 0);
                    break;
                case UnitID.ProtossInterceptor:
                    Init(40, 40, 0, 300, 25, 0, 0);
                    break;
                case UnitID.DarkTemplarHero:
                    Init(40, 80, 0, 750, 150, 150, 0);
                    break;
                case UnitID.ZeratulDarkTemplar:
                    Init(60, 400, 0, 1500, 100, 300, 0);
                    break;
                case UnitID.TassadarZeratulArchon:
                    Init(100, 800, 3, 600, 0, 0, 0);
                    break;
                case UnitID.FenixZealot:
                    Init(240, 240, 2, 1200, 200, 0, 0);
                    break;
                case UnitID.FenixDragoon:
                    Init(240, 240, 3, 1500, 300, 100, 0);
                    break;
                case UnitID.TassadarTemplar:
                    Init(80, 300, 2, 1500, 100, 300, 0);
                    break;
                case UnitID.MojoScout:
                    Init(400, 400, 3, 2400, 600, 300, 0);
                    break;
                case UnitID.WarbringerReaver:
                    Init(200, 400, 3, 1800, 400, 200, 0);
                    break;
                case UnitID.GantrithorCarrier:
                    Init(800, 500, 4, 4200, 700, 600, 0);
                    break;
                case UnitID.ProtossReaver:
                    Init(100, 80, 0, 1050, 200, 100, 0);
                    break;
                case UnitID.ProtossObserver:
                    Init(40, 20, 0, 600, 25, 75, 0);
                    break;
                case UnitID.ProtossScarab:
                    Init(20, 10, 0, 105, 15, 0, 0);
                    break;
                case UnitID.DanimothArbiter:
                    Init(600, 500, 3, 4800, 50, 1000, 0);
                    break;
                case UnitID.AldarisTemplar:
                    Init(80, 300, 2, 1500, 100, 300, 0);
                    break;
                case UnitID.ArtanisScout:
                    Init(250, 250, 3, 2400, 600, 300, 0);
                    break;
                case UnitID.RhynadonBadlandsCritter:
                    Init(60, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.BengalaasJungleCritter:
                    Init(60, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.UnusedWasCargoShip:
                    Init(125, 100, 1, 600, 100, 100, 0);
                    break;
                case UnitID.UnusedWasMercenaryGunship:
                    Init(125, 100, 1, 600, 100, 100, 0);
                    break;
                case UnitID.ScantidDesertCritter:
                    Init(60, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.KakaruTwilightCritter:
                    Init(60, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.RagnasaurAshworldCritter:
                    Init(60, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.UrsadonIceWorldCritter:
                    Init(60, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.LurkerEgg:
                    Init(200, 0, 10, 1, 1, 1, 0);
                    break;
                case UnitID.Raszagal:
                    Init(100, 60, 0, 750, 150, 100, 0);
                    break;
                case UnitID.SamirDuranGhost:
                    Init(200, 100, 2, 1500, 200, 75, 0);
                    break;
                case UnitID.AlexeiStukovGhost:
                    Init(250, 100, 3, 1500, 200, 75, 0);
                    break;
                case UnitID.MapRevealer:
                    Init(1, 1, 0, 1, 0, 0, 0);
                    break;
                case UnitID.GerardDuGalle:
                    Init(700, 100, 4, 4800, 800, 600, 0);
                    break;
                case UnitID.ZergLurker:
                    Init(125, 100, 1, 600, 50, 100, 0);
                    break;
                case UnitID.InfestedDuran:
                    Init(300, 100, 3, 1500, 200, 75, 0);
                    break;
                case UnitID.DisruptionWeb:
                    Init(800, 100, 0, 2400, 250, 250, 0);
                    break;
                case UnitID.TerranCommandCenter:
                    Init(1500, 100, 1, 1800, 400, 0, 0);
                    break;
                case UnitID.TerranComsatStation:
                    Init(500, 100, 1, 600, 50, 50, 0);
                    break;
                case UnitID.TerranNuclearSilo:
                    Init(600, 100, 1, 1200, 100, 100, 0);
                    break;
                case UnitID.TerranSupplyDepot:
                    Init(500, 100, 1, 600, 100, 0, 0);
                    break;
                case UnitID.TerranRefinery:
                    Init(750, 100, 1, 600, 100, 0, 0);
                    break;
                case UnitID.TerranBarracks:
                    Init(1000, 100, 1, 1200, 150, 0, 0);
                    break;
                case UnitID.TerranAcademy:
                    Init(600, 100, 1, 1200, 150, 0, 0);
                    break;
                case UnitID.TerranFactory:
                    Init(1250, 100, 1, 1200, 200, 100, 0);
                    break;
                case UnitID.TerranStarport:
                    Init(1300, 100, 1, 1050, 150, 100, 0);
                    break;
                case UnitID.TerranControlTower:
                    Init(500, 100, 1, 600, 50, 50, 0);
                    break;
                case UnitID.TerranScienceFacility:
                    Init(850, 100, 1, 900, 100, 150, 0);
                    break;
                case UnitID.TerranCovertOps:
                    Init(750, 100, 1, 600, 50, 50, 0);
                    break;
                case UnitID.TerranPhysicsLab:
                    Init(600, 100, 1, 600, 50, 50, 0);
                    break;
                case UnitID.UnusedWasStarbase:
                    Init(0, 100, 1, 1, 1, 1, 0);
                    break;
                case UnitID.TerranMachineShop:
                    Init(750, 100, 1, 600, 50, 50, 0);
                    break;
                case UnitID.UnusedWasRepairBay:
                    Init(0, 100, 1, 1, 1, 1, 0);
                    break;
                case UnitID.TerranEngineeringBay:
                    Init(850, 100, 1, 900, 125, 0, 0);
                    break;
                case UnitID.TerranArmory:
                    Init(750, 100, 1, 1200, 100, 50, 0);
                    break;
                case UnitID.TerranMissileTurret:
                    Init(200, 100, 0, 450, 75, 0, 0);
                    break;
                case UnitID.TerranBunker:
                    Init(350, 100, 1, 450, 100, 0, 0);
                    break;
                case UnitID.NoradII:
                    Init(700, 100, 1, 4800, 800, 600, 0);
                    break;
                case UnitID.IonCannon:
                    Init(2000, 100, 1, 900, 200, 0, 0);
                    break;
                case UnitID.UrajCrystal:
                    Init(10000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.KhalisCrystal:
                    Init(10000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.InfestedCommandCenter:
                    Init(1500, 100, 1, 1800, 1, 1, 0);
                    break;
                case UnitID.ZergHatchery:
                    Init(1250, 100, 1, 1800, 300, 0, 0);
                    break;
                case UnitID.ZergLair:
                    Init(1800, 100, 1, 1500, 150, 100, 0);
                    break;
                case UnitID.ZergHive:
                    Init(2500, 100, 1, 1800, 200, 150, 0);
                    break;
                case UnitID.ZergNydusCanal:
                    Init(250, 100, 1, 600, 150, 0, 0);
                    break;
                case UnitID.ZergHydraliskDen:
                    Init(850, 100, 1, 600, 100, 50, 0);
                    break;
                case UnitID.ZergDefilerMound:
                    Init(850, 100, 1, 900, 100, 100, 0);
                    break;
                case UnitID.ZergGreaterSpire:
                    Init(1000, 100, 1, 1800, 100, 150, 0);
                    break;
                case UnitID.ZergQueensNest:
                    Init(850, 100, 1, 900, 150, 100, 0);
                    break;
                case UnitID.ZergEvolutionChamber:
                    Init(750, 100, 1, 600, 75, 0, 0);
                    break;
                case UnitID.ZergUltraliskCavern:
                    Init(600, 100, 1, 1200, 150, 200, 0);
                    break;
                case UnitID.ZergSpire:
                    Init(600, 100, 1, 1800, 200, 150, 0);
                    break;
                case UnitID.ZergSpawningPool:
                    Init(750, 100, 1, 1200, 200, 0, 0);
                    break;
                case UnitID.ZergCreepColony:
                    Init(400, 100, 0, 300, 75, 0, 0);
                    break;
                case UnitID.ZergSporeColony:
                    Init(400, 100, 0, 300, 50, 0, 0);
                    break;
                case UnitID.UnusedZergBuilding:
                    Init(0, 100, 1, 1, 1, 1, 0);
                    break;
                case UnitID.ZergSunkenColony:
                    Init(300, 100, 2, 300, 50, 0, 0);
                    break;
                case UnitID.ZergOvermindWithShell:
                    Init(5000, 100, 1, 1, 1, 1, 0);
                    break;
                case UnitID.ZergOvermind:
                    Init(2500, 100, 1, 1, 1, 1, 0);
                    break;
                case UnitID.ZergExtractor:
                    Init(750, 100, 1, 600, 50, 0, 0);
                    break;
                case UnitID.MatureChrysalis:
                    Init(250, 100, 1, 0, 0, 0, 0);
                    break;
                case UnitID.ZergCerebrate:
                    Init(1500, 100, 1, 0, 0, 0, 0);
                    break;
                case UnitID.ZergCerebrateDaggoth:
                    Init(1500, 100, 1, 0, 0, 0, 0);
                    break;
                case UnitID.UnusedZergBuilding5:
                    Init(0, 100, 1, 1, 1, 1, 0);
                    break;
                case UnitID.ProtossNexus:
                    Init(750, 750, 1, 1800, 400, 0, 0);
                    break;
                case UnitID.ProtossRoboticsFacility:
                    Init(500, 500, 1, 1200, 200, 200, 0);
                    break;
                case UnitID.ProtossPylon:
                    Init(300, 300, 0, 450, 100, 0, 0);
                    break;
                case UnitID.ProtossAssimilator:
                    Init(450, 450, 1, 600, 100, 0, 0);
                    break;
                case UnitID.UnusedProtossBuilding1:
                    Init(300, 300, 1, 1, 1, 1, 0);
                    break;
                case UnitID.ProtossObservatory:
                    Init(250, 250, 1, 450, 50, 100, 0);
                    break;
                case UnitID.ProtossGateway:
                    Init(500, 500, 1, 900, 150, 0, 0);
                    break;
                case UnitID.UnusedProtossBuilding2:
                    Init(0, 1, 1, 1, 1, 1, 0);
                    break;
                case UnitID.ProtossPhotonCannon:
                    Init(100, 100, 0, 750, 150, 0, 0);
                    break;
                case UnitID.ProtossCitadelofAdun:
                    Init(450, 450, 1, 900, 150, 100, 0);
                    break;
                case UnitID.ProtossCyberneticsCore:
                    Init(500, 500, 1, 900, 200, 0, 0);
                    break;
                case UnitID.ProtossTemplarArchives:
                    Init(500, 500, 1, 900, 150, 200, 0);
                    break;
                case UnitID.ProtossForge:
                    Init(550, 550, 1, 600, 150, 0, 0);
                    break;
                case UnitID.ProtossStargate:
                    Init(600, 600, 1, 1050, 150, 150, 0);
                    break;
                case UnitID.StasisCellPrison:
                    Init(2000, 100, 1, 1, 150, 0, 0);
                    break;
                case UnitID.ProtossFleetBeacon:
                    Init(500, 500, 1, 900, 300, 200, 0);
                    break;
                case UnitID.ProtossArbiterTribunal:
                    Init(500, 500, 1, 900, 200, 150, 0);
                    break;
                case UnitID.ProtossRoboticsSupportBay:
                    Init(450, 450, 1, 450, 150, 100, 0);
                    break;
                case UnitID.ProtossShieldBattery:
                    Init(200, 200, 1, 450, 100, 0, 0);
                    break;
                case UnitID.KhaydarinCrystalFormation:
                    Init(100000, 100, 1, 1, 250, 0, 0);
                    break;
                case UnitID.ProtossTemple:
                    Init(1500, 100, 1, 1, 250, 0, 0);
                    break;
                case UnitID.XelNagaTemple:
                    Init(5000, 100, 1, 4800, 1500, 500, 0);
                    break;
                case UnitID.MineralFieldType1:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.MineralFieldType2:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.MineralFieldType3:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.Cave:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.CaveIn:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.Cantina:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.MiningPlatform:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.IndependantCommandCenter:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.IndependantStarport:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.IndependantJumpGate:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.Ruins:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.KyadarinCrystalFormation:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.VespeneGeyser:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.WarpGate:
                    Init(700, 100, 1, 2400, 600, 200, 0);
                    break;
                case UnitID.PSIDisruptor:
                    Init(2000, 100, 1, 4800, 1000, 400, 0);
                    break;
                case UnitID.ZergMarker:
                    Init(100000, 100, 0, 1, 250, 0, 0);
                    break;
                case UnitID.TerranMarker:
                    Init(100000, 100, 0, 1, 50, 50, 0);
                    break;
                case UnitID.ProtossMarker:
                    Init(100000, 100, 0, 1, 100, 100, 0);
                    break;
                case UnitID.ZergBeacon:
                    Init(100000, 100, 0, 1, 250, 0, 0);
                    break;
                case UnitID.TerranBeacon:
                    Init(100000, 100, 0, 1, 50, 50, 0);
                    break;
                case UnitID.ProtossBeacon:
                    Init(100000, 100, 0, 1, 100, 100, 0);
                    break;
                case UnitID.ZergFlagBeacon:
                    Init(100000, 100, 0, 1, 250, 0, 0);
                    break;
                case UnitID.TerranFlagBeacon:
                    Init(100000, 100, 0, 1, 50, 50, 0);
                    break;
                case UnitID.ProtossFlagBeacon:
                    Init(100000, 100, 0, 1, 100, 100, 0);
                    break;
                case UnitID.PowerGenerator:
                    Init(800, 100, 1, 2400, 200, 50, 0);
                    break;
                case UnitID.OvermindCocoon:
                    Init(2500, 100, 1, 2400, 1000, 500, 0);
                    break;
                case UnitID.DarkSwarm:
                    Init(800, 100, 0, 2400, 250, 200, 0);
                    break;
                case UnitID.FloorMissileTrap:
                    Init(50, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.FloorHatch:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.LeftUpperLevelDoor:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.RightUpperLevelDoor:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.LeftPitDoor:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.RightPitDoor:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.FloorGunTrap:
                    Init(50, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.LeftWallMissileTrap:
                    Init(50, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.LeftWallFlameTrap:
                    Init(50, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.RightWallMissileTrap:
                    Init(50, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.RightWallFlameTrap:
                    Init(50, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.StartLocation:
                    Init(800, 100, 0, 0, 0, 0, 0);
                    break;
                case UnitID.Flag:
                    Init(100000, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.YoungChrysalis:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.PsiEmitter:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.DataDisc:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.KhaydarinCrystal:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.MineralClusterType1:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.MineralClusterType2:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ProtossVespeneGasOrbType1:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ProtossVespeneGasOrbType2:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ZergVespeneGasSacType1:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.ZergVespeneGasSacType2:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.TerranVespeneGasTankType1:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
                case UnitID.TerranVespeneGasTankType2:
                    Init(800, 100, 0, 1, 1, 1, 0);
                    break;
            }
        }

        public void Init(uint hp, ushort shield, byte armor, ushort buildTime, ushort mineral, ushort gas, ushort stringNumber, WeaponID weaponID = WeaponID.None)
        {
            SettingRule = Rule.Setting.Default;

            HP = hp;
            Shield = shield;
            Armor = armor;
            BuildTime = buildTime;
            Mineral = mineral;
            Gas = gas;
            StringNumber = stringNumber;

            WeaponID = weaponID;

            PlayerAvailables.Fill<byte>(1);
            GlobalAvailable = 1;
            UseDefaults.Fill<byte>(1);
        }
    }
}
