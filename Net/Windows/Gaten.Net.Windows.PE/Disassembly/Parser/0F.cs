namespace Gaten.Net.Windows.PE.Disassembly.Parser
{
    public class _0F
    {
        public static void Parse()
        {
            DisassemblyHelper.GetOpcode();

            switch (DisassemblyHelper.Opcode2HexString)
            {
                case "1A":
                    DisassemblyHelper.GetOpcode();

                    switch (DisassemblyHelper.Opcode3HexString)
                    {
                        case "44":
                            DisassemblyHelper.GetOpcode();

                            switch (DisassemblyHelper.Opcode4HexString)
                            {
                                case "04":
                                    DisassemblyHelper.SetDisassemblyString("BNDLDX BND0, SS:[ESP+EAX{0}]", DisassemblyHelper.OperandType.SH8);
                                    break;

                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                    break;

                case "1B":
                    DisassemblyHelper.GetOpcode();

                    switch (DisassemblyHelper.Opcode3HexString)
                    {
                        case "04":
                            DisassemblyHelper.GetOpcode();

                            switch (DisassemblyHelper.Opcode4HexString)
                            {
                                case "04":
                                    DisassemblyHelper.SetDisassemblyString("BNDSTX SS:[ESP+EAX], BND0");
                                    break;

                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                    break;

                case "84":
                    DisassemblyHelper.SetDisassemblyString("JE [{0}]", DisassemblyHelper.OperandType.J32);
                    break;

                case "8D":
                    DisassemblyHelper.SetDisassemblyString("JGE [{0}]", DisassemblyHelper.OperandType.J32);
                    break;

                case "B6":
                    DisassemblyHelper.GetOpcode();

                    switch (DisassemblyHelper.Opcode3HexString)
                    {
                        case "11":
                            DisassemblyHelper.SetDisassemblyString("MOVZX EDX, BYTE PTR DS:[ECX]");
                            break;

                        case "C0":
                            DisassemblyHelper.SetDisassemblyString("MOVZX EAX, AL");
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
