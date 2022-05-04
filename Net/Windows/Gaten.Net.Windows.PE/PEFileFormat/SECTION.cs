using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class SECTION
    {
        public string Name { get; set; }
        public uint SectionSize { get; set; }
        public byte[] Data { get; set; }
        public byte[] Bytes => ToBytes();

        /// <summary>
        /// SECTION
        /// </summary>
        /// <param name="name">IMAGE_SECTION_HEADER의 Name 값</param>
        /// <param name="sectionSize">IMAGE_SECTION_HEADER의 SizeOfRawData 값</param>
        /// <param name="content">SectionData, 실제 길이는 IMAGE_SECTION_HEADER의 VirtualSize 값</param>
        public SECTION(string name, uint sectionSize, byte[] content)
        {
            Name = name;
            SectionSize = sectionSize;
            Data = content;

            switch (name)
            {
                case ".text":
                    //byte[] assemblyData = new byte[sectionSize];
                    //ConcatenateBytes(ref assemblyData, 0, content);

                    //byte[] assemblyEmptyData = new byte[sectionSize - content.Length];
                    //Array.Clear(assemblyEmptyData, 0, assemblyEmptyData.Length);
                    //ConcatenateBytes(ref assemblyData, content.Length, assemblyEmptyData);

                    //Data = assemblyData;
                    break;

                case ".data":
                    //byte[] variableData = new byte[sectionSize];
                    //ConcatenateBytes(ref variableData, 0, content);

                    //byte[] variableEmptyData = new byte[sectionSize - content.Length];
                    //Array.Clear(variableEmptyData, 0, variableEmptyData.Length);
                    //ConcatenateBytes(ref variableData, content.Length, variableEmptyData);

                    //Data = variableData;
                    break;

                case ".rdata":
                    break;

                case ".idata":
                    break;

                case ".msvcjmc":
                    break;

                case ".00cfg":
                    break;

                case ".rsrc":
                    break;

                case ".reloc":
                    break;

                default:
                    break;
            }
        }

        private byte[] ToBytes() => Data;
    }
}
