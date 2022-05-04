namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class MissionBriefing
    {
        public enum Action
        {
            NoAction = 0,
            Wait = 1,
            PlayWAV = 2,
            TextMessage = 3,
            MissionObjectives = 4,
            ShowPortrait = 5,
            HidePortrait = 6,
            DisplaySpeakingPortrait = 7,
            Transmission = 8,
            SkipTutorialEnabled = 9
        }
    }
}
