using Gaten.Stock.MercuryEditor.Enums;

using System;
using System.Linq;
using System.Windows;

namespace Gaten.Stock.MercuryEditor
{
    public class Delegater
    {
        public static Themes CurrentTheme { get; set; } = Themes.Light;
        public static LanguageType CurrentLanguage { get; set; } = LanguageType.En;
        public static ResourceDictionary CurrentLanguageDictionary => Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x.Contains("LanguageResourceDictionary")) ?? default!;

        public static Action ChangeTheme = default!;
        public static Action<LanguageType> SetLanguage = default!;
        public static Action RefreshFileName = default!;
        public static Func<bool> CheckSave = default!;
        public static Action<string> SetEditorText = default!;
        public static Action SetFullScreen = default!;
        public static Action<string?> SetEditorStatusText = default!;
    }
}
