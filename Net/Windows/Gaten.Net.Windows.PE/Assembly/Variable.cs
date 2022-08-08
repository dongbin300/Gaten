using Gaten.Net.Extensions;

namespace Gaten.Net.Windows.PE.Assembly
{
    public class Variable
    {
        public DataType DataType { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public uint Address { get; set; }
        public string HexString => Value.ToHexString();
        public string ReverseHexString => Value.ToHexString(true);

        public Variable(DataType dataType, string name, object value, uint address)
        {
            DataType = dataType;
            Name = name;
            Value = value;
            Address = address;
        }
    }
}
