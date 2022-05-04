namespace Gaten.Net.GameRule.StarCraft.PlaySystem
{
    public class TechSet
    {
        public List<Tech> Techs { get; set; }

        public TechSet()
        {
            Techs = new List<Tech>();

            MakeDefault();
        }

        void MakeDefault()
        {
            Techs.Add(new Tech(TechID.StimPacks));
            Techs.Add(new Tech(TechID.Lockdown));
            Techs.Add(new Tech(TechID.EMPShockwave));
            Techs.Add(new Tech(TechID.SpiderMines));
            Techs.Add(new Tech(TechID.ScannerSweep));
            Techs.Add(new Tech(TechID.SiegeMode));
            Techs.Add(new Tech(TechID.DefensiveMatrix));
            Techs.Add(new Tech(TechID.Irradiate));
            Techs.Add(new Tech(TechID.YamatoGun));
            Techs.Add(new Tech(TechID.CloakingField));
            Techs.Add(new Tech(TechID.PersonnelCloaking));
            Techs.Add(new Tech(TechID.Burrowing));
            Techs.Add(new Tech(TechID.Infestation));
            Techs.Add(new Tech(TechID.SpawnBroodling));
            Techs.Add(new Tech(TechID.DarkSwarm));
            Techs.Add(new Tech(TechID.Plague));
            Techs.Add(new Tech(TechID.Consume));
            Techs.Add(new Tech(TechID.Ensnare));
            Techs.Add(new Tech(TechID.Parasite));
            Techs.Add(new Tech(TechID.PsionicStorm));
            Techs.Add(new Tech(TechID.Hallucination));
            Techs.Add(new Tech(TechID.Recall));
            Techs.Add(new Tech(TechID.StasisField));
            Techs.Add(new Tech(TechID.ArchonWarp));
            Techs.Add(new Tech(TechID.Restoration));
            Techs.Add(new Tech(TechID.DisruptionWeb));
            Techs.Add(new Tech(TechID.Unused26));
            Techs.Add(new Tech(TechID.MindControl));
            Techs.Add(new Tech(TechID.DarkArchonMeld));
            Techs.Add(new Tech(TechID.Feedback));
            Techs.Add(new Tech(TechID.OpticalFlare));
            Techs.Add(new Tech(TechID.Maelstorm));
            Techs.Add(new Tech(TechID.LurkerAspect));
            Techs.Add(new Tech(TechID.Unused33));
            Techs.Add(new Tech(TechID.Healing));
            Techs.Add(new Tech(TechID.Unused35));
            Techs.Add(new Tech(TechID.Unused36));
            Techs.Add(new Tech(TechID.Unused37));
            Techs.Add(new Tech(TechID.Unused38));
            Techs.Add(new Tech(TechID.Unused39));
            Techs.Add(new Tech(TechID.Unused40));
            Techs.Add(new Tech(TechID.Unused41));
            Techs.Add(new Tech(TechID.Unused42));
            Techs.Add(new Tech(TechID.Unused43));
        }
    }
}
