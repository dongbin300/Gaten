namespace Gaten.Net.Windows.CHK
{
    public class StarcraftVersion
    {
        public enum _StarcraftVersion
        {
            Starcraft100,
            Starcraft104,
            Revelations,
            Hybrid,
            BroodWar,
            Remastered
        }

        public static _StarcraftVersion Version { get; set; }

        public StarcraftVersion()
        {
            MakeDefault();
        }

        public void MakeDefault()
        {
            Version = _StarcraftVersion.Remastered;
        }
    }
}
