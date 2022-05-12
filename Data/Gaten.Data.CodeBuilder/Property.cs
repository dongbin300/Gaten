using System.Text;

namespace Gaten.Data.CodeBuilder
{
    public class Property
    {
        public string AccessModifier { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public bool GetAccessor { get; set; }
        public bool SetAccessor { get; set; }
        public string CamelName => char.ToLowerInvariant(Name[0]) + Name.Substring(1);
        public string AccessorString => GetAccessorString();
        public string ParameterString => GetParameterString();
        public string InitString => GetInitString();

        public Property(string accessModifier, string dataType, string name, bool getAccessor, bool setAccessor)
        {
            AccessModifier = accessModifier;
            DataType = dataType;
            Name = name;
            GetAccessor = getAccessor;
            SetAccessor = setAccessor;
        }

        string GetAccessorString()
        {
            if (!GetAccessor && !SetAccessor)
            {
                return ";";
            }

            StringBuilder builder = new StringBuilder("");
            if (GetAccessor)
            {
                builder.Append("{ get; ");
            }
            if (SetAccessor)
            {
                builder.Append("set; ");
            }

            return builder.Append("}").ToString();
        }

        string GetParameterString()
        {
            StringBuilder builder = new StringBuilder(DataType);

            return builder.AppendFormat(" {0}", CamelName).ToString();
        }

        string GetInitString()
        {
            StringBuilder builder = new StringBuilder(Name);

            return builder.AppendFormat(" = {0};", CamelName).ToString();
        }
    }
}
