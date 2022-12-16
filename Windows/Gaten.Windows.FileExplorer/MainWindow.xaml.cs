using Gaten.Net.Diagnostics;
using Gaten.Windows.FileExplorer.Models;

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Windows.FileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileExplorerModel fileExplorer;

        public MainWindow()
        {
            InitializeComponent();

            fileExplorer = new FileExplorerModel();
            FileListDataGrid.ItemsSource = fileExplorer.Files;
            StatusText.DataContext = fileExplorer;
            CurrentPathChanged();
        }

        /// <summary>
        /// 현재 경로가 바뀌었을 경우
        /// </summary>
        private void CurrentPathChanged()
        {
            var path = fileExplorer.CurrentPath;

            if (path.Length < 1)
            {
                return;
            }

            if (!Directory.Exists(path))
            {
                MessageBox.Show("없는 경로입니다.");
            }

            CurrentPathPanel.Children.Clear();
            var rootButton = new Button
            {
                Content = fileExplorer.CurrentPathBlocks[0].Name,
                Background = new SolidColorBrush(Colors.Transparent),
                Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xF7, 0xF7, 0xF7)),
                BorderThickness = new Thickness(0),
                Style = (Style)FindResource("PathButton")
            };
            CurrentPathPanel.Children.Add(rootButton);
            for (int i = 1; i < fileExplorer.CurrentPathBlocks.Count; i++)
            {
                var block = fileExplorer.CurrentPathBlocks[i];
                var text = new TextBlock
                {
                    Text = ">",
                    Background = new SolidColorBrush(Colors.Transparent),
                    Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x53, 0x53, 0x53)),
                    Padding = new Thickness(3),
                    VerticalAlignment = VerticalAlignment.Center
                };
                CurrentPathPanel.Children.Add(text);
                var button = new Button
                {
                    Content = block.Name,
                    Background = new SolidColorBrush(Colors.Transparent),
                    Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xF7, 0xF7, 0xF7)),
                    BorderThickness = new Thickness(0),
                    Style = (Style)FindResource("PathButton")
                };
                CurrentPathPanel.Children.Add(button);
            }


            fileExplorer.Files.Clear();
            var dirInfo = new DirectoryInfo(path);
            var files = dirInfo.GetFiles();
            var directories = dirInfo.GetDirectories();
            foreach (var file in files)
            {
                fileExplorer.Files.Add(new FileModel(FileType.File, file.Directory.FullName, file.Name));
            }
            foreach (var directory in directories)
            {
                fileExplorer.Files.Add(new FileModel(FileType.Directory, directory.Parent.FullName, directory.Name));
            }
        }

        private void Undo_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Redo_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Top_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void FileListDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FileListDataGrid.SelectedItem == null)
            {
                return;
            }

            var selectedFile = FileListDataGrid.SelectedItem as FileModel;

            if (selectedFile.Type == FileType.Directory)
            {
                fileExplorer.CurrentPath = selectedFile.FullName;
                CurrentPathChanged();
            }
            else
            {
                GProcess.Start(selectedFile.FullName);
            }
        }

        private void FileListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fileExplorer.SelectedFiles.Clear();
            foreach (FileModel file in FileListDataGrid.SelectedItems)
            {
                fileExplorer.SelectedFiles.Add(file);
            }
            StatusText.DataContext = null;
            StatusText.DataContext = fileExplorer;
        }
    }
}
