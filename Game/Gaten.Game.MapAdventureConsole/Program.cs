namespace Gaten.Game.MapAdventureConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Character.Initialize();

            GameEngine engine = new GameEngine("engine", 10);
            engine.Start();
        }
    }
}
