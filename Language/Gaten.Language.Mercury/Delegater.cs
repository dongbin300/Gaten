using System;

namespace Gaten.Language.Mercury
{
    public class Delegater
    {
        public static Themes CurrentTheme { get; set; } = Themes.Light;
        public static Action ChangeTheme;
    }
}
