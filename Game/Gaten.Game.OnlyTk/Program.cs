using osuTK;
using osuTK.Graphics;

namespace Gaten.Game.OnlyTk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var box = new Box2(0, 200, 10, 210);

            using (var window = new GameWindow(320, 240, GraphicsMode.Default, "ONLY TK", GameWindowFlags.Default))
            {
                window.RenderFrame += (sender, e) =>
                {
                    
                };

                window.UpdateFrame += (sender, e) =>
                {

                };

                window.Run(60, 60);
            }
        }
    }
}