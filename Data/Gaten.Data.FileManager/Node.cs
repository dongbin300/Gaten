using System.Windows.Controls;

namespace Gaten.Data.FileManager
{
    public class Node
    {
        public NodeType NodeType { get; set; } = NodeType.None;
        public TreeViewItem Item { get; set; } = new TreeViewItem();
        public string Name => Item.Header.ToString() ?? string.Empty;
        public string FullPath { get; set; } = string.Empty;

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
        None,
        Directory,
        File
    }
}
