using Gaten.Net.Extension;

using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace Gaten.Net.Windows.PE.Build
{
    public class PEFile
    {
        public static void Make(bool Is64BitAddress = false)
        {
            PEHeaderBuilder headerBuilder = new(
                machine: Machine.I386,
                sectionAlignment: 4096,
                fileAlignment: 512,
                imageBase: 4194304,
                majorLinkerVersion: 48,
                minorLinkerVersion: 0,
                majorOperatingSystemVersion: 4,
                minorOperatingSystemVersion: 0,
                majorImageVersion: 0,
                minorImageVersion: 0,
                majorSubsystemVersion: 4,
                minorSubsystemVersion: 0,
                subsystem: Subsystem.WindowsGui,
                dllCharacteristics: 0,
                //DllCharacteristics.DynamicBase | 
                //DllCharacteristics.NxCompatible | 
                //DllCharacteristics.NoSeh | 
                //DllCharacteristics.TerminalServerAware,
                imageCharacteristics: 
                Characteristics.RelocsStripped | 
                Characteristics.ExecutableImage | 
                Characteristics.LineNumsStripped | 
                Characteristics.LocalSymsStripped | 
                Characteristics.Bit32Machine | 
                (Is64BitAddress ? Characteristics.LargeAddressAware : 0),
                sizeOfStackReserve: 1048576,
                sizeOfStackCommit: 4096,
                sizeOfHeapReserve: 1048576,
                sizeOfHeapCommit: 4096
                );

            PEHeaderBuilder headerBuilder2 = new();

            BlobBuilder blobBuilder = new();
            MetadataBuilder metadataBuilder = new();

            #region bbbb
            var bbb = (
                "A1 00 20 40 00 3B 05 04 20 40 00 7F 22 74 2C 7C " +
                "36 C7 05 00 20 40 00 EF BE AD DE C7 05 04 20 40 " +
                "00 EF BE AD DE C7 05 08 20 40 00 EF BE AD DE C7 " +
                "05 08 20 40 00 01 00 00 00 EB 18 C7 05 08 20 40 " +
                "00 02 00 00 00 EB 0C C7 05 08 20 40 00 03 00 00 " +
                "00 EB 00 C3").ToBytes();
            #endregion

            metadataBuilder.GetOrAddBlob(bbb);
             
            ManagedPEBuilder peBuilder = new(
                headerBuilder,
                new MetadataRootBuilder(metadataBuilder),
                blobBuilder
                );

            peBuilder.Serialize(blobBuilder);

            using FileStream stream = new("petest.exe", FileMode.OpenOrCreate, FileAccess.Write);
            blobBuilder.WriteContentTo(stream);
        }
    }
}
