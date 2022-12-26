using Gaten.Net.IO;

using MySqlX.XDevAPI.Common;

using Renci.SshNet;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

namespace Gaten.Web.Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string directoryCommand = "";
        SshClient client;

        public MainWindow()
        {
            InitializeComponent();

            var data = GResource.GetTextLines("nas_ssh.txt");
            client = new SshClient(data[0], int.Parse(data[1]), data[2], data[3]);
            client.Connect();
        }

        private void Run(string command)
        {
            try
            {
                var result = Process.Start("Resources/MobaXterm_Personal_22.3.exe", $"-exec {command}");
                //var sshCommand = client.RunCommand(command);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string RunCommand(string input)
        {
            var command = client.RunCommand(input);
            var result = !string.IsNullOrEmpty(command.Error) ? "[Error] " + command.Error + Environment.NewLine + command.Result : command.Result;

            return result;
        }

        public string FastRun(string input)
        {
            if (input.StartsWith("cd "))
            {
                directoryCommand = input + " && ";
            }

            var result = RunCommand(directoryCommand + input);
            LogTextBox.AppendText(Environment.NewLine + "> " + input + Environment.NewLine);

            if (!string.IsNullOrEmpty(result))
            {
                LogTextBox.AppendText(result);
                LogTextBox.Focus();
                LogTextBox.CaretIndex = LogTextBox.Text.Length;
            }

            return result;
        }

        private void ContainerRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            MobaXtermCommander.Init();
            MobaXtermCommander.Run("docker ps");
            FastRun("docker build -t trn /volume1/docker/tarinance/");
        }
    }
}
