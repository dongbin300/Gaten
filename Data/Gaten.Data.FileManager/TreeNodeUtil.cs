using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaten.Data.FileManager
{
    public class TreeNodeUtil
    {
        //public static List<Node> CircuitNodes(Node node)
        //{
        //    List<Node> nodes = new();

        //    if (node == null) return null;

        //    nodes.Add(node);

        //    foreach (Node childrenNode in node.Item.Items)
        //    {
        //        nodes.AddRange(CircuitNodes(childrenNode));
        //    }

        //    return nodes;
        //}

        public static string GetFullPath(TreeViewItem node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            string? result = Convert.ToString(node.Header) ?? string.Empty;

            for (TreeViewItem? i = GetParentItem(node); i != null; i = GetParentItem(i))
            {
                result = i.Header + "\\" + result;
            }

            return result;
        }

        private static TreeViewItem GetParentItem(TreeViewItem item)
        {
            for (System.Windows.DependencyObject? i = VisualTreeHelper.GetParent(item); i != null; i = VisualTreeHelper.GetParent(i))
            {
                if (i is TreeViewItem item1)
                {
                    return item1;
                }
            }

            return new TreeViewItem();
        }
    }
}
