using System;

namespace Gaten.Stock.MercuryEditor
{
    public class Delegater
    {
        public static Themes CurrentTheme { get; set; } = Themes.Light;
        public static Action ChangeTheme = default!;
        public static Action RefreshFileName = default!;
        public static Func<bool> CheckSave = default!;
        public static Action<string> SetEditorText = default!;
    }
}
