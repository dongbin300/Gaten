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
                throw new ArgumentNullException();
            }

            var result = Convert.ToString(node.Header);

            for (var i = GetParentItem(node); i != null; i = GetParentItem(i))
            {
                result = i.Header + "\\" + result;
            }

            return result;
        }

        static TreeViewItem GetParentItem(TreeViewItem item)
        {
            for (var i = VisualTreeHelper.GetParent(item); i != null; i = VisualTreeHelper.GetParent(i))
            {
                if (i is TreeViewItem item1)
                {
                    return item1;
                }
            }

            return null;
        }
    }
}
