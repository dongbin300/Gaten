using Gaten.Windows.MintChoco3.Resources.Texts;

using Microsoft.Win32;

using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace Gaten.Windows.MintChoco3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // 1. %APPDATA%에 민트초코 메인 폴더가 없으면 생성
            if (!Directory.Exists(PathCollection.MintChocoMainPath))
            {
                Directory.CreateDirectory(PathCollection.MintChocoMainPath);
            }

            // 2. 민트초코 메인 폴더에 설정 파일이 없으면 생성
            if (!File.Exists(PathCollection.MintChocoSettingPath))
            {
                File.Create(PathCollection.MintChocoSettingPath);
            }

            // 3. 시작프로그램 등록
            RegisterStartProgram();

            ContextMenuStrip menu = new();
            //menu.Items.Add("메뉴 열기", null, OpenClick);
            menu.Items.Add("메뉴 편집", null, SettingClick);
            menu.Items.Add("로그 관리", null, LogClick);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("민트초코 종료", null, ExitClick);

            NotifyIcon trayIcon = new();
            trayIcon.Text = "MintChoco 3";
            trayIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Environment.ProcessPath);
            trayIcon.ContextMenuStrip = menu;
            trayIcon.Visible = true;

            MainWindow = new MainWindow();
            MainWindow.Hide();
        }

        //static void OpenClick(object? sender, EventArgs e)
        //{
        //    Selector selector = new Selector();
        //    selector.Show();
        //}

        static void SettingClick(object? sender, EventArgs e)
        {
            MenuSetting menuSetting = new MenuSetting();
            menuSetting.Show();
        }

        static void LogClick(object? sender, EventArgs e)
        {
            LogViewer logViewer = new LogViewer();
            logViewer.Show();
        }

        static void ExitClick(object? sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        static void RegisterStartProgram()
        {
            try
            {
                string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                var key = Registry.LocalMachine.OpenSubKey(runKey);
                if (key == null)
                {
                    return;
                }
                if (key.GetValue("MintChoco3") != null)
                {
                    return;
                }

                key.Close();
                key = Registry.LocalMachine.OpenSubKey(runKey, true);
                if (key == null)
                {
                    return;
                }

                // 시작프로그램 등록명과 exe경로를 레지스트리에 등록 TODO
                key.SetValue("MintChoco3", Environment.ProcessPath);
            }
            catch
            {
            }
        }

        static void UnregisterStartProgram()
        {
            try
            {
                string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                var key = Registry.LocalMachine.OpenSubKey(runKey, true);
                if (key == null)
                {
                    return;
                }

                // 레지스트리값 제거
                key.DeleteValue("MintChoco3");
            }
            catch
            {
            }
        }
    }
}
