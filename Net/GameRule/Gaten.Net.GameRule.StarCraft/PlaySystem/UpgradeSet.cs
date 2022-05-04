namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public class UpgradeSet
    {
        public List<Upgrade> Upgrades { get; set; }

        public UpgradeSet()
        {
            Upgrades = new List<Upgrade>();

            MakeDefault();
        }

        void MakeDefault()
        {
            Upgrades.Add(new Upgrade(UpgradeID.TerranInfantryArmor));
            Upgrades.Add(new Upgrade(UpgradeID.TerranVehiclePlating));
            Upgrades.Add(new Upgrade(UpgradeID.TerranShipPlating));
            Upgrades.Add(new Upgrade(UpgradeID.ZergCarapace));
            Upgrades.Add(new Upgrade(UpgradeID.ZergFlyerCaparace));
            Upgrades.Add(new Upgrade(UpgradeID.ProtossArmor));
            Upgrades.Add(new Upgrade(UpgradeID.ProtossPlating));
            Upgrades.Add(new Upgrade(UpgradeID.TerranInfantryWeapons));
            Upgrades.Add(new Upgrade(UpgradeID.TerranVehicleWeapons));
            Upgrades.Add(new Upgrade(UpgradeID.TerranShipWeapons));
            Upgrades.Add(new Upgrade(UpgradeID.ZergMeleeAttacks));
            Upgrades.Add(new Upgrade(UpgradeID.ZergMissileAttacks));
            Upgrades.Add(new Upgrade(UpgradeID.ZergFlyerAttacks));
            Upgrades.Add(new Upgrade(UpgradeID.ProtossGroundWeapons));
            Upgrades.Add(new Upgrade(UpgradeID.ProtossAirWeapons));
            Upgrades.Add(new Upgrade(UpgradeID.ProtossPlasmaShields));
            Upgrades.Add(new Upgrade(UpgradeID.U238Shells));
            Upgrades.Add(new Upgrade(UpgradeID.IonThrusters));
            Upgrades.Add(new Upgrade(UpgradeID.BurstLasers));
            Upgrades.Add(new Upgrade(UpgradeID.TitanReactor));
            Upgrades.Add(new Upgrade(UpgradeID.OcularImplants));
            Upgrades.Add(new Upgrade(UpgradeID.MoebiusReactor));
            Upgrades.Add(new Upgrade(UpgradeID.ApolloReactor));
            Upgrades.Add(new Upgrade(UpgradeID.ColossusReactor));
            Upgrades.Add(new Upgrade(UpgradeID.VentralSacs));
            Upgrades.Add(new Upgrade(UpgradeID.Antennae));
            Upgrades.Add(new Upgrade(UpgradeID.PneumatizedCarapace));
            Upgrades.Add(new Upgrade(UpgradeID.MetabolicBoost));
            Upgrades.Add(new Upgrade(UpgradeID.AdrenalGlands));
            Upgrades.Add(new Upgrade(UpgradeID.MuscularAugments));
            Upgrades.Add(new Upgrade(UpgradeID.GroovedSpines));
            Upgrades.Add(new Upgrade(UpgradeID.GameteMeiosis));
            Upgrades.Add(new Upgrade(UpgradeID.MetasynapticNode));
            Upgrades.Add(new Upgrade(UpgradeID.SingularityCharge));
            Upgrades.Add(new Upgrade(UpgradeID.LegEnhancements));
            Upgrades.Add(new Upgrade(UpgradeID.ScarabDamage));
            Upgrades.Add(new Upgrade(UpgradeID.ReaverCapacity));
            Upgrades.Add(new Upgrade(UpgradeID.GraviticDrive));
            Upgrades.Add(new Upgrade(UpgradeID.SensorArray));
            Upgrades.Add(new Upgrade(UpgradeID.GraviticBoosters));
            Upgrades.Add(new Upgrade(UpgradeID.KhaydarinAmulet));
            Upgrades.Add(new Upgrade(UpgradeID.ApialSensors));
            Upgrades.Add(new Upgrade(UpgradeID.GraviticThrusters));
            Upgrades.Add(new Upgrade(UpgradeID.CarrierCapacity));
            Upgrades.Add(new Upgrade(UpgradeID.KhaydarinCore));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade45));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade46));
            Upgrades.Add(new Upgrade(UpgradeID.ArgusJewel));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade48));
            Upgrades.Add(new Upgrade(UpgradeID.ArgusTalisman));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade50));
            Upgrades.Add(new Upgrade(UpgradeID.CaduceusReactor));
            Upgrades.Add(new Upgrade(UpgradeID.ChitinousPlating));
            Upgrades.Add(new Upgrade(UpgradeID.AnabolicSynthesis));
            Upgrades.Add(new Upgrade(UpgradeID.CharonBooster));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade55));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade56));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade57));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade58));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade59));
            Upgrades.Add(new Upgrade(UpgradeID.UnknownUpgrade60));
        }
    }
}
