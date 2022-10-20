using Gaten.Net.Diagnostics;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// FirstSettingsWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FirstSettingsWindow : Window
    {
        public FirstSettingsWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(FirstSettingsWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(FirstSettingsWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void ProjectPathButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProjectPathText.Text = MintPandaPathManager.ProjectPath = dialog.SelectedPath;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
