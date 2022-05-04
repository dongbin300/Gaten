namespace Gaten.Game.NGDG2.Screen
{
    interface IScreen
    {
        void Show();

        string React(ConsoleKey key);
    }
}
