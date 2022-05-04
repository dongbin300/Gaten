using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Gaten.Net.Windows.CHK.Chunks;

namespace CHKFormat
{
    public class ManualExecute
    {
        static ChkChunk cc;
        static bool Run;
        enum Status
        {
            None,
            Make,
            PlayerSystem,
            Terrain,
            StareditTerrain,
            IsometricTerrain,
            PlaySystem,
            FogOfWar,
            Location,
            String,
            Export
        }
        static Status CurrentStatus;

        public ManualExecute()
        {
            Run = true;

            Thread statusWorker = new Thread(new ThreadStart(CheckStatus));
            statusWorker.Start();

            Setting();
            Make();

            CurrentStatus = Status.Make;

            Export();

            CurrentStatus = Status.Export;

            Run = false;
        }

        static void Setting()
        {

        }

        static void Make()
        {
            cc = new ChkChunk();
        }

        static void Export()
        {
            using(FileStream stream = new FileStream("out.chk", FileMode.Create))
            {
                using(BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(cc.VERChunk.ToBytes());
                    writer.Write(cc.TYPEChunk.ToBytes());
                    writer.Write(cc.IVE2Chunk.ToBytes());
                    writer.Write(cc.VCODChunk.ToBytes());
                    writer.Write(cc.IOWNChunk.ToBytes());
                    writer.Write(cc.OWNRChunk.ToBytes());
                    writer.Write(cc.SIDEChunk.ToBytes());
                    writer.Write(cc.COLRChunk.ToBytes());
                    writer.Write(cc.ERAChunk.ToBytes());
                    writer.Write(cc.DIMChunk.ToBytes());
                    CurrentStatus = Status.PlayerSystem;
                    writer.Write(cc.MTXMChunk.ToBytes());
                    CurrentStatus = Status.Terrain;
                    writer.Write(cc.TILEChunk.ToBytes());
                    CurrentStatus = Status.StareditTerrain;
                    writer.Write(cc.ISOMChunk.ToBytes());
                    CurrentStatus = Status.IsometricTerrain;
                    writer.Write(cc.UNITChunk.ToBytes());
                    writer.Write(cc.PUNIChunk.ToBytes());
                    writer.Write(cc.UNIXChunk.ToBytes());
                    writer.Write(cc.PUPXChunk.ToBytes());
                    writer.Write(cc.UPGXChunk.ToBytes());
                    CurrentStatus = Status.PlaySystem;
                    writer.Write(cc.DD2Chunk.ToBytes());
                    writer.Write(cc.THG2Chunk.ToBytes());
                    writer.Write(cc.MASKChunk.ToBytes());
                    CurrentStatus = Status.FogOfWar;
                    writer.Write(cc.MRGNChunk.ToBytes());
                    CurrentStatus = Status.Location;
                    writer.Write(cc.STRXChunk.ToBytes());
                    CurrentStatus = Status.String;
                    writer.Write(cc.SPRPChunk.ToBytes());
                    writer.Write(cc.FORCChunk.ToBytes());
                    writer.Write(cc.WAVChunk.ToBytes());
                    writer.Write(cc.PTEXChunk.ToBytes());
                    writer.Write(cc.TECXChunk.ToBytes());
                    writer.Write(cc.MBRFChunk.ToBytes());
                    writer.Write(cc.TRIGChunk.ToBytes());
                    writer.Write(cc.UPRPChunk.ToBytes());
                    writer.Write(cc.UPUSChunk.ToBytes());
                    writer.Write(cc.SWNMChunk.ToBytes());
                }
            }
        }

        static void CheckStatus()
        {
            while (Run)
            {
                Thread.Sleep(10);

                switch (CurrentStatus)
                {
                    case Status.Make:
                        Console.WriteLine("Make Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.PlayerSystem:
                        Console.WriteLine("PlayerSystem Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.Terrain:
                        Console.WriteLine("Terrain Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.StareditTerrain:
                        Console.WriteLine("StareditTerrain Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.IsometricTerrain:
                        Console.WriteLine("IsometricTerrain Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.PlaySystem:
                        Console.WriteLine("PlaySystem Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.FogOfWar:
                        Console.WriteLine("FogOfWar Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.Location:
                        Console.WriteLine("Location Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.String:
                        Console.WriteLine("String Complete.");
                        CurrentStatus = Status.None;
                        break;
                    case Status.Export:
                        Console.WriteLine("Export Complete.");
                        CurrentStatus = Status.None;
                        break;
                    default:
                       // CurrentStatus = Status.None;
                        break;
                }
            }
        }
    }
}