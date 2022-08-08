using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gaten.Net.Serialization;
using Gaten.Net.Extensions;

namespace Gaten.Net.Windows.PE.MachineCode
{
    public class AssemblyHex
    {
        /// <summary>
        /// Flexible size
        /// Max 4 Bytes
        /// </summary>
        public byte[]? Opcode { get; set; }

        /// <summary>
        /// Fixed Size
        /// Max 4 Bytes
        /// </summary>
        public byte[]? Operand1 { get; set; }

        /// <summary>
        /// Fixed Size
        /// Max 4 Bytes
        /// </summary>
        public byte[]? Operand2 { get; set; }

        public string String => ToString();
        public byte[] Bytes => ToBytes();

        /// <summary>
        /// If opcode starts with 0x00 byte, must set opcodeSize
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="opcodeSize"></param>
        public AssemblyHex(object? opcode, object? operand1 = null, object? operand2 = null, int opcodeSize = 0)
        {
            if (opcode == null)
            {
                throw new ArgumentNullException(nameof(opcode));
            }

            Opcode = opcodeSize != 0 ?
                     opcode.GetTypeCode() switch
                     {
                         ExtensionTypeCode.Int32 => BitConverter.GetBytes((int)opcode).GetBytes(0, opcodeSize).ReverseBytes(),
                         ExtensionTypeCode.UInt32 => BitConverter.GetBytes((uint)opcode).GetBytes(0, opcodeSize).ReverseBytes(),
                         _ => null
                     }
                 :
                opcode.ToBytes(true).Trim();

            Operand1 = operand1 switch
            {
                null => null,
                _ => operand1.ToBytes()
            };

            Operand2 = operand2 switch
            {
                null => null,
                _ => operand2.ToBytes()
            };
        }

        new string ToString()
        {
            if (Opcode == null)
            {
                throw new NullReferenceException(nameof(Opcode));
            }

            if (Operand1 == null)
            {
                return Opcode.ToHexString();
            }

            if (Operand2 == null)
            {
                return Opcode.ToHexString() + Operand1.ToHexString();
            }

            return Opcode.ToHexString() + Operand1.ToHexString() + Operand2.ToHexString();
        }

        byte[] ToBytes()
        {
            Serializer serializer = new Serializer();

            if (Opcode == null)
            {
                throw new NullReferenceException(nameof(Opcode));
            }

            if (Operand1 == null)
            {
                return Opcode;
            }

            if (Operand2 == null)
            {
                serializer.Add(Opcode);
                serializer.Add(Operand1);

                return serializer.ToBytes();
            }

            serializer.Add(Opcode);
            serializer.Add(Operand1);
            serializer.Add(Operand2);

            return serializer.ToBytes();
        }
    }
}
