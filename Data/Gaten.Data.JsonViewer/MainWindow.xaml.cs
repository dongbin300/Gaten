using Newtonsoft.Json.Linq;

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.Data.JsonViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object arg)
        {
            InitializeComponent();

            var jsonString = arg.ToString()?
                .Replace('醵', ' ')
                .Replace('蹃', '\"')
                .Replace('略', '\'')
                ?? string.Empty;

            var rootNode = DisplayTreeView(JToken.Parse(jsonString));
            ExpandAll(rootNode, true);
            SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void ExpandAll(TreeViewItem treeView, bool isExpanded)
        {
            treeView.IsExpanded = isExpanded;
            foreach (TreeViewItem item in treeView.Items)
            {
                item.IsExpanded = isExpanded;
                foreach (TreeViewItem _item in item.Items)
                {
                    ExpandAll(_item, isExpanded);
                }
            }
        }

        private TreeViewItem DisplayTreeView(JToken root)
        {
            TreeViewItem rootNode = new TreeViewItem();
            treeView.BeginInit();
            try
            {
                treeView.Items.Clear();
                rootNode = (TreeViewItem)treeView.Items[treeView.Items.Add(new TreeViewItem { Header = $"JSON_{DateTime.Now:yyyy-MM-dd_HH:mm:ss}" })];

                AddNode(root, rootNode);
                return rootNode;
            }
            finally
            {
                treeView.EndInit();
            }
        }

        private string AddNode(JToken token, TreeViewItem inTreeViewItem)
        {
            if (token == null)
            {
                return "";
            }

            if (token is JObject)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    var newItem = new TreeViewItem { Header = property.Name };
                    var index = inTreeViewItem.Items.Add(newItem);
                    var childNode = (TreeViewItem)inTreeViewItem.Items[index];

                    if (property.Value is JValue)
                    {
                        (inTreeViewItem.Items[index] as TreeViewItem).Header += " : " + property.Value;
                    }
                    else
                    {
                        AddNode(property.Value, childNode);
                    }
                }

                return "";
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    var childNode = (TreeViewItem)inTreeViewItem.Items[inTreeViewItem.Items.Add(new TreeViewItem { Header = $"{inTreeViewItem.Header}[{i}]" })];
                    childNode.Tag = array[i];
                    AddNode(array[i], childNode);
                }

                return "";
            }
            else
            {
                Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
                return "";
            }
        }
    }
}
