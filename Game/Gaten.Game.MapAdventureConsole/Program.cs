using System.Runtime.Versioning;

namespace Gaten.Game.MapAdventureConsole
{
    [SupportedOSPlatform("windows")]
    internal class Program
    {
        private static void Main(string[] args)
        {
            Character.Initialize();

            GameEngine? engine = new("engine", 10);
            engine.Start();
        }
    }
}
