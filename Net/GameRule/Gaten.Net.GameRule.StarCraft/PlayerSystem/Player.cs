namespace Gaten.Net.GameRule.StarCraft.PlayerSystem
{
    public class Player
    {
        public enum PlayerType
        {
            Inactive = 0,
            ComputerGame = 1,
            OccupiedByHumanPlayer = 2,
            RescuePassive = 3,
            Unused = 4,
            Computer = 5,
            Human = 6,
            Neutral = 7,
            ClosedSlot = 8
        }

        public enum Species
        {
            Zerg = 0,
            Terran = 1,
            Protoss = 2,
            Independent = 3,
            Neutral = 4,
            UserSelectable = 5,
            Random = 6,
            Inactive = 7
        }

        public enum Color
        {
            Red = 0,
            Blue = 1,
            Teal = 2,
            Purple = 3,
            Orange = 4,
            Brown = 5,
            White = 6,
            Yellow = 7,
            Green = 8,
            PaleYellow = 9,
            Tan = 10,
            Azure = 11
        }

        public enum GroupID
        {
            Player1 = 0,
            Player2 = 1,
            Player3 = 2,
            Player4 = 3,
            Player5 = 4,
            Player6 = 5,
            Player7 = 6,
            Player8 = 7,
            Player9 = 8,
            Player10 = 9,
            Player11 = 10,
            Player12 = 11,
            None = 12,
            CurrentPlayer = 13,
            Foes = 14,
            Allies = 15,
            NeutralPlayers = 16,
            AllPlayers = 17,
            Force1 = 18,
            Force2 = 19,
            Force3 = 20,
            Force4 = 21,
            Unused1 = 22,
            Unused2 = 23,
            Unused3 = 24,
            Unused4 = 25,
            NonAlliedVictoryPlayers = 26
        }

        public PlayerType[] StareditTypes { get; set; }
        public PlayerType[] StarcraftTypes { get; set; }
        public Species[] Races { get; set; }
        public Color[] Colors { get; set; }
        public byte[] ForceNumbers { get; set; }

        public Player()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            StareditTypes = new PlayerType[12]
            {
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Human,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive
            };

            StarcraftTypes = new PlayerType[12]
            {
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive,
                PlayerType.Inactive
            };

            Races = new Species[12]
            {
                Species.UserSelectable,
                Species.UserSelectable,
                Species.UserSelectable,
                Species.UserSelectable,
                Species.UserSelectable,
                Species.UserSelectable,
                Species.UserSelectable,
                Species.UserSelectable,
                Species.Inactive,
                Species.Inactive,
                Species.Inactive,
                Species.Inactive,
            };

            Colors = new Color[8]
            {
                 Color.Red,
                 Color.Blue,
                 Color.Teal,
                 Color.Purple,
                 Color.Orange,
                 Color.Brown,
                 Color.White,
                 Color.Yellow,
            };

            ForceNumbers = new byte[8]
            {
                0, 0, 0, 0, 0, 0, 0, 0
            };
        }
    }
}
