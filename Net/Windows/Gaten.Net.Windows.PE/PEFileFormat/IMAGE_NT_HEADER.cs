using Gaten.Net.Data.Serialization;
using Gaten.Net.Extension;
using Gaten.Net.Windows.PE.Build;
using Gaten.Net.Windows.PE.Build.Assemble;

namespace Gaten.Net.Windows.PE.PEFileFormat
{
    public class IMAGE_NT_HEADER
    {
        public uint Signature { get; set; }
        public IMAGE_FILE_HEADER ImageFileHeader { get; set; }
        public IMAGE_OPTIONAL_HEADER ImageOptionalHeader { get; set; }
        public byte[] Bytes => ToBytes();
        private readonly List<IMAGE_DATA_DIRECTORY> dataDirectories;

        public IMAGE_NT_HEADER(ushort sectionCount)
        {
            // Signature
            Signature = "PE".ToUInt();

            // Data Directory
            dataDirectories = new List<IMAGE_DATA_DIRECTORY>();
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0000B1C8, 0x00000050));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0000E000, 0x0000043C));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0000F000, 0x000003AC));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x000084F4, 0x00000038));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00008530, 0x00000040));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x0000B000, 0x000001C8));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));
            dataDirectories.Add(new IMAGE_DATA_DIRECTORY(0x00000000, 0x00000000));

            // Optional Header
            ImageOptionalHeader = new IMAGE_OPTIONAL_HEADER(
                BuildEnvironment.Format, 0x0E, 0x1C, 0x00005A00,
                0x00004600, 0x00000000,
                AddressManager.EntryPointAddress, 0x00001000, 0x00001000,
                AddressManager.ImageBaseAddress, AddressManager.SectionAlignment, AddressManager.FileAlignment,
                0x0006, 0x0000, 0x0000, 0x0000,
                0x0006, 0x0000, 0x00000000,
                AddressManager.ImageSize, 0x00000400, 0x00000000, 
                WindowsSubsystem.IMAGE_SUBSYSTEM_WINDOWS_CUI,
                DLLCharacteristics.IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE | DLLCharacteristics.IMAGE_DLLCHARACTERISTICS_NX_COMPAT | DLLCharacteristics.IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE,
                0x00100000, 0x00001000, 0x00100000, 0x00001000, 0x00000000,
                (uint)dataDirectories.Count, dataDirectories);

            // File Header
            ImageFileHeader = new IMAGE_FILE_HEADER(
                MachineType.IMAGE_FILE_MACHINE_I386, sectionCount, 
                (int)((long)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds & 0xFFFFFFFF),
                0x00000000, 0x00000000, (ushort)ImageOptionalHeader.Bytes.Length, 
                Characteristics.IMAGE_FILE_EXECUTABLE_IMAGE | Characteristics.IMAGE_FILE_32BIT_MACHINE);
        }

        private byte[] ToBytes()
        {
            Serializer serializer = new();
            serializer.Add(BitConverter.GetBytes(Signature));
            serializer.Add(ImageFileHeader.Bytes);
            serializer.Add(ImageOptionalHeader.Bytes);

            return serializer.ToBytes();
        }
    }
}
