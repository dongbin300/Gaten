namespace Gaten.Net.Windows.PE.Assembly
{
    public class Site
    {
        public string Name { get; set; }
        public uint Address { get; set; }

        public Site()
        {
            Name = string.Empty;
            Address = 0;
        }

        public Site(string name)
        {
            Name = name;
            Address = 0;
        }

        public Site(string name, uint address)
        {
            Name = name;
            Address = address;
        }
    }
}
