namespace Gaten.Game.NGDG2.Screen.Interface
{
    internal interface IScreen
    {
        void Show();

        string React(ConsoleKey key);
    }
}
