using Gaten.Net.Windows.PE.Build;
using Gaten.Net.Windows.PE.PEFileFormat;

namespace Gaten.Windows.SaturnBuilder
{
    class Program
    {
        /// <summary>
        /// Builder Base Logic
        /// 
        /// - It is an aseemble process without a link process
        /// 
        /// 1. Add AddressManager for manage about memory address
        /// 2. Add Instructions
        /// 3. Add Variables through AddressManager
        /// 4. Build assembly bytes and data bytes
        /// 5. Build PE file
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            //List<Instruction> instructions = new List<Instruction>()
            //{
            //    new Instruction(OpcodeType.MOV, R32.EAX, new PTRC(DataType.DWORD, 0x402000)),
            //    new Instruction(OpcodeType.MUL, new PTRC(DataType.DWORD, 0x402004)),
            //    new Instruction(OpcodeType.MOV, new PTRC(DataType.DWORD, 0x402008), R32.EAX),
            //    new Instruction(OpcodeType.MOV, R32.EAX, new PTRC(DataType.DWORD, 0x402000)),
            //    new Instruction(OpcodeType.DIV, new PTRC(DataType.DWORD, 0x402004)),
            //    new Instruction(OpcodeType.MOV, new PTRC(DataType.DWORD, 0x40200C), R32.EAX),
            //    new Instruction(OpcodeType.RET),
            //};

            //List<Variable> variables = new List<Variable>();

            //AddressManager.AddVariable(DataType.BYTE, "var1", 12);
            //AddressManager.AddVariable(DataType.WORD, "var2", 1234);
            //AddressManager.AddVariable(DataType.DWORD, "var3", 12345678);
            //AddressManager.AddVariable(DataType.QWORD, "var4", 12345678901234);

            //var assemblyBytes = AssembleHelper.BuildAssemblyBytes(instructions);
            //var dataBytes = AssembleHelper.BuildDataBytes(variables);

            var assemblyBytes = RAW_DATA.TextData;
            var dataBytes = RAW_DATA.DataData;

            Build(assemblyBytes, dataBytes);
        }

        static void Build(byte[] assemblyBytes, byte[] dataBytes)
        {
            PEBuilder peBuilder = new(assemblyBytes, dataBytes);

            string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "petest.exe");

            using FileStream stream = new(outputPath, FileMode.Create, FileAccess.Write);
            peBuilder.WriteFile(stream);
        }
    }
}
