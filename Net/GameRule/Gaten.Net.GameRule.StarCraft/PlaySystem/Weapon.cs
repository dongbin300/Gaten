namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public enum WeaponID
    {
        GaussRifleNormal = 0, // Marine
        GaussRifleJimRaynorMarine = 1,
        C10ConcussionRifleNormal = 2, // Ghost
        C10ConcussionRifleSarahKerrigan = 3,
        FragmentationGrenadeNormal = 4, // Vulture
        FragmentationGrenadeJimRaynorVulture = 5,
        SpiderMines = 6,
        TwinAutocannonsNormal = 7, // Goliath
        HellfireMissilePackNormal = 8, // Goliath
        TwinAutocannonsAlanSchezar = 9,
        HellfireMissilePackAlanSchezar = 10,
        ArcliteCannonNormal = 11, // Siege Tank
        ArcliteCannonEdmundDuke = 12,
        FusionCutter = 13, // SCV
        FusionCutterHarvest = 14,
        GeminiMissilesNormal = 15, // Wraith
        BurstLasersNormal = 16, // Wraith
        GeminiMissilesTomKazansky = 17,
        BurstLasersTomKazansky = 18,
        ATSLaserBatteryNormal = 19, // Battle Cruiser
        ATALaserBatteryNormal = 20, // Battle Cruiser
        ATSLaserBatteryNoradIIMengskDuGalle = 21,
        ATALaserBatteryNoradIIMengskDuGalle = 22,
        ATSLaserBatteryHyperion = 23,
        ATALaserBatteryHyperion = 24,
        FlameThrowerNormal = 25, // Firebat
        FlameThrowerGuiMontag = 26,
        ArcliteShockCannonNormal = 27, // Siege Tank
        ArcliteShockCannonEdmundDuke = 28,
        LongboltMissiles = 29, // ?? 20
        YamatoGun = 30,
        NuclearMissile = 31,
        Lockdown = 32,
        EMPShockwave = 33,
        Irradiate = 34,
        ClawsNormal = 35, // Zergling
        ClawsDevouringOne = 36,
        ClawsInfestedKerrigan = 37,
        NeedleSpinesNormal = 38, // Hydralisk
        NeedleSpinesHunterKiller = 39,
        KaiserBladesNormal = 40, // Ultralisk
        KaiserBladesTorrasque = 41,
        ToxicSporesBroodling = 42,
        Spines = 43, // Drone
        SpinesHarvest = 44,
        AcidSprayUnused = 45,
        AcidSporeNormal = 46, // Guardian
        AcidSporeKukulzaGuardian = 47,
        GlaveWurmNormal = 48, // Mutalisk
        GlaveWurmKukulzaMutalisk = 49,
        VenomUnusedDefiler = 50,
        VenomUnusedDefilerHero = 51,
        SeekerSpores = 52,
        SubterraneanTentacle = 53,
        SuicideInfestedTerran = 54,
        SuicideScourge = 55,
        Parasite = 56,
        SpawnBroodlings = 57,
        Ensnare = 58,
        DarkSwarm = 59,
        Plague = 60,
        Consume = 61,
        ParticleBeam = 62,
        ParticleBeamHarvest = 63,
        PsiBladesNormal = 64,
        PsiBladesFenixZealot = 65,
        PhaseDisruptorNormal = 66,
        PhaseDisruptorFenixDragoon = 67,
        PsiAssaultNormalUnused = 68,
        PsiAssaultTassadarAldaris = 69,
        PsionicShockwaveNormal = 70,
        PsionicShockwaveTassadarZeratulArchon = 71,
        Unknown72 = 72,
        DualPhotonBlastersNormal = 73,
        AntimatterMissilesNormal = 74,
        DualPhotonBlastersMojo = 75,
        AnitmatterMissilesMojo = 76,
        PhaseDisruptorCannonNormal = 77,
        PhaseDisruptorCannonDanimoth = 78,
        PulseCannon = 79,
        STSPhotonCannon = 80,
        STAPhotonCannon = 81,
        Scarab = 82,
        StasisField = 83,
        PsiStorm = 84,
        WarpBladesZeratul = 85,
        WarpBladesDarkTemplarHero = 86,
        MissilesUnused = 87,
        LaserBattery1Unused = 88,
        TormentorMissilesUnused = 89,
        BombsUnused = 90,
        RaiderGunUnused = 91,
        LaserBattery2Unused = 92,
        LaserBattery3Unused = 93,
        DualPhotonBlastersUnused = 94,
        FlechetteGrenadeUnused = 95,
        TwinAutocannonsFloorTrap = 96,
        HellfireMissilePackWallTrap = 97,
        FlameThrowerWallTrap = 98,
        HellfireMissilePackFloorTrap = 99,
        NeutronFlare = 100,
        DisruptionWeb = 101,
        Restoration = 102,
        HaloRockets = 103, // Valkyrie
        CorrosiveAcid = 104,
        MindControl = 105,
        Feedback = 106,
        OpticalFlare = 107,
        Maelstrom = 108,
        SubterraneanSpines = 109,
        GaussRifle0Unused = 110,
        WarpBladesNormal = 111,
        C10ConcussionRifleSamirDuran = 112,
        C10ConcussionRifleInfestedDuran = 113,
        DualPhotonBlastersArtanis = 114,
        AntimatterMissilesArtanis = 115,
        C10ConcussionRifleAlexeiStukov = 116,
        GaussRifle1Unused = 117,
        GaussRifle2Unused = 118,
        GaussRifle3Unused = 119,
        GaussRifle4Unused = 120,
        GaussRifle5Unused = 121,
        GaussRifle6Unused = 122,
        GaussRifle7Unused = 123,
        GaussRifle8Unused = 124,
        GaussRifle9Unused = 125,
        GaussRifle10Unused = 126,
        GaussRifle11Unused = 127,
        GaussRifle12Unused = 128,
        GaussRifle13Unused = 129,
        None = 130 // not use
    }

    public class Weapon
    {
        public static string[] IdString =
        {
            "GaussRifleNormal",
            "GaussRifleJimRaynorMarine",
            "C10ConcussionRifleNormal",
            "C10ConcussionRifleSarahKerrigan",
            "FragmentationGrenadeNormal",
            "FragmentationGrenadeJimRaynorVulture",
            "SpiderMines",
            "TwinAutocannonsNormal",
            "HellfireMissilePackNormal",
            "TwinAutocannonsAlanSchezar",
            "HellfireMissilePackAlanSchezar",
            "ArcliteCannonNormal",
            "ArcliteCannonEdmundDuke",
            "FusionCutter",
            "FusionCutterHarvest",
            "GeminiMissilesNormal",
            "BurstLasersNormal",
            "GeminiMissilesTomKazansky",
            "BurstLasersTomKazansky",
            "ATSLaserBatteryNormal",
            "ATALaserBatteryNormal",
            "ATSLaserBatteryNoradIIMengskDuGalle",
            "ATALaserBatteryNoradIIMengskDuGalle",
            "ATSLaserBatteryHyperion",
            "ATALaserBatteryHyperion",
            "FlameThrowerNormal",
            "FlameThrowerGuiMontag",
            "ArcliteShockCannonNormal",
            "ArcliteShockCannonEdmundDuke",
            "LongboltMissiles",
            "YamatoGun",
            "NuclearMissile",
            "Lockdown",
            "EMPShockwave",
            "Irradiate",
            "ClawsNormal",
            "ClawsDevouringOne",
            "ClawsInfestedKerrigan",
            "NeedleSpinesNormal",
            "NeedleSpinesHunterKiller",
            "KaiserBladesNormal",
            "KaiserBladesTorrasque",
            "ToxicSporesBroodling",
            "Spines",
            "SpinesHarvest",
            "AcidSprayUnused",
            "AcidSporeNormal",
            "AcidSporeKukulzaGuardian",
            "GlaveWurmNormal",
            "GlaveWurmKukulzaMutalisk",
            "VenomUnusedDefiler",
            "VenomUnusedDefilerHero",
            "SeekerSpores",
            "SubterraneanTentacle",
            "SuicideInfestedTerran",
            "SuicideScourge",
            "Parasite",
            "SpawnBroodlings",
            "Ensnare",
            "DarkSwarm",
            "Plague",
            "Consume",
            "ParticleBeam",
            "ParticleBeamHarvest",
            "PsiBladesNormal",
            "PsiBladesFenixZealot",
            "PhaseDisruptorNormal",
            "PhaseDisruptorFenixDragoon",
            "PsiAssaultNormalUnused",
            "PsiAssaultTassadarAldaris",
            "PsionicShockwaveNormal",
            "PsionicShockwaveTassadarZeratulArchon",
            "Unknown72",
            "DualPhotonBlastersNormal",
            "AntimatterMissilesNormal",
            "DualPhotonBlastersMojo",
            "AnitmatterMissilesMojo",
            "PhaseDisruptorCannonNormal",
            "PhaseDisruptorCannonDanimoth",
            "PulseCannon",
            "STSPhotonCannon",
            "STAPhotonCannon",
            "Scarab",
            "StasisField",
            "PsiStorm",
            "WarpBladesZeratul",
            "WarpBladesDarkTemplarHero",
            "MissilesUnused",
            "LaserBattery1Unused",
            "TormentorMissilesUnused",
            "BombsUnused",
            "RaiderGunUnused",
            "LaserBattery2Unused",
            "LaserBattery3Unused",
            "DualPhotonBlastersUnused",
            "FlechetteGrenadeUnused",
            "TwinAutocannonsFloorTrap",
            "HellfireMissilePackWallTrap",
            "FlameThrowerWallTrap",
            "HellfireMissilePackFloorTrap",
            "NeutronFlare",
            "DisruptionWeb",
            "Restoration",
            "HaloRockets",
            "CorrosiveAcid",
            "MindControl",
            "Feedback",
            "OpticalFlare",
            "Maelstrom",
            "SubterraneanSpines",
            "GaussRifle0Unused",
            "WarpBladesNormal",
            "C10ConcussionRifleSamirDuran",
            "C10ConcussionRifleInfestedDuran",
            "DualPhotonBlastersArtanis",
            "AntimatterMissilesArtanis",
            "C10ConcussionRifleAlexeiStukov",
            "GaussRifle1Unused",
            "GaussRifle2Unused",
            "GaussRifle3Unused",
            "GaussRifle4Unused",
            "GaussRifle5Unused",
            "GaussRifle6Unused",
            "GaussRifle7Unused",
            "GaussRifle8Unused",
            "GaussRifle9Unused",
            "GaussRifle10Unused",
            "GaussRifle11Unused",
            "GaussRifle12Unused",
            "GaussRifle13Unused",
            "None"
        };

        public WeaponID ID;
        public ushort Power;
        public ushort PowerBonus;

        public Weapon()
        {

        }

        public Weapon(WeaponID id)
        {
            ID = id;

            switch (id)
            {
                case WeaponID.GaussRifleNormal:
                    Init(6, 1);
                    break;
                case WeaponID.GaussRifleJimRaynorMarine:
                    Init(18, 1);
                    break;
                case WeaponID.C10ConcussionRifleNormal:
                    Init(10, 1);
                    break;
                case WeaponID.C10ConcussionRifleSarahKerrigan:
                    Init(30, 1);
                    break;
                case WeaponID.FragmentationGrenadeNormal:
                    Init(20, 2);
                    break;
                case WeaponID.FragmentationGrenadeJimRaynorVulture:
                    Init(30, 2);
                    break;
                case WeaponID.SpiderMines:
                    Init(125, 0);
                    break;
                case WeaponID.TwinAutocannonsNormal:
                    Init(12, 1);
                    break;
                case WeaponID.HellfireMissilePackNormal:
                    Init(10, 2);
                    break;
                case WeaponID.TwinAutocannonsAlanSchezar:
                    Init(24, 1);
                    break;
                case WeaponID.HellfireMissilePackAlanSchezar:
                    Init(20, 1);
                    break;
                case WeaponID.ArcliteCannonNormal:
                    Init(30, 3);
                    break;
                case WeaponID.ArcliteCannonEdmundDuke:
                    Init(70, 3);
                    break;
                case WeaponID.FusionCutter:
                    Init(5, 1);
                    break;
                case WeaponID.FusionCutterHarvest:
                    Init(0, 0);
                    break;
                case WeaponID.GeminiMissilesNormal:
                    Init(20, 2);
                    break;
                case WeaponID.BurstLasersNormal:
                    Init(8, 1);
                    break;
                case WeaponID.GeminiMissilesTomKazansky:
                    Init(40, 2);
                    break;
                case WeaponID.BurstLasersTomKazansky:
                    Init(16, 1);
                    break;
                case WeaponID.ATSLaserBatteryNormal:
                    Init(25, 3);
                    break;
                case WeaponID.ATALaserBatteryNormal:
                    Init(25, 3);
                    break;
                case WeaponID.ATSLaserBatteryNoradIIMengskDuGalle:
                    Init(50, 3);
                    break;
                case WeaponID.ATALaserBatteryNoradIIMengskDuGalle:
                    Init(50, 3);
                    break;
                case WeaponID.ATSLaserBatteryHyperion:
                    Init(30, 3);
                    break;
                case WeaponID.ATALaserBatteryHyperion:
                    Init(30, 3);
                    break;
                case WeaponID.FlameThrowerNormal:
                    Init(8, 1);
                    break;
                case WeaponID.FlameThrowerGuiMontag:
                    Init(16, 1);
                    break;
                case WeaponID.ArcliteShockCannonNormal:
                    Init(70, 5);
                    break;
                case WeaponID.ArcliteShockCannonEdmundDuke:
                    Init(150, 5);
                    break;
                case WeaponID.LongboltMissiles:
                    Init(20, 0);
                    break;
                case WeaponID.YamatoGun:
                    Init(0, 0);
                    break;
                case WeaponID.NuclearMissile:
                    Init(0, 0);
                    break;
                case WeaponID.Lockdown:
                    Init(0, 0);
                    break;
                case WeaponID.EMPShockwave:
                    Init(0, 0);
                    break;
                case WeaponID.Irradiate:
                    Init(0, 0);
                    break;
                case WeaponID.ClawsNormal:
                    Init(5, 1);
                    break;
                case WeaponID.ClawsDevouringOne:
                    Init(10, 1);
                    break;
                case WeaponID.ClawsInfestedKerrigan:
                    Init(50, 1);
                    break;
                case WeaponID.NeedleSpinesNormal:
                    Init(10, 1);
                    break;
                case WeaponID.NeedleSpinesHunterKiller:
                    Init(20, 1);
                    break;
                case WeaponID.KaiserBladesNormal:
                    Init(20, 3);
                    break;
                case WeaponID.KaiserBladesTorrasque:
                    Init(50, 3);
                    break;
                case WeaponID.ToxicSporesBroodling:
                    Init(4, 1);
                    break;
                case WeaponID.Spines:
                    Init(5, 0);
                    break;
                case WeaponID.SpinesHarvest:
                    Init(0, 0);
                    break;
                case WeaponID.AcidSprayUnused:
                    Init(0, 0);
                    break;
                case WeaponID.AcidSporeNormal:
                    Init(20, 2);
                    break;
                case WeaponID.AcidSporeKukulzaGuardian:
                    Init(40, 2);
                    break;
                case WeaponID.GlaveWurmNormal:
                    Init(9, 1);
                    break;
                case WeaponID.GlaveWurmKukulzaMutalisk:
                    Init(18, 1);
                    break;
                case WeaponID.VenomUnusedDefiler:
                    Init(0, 0);
                    break;
                case WeaponID.VenomUnusedDefilerHero:
                    Init(0, 0);
                    break;
                case WeaponID.SeekerSpores:
                    Init(15, 0);
                    break;
                case WeaponID.SubterraneanTentacle:
                    Init(40, 0);
                    break;
                case WeaponID.SuicideInfestedTerran:
                    Init(500, 0);
                    break;
                case WeaponID.SuicideScourge:
                    Init(110, 0);
                    break;
                case WeaponID.Parasite:
                    Init(0, 0);
                    break;
                case WeaponID.SpawnBroodlings:
                    Init(0, 0);
                    break;
                case WeaponID.Ensnare:
                    Init(0, 0);
                    break;
                case WeaponID.DarkSwarm:
                    Init(0, 0);
                    break;
                case WeaponID.Plague:
                    Init(0, 0);
                    break;
                case WeaponID.Consume:
                    Init(0, 0);
                    break;
                case WeaponID.ParticleBeam:
                    Init(5, 0);
                    break;
                case WeaponID.ParticleBeamHarvest:
                    Init(0, 0);
                    break;
                case WeaponID.PsiBladesNormal:
                    Init(8, 1);
                    break;
                case WeaponID.PsiBladesFenixZealot:
                    Init(20, 1);
                    break;
                case WeaponID.PhaseDisruptorNormal:
                    Init(20, 2);
                    break;
                case WeaponID.PhaseDisruptorFenixDragoon:
                    Init(45, 2);
                    break;
                case WeaponID.PsiAssaultNormalUnused:
                    Init(0, 0);
                    break;
                case WeaponID.PsiAssaultTassadarAldaris:
                    Init(20, 1);
                    break;
                case WeaponID.PsionicShockwaveNormal:
                    Init(30, 3);
                    break;
                case WeaponID.PsionicShockwaveTassadarZeratulArchon:
                    Init(60, 3);
                    break;
                case WeaponID.Unknown72:
                    Init(0, 0);
                    break;
                case WeaponID.DualPhotonBlastersNormal:
                    Init(8, 1);
                    break;
                case WeaponID.AntimatterMissilesNormal:
                    Init(14, 1);
                    break;
                case WeaponID.DualPhotonBlastersMojo:
                    Init(20, 1);
                    break;
                case WeaponID.AnitmatterMissilesMojo:
                    Init(28, 1);
                    break;
                case WeaponID.PhaseDisruptorCannonNormal:
                    Init(10, 1);
                    break;
                case WeaponID.PhaseDisruptorCannonDanimoth:
                    Init(20, 1);
                    break;
                case WeaponID.PulseCannon:
                    Init(46, 1);
                    break;
                case WeaponID.STSPhotonCannon:
                    Init(20, 0);
                    break;
                case WeaponID.STAPhotonCannon:
                    Init(20, 0);
                    break;
                case WeaponID.Scarab:
                    Init(100, 25);
                    break;
                case WeaponID.StasisField:
                    Init(0, 0);
                    break;
                case WeaponID.PsiStorm:
                    Init(0, 0);
                    break;
                case WeaponID.WarpBladesZeratul:
                    Init(100, 1);
                    break;
                case WeaponID.WarpBladesDarkTemplarHero:
                    Init(45, 1);
                    break;
                case WeaponID.MissilesUnused:
                    Init(0, 0);
                    break;
                case WeaponID.LaserBattery1Unused:
                    Init(0, 0);
                    break;
                case WeaponID.TormentorMissilesUnused:
                    Init(0, 0);
                    break;
                case WeaponID.BombsUnused:
                    Init(0, 0);
                    break;
                case WeaponID.RaiderGunUnused:
                    Init(0, 0);
                    break;
                case WeaponID.LaserBattery2Unused:
                    Init(7, 1);
                    break;
                case WeaponID.LaserBattery3Unused:
                    Init(7, 1);
                    break;
                case WeaponID.DualPhotonBlastersUnused:
                    Init(0, 0);
                    break;
                case WeaponID.FlechetteGrenadeUnused:
                    Init(0, 0);
                    break;
                case WeaponID.TwinAutocannonsFloorTrap:
                    Init(10, 1);
                    break;
                case WeaponID.HellfireMissilePackWallTrap:
                    Init(10, 1);
                    break;
                case WeaponID.FlameThrowerWallTrap:
                    Init(8, 1);
                    break;
                case WeaponID.HellfireMissilePackFloorTrap:
                    Init(10, 1);
                    break;
                case WeaponID.NeutronFlare:
                    Init(5, 1);
                    break;
                case WeaponID.DisruptionWeb:
                    Init(0, 0);
                    break;
                case WeaponID.Restoration:
                    Init(0, 0);
                    break;
                case WeaponID.HaloRockets:
                    Init(6, 1);
                    break;
                case WeaponID.CorrosiveAcid:
                    Init(25, 2);
                    break;
                case WeaponID.MindControl:
                    Init(0, 0);
                    break;
                case WeaponID.Feedback:
                    Init(0, 0);
                    break;
                case WeaponID.OpticalFlare:
                    Init(0, 0);
                    break;
                case WeaponID.Maelstrom:
                    Init(0, 0);
                    break;
                case WeaponID.SubterraneanSpines:
                    Init(20, 2);
                    break;
                case WeaponID.GaussRifle0Unused:
                    Init(0, 0);
                    break;
                case WeaponID.WarpBladesNormal:
                    Init(40, 3);
                    break;
                case WeaponID.C10ConcussionRifleSamirDuran:
                    Init(25, 1);
                    break;
                case WeaponID.C10ConcussionRifleInfestedDuran:
                    Init(25, 1);
                    break;
                case WeaponID.DualPhotonBlastersArtanis:
                    Init(20, 1);
                    break;
                case WeaponID.AntimatterMissilesArtanis:
                    Init(28, 1);
                    break;
                case WeaponID.C10ConcussionRifleAlexeiStukov:
                    Init(30, 1);
                    break;
                case WeaponID.GaussRifle1Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle2Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle3Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle4Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle5Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle6Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle7Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle8Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle9Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle10Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle11Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle12Unused:
                    Init(0, 0);
                    break;
                case WeaponID.GaussRifle13Unused:
                    Init(0, 0);
                    break;
                case WeaponID.None:
                    Init(0, 0);
                    break;
            }
        }

        public Weapon GetWeapon(WeaponID id)
        {
            return this;
        }

        public void Init(ushort power, ushort powerBonus)
        {
            Power = power;
            PowerBonus = powerBonus;
        }
    }
}
