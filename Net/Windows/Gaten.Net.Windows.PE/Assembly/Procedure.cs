namespace Gaten.Net.Windows.PE.Assembly
{
    public class Procedure : Site
    {
        public Procedure()
        {
            Name = string.Empty;
            Address = 0;
        }

        public Procedure(string name) : base (name)
        {
            Name = name;
            Address = 0;
        }

        public Procedure(string name, uint address) : base(name, address)
        {
            Name = name;
            Address = address;
        }
    }
}
