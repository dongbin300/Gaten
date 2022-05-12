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
            SearchTypeComboBox.Items.Add("파일");
            SearchTypeComboBox.Items.Add("문자열");
            SearchTypeComboBox.SelectedIndex = 1;

            NodeManager.Nodes = new List<Node>();
        }

        private void StorageTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = (sender as TreeView).SelectedItem as TreeViewItem;

            if (selectedItem == null)
                return;

            string fullPath = TreeNodeUtil.GetFullPath(selectedItem);

            NodeManager.SelectedNode = NodeManager.Nodes.Find(n => n.FullPath.Equals(fullPath));
            PathText.Text = fullPath;
        }

        private void StorageTreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as TreeView).SelectedItem as TreeViewItem;

            if (selectedItem == null)
                return;

            string fullPath = TreeNodeUtil.GetFullPath(selectedItem);
            Net.Data.Process.Start(fullPath);
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
            foreach (var filePath in filteredFilePaths)
                FilteredListBox.Items.Add($"{filePath.Name} ({filePath.FullPath})");
        }

        private void FilteredListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = ((string)FilteredListBox.SelectedItem).Split('(')[1].Replace(")", "");

            System.Diagnostics.Process.Start(path);
        }

        string GetLocalPath()
        {
            return Net.Data.CommonResource.GetText("fm-dir.ini");
        }

        private void RootPathButton_Click(object sender, RoutedEventArgs e)
        {
            StorageTreeView.Items.Clear();
            Node node = TreeHelper.MakeWindowTree(RootPathText.Text);
            StorageTreeView.Items.Add(node.Item);
        }

        private void RootSelectButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RootPathText.Text = dialog.SelectedPath;
            }
        }

        private void FilteredListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            var selectedString = selectedItem.ToString();
            var fullPath = selectedString.Substring(selectedString.IndexOf('(') + 1, selectedString.Length - selectedString.IndexOf('(') -2);

            Net.Data.Process.Start(fullPath);
        }
    }
}
