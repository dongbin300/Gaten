using Gaten.Net.Data.Diagnostics;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Windows.SmartOpen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Setting.LoadSettingsData();
            Setting.LoadDirectoryData();

            RefreshControl();
        }

        private void RefreshControl()
        {
            NavigatorGrid.ColumnDefinitions.Clear();
            NavigatorGrid.RowDefinitions.Clear();
            NavigatorGrid.Children.Clear();

            Width = Height = (Setting.Size + Setting.Padding) * Setting.Count;

            for (int i = 0; i < Setting.Count; i++)
            {
                NavigatorGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(Setting.Count, GridUnitType.Star)
                });

                NavigatorGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(Setting.Count, GridUnitType.Star)
                });
            }

            for (int i = 0; i < Setting.Count; i++)
            {
                for (int j = 0; j < Setting.Count; j++)
                {
                    var navigator = Setting.Navigators.Find(n => n.Index.Equals(i * Setting.Count + j));

                    Button button = new Button();
                    button.Name = "Button" + (i * Setting.Count + j);
                    button.Content = navigator == null ? "" : navigator.Name;
                    button.Width = Setting.Size;
                    button.Height = Setting.Size;
                    button.Padding = new Thickness(Setting.Padding);
                    button.SetValue(Grid.RowProperty, i);
                    button.SetValue(Grid.ColumnProperty, j);
                    button.Foreground = Setting.MainForegroundColor;
                    button.Background = Setting.MainBackgroundColor;
                    button.HorizontalContentAlignment = HorizontalAlignment.Center;
                    button.VerticalContentAlignment = VerticalAlignment.Center;
                    button.TabIndex = i * Setting.Count + j;
                    button.Click += Button_Click;
                    button.MouseRightButtonDown += Button_MouseRightButtonDown;

                    NavigatorGrid.Children.Add(button);
                }
            }


            //settingsButton = new Button();
            //settingsButton.Text = "설정";
            //settingsButton.Size = new Size(80, 30);
            //settingsButton.Location = new Point(margin + count * (openButton[0].Width + padding) + padding, margin);
            //settingsButton.ForeColor = mainForegroundColor;
            //settingsButton.TabStop = false;
            //settingsButton.FlatStyle = FlatStyle.Flat;
            //settingsButton.FlatAppearance.BorderColor = mainForegroundColor;
            //settingsButton.FlatAppearance.MouseOverBackColor = mouseOverColor;
            //settingsButton.Click += settingsButton_Click;

            //Controls.Add(settingsButton);

            //exitButton = new Button();
            //exitButton.Text = "종료";
            //exitButton.Size = new Size(80, 30);
            //exitButton.Location = new Point(margin + count * (openButton[0].Width + padding) + padding, margin + 35);
            //exitButton.ForeColor = mainForegroundColor;
            //exitButton.TabStop = false;
            //exitButton.FlatStyle = FlatStyle.Flat;
            //exitButton.FlatAppearance.BorderColor = mainForegroundColor;
            //exitButton.FlatAppearance.MouseOverBackColor = mouseOverColor;
            //exitButton.Click += exitButton_Click;

            //Controls.Add(exitButton);

        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            int index = int.Parse(button.Name.Replace("Button", ""));
            Setting.SelectedNavigatorsIndex = index;

            DirectorySetting directorySetting = new DirectorySetting();
            directorySetting.WindowStartupLocation = WindowStartupLocation.Manual;
            directorySetting.Left = PointToScreen(e.GetPosition(this)).X;
            directorySetting.Top = PointToScreen(e.GetPosition(this)).Y;

            if (directorySetting.ShowDialog().Value)
            {
                Setting.SaveDirectoryData();
                RefreshControl();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = int.Parse(button.Name.Replace("Button", ""));
            Setting.SelectedNavigatorsIndex = index;

            var navigator = Setting.Navigators.Find(n => n.Index.Equals(index));
            if (navigator == null || string.IsNullOrEmpty(navigator.Directory))
            {
                return;
            }

            GProcess.Start(navigator.Directory);
        }
    }
}
