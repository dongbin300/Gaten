using Gaten.Net.Diagnostics;
using Gaten.Net.IO;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Data.FileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RootPathText.Text = GetLocalPath();
            //RootPathText.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ftest";
            SearchTypeComboBox.Items.Clear();
            _ = SearchTypeComboBox.Items.Add("파일");
            _ = SearchTypeComboBox.Items.Add("문자열");
            SearchTypeComboBox.SelectedIndex = 1;

            NodeManager.Nodes = new List<Node>();
        }

        private void StorageTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is not TreeView treeView)
            {
                return;
            }

            if (treeView.SelectedItem is not TreeViewItem selectedItem)
            {
                return;
            }

            string fullPath = TreeNodeUtil.GetFullPath(selectedItem);
            NodeManager.SelectedNode = NodeManager.Nodes.Find(n => n.FullPath.Equals(fullPath)) ?? new Node();
            PathText.Text = fullPath;
        }

        private void StorageTreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not TreeView treeView)
            {
                return;
            }

            if (treeView.SelectedItem is not TreeViewItem selectedItem)
            {
                return;
            }

            string fullPath = TreeNodeUtil.GetFullPath(selectedItem);
            _ = GProcess.Start(fullPath);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Node> filteredFilePaths = new();
            switch (SearchTypeComboBox.SelectedItem)
            {
                case "파일":
                    filteredFilePaths = Util.SearchFiles(NodeManager.SelectedNode, KeywordText.Text);
                    break;
                case "문자열":
                    filteredFilePaths = Util.SearchStrings(NodeManager.SelectedNode, KeywordText.Text);
                    break;
            }

            FilteredListBox.Items.Clear();
            foreach (Node? filePath in filteredFilePaths)
            {
                _ = FilteredListBox.Items.Add($"{filePath.Name} ({filePath.FullPath})");
            }
        }

        private void FilteredListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = ((string)FilteredListBox.SelectedItem).Split('(')[1].Replace(")", "");

            _ = System.Diagnostics.Process.Start(path);
        }

        private string GetLocalPath()
        {
            return GResource.GetText("fm-dir.ini");
        }

        private void RootPathButton_Click(object sender, RoutedEventArgs e)
        {
            StorageTreeView.Items.Clear();
            Node node = TreeHelper.MakeWindowTree(RootPathText.Text);
            _ = StorageTreeView.Items.Add(node.Item);
        }

        private void RootSelectButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new()
            {
                RootFolder = Environment.SpecialFolder.Desktop
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RootPathText.Text = dialog.SelectedPath;
            }
        }

        private void FilteredListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListBox listBox)
            {
                return;
            }

            if (listBox.SelectedItem.ToString() is not string selectedString)
            {
                return;
            }

            string? fullPath = selectedString.Substring(selectedString.IndexOf('(') + 1, selectedString.Length - selectedString.IndexOf('(') - 2);
            _ = GProcess.Start(fullPath);
        }
    }
}
