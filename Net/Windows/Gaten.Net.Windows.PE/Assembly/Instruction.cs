using Gaten.Net.Windows.PE.MachineCode;

using System.Text;

namespace Gaten.Net.Windows.PE.Assembly
{
    public class Instruction : IAssembly
    {
        private enum CodeFormat
        {
            One,
            Two,
            OneTwo,
            TwoOne,
            JustOne,
            JustTwo
        }
        public OpcodeType Opcode { get; set; }
        public object? Operand1 { get; set; }
        public object? Operand2 { get; set; }
        public uint Address { get; set; }
        public AssemblyHex MachineCode => ToMachineCode();
        public AssemblyHex MachineCodeTest => ToMachineCodeTest();
        public string String => ToString();

        /// <summary>
        /// opcode는 필수
        /// operand에는 각각 r/ptr/상수 값이 들어갈 수 있음
        /// 상수를 넣을 때는 항상 캐스팅된 상태로 넣어야 함
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        public Instruction(OpcodeType opcode, object? operand1 = null, object? operand2 = null, uint address = 0x00)
        {
            Opcode = opcode;
            Operand1 = operand1;
            Operand2 = operand2;
            Address = address;

            try
            {
                SmartCast();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        private void SmartCast()
        {
            //    if(Operand1 is int)
            //    {

            //    }

            //if(Operand1 is R8 && Operand2 is R16 ||
            //    Operand1 is R8 && Operand2 is R32 ||
            //    Operand1 is R8 && Operand2 is PTR16 ||
            //    Operand1 is R8 && Operand2 is PTR32 ||
            //    Operand1 is R16 && Operand2 is R8 ||
            //    Operand1 is R16 && Operand2 is R32 ||
            //    Operand1 is R16 && Operand2 is PTR8 ||
            //    Operand1 is R16 && Operand2 is PTR32 ||
            //    Operand1 is R32 && Operand2 is R8 ||
            //    Operand1 is R32 && Operand2 is R16 ||
            //    Operand1 is R32 && Operand2 is PTR8 ||
            //    Operand1 is R32 && Operand2 is PTR16 ||
            //    Operand1 is PTR8 && Operand2 is R16 ||
            //    Operand1 is PTR8 && Operand2 is R32 ||
            //    Operand1 is PTR8 && Operand2 is PTR16 ||
            //    Operand1 is PTR8 && Operand2 is PTR32 ||
            //    Operand1 is PTR16 && Operand2 is R8 ||
            //    Operand1 is PTR16 && Operand2 is R32 ||
            //    Operand1 is PTR16 && Operand2 is PTR8 ||
            //    Operand1 is PTR16 && Operand2 is PTR32 ||
            //    Operand1 is PTR32 && Operand2 is R8 ||
            //    Operand1 is PTR32 && Operand2 is R16 ||
            //    Operand1 is PTR32 && Operand2 is PTR8 ||
            //    Operand1 is PTR32 && Operand2 is PTR16)
            //{
            //    throw new Exception("Invalid operands match type.");
            //}
        }

        /// <summary>
        /// Formalize Machine Code
        /// </summary>
        /// <param name="codeFormat">
        /// One : operand1 + base
        /// Two : operand2 + base
        /// OneTwo : operand1 * 8 + operand2 + base
        /// TwoOne : operand2 * 8 + operand1 + base
        /// JustOne : operand1 * 8 + base
        /// JustTwo : operand2 * 8 + base
        /// </param>
        /// <param name="_base"></param>
        /// <returns></returns>
        private uint Formalize(CodeFormat codeFormat, uint _base = 0x00)
        {
            return codeFormat switch
            {
                CodeFormat.One => Operand1 == null ? _base : (byte)Operand1 + _base,
                CodeFormat.Two => Operand2 == null ? _base : (byte)Operand2 + _base,
                CodeFormat.OneTwo => Operand1 == null || Operand2 == null ? _base : (byte)Operand1 * 0x08U + (byte)Operand2 + _base,
                CodeFormat.TwoOne => Operand1 == null || Operand2 == null ? _base : (byte)Operand2 * 0x08U + (byte)Operand1 + _base,
                CodeFormat.JustOne => Operand1 == null ? _base : (byte)Operand1 * 0x08U + _base,
                CodeFormat.JustTwo => Operand2 == null ? _base : (byte)Operand2 * 0x08U + _base,
                _ => 0,
            };
        }

        private AssemblyHex ToMachineCode()
        {
            var result = Opcode switch
            {
                #region AAA
                OpcodeType.AAA => new AssemblyHex(0x37),
                #endregion

                #region AAD
                OpcodeType.AAD => Operand1 switch
                {
                    byte x => new AssemblyHex(0xD5, x),
                    _ => null
                },
                #endregion

                #region AAM
                OpcodeType.AAM => Operand1 switch
                {
                    byte x => new AssemblyHex(0xD4, x),
                    _ => null
                },
                #endregion

                #region AAS
                OpcodeType.AAS => new AssemblyHex(0x3F),
                #endregion

                #region ADC
                OpcodeType.ADC => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8010), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x1000)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8310), x), // TODO: 무조건 x는 uint로 파싱되기 때문에 타지 않음
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8110), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x1100)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => new AssemblyHex(0x8015, x.Value, (byte)Operand2),
                        DataType.WORD => new AssemblyHex(0x668115, x.Value, (ushort)Operand2),
                        DataType.DWORD => new AssemblyHex(0x8115, x.Value, (uint)Operand2),
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x14, x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(0x1245, (byte)0x00), // TODO: ebp뒤에 +C8 들어감
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x1200))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x1205, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x10C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80D0), x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1245), (byte)0x00), // TODO: ebp뒤에 +C8 들어감
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x1200))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1205), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x10C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            ushort x => new AssemblyHex(0x6615, x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(0x661345, (byte)0x00), // TODO: ebp뒤에 +C8 들어감
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x661300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x661305, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6611C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681D0), x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x661345), (byte)0x00), // TODO: ebp뒤에 +C8 들어감
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x661300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x661305), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6611C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            uint x => new AssemblyHex(0x15, x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(0x1345, (byte)0x00), // TODO: ebp뒤에 +C8 들어감
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x1300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x1305, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x11C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81D0), x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1345), (byte)0x00), // TODO: ebp뒤에 +C8 들어감
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x1300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1305), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x11C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                #region ADD
                OpcodeType.ADD => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8000), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x0000), null, null, 2),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668300), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668100), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x660100)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8300), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8100), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x0100)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x8005, x.Value, y),
                            _ => null
                        },
                        DataType.WORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x668305, x.Value, y), // TODO: ADD는 크기상관없이 항상 byte, word, dword가 존재함
                            ushort y => new AssemblyHex(0x668105, x.Value, y),
                            _ => null
                        },
                        DataType.DWORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x8305, x.Value, y),
                            uint y => new AssemblyHex(0x8105, x.Value, y),
                            _ => null
                        },
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x04, x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(0x0245, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x0200))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x0205, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x00C0), null, null, 2),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80C0), x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x0245), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x0200))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x0205), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x00C0), null, null, 2),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            ushort x => new AssemblyHex(0x6605, x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(0x660345, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x660300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x660305, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6601C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681C0), x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x660345), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x660300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x660305), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6601C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            uint x => new AssemblyHex(0x05, x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(0x0345, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x0300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x0305, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x01C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81C0), x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x0345), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x0300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x0305), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x01C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                #region ADDR16
                //OpcodeType.ADDR16 => new Binary(0x67),
                #endregion

                #region AND
                OpcodeType.AND => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8020), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x2000)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668320), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668120), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x662100)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8320), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8120), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x2100)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => new AssemblyHex(0x8025, x.Value, (byte)Operand2),
                        DataType.WORD => new AssemblyHex(0x668125, x.Value, (ushort)Operand2),
                        DataType.DWORD => new AssemblyHex(0x8125, x.Value, (uint)Operand2),
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x24, x),
                            PTR8 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x2200)),
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x2205, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x20C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80E0), x),
                            PTR8 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x2200)),
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x2205), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x20C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x6683E0, x),
                            ushort x => new AssemblyHex(0x6625, x),
                            PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x662300)),
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x662305, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6621C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x6683E0), x),
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681E0), x),
                            PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x662300)),
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x662305), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6621C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x83E0, x),
                            uint x => new AssemblyHex(0x25, x),
                            PTR32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x2300)),
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x2305, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x21C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x83E0), x),
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81E0), x),
                            PTR32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x2300)),
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x2305), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x21C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                #region ARPL
                OpcodeType.ARPL => Operand1 switch
                {
                    PTR16 _ => Operand2 switch
                    {
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6300)),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region CALL
                OpcodeType.CALL => Operand1 switch
                {
                    int x => new AssemblyHex(0xE8, x),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFF10)),
                    _ => null
                },
                #endregion

                #region CDQ
                OpcodeType.CDQ => new AssemblyHex(0x99),
                #endregion

                #region CLC
                OpcodeType.CLC => new AssemblyHex(0xF8),
                #endregion

                #region CLD
                OpcodeType.CLD => new AssemblyHex(0xFC),
                #endregion

                #region CLI
                OpcodeType.CLI => new AssemblyHex(0xFA),
                #endregion

                #region CMC
                OpcodeType.CMC => new AssemblyHex(0xF5),
                #endregion

                #region CMP
                OpcodeType.CMP => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8038), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x3800)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668338), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668138), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x663900)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8338), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8138), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x3900)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => new AssemblyHex(0x803D, x.Value, (byte)Operand2),
                        DataType.WORD => new AssemblyHex(0x66813D, x.Value, (ushort)Operand2),
                        DataType.DWORD => new AssemblyHex(0x813D, x.Value, (uint)Operand2),
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x3C, x),
                            PTR8 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x3A00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x3A05, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x38C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80F8), x),
                            PTR8 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x3A00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x3A05), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x38C0)),
                            _ => null
                        },
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x6683F8, x),
                            ushort x => new AssemblyHex(0x663D, x),
                            PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x663B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x663B05, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6639C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x6683F8), x),
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681F8), x),
                            PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x663B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x663B05), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6639C0)),
                            _ => null
                        },
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x83F8, x),
                            uint x => new AssemblyHex(0x3D, x),
                            PTR32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x3B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x3B05, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x39C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x83F8), x),
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81F8), x),
                            PTR32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x3B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x3B05), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x39C0)),
                            _ => null
                        },
                    },
                    _ => null
                },
                #endregion

                #region CMPS
                OpcodeType.CMPS => Operand1 switch
                {
                    PTR8 _ => new AssemblyHex(0xA6),
                    PTR32 _ => new AssemblyHex(0xA7),
                    _ => null
                },
                #endregion

                #region CS
                OpcodeType.CS => new AssemblyHex(0x2E),
                #endregion

                #region CWDE
                OpcodeType.CWDE => new AssemblyHex(0x98),
                #endregion

                #region DAA
                OpcodeType.DAA => new AssemblyHex(0x27),
                #endregion

                #region DAS
                OpcodeType.DAS => new AssemblyHex(0x2F),
                #endregion

                #region DATA16
                //OpcodeType.DATA16 => new Binary(0x66),
                #endregion

                #region DEC
                OpcodeType.DEC => Operand1 switch
                {
                    PTR8 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFE08)),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFF08)),
                    R32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0x48)),
                    _ => null
                },
                #endregion

                #region DIV
                OpcodeType.DIV => Operand1 switch
                {
                    PTRC x => new AssemblyHex(0xF735, x.Value),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xF730)),
                    _ => null
                },
                #endregion

                #region DS
                //OpcodeType.DS => new Binary(0x3E),
                #endregion

                #region ES
                //OpcodeType.ES => new Binary(0x26),
                #endregion

                #region FS
                //OpcodeType.FS => new Binary(0x64),
                #endregion

                #region FWAIT
                OpcodeType.FWAIT => new AssemblyHex(0x9B),
                #endregion

                #region GS
                //OpcodeType.GS => new Binary(0x65),
                #endregion

                #region HLT
                OpcodeType.HLT => new AssemblyHex(0xF4),
                #endregion

                #region ICEBP / INT1
                OpcodeType.ICEBP => new AssemblyHex(0xF1),
                OpcodeType.INT1 => new AssemblyHex(0xF1),
                #endregion

                #region IDIV
                OpcodeType.IDIV => Operand1 switch
                {
                    PTRC x => new AssemblyHex(0xF73D, x.Value),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xF738)),
                    _ => null
                },
                #endregion

                #region IMUL
                OpcodeType.IMUL => Operand1 switch
                {
                    PTRC x => new AssemblyHex(0xF72D, x.Value),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xF728)),
                    _ => null
                },
                #endregion

                #region IN
                OpcodeType.IN => Operand1 switch
                {
                    R8.AL => Operand2 switch
                    {
                        byte x => new AssemblyHex(0xE4, x),
                        R16.DX => new AssemblyHex(0xEC),
                        _ => null
                    },
                    R32.EAX => Operand2 switch
                    {
                        byte x => new AssemblyHex(0xE5, x),
                        R16.DX => new AssemblyHex(0xED),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region INC
                OpcodeType.INC => Operand1 switch
                {
                    PTR8 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFE00)),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFF00)),
                    R32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0x40)),
                    _ => null
                },
                #endregion

                #region INS / INSB / INSD
                OpcodeType.INS => Operand1 switch
                {
                    PTR8.EDI => Operand2 switch
                    {
                        R16.DX => new AssemblyHex(0x6C),
                        _ => null
                    },
                    PTR32.EDI => Operand2 switch
                    {
                        R16.DX => new AssemblyHex(0x6D),
                        _ => null
                    },
                    _ => null
                },
                OpcodeType.INSB => new AssemblyHex(0x6C),
                OpcodeType.INSD => new AssemblyHex(0x6D),
                #endregion

                #region INT
                OpcodeType.INT => Operand1 switch
                {
                    byte x => new AssemblyHex(0xCD, x),
                    _ => null
                },
                #endregion

                #region INT3
                OpcodeType.INT3 => new AssemblyHex(0xCC),
                #endregion

                #region INTO
                OpcodeType.INTO => new AssemblyHex(0xCE),
                #endregion

                #region IRET / IRETD
                OpcodeType.IRET => new AssemblyHex(0xCF),
                OpcodeType.IRETD => new AssemblyHex(0xCF),
                #endregion

                #region JA
                OpcodeType.JA => Operand1 switch
                {
                    byte x => new AssemblyHex(0x77, x),
                    _ => null
                },
                #endregion

                #region JAE
                OpcodeType.JAE => Operand1 switch
                {
                    byte x => new AssemblyHex(0x73, x),
                    _ => null
                },
                #endregion

                #region JB
                OpcodeType.JB => Operand1 switch
                {
                    byte x => new AssemblyHex(0x72, x),
                    _ => null
                },
                #endregion

                #region JBE
                OpcodeType.JBE => Operand1 switch
                {
                    byte x => new AssemblyHex(0x76, x),
                    _ => null
                },
                #endregion

                #region JE
                OpcodeType.JE => Operand1 switch
                {
                    byte x => new AssemblyHex(0x74, x),
                    _ => null
                },
                #endregion

                #region JECXZ
                OpcodeType.JECXZ => Operand1 switch
                {
                    byte x => new AssemblyHex(0xE3, x),
                    _ => null
                },
                #endregion

                #region JG
                OpcodeType.JG => Operand1 switch
                {
                    byte x => new AssemblyHex(0x7F, x),
                    _ => null
                },
                #endregion

                #region JGE
                OpcodeType.JGE => Operand1 switch
                {
                    byte x => new AssemblyHex(0x7D, x),
                    _ => null
                },
                #endregion

                #region JL
                OpcodeType.JL => Operand1 switch
                {
                    byte x => new AssemblyHex(0x7C, x),
                    _ => null
                },
                #endregion

                #region JLE
                OpcodeType.JLE => Operand1 switch
                {
                    byte x => new AssemblyHex(0x7E, x),
                    _ => null
                },
                #endregion

                #region JMP
                OpcodeType.JMP => Operand1 switch
                {
                    byte x => new AssemblyHex(0xEB, x),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFF20)),
                    PTR48 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFF28)),
                    _ => null
                },
                #endregion

                #region JNE
                OpcodeType.JNE => Operand1 switch
                {
                    byte x => new AssemblyHex(0x75, x),
                    _ => null
                },
                #endregion

                #region JNO
                OpcodeType.JNO => Operand1 switch
                {
                    byte x => new AssemblyHex(0x71, x),
                    _ => null
                },
                #endregion

                #region JNP
                OpcodeType.JNP => Operand1 switch
                {
                    byte x => new AssemblyHex(0x7B, x),
                    _ => null
                },
                #endregion

                #region JNS
                OpcodeType.JNS => Operand1 switch
                {
                    byte x => new AssemblyHex(0x79, x),
                    _ => null
                },
                #endregion

                #region JO
                OpcodeType.JO => Operand1 switch
                {
                    byte x => new AssemblyHex(0x70, x),
                    _ => null
                },
                #endregion

                #region JP
                OpcodeType.JP => Operand1 switch
                {
                    byte x => new AssemblyHex(0x7A, x),
                    _ => null
                },
                #endregion

                #region JS
                OpcodeType.JS => Operand1 switch
                {
                    byte x => new AssemblyHex(0x78, x),
                    _ => null
                },
                #endregion

                #region LAHF
                OpcodeType.LAHF => new AssemblyHex(0x9F),
                #endregion

                #region LEA
                OpcodeType.LEA => Operand1 switch
                {
                    R32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x8D00)),
                    _ => null
                },
                #endregion

                #region LEAVE
                OpcodeType.LEAVE => new AssemblyHex(0xC9),
                #endregion

                #region LOCK
                //OpcodeType.LOCK => new Binary(0xF0),
                #endregion

                #region LODS / LODSB / LODSD
                OpcodeType.LODS => Operand1 switch
                {
                    R8.AL => new AssemblyHex(0xAC),
                    R32.EAX => new AssemblyHex(0xAD),
                    _ => null
                },
                OpcodeType.LODSB => new AssemblyHex(0xAC),
                OpcodeType.LODSD => new AssemblyHex(0xAD),
                #endregion

                #region LOOP
                OpcodeType.LOOP => Operand1 switch
                {
                    byte x => new AssemblyHex(0xE2, x),
                    _ => null
                },
                #endregion

                #region LOOPE
                OpcodeType.LOOPE => Operand1 switch
                {
                    byte x => new AssemblyHex(0xE1, x),
                    _ => null
                },
                #endregion

                #region LOOPNE
                OpcodeType.LOOPNE => Operand1 switch
                {
                    byte x => new AssemblyHex(0xE0, x),
                    _ => null
                },
                #endregion

                #region MOV
                OpcodeType.MOV => Operand1 switch
                {
                    PTRC x => Operand2 switch
                    {
                        byte y => new AssemblyHex(0xC605, x.Value, y),
                        ushort y => new AssemblyHex(0x66C705, x.Value, y),
                        uint y => new AssemblyHex(0xC705, x.Value, y),
                        R8 _ => Operand2 switch
                        {
                            R8.AL => new AssemblyHex(0xA2, x.Value),
                            _ => new AssemblyHex(Formalize(CodeFormat.JustTwo, 0x8805), x.Value)
                        },
                        R16 _ => Operand2 switch
                        {
                            R16.AX => new AssemblyHex(0x66A3, x.Value),
                            _ => new AssemblyHex(Formalize(CodeFormat.JustTwo, 0x668905), x.Value)
                        },
                        R32 _ => Operand2 switch
                        {
                            R32.EAX => new AssemblyHex(0xA3, x.Value),
                            _ => new AssemblyHex(Formalize(CodeFormat.JustTwo, 0x8905), x.Value)
                        },
                        _ => null
                    },
                    PTR8 _ => Operand2 switch
                    {
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x8800)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x668900)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x8900)),
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0xB0, x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(0x8A45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x8A00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0xA0, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x88C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xB0), x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x8A45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x8A00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x8A05), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x88C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            ushort x => new AssemblyHex(0x66B8, x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(0x668B45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x668B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x66A1, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6689C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x66B8), x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x668B45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x668B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x668B05), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6689C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            uint x => new AssemblyHex(0xB8, x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(0x8B45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x8B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0xA1, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x89C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0xB8), x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x8B45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x8B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x8B05), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x89C0)),
                            _ => null
                        }
                    },
                    S _ => Operand2 switch
                    {
                        PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x8E00)),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region MOVS / MOVSB / MOVSD
                OpcodeType.MOVS => Operand1 switch
                {
                    PTR8 _ => new AssemblyHex(0xA4),
                    PTR32 _ => new AssemblyHex(0xA5),
                    _ => null
                },
                OpcodeType.MOVSB => new AssemblyHex(0xA4),
                OpcodeType.MOVSD => new AssemblyHex(0xA5),
                #endregion

                #region MUL
                OpcodeType.MUL => Operand1 switch
                {
                    PTRC x => new AssemblyHex(0xF725, x.Value),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xF720)),
                    _ => null
                },
                #endregion

                #region NEG
                OpcodeType.NEG => Operand1 switch
                {
                    PTRC x => new AssemblyHex(0xF71D, x.Value),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xF718)),
                    _ => null
                },
                #endregion

                #region NOP
                OpcodeType.NOP => new AssemblyHex(0x90),
                #endregion

                #region NOT
                OpcodeType.NOT => Operand1 switch
                {
                    PTRC x => new AssemblyHex(0xF715, x.Value),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xF710)),
                    _ => null
                },
                #endregion

                #region OR
                OpcodeType.OR => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8008), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x0800)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668308), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668108), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x660900)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8308), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8108), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x0900)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => new AssemblyHex(0x0805, x.Value),
                        DataType.WORD => new AssemblyHex(0x660905, x.Value),
                        DataType.DWORD => new AssemblyHex(0x0905, x.Value),
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x0C, x),
                            PTR8 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x0A00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x0A05, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x08C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80C8), x),
                            PTR8 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x0A00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x0A05), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x08C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x6683C8, x),
                            ushort x => new AssemblyHex(0x660D, x),
                            PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x660B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x660B05, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6609C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x6683C8), x),
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681C8), x),
                            PTR16 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x660B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x660B05), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6609C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x83C8, x),
                            uint x => new AssemblyHex(0x0D, x),
                            PTR32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x0B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x0B05, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x09C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x83C8), x),
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81C8), x),
                            PTR32 _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x0B00)),
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x0B05), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x09C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                #region OUT
                OpcodeType.OUT => Operand1 switch
                {
                    byte x => Operand2 switch
                    {
                        R8.AL => new AssemblyHex(0xE6, x),
                        R32.EAX => new AssemblyHex(0xE7, x),
                        _ => null
                    },
                    R16.DX => Operand2 switch
                    {
                        R8.AL => new AssemblyHex(0xEE),
                        R32.EAX => new AssemblyHex(0xEF),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region OUTS / OUTSB / OUTSD
                OpcodeType.OUTS => Operand1 switch
                {
                    R16.DX => Operand2 switch
                    {
                        PTR8.ESI => new AssemblyHex(0x6E),
                        PTR32.ESI => new AssemblyHex(0x6F),
                        _ => null
                    },
                    _ => null
                },
                OpcodeType.OUTSB => new AssemblyHex(0x6E),
                OpcodeType.OUTSD => new AssemblyHex(0x6F),
                #endregion

                #region POP
                OpcodeType.POP => Operand1 switch
                {
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0x8F00)),
                    R32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0x58)),
                    S.ES => new AssemblyHex(0x07),
                    S.SS => new AssemblyHex(0x17),
                    S.DS => new AssemblyHex(0x1F),
                    _ => null
                },
                #endregion

                #region POPA / POPAD
                OpcodeType.POPA => new AssemblyHex(0x61),
                OpcodeType.POPAD => new AssemblyHex(0x61),
                #endregion

                #region POPF / POPFD
                OpcodeType.POPF => new AssemblyHex(0x9D),
                OpcodeType.POPFD => new AssemblyHex(0x9D),
                #endregion

                #region PUSH
                OpcodeType.PUSH => Operand1 switch
                {
                    byte x => new AssemblyHex(0x6A, x),
                    PTR32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0xFF30)),
                    R32 _ => new AssemblyHex(Formalize(CodeFormat.One, 0x50)),
                    S.ES => new AssemblyHex(0x06),
                    S.CS => new AssemblyHex(0x0E),
                    S.SS => new AssemblyHex(0x16),
                    S.DS => new AssemblyHex(0x1E),
                    _ => null
                },
                #endregion

                #region PUSHA / PUSHAD
                OpcodeType.PUSHA => new AssemblyHex(0x60),
                OpcodeType.PUSHAD => new AssemblyHex(0x60),
                #endregion

                #region PUSHF / PUSHFD
                OpcodeType.PUSHF => new AssemblyHex(0x9C),
                OpcodeType.PUSHFD => new AssemblyHex(0x9C),
                #endregion

                #region REPZ
                //OpcodeType.REPZ => new Binary(0xF3),
                #endregion

                #region REPNZ
                //OpcodeType.REPNZ => new Binary(0xF2),
                #endregion

                #region RET
                OpcodeType.RET => new AssemblyHex(0xC3),
                #endregion

                #region RETF / RETFAR
                OpcodeType.RETF => new AssemblyHex(0xCB),
                OpcodeType.RETFAR => new AssemblyHex(0xCB),
                #endregion

                #region RCL
                OpcodeType.RCL => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD010)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD210)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD110)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD310)),
                        _ => null
                    },
                    R8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD0D0)),
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xC0D0), x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region RCR
                OpcodeType.RCR => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD018)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD218)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD118)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD318)),
                        _ => null
                    },
                    R8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD0D8)),
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xC0D8), x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region ROL
                OpcodeType.ROL => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD000)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD200)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD100)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD300)),
                        _ => null
                    },
                    R8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD0C0)),
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xC0C0), x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region ROR
                OpcodeType.ROR => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD008)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD208)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD108)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD308)),
                        _ => null
                    },
                    R8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD0C8)),
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xC0C8), x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region SAHF
                OpcodeType.SAHF => new AssemblyHex(0x9E),
                #endregion

                #region SBB
                OpcodeType.SBB => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8018), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x1800)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668318), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668118), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x661900)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8318), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8118), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x1900)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x801D, x.Value, y),
                            _ => null
                        },
                        DataType.WORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x66831D, x.Value, y), // TODO: ADD는 크기상관없이 항상 byte, word, dword가 존재함
                            ushort y => new AssemblyHex(0x66811D, x.Value, y),
                            _ => null
                        },
                        DataType.DWORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x831D, x.Value, y),
                            uint y => new AssemblyHex(0x811D, x.Value, y),
                            _ => null
                        },
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x1C, x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(0x1A45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x1A00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x1A05, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x18C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80D8), x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1A45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x1A00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1A05), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x18C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            ushort x => new AssemblyHex(0x661D, x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(0x661B45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x661B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x661B05, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6619C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681D8), x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x661B45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x661B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x661B05), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6619C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            uint x => new AssemblyHex(0x1D, x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(0x1B45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x1B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x1B05, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x19C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81D8), x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1B45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x1B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x1B05), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x19C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                #region SCAS / SCASB / SCASD
                OpcodeType.SCAS => Operand1 switch
                {
                    R8.AL => new AssemblyHex(0xAE),
                    R32.EAX => new AssemblyHex(0xAF),
                    _ => null
                },
                OpcodeType.SCASB => new AssemblyHex(0xAE),
                OpcodeType.SCASD => new AssemblyHex(0xAF),
                #endregion

                #region SHL
                OpcodeType.SHL => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD020)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD220)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD120)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD320)),
                        _ => null
                    },
                    R8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD0E0)),
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xC0E0), x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region SHR
                OpcodeType.SHR => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD028)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD228)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD128)),
                        R8.CL => new AssemblyHex(Formalize(CodeFormat.One, 0xD328)),
                        _ => null
                    },
                    R8 _ => Operand2 switch
                    {
                        byte x when x == 1 => new AssemblyHex(Formalize(CodeFormat.One, 0xD0E8)),
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0xC0E8), x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region SS
                //OpcodeType.SS => new Binary(0x36),
                #endregion

                #region STC
                OpcodeType.STC => new AssemblyHex(0xF9),
                #endregion

                #region STD
                OpcodeType.STD => new AssemblyHex(0xFD),
                #endregion

                #region STI
                OpcodeType.STI => new AssemblyHex(0xFB),
                #endregion

                #region STOS / STOSB / STOSD
                OpcodeType.STOS => Operand1 switch
                {
                    PTR8.EDI => Operand2 switch
                    {
                        R8.AL => new AssemblyHex(0xAA),
                        _ => null
                    },
                    PTR32.EDI => Operand2 switch
                    {
                        R32.EAX => new AssemblyHex(0xAB),
                        _ => null
                    },
                    _ => null
                },
                OpcodeType.STOSB => new AssemblyHex(0xAA),
                OpcodeType.STOSD => new AssemblyHex(0xAB),
                #endregion

                #region SUB
                OpcodeType.SUB => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8028), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x2800)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668328), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668128), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x662900)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8328), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8128), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x2900)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x802D, x.Value, y),
                            _ => null
                        },
                        DataType.WORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x66832D, x.Value, y), // TODO: ADD는 크기상관없이 항상 byte, word, dword가 존재함
                            ushort y => new AssemblyHex(0x66812D, x.Value, y),
                            _ => null
                        },
                        DataType.DWORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x832D, x.Value, y),
                            uint y => new AssemblyHex(0x812D, x.Value, y),
                            _ => null
                        },
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x2C, x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(0x2A45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x2A00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x2A05, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x28C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80D8), x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x2A45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x2A00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x2A05), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x28C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            ushort x => new AssemblyHex(0x662D, x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(0x662B45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x662B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x662B05, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6629C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681E8), x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x662B45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x662B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x662B05), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6629C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            uint x => new AssemblyHex(0x2D, x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(0x2B45, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x2B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x2B05, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x29C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81E8), x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x2B45), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x2B00))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x2B05), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x29C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                #region TEST
                OpcodeType.TEST => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x8400)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0xF700), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x8500)),
                        _ => null
                    },
                    R8.AL => Operand2 switch
                    {
                        byte x => new AssemblyHex(0xA8, x),
                        _ => null
                    },
                    R32.EAX => Operand2 switch
                    {
                        uint x => new AssemblyHex(0xA9, x),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region XCHG
                OpcodeType.XCHG => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x8600)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x8700)),
                        _ => null
                    },
                    R32 _ => Operand2 switch
                    {
                        R32.EAX => new AssemblyHex(Formalize(CodeFormat.One, 0x90)),
                        _ => null
                    },
                    _ => null
                },
                #endregion

                #region XLAT
                OpcodeType.XLAT => Operand1 switch
                {
                    null => new AssemblyHex(0xD7),
                    PTR8.EBX => new AssemblyHex(0xD7),
                    _ => null
                },
                #endregion

                #region XOR
                OpcodeType.XOR => Operand1 switch
                {
                    PTR8 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8030), x),
                        R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x3000)),
                        _ => null
                    },
                    PTR16 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x668330), x),
                        ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x668130), x),
                        R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x663100)),
                        _ => null
                    },
                    PTR32 _ => Operand2 switch
                    {
                        byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x8330), x),
                        uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x8130), x),
                        R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x3100)),
                        _ => null
                    },
                    PTRC x => x.DataType switch
                    {
                        DataType.BYTE => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x8035, x.Value, y),
                            _ => null
                        },
                        DataType.WORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x668335, x.Value, y), // TODO: ADD는 크기상관없이 항상 byte, word, dword가 존재함
                            ushort y => new AssemblyHex(0x668135, x.Value, y),
                            _ => null
                        },
                        DataType.DWORD => Operand2 switch
                        {
                            byte y => new AssemblyHex(0x8335, x.Value, y),
                            uint y => new AssemblyHex(0x8135, x.Value, y),
                            _ => null
                        },
                        _ => null
                    },
                    R8 _ => Operand1 switch
                    {
                        R8.AL => Operand2 switch
                        {
                            byte x => new AssemblyHex(0x34, x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(0x3245, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x3200))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(0x3205, x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x30C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            byte x => new AssemblyHex(Formalize(CodeFormat.One, 0x80F0), x),
                            PTR8 _ => Operand2 switch
                            {
                                PTR8.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x3245), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x3200))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.BYTE => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x3205), x.Value),
                                _ => null
                            },
                            R8 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x30C0)),
                            _ => null
                        }
                    },
                    R16 _ => Operand1 switch
                    {
                        R16.AX => Operand2 switch
                        {
                            ushort x => new AssemblyHex(0x6635, x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(0x663345, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x663300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(0x663305, x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6631C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            ushort x => new AssemblyHex(Formalize(CodeFormat.One, 0x6681F0), x),
                            PTR16 _ => Operand2 switch
                            {
                                PTR16.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x663345), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x663300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.WORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x663305), x.Value),
                                _ => null
                            },
                            R16 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x6631C0)),
                            _ => null
                        }
                    },
                    R32 _ => Operand1 switch
                    {
                        R32.EAX => Operand2 switch
                        {
                            uint x => new AssemblyHex(0x35, x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(0x3345, (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.Two, 0x3300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(0x3305, x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x31C0)),
                            _ => null
                        },
                        _ => Operand2 switch
                        {
                            uint x => new AssemblyHex(Formalize(CodeFormat.One, 0x81F0), x),
                            PTR32 _ => Operand2 switch
                            {
                                PTR32.EBP => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x3345), (byte)0x00),
                                _ => new AssemblyHex(Formalize(CodeFormat.OneTwo, 0x3300))
                            },
                            PTRC x => x.DataType switch
                            {
                                DataType.DWORD => new AssemblyHex(Formalize(CodeFormat.JustOne, 0x3305), x.Value),
                                _ => null
                            },
                            R32 _ => new AssemblyHex(Formalize(CodeFormat.TwoOne, 0x31C0)),
                            _ => null
                        }
                    },
                    _ => null
                },
                #endregion

                _ => null
            };

            return result == null ? new AssemblyHex(null) : result;
        }

        AssemblyHex ToMachineCodeTest()
        {
            //switch (Opcode)
            //{
            //    case OpcodeType.IN:
            //        switch (Operand1)
            //        {
            //            case R8.AL:
            //                switch (Operand2)
            //                {
            //                    case byte x:
            //                        return new Binary(0xE4, x);
            //                    case R16.DX:
            //                        return new Binary(0xEC);
            //                    default:
            //                        return null;
            //                }
            //            case R32.EAX:
            //                switch (Operand2)
            //                {
            //                    case byte x:
            //                        return new Binary(0xE5, x);
            //                    case R16.DX:
            //                        return new Binary(0xED);
            //                    default:
            //                        return null;
            //                }
            //            default:
            //                return null;
            //        }
            //    default:
            //        return null;
            //}

            return new AssemblyHex(null);
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.Append(Opcode.ToString());
            builder.Append(' ');

            if (Operand1 != null)
            {
                builder.Append(
                    Operand1 is PTR8 ?
                    "BYTE" + "[" + Operand1 + "]" :
                    Operand1 is PTR16 ?
                    "WORD" + "[" + Operand1 + "]" :
                    Operand1 is PTR32 ?
                    "DWORD" + "[" + Operand1 + "]" :
                    Operand1 is PTR48 ?
                    "FWORD" + "[" + Operand1 + "]" :
                    Operand1 is PTR64 ?
                    "QWORD" + "[" + Operand1 + "]" :
                    Operand1 is PTRC operand1 ?
                    operand1.DataType.ToString() + "[" + operand1.ReverseHexString + "]" :
                    Operand1.ToString()
                    );
            }

            if (Operand2 != null)
            {
                builder.Append(", ");
                builder.Append(
                    Operand2 is PTR8 ?
                    "BYTE" + "[" + Operand2 + "]" :
                    Operand2 is PTR16 ?
                    "WORD" + "[" + Operand2 + "]" :
                    Operand2 is PTR32 ?
                    "DWORD" + "[" + Operand2 + "]" :
                    Operand2 is PTR48 ?
                    "FWORD" + "[" + Operand2 + "]" :
                    Operand2 is PTR64 ?
                    "QWORD" + "[" + Operand2 + "]" :
                    Operand2 is PTRC operand2 ?
                    operand2.DataType.ToString() + "[" + operand2.ReverseHexString + "]" :
                    Operand2.ToString()
                    );
            }

            return builder.ToString();
        }
    }
}
