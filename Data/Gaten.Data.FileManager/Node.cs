using System.Windows.Controls;

namespace Gaten.Data.FileManager
{
    public class Node
    {
        public NodeType NodeType { get; set; }
        public TreeViewItem Item { get; set; }
        public string Name => Item.Header.ToString();
        public string FullPath { get; set; }

        public Node()
        {
            Item = new TreeViewItem();
        }

        public Node(NodeType nodeType, TreeViewItem item, string fullPath)
        {
            NodeType = nodeType;
            Item = item;
            FullPath = fullPath;
        }
    }

    public enum NodeType
    {
        Directory,
        File
    }
}
