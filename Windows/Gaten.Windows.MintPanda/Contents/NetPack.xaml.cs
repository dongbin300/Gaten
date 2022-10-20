using Gaten.Net.Diagnostics;
using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.IO.Compression;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// NetPack.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NetPack : Window
    {
        List<ProjectModel> projects = new();

        public NetPack()
        {
            try
            {
                InitializeComponent();

                Init();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(NetPack), MethodBase.GetCurrentMethod()?.Name, ex);
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
                GLogger.Log(nameof(NetPack), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public void Init()
        {
            try
            {
                var files = new DirectoryInfo(MintPandaPathManager.ProjectPath).GetFiles("*.csproj", SearchOption.AllDirectories);
                projects.Clear();
                foreach (var file in files)
                {
                    var project = new ProjectModel(file.FullName);
                    projects.Add(project);
                }

                RefreshList(projects);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(NetPack), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RefreshList(List<ProjectModel> _projects)
        {
            ProjectListBox.Items.Clear();
            foreach (var project in _projects)
            {
                ProjectListBox.Items.Add(project);
            }
        }

        private void ProjectListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Release using PowerShell
                var projectFullName = ProjectListBox.SelectedValue.ToString();
                string projectDirectory = projectFullName?.GetDirectory() ?? string.Empty;
                var result = PowerShellUtil.Run(@$"dotnet publish {projectFullName} -c Release");
                var outputPath = result.Split("->")[^1].Trim();
                ResultTextBox.Text = result;

                // Collect released files
                var files = Directory.GetFiles(outputPath, string.Empty, SearchOption.AllDirectories);

                // Zipping
                var zipPath = GPath.Desktop.Down($"{projectFullName?.GetOnlyFileName()}_{DateTime.Now.ToSimpleFileName()}.zip");
                using var fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.ReadWrite);
                using var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create);
                foreach (string file in files)
                {
                    string fileName = file.GetFileName();
                    if (fileName.EndsWith(".deps.json") || fileName.EndsWith(".pdb") || fileName.EndsWith(".dll.config"))
                    {
                        continue;
                    }
                    zipArchive.CreateEntryFromFile(file, fileName);
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(NetPack), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                if (SearchTextBox.Text.Length > 0)
                {
                    var filteredProjects = projects.FindAll(x => x.Name.ToLower().Contains(SearchTextBox.Text.ToLower()));
                    RefreshList(filteredProjects);
                }
                else
                {
                    RefreshList(projects);
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(NetPack), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }

    public class ProjectModel
    {
        public string Name => Path.GetLowestDirectory();
        public string Path { get; set; }

        public ProjectModel(string path)
        {
            Path = path;
        }
    }
}
