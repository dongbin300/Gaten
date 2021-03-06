using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Gaten.Data.FileManager
{
    public class TreeHelper
    {
        public static Node MakeWindowTree(string rootPath)
        {
            TreeViewItem rootItem = new TreeViewItem() { Header = rootPath };
            Node root = new Node(
                NodeType.Directory,
                rootItem,
                rootPath
                );

            root = AddChildrenNodes(root, "");

            NodeManager.Nodes.Add(root);

            return root;
        }

        public static Node AddChildrenNodes(Node node, string path)
        {
            path = Path.Combine(path, node.Name);

            node = AddFileNodes(node, path);
            node = AddDirectoryNodes(node, path);

            return node;
        }

        public static Node AddFileNodes(Node node, string path)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            try
            {
                fileInfos = new DirectoryInfo(path).GetFiles().ToList();
            }
            catch
            {

            }

            if (fileInfos == null)
            {
                return null;
            }

            foreach (FileInfo info in fileInfos)
            {
                if (Util.SupportsExtension(info.Name))
                {
                    TreeViewItem childrenItem = new TreeViewItem() { Header = info.Name };

                    Node childrenNode = new Node(
                         NodeType.File,
                         childrenItem,
                         Path.Combine(path, info.Name)
                        );

                    node.Item.Items.Add(childrenItem);
                    NodeManager.Nodes.Add(childrenNode);
                }
            }

            return node;
        }

        public static Node AddDirectoryNodes(Node node, string path)
        {
            List<DirectoryInfo> directoryInfos = new List<DirectoryInfo>();
            try
            {
                directoryInfos = new DirectoryInfo(path).GetDirectories().ToList();
            }
            catch
            {

            }

            if (directoryInfos == null) return null;

            foreach (DirectoryInfo info in directoryInfos)
            {
                TreeViewItem childrenItem = new TreeViewItem() { Header = info.Name };

                Node childrenNode = new Node(
                         NodeType.Directory,
                         childrenItem,
                         Path.Combine(path, info.Name)
                        );

                childrenNode = AddChildrenNodes(childrenNode, path);

                if (childrenNode == null) continue;

                node.Item.Items.Add(childrenItem);

                NodeManager.Nodes.Add(childrenNode);
            }

            return node;
        }
    }
}
