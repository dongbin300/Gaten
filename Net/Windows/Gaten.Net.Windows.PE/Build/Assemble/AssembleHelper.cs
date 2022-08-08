using Gaten.Net.Exceptions;
using Gaten.Net.Extensions;
using Gaten.Net.Windows.PE.Assembly;

namespace Saturn.Build.Assemble
{
    public class AssembleHelper
    {
        /// <summary>
        /// Instructions to Assembly Bytes
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public static byte[] BuildAssemblyBytes(List<Instruction> instructions)
        {
            byte[] assemblyBytes = Array.Empty<byte>();

            foreach (Instruction i in instructions)
            {
                var machineCode = i.MachineCode;

                if (machineCode == null)
                {
                    throw new NotParsedException(i.String);
                }

                assemblyBytes = assemblyBytes.Serialize(machineCode.Bytes);
            }

            return assemblyBytes;
        }

        public static byte[] BuildDataBytes(List<Variable> variables)
        {
            byte[] dataBytes = Array.Empty<byte>();

            foreach (Variable v in variables)
            {
                dataBytes = dataBytes.Serialize(v.Value.ToBytes());
            }

            return dataBytes;
        }
    }
}
