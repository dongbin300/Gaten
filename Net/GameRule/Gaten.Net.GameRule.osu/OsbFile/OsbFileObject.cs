using Gaten.Net.GameRule.osu.OsbFile.Headers;

namespace Gaten.Net.GameRule.osu.OsbFile
{
    public class OsbFileObject
    {
        public string FileName { get; set; } = "";
        public List<SBAction> SBActions { get; set; } = new();

        public void WriteToOsbFile()
        {
            List<string> contents = new();
            contents.Add("[Events]");
            contents.Add("//Background and Video events");
            contents.Add("//Storyboard Layer 0 (Background)");
            contents.Add("//Storyboard Layer 1 (Fail)");
            contents.Add("//Storyboard Layer 2 (Pass)");
            contents.Add("//Storyboard Layer 3 (Foreground)");
            foreach (var action in SBActions)
            {
                contents.Add($"Sprite,Foreground,Centre,\"{action.Sprite.Path}\",40,30");
                contents.Add($" M,0,{action.StartTiming},{action.EndTiming},{action.StartPoint.X},{action.StartPoint.Y},{action.EndPoint.X},{action.EndPoint.Y}");
            }
            contents.Add("//Storyboard Layer 4 (Overlay)");
            contents.Add("//Storyboard Sound Samples");

            Data.IO.File.WriteByArray(FileName, contents);
        }
    }
}
