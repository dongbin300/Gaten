using System;

namespace Gaten.Stock.MercuryEditor
{
    public class Delegater
    {
        public static Themes CurrentTheme { get; set; } = Themes.Light;
        public static Action ChangeTheme;
    }
}
