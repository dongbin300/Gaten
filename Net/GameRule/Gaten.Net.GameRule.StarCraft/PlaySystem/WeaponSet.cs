namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public class WeaponSet
    {
        public List<Weapon> Weapons { get; set; }

        public WeaponSet()
        {
            Weapons = new List<Weapon>();

            MakeDefault();
        }

        void MakeDefault()
        {
            Weapons.Add(new Weapon(WeaponID.GaussRifleNormal));
            Weapons.Add(new Weapon(WeaponID.GaussRifleJimRaynorMarine));
            Weapons.Add(new Weapon(WeaponID.C10ConcussionRifleNormal));
            Weapons.Add(new Weapon(WeaponID.C10ConcussionRifleSarahKerrigan));
            Weapons.Add(new Weapon(WeaponID.FragmentationGrenadeNormal));
            Weapons.Add(new Weapon(WeaponID.FragmentationGrenadeJimRaynorVulture));
            Weapons.Add(new Weapon(WeaponID.SpiderMines));
            Weapons.Add(new Weapon(WeaponID.TwinAutocannonsNormal));
            Weapons.Add(new Weapon(WeaponID.HellfireMissilePackNormal));
            Weapons.Add(new Weapon(WeaponID.TwinAutocannonsAlanSchezar));
            Weapons.Add(new Weapon(WeaponID.HellfireMissilePackAlanSchezar));
            Weapons.Add(new Weapon(WeaponID.ArcliteCannonNormal));
            Weapons.Add(new Weapon(WeaponID.ArcliteCannonEdmundDuke));
            Weapons.Add(new Weapon(WeaponID.FusionCutter));
            Weapons.Add(new Weapon(WeaponID.FusionCutterHarvest));
            Weapons.Add(new Weapon(WeaponID.GeminiMissilesNormal));
            Weapons.Add(new Weapon(WeaponID.BurstLasersNormal));
            Weapons.Add(new Weapon(WeaponID.GeminiMissilesTomKazansky));
            Weapons.Add(new Weapon(WeaponID.BurstLasersTomKazansky));
            Weapons.Add(new Weapon(WeaponID.ATSLaserBatteryNormal));
            Weapons.Add(new Weapon(WeaponID.ATALaserBatteryNormal));
            Weapons.Add(new Weapon(WeaponID.ATSLaserBatteryNoradIIMengskDuGalle));
            Weapons.Add(new Weapon(WeaponID.ATALaserBatteryNoradIIMengskDuGalle));
            Weapons.Add(new Weapon(WeaponID.ATSLaserBatteryHyperion));
            Weapons.Add(new Weapon(WeaponID.ATALaserBatteryHyperion));
            Weapons.Add(new Weapon(WeaponID.FlameThrowerNormal));
            Weapons.Add(new Weapon(WeaponID.FlameThrowerGuiMontag));
            Weapons.Add(new Weapon(WeaponID.ArcliteShockCannonNormal));
            Weapons.Add(new Weapon(WeaponID.ArcliteShockCannonEdmundDuke));
            Weapons.Add(new Weapon(WeaponID.LongboltMissiles));
            Weapons.Add(new Weapon(WeaponID.YamatoGun));
            Weapons.Add(new Weapon(WeaponID.NuclearMissile));
            Weapons.Add(new Weapon(WeaponID.Lockdown));
            Weapons.Add(new Weapon(WeaponID.EMPShockwave));
            Weapons.Add(new Weapon(WeaponID.Irradiate));
            Weapons.Add(new Weapon(WeaponID.ClawsNormal));
            Weapons.Add(new Weapon(WeaponID.ClawsDevouringOne));
            Weapons.Add(new Weapon(WeaponID.ClawsInfestedKerrigan));
            Weapons.Add(new Weapon(WeaponID.NeedleSpinesNormal));
            Weapons.Add(new Weapon(WeaponID.NeedleSpinesHunterKiller));
            Weapons.Add(new Weapon(WeaponID.KaiserBladesNormal));
            Weapons.Add(new Weapon(WeaponID.KaiserBladesTorrasque));
            Weapons.Add(new Weapon(WeaponID.ToxicSporesBroodling));
            Weapons.Add(new Weapon(WeaponID.Spines));
            Weapons.Add(new Weapon(WeaponID.SpinesHarvest));
            Weapons.Add(new Weapon(WeaponID.AcidSprayUnused));
            Weapons.Add(new Weapon(WeaponID.AcidSporeNormal));
            Weapons.Add(new Weapon(WeaponID.AcidSporeKukulzaGuardian));
            Weapons.Add(new Weapon(WeaponID.GlaveWurmNormal));
            Weapons.Add(new Weapon(WeaponID.GlaveWurmKukulzaMutalisk));
            Weapons.Add(new Weapon(WeaponID.VenomUnusedDefiler));
            Weapons.Add(new Weapon(WeaponID.VenomUnusedDefilerHero));
            Weapons.Add(new Weapon(WeaponID.SeekerSpores));
            Weapons.Add(new Weapon(WeaponID.SubterraneanTentacle));
            Weapons.Add(new Weapon(WeaponID.SuicideInfestedTerran));
            Weapons.Add(new Weapon(WeaponID.SuicideScourge));
            Weapons.Add(new Weapon(WeaponID.Parasite));
            Weapons.Add(new Weapon(WeaponID.SpawnBroodlings));
            Weapons.Add(new Weapon(WeaponID.Ensnare));
            Weapons.Add(new Weapon(WeaponID.DarkSwarm));
            Weapons.Add(new Weapon(WeaponID.Plague));
            Weapons.Add(new Weapon(WeaponID.Consume));
            Weapons.Add(new Weapon(WeaponID.ParticleBeam));
            Weapons.Add(new Weapon(WeaponID.ParticleBeamHarvest));
            Weapons.Add(new Weapon(WeaponID.PsiBladesNormal));
            Weapons.Add(new Weapon(WeaponID.PsiBladesFenixZealot));
            Weapons.Add(new Weapon(WeaponID.PhaseDisruptorNormal));
            Weapons.Add(new Weapon(WeaponID.PhaseDisruptorFenixDragoon));
            Weapons.Add(new Weapon(WeaponID.PsiAssaultNormalUnused));
            Weapons.Add(new Weapon(WeaponID.PsiAssaultTassadarAldaris));
            Weapons.Add(new Weapon(WeaponID.PsionicShockwaveNormal));
            Weapons.Add(new Weapon(WeaponID.PsionicShockwaveTassadarZeratulArchon));
            Weapons.Add(new Weapon(WeaponID.Unknown72));
            Weapons.Add(new Weapon(WeaponID.DualPhotonBlastersNormal));
            Weapons.Add(new Weapon(WeaponID.AntimatterMissilesNormal));
            Weapons.Add(new Weapon(WeaponID.DualPhotonBlastersMojo));
            Weapons.Add(new Weapon(WeaponID.AnitmatterMissilesMojo));
            Weapons.Add(new Weapon(WeaponID.PhaseDisruptorCannonNormal));
            Weapons.Add(new Weapon(WeaponID.PhaseDisruptorCannonDanimoth));
            Weapons.Add(new Weapon(WeaponID.PulseCannon));
            Weapons.Add(new Weapon(WeaponID.STSPhotonCannon));
            Weapons.Add(new Weapon(WeaponID.STAPhotonCannon));
            Weapons.Add(new Weapon(WeaponID.Scarab));
            Weapons.Add(new Weapon(WeaponID.StasisField));
            Weapons.Add(new Weapon(WeaponID.PsiStorm));
            Weapons.Add(new Weapon(WeaponID.WarpBladesZeratul));
            Weapons.Add(new Weapon(WeaponID.WarpBladesDarkTemplarHero));
            Weapons.Add(new Weapon(WeaponID.MissilesUnused));
            Weapons.Add(new Weapon(WeaponID.LaserBattery1Unused));
            Weapons.Add(new Weapon(WeaponID.TormentorMissilesUnused));
            Weapons.Add(new Weapon(WeaponID.BombsUnused));
            Weapons.Add(new Weapon(WeaponID.RaiderGunUnused));
            Weapons.Add(new Weapon(WeaponID.LaserBattery2Unused));
            Weapons.Add(new Weapon(WeaponID.LaserBattery3Unused));
            Weapons.Add(new Weapon(WeaponID.DualPhotonBlastersUnused));
            Weapons.Add(new Weapon(WeaponID.FlechetteGrenadeUnused));
            Weapons.Add(new Weapon(WeaponID.TwinAutocannonsFloorTrap));
            Weapons.Add(new Weapon(WeaponID.HellfireMissilePackWallTrap));
            Weapons.Add(new Weapon(WeaponID.FlameThrowerWallTrap));
            Weapons.Add(new Weapon(WeaponID.HellfireMissilePackFloorTrap));
            Weapons.Add(new Weapon(WeaponID.NeutronFlare));
            Weapons.Add(new Weapon(WeaponID.DisruptionWeb));
            Weapons.Add(new Weapon(WeaponID.Restoration));
            Weapons.Add(new Weapon(WeaponID.HaloRockets));
            Weapons.Add(new Weapon(WeaponID.CorrosiveAcid));
            Weapons.Add(new Weapon(WeaponID.MindControl));
            Weapons.Add(new Weapon(WeaponID.Feedback));
            Weapons.Add(new Weapon(WeaponID.OpticalFlare));
            Weapons.Add(new Weapon(WeaponID.Maelstrom));
            Weapons.Add(new Weapon(WeaponID.SubterraneanSpines));
            Weapons.Add(new Weapon(WeaponID.GaussRifle0Unused));
            Weapons.Add(new Weapon(WeaponID.WarpBladesNormal));
            Weapons.Add(new Weapon(WeaponID.C10ConcussionRifleSamirDuran));
            Weapons.Add(new Weapon(WeaponID.C10ConcussionRifleInfestedDuran));
            Weapons.Add(new Weapon(WeaponID.DualPhotonBlastersArtanis));
            Weapons.Add(new Weapon(WeaponID.AntimatterMissilesArtanis));
            Weapons.Add(new Weapon(WeaponID.C10ConcussionRifleAlexeiStukov));
            Weapons.Add(new Weapon(WeaponID.GaussRifle1Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle2Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle3Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle4Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle5Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle6Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle7Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle8Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle9Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle10Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle11Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle12Unused));
            Weapons.Add(new Weapon(WeaponID.GaussRifle13Unused));
        }
    }
}
