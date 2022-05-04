using Gaten.Net.Extension;

namespace Gaten.Net.Windows.PE.Assembly
{
    /// <summary>
    /// BYTE[00405060]<br/>
    /// WORD[00405060]<br/>
    /// DWORD[00405060]<br/>
    /// QWORD[00405060]<br/>
    /// </summary>
    public class PTRC
    {
        public DataType DataType { get; set; }
        public uint Value { get; set; }
        public string HexString => Value.ToHexString();
        public string ReverseHexString => Value.ToHexString(true);

        public PTRC(uint value)
        {
            DataType = DataType.DWORD;
            Value = value;
        }

        public PTRC(DataType dataType, uint value)
        {
            DataType = dataType;
            Value = value;
        }
    }
}
