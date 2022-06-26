using Gaten.Net.Data.Collections;
using Gaten.Net.Windows;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Interop;

namespace Gaten.Windows.RestoreWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double screenWidth = SystemParameters.PrimaryScreenWidth;
        double screenHeight = SystemParameters.PrimaryScreenHeight;
        List<ProcessWindow> processWindows = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var processes = Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(p.MainWindowTitle) && p.Responding);

                processWindows.Clear();
                foreach (var process in processes)
                {
                    var placement = WinAPI.GetWindowPlacement(process.MainWindowHandle);

                    if (placement.showCmd == WinAPI.ShowWindowCommands.Normal && placement.rcNormalPosition.X == 0 && placement.rcNormalPosition.Y == 0 && placement.rcNormalPosition.Width == screenWidth && placement.rcNormalPosition.Height == screenHeight)
                    {
                        continue;
                    }

                    if (new WindowInteropHelper(this).Handle == process.MainWindowHandle)
                    {
                        continue;
                    }

                    processWindows.Add(new ProcessWindow
                    {
                        ProcessName = process.ProcessName,
                        FileName = process.MainModule.FileName,
                        X = placement.rcNormalPosition.X,
                        Y = placement.rcNormalPosition.Y,
                        Width = placement.rcNormalPosition.Width,
                        Height = placement.rcNormalPosition.Height,
                        WindowState = placement.showCmd switch
                        {
                            WinAPI.ShowWindowCommands.Hide => WindowState.Minimized,
                            WinAPI.ShowWindowCommands.Normal => WindowState.Normal,
                            WinAPI.ShowWindowCommands.Minimized => WindowState.Minimized,
                            WinAPI.ShowWindowCommands.Maximized => WindowState.Maximized,
                            _ => WindowState.Normal
                        }
                    });
                }

                var dataSource = new DataSource(processWindows);
                dataSource.SaveCsvFile("data.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists("data.csv"))
                {
                    throw new Exception("저장한 데이터가 없습니다.");
                }

                var dataSource = new DataSource("data.csv");
                foreach (DataRow row in dataSource.table.Rows)
                {
                    var process = Net.Data.Process.Start(row["FileName"].ToString());
                    process.WaitForExit();
                    var handle = process.MainWindowHandle;
                    WinAPI.MoveWindow(handle, int.Parse(row["X"].ToString()), int.Parse(row["Y"].ToString()), int.Parse(row["Width"].ToString()), int.Parse(row["Height"].ToString()), false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
