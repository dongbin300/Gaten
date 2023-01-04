using Gaten.Net.IO;

using Renci.SshNet;

using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace Gaten.Web.Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string directoryCommand = "";
        SshClient client;
        private string password = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            var data = GResource.GetTextLines("nas_ssh.txt");
            client = new SshClient(data[0], int.Parse(data[1]), data[2], data[3]);
            client.Connect();

            password = data[3];

            Log($"{data[2]}@{data[0]} Connected.");
        }

        void Log(string message)
        {
            LogTextBox.AppendText(message + Environment.NewLine);
        }

        [GeneratedRegex("CONTAINER")]
        private static partial Regex DockerContainerRegex();
        [GeneratedRegex("[0-9a-fA-F]{64}")]
        private static partial Regex DockerRunExpectRegex();
        private void ContainerRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var stream = client.CreateShellStream("foo", 100, 50, 400, 300, 256);
                stream.WriteLine("sudo -i");
                Thread.Sleep(100);
                stream.Expect("Password:");
                stream.WriteLine(password);
                Thread.Sleep(100);
                stream.WriteLine("docker ps -a");
                Thread.Sleep(100);
                var expect = stream.Expect(DockerContainerRegex());
                var data = expect.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                var i = Array.FindIndex(data, x => x.Equals("trn"));
                var containerId = data[i - 1];
                stream.WriteLine($"docker rm -f {containerId}");
                Thread.Sleep(2000);
                stream.WriteLine($"docker build -t trn /volume1/docker/tarinance/");
                Thread.Sleep(2000);
                stream.WriteLine($"docker run -v /volume1/docker/tarinance:/app -e ASPNETCORE_ENVIRONMENT=Development -d --name trn1 trn");
                Thread.Sleep(3000);
                stream.Expect(DockerRunExpectRegex());
                Log("새로고침 성공");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                throw;
            }
        }
    }
}
