using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.GameRule.StarCraft.Region
{
    public class FogOfWar
    {
        [Flags]
        public enum Fogs
        {
            Player1 = 1,
            Player2 = 2,
            Player3 = 4,
            Player4 = 8,
            Player5 = 16,
            Player6 = 32,
            Player7 = 64,
            Player8 = 128
        }

        public static Fogs[] _Fogs { get; set; }

        public FogOfWar()
        {
            _Fogs = new Fogs[(int)Base.HorizontalDimension * (int)Base.VerticalDimension];

            MakeDefault();
        }

        void MakeDefault()
        {
            for (int i = 0; i < _Fogs.Length; i++)
            {
                _Fogs[i] = Fogs.Player1 | Fogs.Player2 | Fogs.Player3 | Fogs.Player4 | Fogs.Player5 | Fogs.Player6 | Fogs.Player7 | Fogs.Player8;
            }
        }
    }
}
