using System.Collections.Generic;

namespace Gaten.Data.FileManager
{
    public class NodeManager
    {
        public static List<Node> Nodes { get; set; } = new List<Node>();
        public static Node SelectedNode { get; set; } = new Node();
    }
}
