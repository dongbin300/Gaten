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
        public string CamelName => char.ToLowerInvariant(Name[0]) + Name[1..];
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

        private string GetAccessorString()
        {
            if (!GetAccessor && !SetAccessor)
            {
                return ";";
            }

            StringBuilder builder = new("");
            if (GetAccessor)
            {
                _ = builder.Append("{ get; ");
            }
            if (SetAccessor)
            {
                _ = builder.Append("set; ");
            }

            return builder.Append("}").ToString();
        }

        private string GetParameterString()
        {
            StringBuilder builder = new(DataType);

            return builder.AppendFormat(" {0}", CamelName).ToString();
        }

        private string GetInitString()
        {
            StringBuilder builder = new(Name);

            return builder.AppendFormat(" = {0};", CamelName).ToString();
        }
    }
}
