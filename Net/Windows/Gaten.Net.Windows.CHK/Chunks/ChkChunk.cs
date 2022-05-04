
using Gaten.Net.GameRule.StarCraft.PlayerSystem;
using Gaten.Net.GameRule.StarCraft.PlaySystem;
using Gaten.Net.GameRule.StarCraft.Region;
using Gaten.Net.GameRule.StarCraft.Region.Map;
using Gaten.Net.GameRule.StarCraft.Script;
using Gaten.Net.Windows.CHK;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class ChkChunk
    {
        public Player Player { get; set; }
        public Force Force { get; set; }
        public List<PlacedUnit> PlacedUnits { get; set; }
        public UnitSet UnitSet { get; set; }
        public WeaponSet WeaponSet { get; set; }
        public UpgradeSet UpgradeSet { get; set; }
        public List<Doodad> Doodads { get; set; }
        public List<Sprite> Sprites { get; set; }
        public LocationSet LocationSet { get; set; }
        public GameRule.StarCraft.Script.String String { get; set; }
        public TechSet TechSet { get; set; }
        public TriggerSet TriggerSet { get; set; }
        public CUWPSet CUWPSet { get; set; }
        public SwitchSet SwitchSet { get; set; }

        public VERChunk VERChunk { get; set; }
        public TYPEChunk TYPEChunk { get; set; }
        public IVE2Chunk IVE2Chunk { get; set; }
        public VCODChunk VCODChunk { get; set; }
        public IOWNChunk IOWNChunk { get; set; }
        public OWNRChunk OWNRChunk { get; set; }
        public SIDEChunk SIDEChunk { get; set; }
        public COLRChunk COLRChunk { get; set; }
        public ERAChunk ERAChunk { get; set; }
        public DIMChunk DIMChunk { get; set; }
        public MTXMChunk MTXMChunk { get; set; }
        public TILEChunk TILEChunk { get; set; }
        public ISOMChunk ISOMChunk { get; set; }
        public UNITChunk UNITChunk { get; set; }
        public PUNIChunk PUNIChunk { get; set; }
        public UNIXChunk UNIXChunk { get; set; }
        public PUPXChunk PUPXChunk { get; set; }
        public UPGXChunk UPGXChunk { get; set; }
        public DD2Chunk DD2Chunk { get; set; }
        public THG2Chunk THG2Chunk { get; set; }
        public MASKChunk MASKChunk { get; set; }
        public MRGNChunk MRGNChunk { get; set; }
        public STRXChunk STRXChunk { get; set; }
        public SPRPChunk SPRPChunk { get; set; }
        public FORCChunk FORCChunk { get; set; }
        public WAVChunk WAVChunk { get; set; }
        public PTEXChunk PTEXChunk { get; set; }
        public TECXChunk TECXChunk { get; set; }
        public MBRFChunk MBRFChunk { get; set; }
        public TRIGChunk TRIGChunk { get; set; }
        public UPRPChunk UPRPChunk { get; set; }
        public UPUSChunk UPUSChunk { get; set; }
        public SWNMChunk SWNMChunk { get; set; }

        public ChkChunk()
        {
            Init();

            VERChunk = new VERChunk();
            TYPEChunk = new TYPEChunk();
            IVE2Chunk = new IVE2Chunk();

            VCODChunk = new VCODChunk();

            IOWNChunk = new IOWNChunk(Player);
            OWNRChunk = new OWNRChunk(Player);
            SIDEChunk = new SIDEChunk(Player);
            COLRChunk = new COLRChunk(Player);

            ERAChunk = new ERAChunk();
            DIMChunk = new DIMChunk();

            MTXMChunk = new MTXMChunk();
            TILEChunk = new TILEChunk();
            ISOMChunk = new ISOMChunk();

            UNITChunk = new UNITChunk(PlacedUnits);
            PUNIChunk = new PUNIChunk(UnitSet);
            UNIXChunk = new UNIXChunk(UnitSet, WeaponSet);

            PUPXChunk = new PUPXChunk(UpgradeSet);
            UPGXChunk = new UPGXChunk(UpgradeSet);

            DD2Chunk = new DD2Chunk(Doodads);
            THG2Chunk = new THG2Chunk(Sprites);

            MASKChunk = new MASKChunk();
            MRGNChunk = new MRGNChunk(LocationSet);

            STRXChunk = new STRXChunk(String);

            SPRPChunk = new SPRPChunk();

            FORCChunk = new FORCChunk(Player);

            WAVChunk = new WAVChunk();

            PTEXChunk = new PTEXChunk(TechSet);
            TECXChunk = new TECXChunk(TechSet);

            MBRFChunk = new MBRFChunk();
            TRIGChunk = new TRIGChunk(TriggerSet);

            UPRPChunk = new UPRPChunk(CUWPSet);
            UPUSChunk = new UPUSChunk(CUWPSet);

            SWNMChunk = new SWNMChunk(SwitchSet);
        }

        void Init()
        {
            _ = new StarcraftVersion();
            _ = new VerificationCode();
            Player = new Player();
            Force = new Force();
            _ = new Base();
            _ = new Terrain();
            _ = new StareditTerrain();
            _ = new IsometricTerrain();
            PlacedUnits = new List<PlacedUnit>();
            UnitSet = new UnitSet();
            WeaponSet = new WeaponSet();
            UpgradeSet = new UpgradeSet();
            Doodads = new List<Doodad>();
            Sprites = new List<Sprite>();
            _ = new FogOfWar();
            LocationSet = new LocationSet();
            String = new GameRule.StarCraft.Script.String();
            _ = new Scenario();
            _ = new ForceSet();
            _ = new Wav();
            TechSet = new TechSet();
            TriggerSet = new TriggerSet();
            CUWPSet = new CUWPSet();
            SwitchSet = new SwitchSet();

            Renovate();

            Console.WriteLine("Make Complete.");
        }

        void Renovate()
        {
            //StarcraftVersion.Version = StarcraftVersion._StarcraftVersion.BroodWar;
            //Player.Colors[0] = Player.Color.Azure;

            //Base.TileSet = Base.MapTileSet.Arctic;
            //Base.HorizontalDimension = Base.MapDimension.Size192;

            for (int i = 5; i < 15; i++)
            {
                Util.SetTile(2, i, 90);
            }
        }

        public void Show()
        {
        }
    }
}
