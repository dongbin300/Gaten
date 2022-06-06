namespace Gaten.Windows.SmartOpen
{
    internal class Navigator
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Directory { get; set; }

        public Navigator(int index, string name, string directory)
        {
            Index = index;
            Name = name;
            Directory = directory;
        }
    }
}
