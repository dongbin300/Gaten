using Gaten.Stock.MercuryEditor.Editor;
using Gaten.Stock.MercuryEditor.Enums;

using System;
using System.Windows;

namespace Gaten.Stock.MercuryEditor
{
    public enum Themes
    {
        Light,
        Dark
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow = default!;
        SimpleMainWindow simpleMainWindow = default!;
        bool isSimpleMode = false;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MercuryEditorEntire.Init();
            Delegater.ChangeTheme = ChangeTheme;
            Delegater.SetLanguage = SetLanguage;

            if (e.Args.Length > 0)
            {
                if (e.Args[0] == "simple")
                {
                    isSimpleMode = true;
                    simpleMainWindow = new SimpleMainWindow();
                    InitSettings();
                    simpleMainWindow.Show();
                    return;
                }
            }
            mainWindow = new MainWindow();
            InitSettings();
            mainWindow.Show();
        }

        private void InitSettings()
        {
            switch (Settings.Default.Theme)
            {
                case "Light":
                    Delegater.CurrentTheme = Themes.Light;
                    if (isSimpleMode)
                    {
                        simpleMainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryLightHighlighting;
                    }
                    else
                    {
                        mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryLightHighlighting;
                    }
                    Resources.MergedDictionaries.Remove(DarkThemeResource);
                    LightThemeResource = AddResourceDictionary("Resources/Themes/LightTheme.xaml");
                    break;
                case "Dark":
                    Delegater.CurrentTheme = Themes.Dark;
                    if (isSimpleMode)
                    {
                        simpleMainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryDarkHighlighting;
                    }
                    else
                    {
                        mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryDarkHighlighting;
                    }
                    Resources.MergedDictionaries.Remove(LightThemeResource);
                    DarkThemeResource = AddResourceDictionary("Resources/Themes/DarkTheme.xaml");
                    break;
            }

            switch (Settings.Default.Language)
            {
                default:
                case "En":
                    Resources.MergedDictionaries.Remove(KoLanguageResource);
                    Resources.MergedDictionaries.Remove(JaLanguageResource);
                    EnLanguageResource = AddResourceDictionary("Resources/Languages/Language-en.xaml");
                    break;

                case "Ko":
                    Resources.MergedDictionaries.Remove(EnLanguageResource);
                    Resources.MergedDictionaries.Remove(JaLanguageResource);
                    KoLanguageResource = AddResourceDictionary("Resources/Languages/Language-ko.xaml");
                    break;

                case "Ja":
                    Resources.MergedDictionaries.Remove(EnLanguageResource);
                    Resources.MergedDictionaries.Remove(KoLanguageResource);
                    JaLanguageResource = AddResourceDictionary("Resources/Languages/Language-ja.xaml");
                    break;
            }

            if (isSimpleMode)
            {
                simpleMainWindow.textEditor.WordWrap = true;
                simpleMainWindow.textEditor.ShowLineNumbers = true;
            }
            else
            {
                mainWindow.textEditor.WordWrap = mainWindow.TitleBar.SettingsWrapMenuItem.IsChecked = Settings.Default.TextWrap;
                mainWindow.textEditor.ShowLineNumbers = mainWindow.TitleBar.SettingsNumberMenuItem.IsChecked = Settings.Default.LineNumber;
            }
        }

        ResourceDictionary LightThemeResource = new();
        ResourceDictionary DarkThemeResource = new();
        public void ChangeTheme()
        {
            switch (Delegater.CurrentTheme)
            {
                case Themes.Light:
                    Delegater.CurrentTheme = Themes.Dark;
                    if (isSimpleMode)
                    {
                        simpleMainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryDarkHighlighting;
                    }
                    else
                    {
                        mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryDarkHighlighting;
                    }
                    Resources.MergedDictionaries.Remove(LightThemeResource);
                    DarkThemeResource = AddResourceDictionary("Resources/Themes/DarkTheme.xaml");
                    break;
                default:
                case Themes.Dark:
                    Delegater.CurrentTheme = Themes.Light;
                    if (isSimpleMode)
                    {
                        simpleMainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryLightHighlighting;
                    }
                    else
                    {
                        mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryLightHighlighting;
                    }
                    Resources.MergedDictionaries.Remove(DarkThemeResource);
                    LightThemeResource = AddResourceDictionary("Resources/Themes/LightTheme.xaml");
                    break;
            }
        }

        ResourceDictionary EnLanguageResource = new();
        ResourceDictionary KoLanguageResource = new();
        ResourceDictionary JaLanguageResource = new();
        public void SetLanguage(LanguageType type)
        {
            switch (type)
            {
                default:
                case LanguageType.En:
                    Resources.MergedDictionaries.Remove(KoLanguageResource);
                    Resources.MergedDictionaries.Remove(JaLanguageResource);
                    EnLanguageResource = AddResourceDictionary("Resources/Languages/Language-en.xaml");
                    break;

                case LanguageType.Ko:
                    Resources.MergedDictionaries.Remove(EnLanguageResource);
                    Resources.MergedDictionaries.Remove(JaLanguageResource);
                    KoLanguageResource = AddResourceDictionary("Resources/Languages/Language-ko.xaml");
                    break;

                case LanguageType.Ja:
                    Resources.MergedDictionaries.Remove(EnLanguageResource);
                    Resources.MergedDictionaries.Remove(KoLanguageResource);
                    JaLanguageResource = AddResourceDictionary("Resources/Languages/Language-ja.xaml");
                    break;
            }
        }

        ResourceDictionary AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = (ResourceDictionary)LoadComponent(new Uri(source, UriKind.Relative));
            Resources.MergedDictionaries.Add(resourceDictionary);
            return resourceDictionary;
        }
    }
}
