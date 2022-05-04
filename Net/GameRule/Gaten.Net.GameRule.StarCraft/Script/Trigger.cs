namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class Trigger
    {
        public enum Condition
        {
            NoCondition = 0,
            CountdownTimer = 1,
            Command = 2,
            Bring = 3,
            Accumulate = 4,
            Kill = 5,
            CommandTheMost = 6,
            CommandsTheMostAt = 7,
            MostKills = 8,
            HighestScore = 9,
            MostResources = 10,
            Switch = 11,
            ElapsedTime = 12,
            DataIsAMissionBriefing = 13,
            Opponents = 14,
            Deaths = 15,
            CommandTheLeast = 16,
            CommandTheLeastAt = 17,
            LeastKills = 18,
            LowestScore = 19,
            LeastResources = 20,
            Score = 21,
            Always = 22,
            Never = 23
        }

        public enum Action
        {
            NoAction = 0,
            Victory = 1,
            Defeat = 2,
            PreserveTrigger = 3,
            Wait = 4,
            PauseGame = 5,
            UnpauseGame = 6,
            Transmission = 7,
            PlayWAV = 8,
            DisplayTextMessage = 9,
            CenterView = 10,
            CreateUnitwithProperties = 11,
            SetMissionObjectives = 12,
            SetSwitch = 13,
            SetCountdownTimer = 14,
            RunAIScript = 15,
            RunAIScriptAtLocation = 16,
            LeaderBoardControl = 17,
            LeaderBoardControlAtLocation = 18,
            LeaderBoardResources = 19,
            LeaderBoardKills = 20,
            LeaderBoardPoints = 21,
            KillUnit = 22,
            KillUnitAtLocation = 23,
            RemoveUnit = 24,
            RemoveUnitAtLocation = 25,
            SetResources = 26,
            SetScore = 27,
            MinimapPing = 28,
            TalkingPortrait = 29,
            MuteUnitSpeech = 30,
            UnmuteUnitSpeech = 31,
            LeaderboardComputerPlayers = 32,
            LeaderboardGoalControl = 33,
            LeaderboardGoalControlAtLocation = 34,
            LeaderboardGoalResources = 35,
            LeaderboardGoalKills = 36,
            LeaderboardGoalPoints = 37,
            MoveLocation = 38,
            MoveUnit = 39,
            Leaderboard = 40,
            SetNextScenario = 41,
            SetDoodadState = 42,
            SetInvincibility = 43,
            CreateUnit = 44,
            SetDeaths = 45,
            Order = 46,
            Comment = 47,
            GiveUnitstoPlayer = 48,
            ModifyUnitHitPoints = 49,
            ModifyUnitEnergy = 50,
            ModifyUnitShieldPoints = 51,
            ModifyUnitResourceAmount = 52,
            ModifyUnitHangerCount = 53,
            PauseTimer = 54,
            UnpauseTimer = 55,
            Draw = 56,
            SetAllianceStatus = 57,
            DisableDebugMode = 58,
            EnableDebugMode = 59
        }

        public enum NumericComparison
        {
            AtLeast = 0,
            AtMost = 1,
            Exactly = 10
        }

        public enum ScoreType
        {
            Total = 0,
            Units = 1,
            Buildings = 2,
            UnitsAndBuildings = 3,
            Kills = 4,
            Razings = 5,
            KillsAndRazings = 6,
            Custom = 7
        }

        public enum ResourceType
        {
            Ore = 0,
            Gas = 1,
            OreAndGas = 2
        }

        public enum AllianceStatus
        {
            Enemy = 0,
            Ally = 1,
            AlliedVictory = 2
        }

        public enum UnitOrder
        {
            Move = 0,
            Patrol = 1,
            Attack = 2
        }

        public enum ActionState
        {
            SetSwitch = 4,
            ClearSwitch = 5,
            ToggleSwitch = 6,
            RandomizeSwitch = 11
        }

        public enum NumberModifier
        {
            SetTo = 7,
            Add = 8,
            Subtract = 9
        }

        public enum CompleteModifier
        {
            ConditionGreaterThanOrEqualTo = 0,
            ConditionLessThanOrEqualTo = 1,
            ConditionIsTrue = 2,
            ConditionIsFalse = 3,
            ActionSetToTrue = 4,
            ActionSetToFalse = 5,
            ActionToggle = 6,
            ActionSetTo = 7,
            ActionAdd = 8,
            ActionSubtract = 9,
            ConditionExactly = 10,
            ActionRandomize = 11
        }

        // Conditions (20 * 16 = 320)
        public uint ConditionLocationNumber { get; set; }
        public uint ConditionGroupID { get; set; }
        public uint QualifiedNumber { get; set; }
        public PlaySystem.UnitID ConditionUnitID { get; set; }
        public NumericComparison _NumericComparison { get; set; }
        public Condition _Condition { get; set; }
        public ResourceType _ResourceType { get; set; }

        // Actions (32 * 64 = 2048)

        // Player Execution (32)

        
    }
}
