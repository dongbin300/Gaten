using Gaten.Stock.MercuryEditor.Editor;

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

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MercuryEditorEntire.Init();
            Delegater.ChangeTheme = ChangeTheme;

            mainWindow = new MainWindow();
            InitTheme();
            mainWindow.Show();
        }

        private void InitTheme()
        {
            switch (Settings.Default.Theme)
            {
                case "Light":
                    Delegater.CurrentTheme = Themes.Light;
                    mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryLightHighlighting;
                    AddResourceDictionary("Resources/Themes/LightTheme.xaml");
                    break;
                case "Dark":
                    Delegater.CurrentTheme = Themes.Dark;
                    mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryDarkHighlighting;
                    AddResourceDictionary("Resources/Themes/DarkTheme.xaml");
                    break;
            }
        }

        public void ChangeTheme()
        {
            switch (Delegater.CurrentTheme)
            {
                case Themes.Light:
                    Delegater.CurrentTheme = Themes.Dark;
                    mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryDarkHighlighting;
                    Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/Themes/DarkTheme.xaml");
                    break;
                default:
                case Themes.Dark:
                    Delegater.CurrentTheme = Themes.Light;
                    mainWindow.textEditor.SyntaxHighlighting = MercuryEditorEntire.MercuryLightHighlighting;
                    Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/Themes/LightTheme.xaml");
                    break;
            }
        }

        void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = (ResourceDictionary)LoadComponent(new Uri(source, UriKind.Relative));
            Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
