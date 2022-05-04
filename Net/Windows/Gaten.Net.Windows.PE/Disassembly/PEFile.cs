using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Gaten.Net.Windows.PE.Disassembly
{
    public class PEFile
    {
        //public string Name { get; set; }
        //public string FileName { get; set; }
        //public byte[] Data { get; set; }
        //public IMAGE_DOS_HEADER ImageDOSHeader { get; set; }
        //public MS_DOS_STUB MSDOSStub { get; set; }
        //public IMAGE_NT_HEADER ImageNTHeader { get; set; }
        //public List<IMAGE_SECTION_HEADER> ImageSectionHeaders { get; set; }
        //public List<SECTION> Sections { get; set; }

        //public void ReadFile()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(FileName))
        //        {
        //            throw new Exception("File name is not exist.");
        //        }

        //        if (!File.Exists(FileName))
        //        {
        //            throw new Exception("File is not exist.");
        //        }

        //        // Read All Data
        //        Data = File.ReadAllBytes(FileName);

        //        // Read Image DOS Header
        //        ImageDOSHeader = new IMAGE_DOS_HEADER(Util.GetBytes(Data, 0, 64));

        //        // Read MS-DOS stub
        //        int NTHeaderStartIndex = ImageDOSHeader.OffsetToNewEXEHeader;
        //        MSDOSStub = new MS_DOS_STUB(Util.GetBytes(Data, 64, NTHeaderStartIndex - 64));

        //        // Read Image NT Header
        //        ImageNTHeader = new IMAGE_NT_HEADER(Util.GetBytes(Data, NTHeaderStartIndex, 248));

        //        // Read Image Section Headers
        //        int sectionHeaderStartIndex = NTHeaderStartIndex + 248;
        //        int numberOfSection = ImageNTHeader.ImageFileHeader.NumberOfSections;
        //        ImageSectionHeaders = new List<IMAGE_SECTION_HEADER>();
        //        for (int i = 0; i < numberOfSection; i++)
        //        {
        //            ImageSectionHeaders.Add(
        //                new IMAGE_SECTION_HEADER(Util.GetBytes(Data, sectionHeaderStartIndex + i * 40, 40))
        //                );
        //        }

        //        // Read Sections
        //        Sections = new List<SECTION>();
        //        foreach (IMAGE_SECTION_HEADER header in ImageSectionHeaders)
        //        {
        //            Sections.Add(
        //                new SECTION(header.NameByString, Util.GetBytes(Data, header.PointerToRawData, header.SizeOfRawData))
        //                );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public byte[] GetDisassemblyBytes()
        //{
        //    try
        //    {
        //        if (Data == null)
        //        {
        //            ReadFile();
        //        }

        //        byte[] textSectionData = Sections.Find(s => s.Name.Equals(".text")).Data;
        //        int disassemblySize = ImageSectionHeaders.Find(h => h.NameByString.Equals(".text")).VirtualSize;

        //        return Util.GetBytes(textSectionData, 0, disassemblySize);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public static PEFileDisassembly GetPEFileDisassembly(string fileName)
        {
            try
            {
                var disassembly = new PEFileDisassembly();

                //IntPtr baseAddress = GetBaseAddress(fileName);

                using (Stream stream = File.OpenRead(fileName))
                {
                    using var reader = new PEReader(stream);
                    var header = reader.PEHeaders;

                    // TEXT Section Header에 적혀있는 Virtual Address부터 Virtual Size만큼 바이트를 읽는다.
                    var textSectionHeader = header.SectionHeaders.Where(h => h.Name.Equals(".text")).First();
                    disassembly.Data = reader.GetSectionData(textSectionHeader.VirtualAddress).GetContent(0, textSectionHeader.VirtualSize).ToArray();

                    //if(baseAddress == IntPtr.Zero)
                    //{

                    if (header.PEHeader == null)
                    {
                        throw new NullReferenceException(nameof(header.PEHeader));
                    }

                    int baseAddress = (int)header.PEHeader.ImageBase;
                    //}

                    disassembly.BaseAddress = (uint)(baseAddress + textSectionHeader.VirtualAddress);
                    //disassembly.BassAddressInterval = (int)((ulong)baseAddress - reader.PEHeaders.PEHeader.ImageBase);
                }

                return disassembly;
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// BaseAddress 가져오기
        /// 실패 시 IntPtr.Zero를 반환
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static IntPtr GetBaseAddress(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                using var process = new Process();
                var myProcessStartInfo = new ProcessStartInfo()
                {
                    FileName = fileName,
                    CreateNoWindow = true
                };
                process.StartInfo = myProcessStartInfo;
                process.Start();

                Thread.Sleep(200);

                ProcessModule? processModule;
                ProcessModuleCollection myProcessModuleCollection;
                try
                {
                    myProcessModuleCollection = process.Modules;
                }
                catch (System.Exception) // MASM32로 컴파일한 파일은 실패
                {
                    return IntPtr.Zero;
                }

                for (int i = 0; i < myProcessModuleCollection.Count; i++)
                {
                    processModule = myProcessModuleCollection[i];
                }
                processModule = process.MainModule;

                IntPtr? baseAddress = processModule?.BaseAddress;

                process.CloseMainWindow();

                return baseAddress == null ? IntPtr.Zero : baseAddress.Value;
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
