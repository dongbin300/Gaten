
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
        public Player Player { get; set; } = default!;
        public Force Force { get; set; } = default!;
        public List<PlacedUnit> PlacedUnits { get; set; } = default!;
        public UnitSet UnitSet { get; set; } = default!;
        public WeaponSet WeaponSet { get; set; } = default!;
        public UpgradeSet UpgradeSet { get; set; } = default!;
        public List<Doodad> Doodads { get; set; } = default!;
        public List<Sprite> Sprites { get; set; } = default!;
        public LocationSet LocationSet { get; set; } = default!;
        public GameRule.StarCraft.Script.String String { get; set; } = default!;
        public TechSet TechSet { get; set; } = default!;
        public TriggerSet TriggerSet { get; set; } = default!;
        public CUWPSet CUWPSet { get; set; } = default!;
        public SwitchSet SwitchSet { get; set; } = default!;

        public VERChunk VERChunk { get; set; } = default!;
        public TYPEChunk TYPEChunk { get; set; } = default!;
        public IVE2Chunk IVE2Chunk { get; set; } = default!;
        public VCODChunk VCODChunk { get; set; } = default!;
        public IOWNChunk IOWNChunk { get; set; } = default!;
        public OWNRChunk OWNRChunk { get; set; } = default!;
        public SIDEChunk SIDEChunk { get; set; } = default!;
        public COLRChunk COLRChunk { get; set; } = default!;
        public ERAChunk ERAChunk { get; set; } = default!;
        public DIMChunk DIMChunk { get; set; } = default!;
        public MTXMChunk MTXMChunk { get; set; } = default!;
        public TILEChunk TILEChunk { get; set; } = default!;
        public ISOMChunk ISOMChunk { get; set; } = default!;
        public UNITChunk UNITChunk { get; set; } = default!;
        public PUNIChunk PUNIChunk { get; set; } = default!;
        public UNIXChunk UNIXChunk { get; set; } = default!;
        public PUPXChunk PUPXChunk { get; set; } = default!;
        public UPGXChunk UPGXChunk { get; set; } = default!;
        public DD2Chunk DD2Chunk { get; set; } = default!;
        public THG2Chunk THG2Chunk { get; set; } = default!;
        public MASKChunk MASKChunk { get; set; } = default!;
        public MRGNChunk MRGNChunk { get; set; } = default!;
        public STRXChunk STRXChunk { get; set; } = default!;
        public SPRPChunk SPRPChunk { get; set; } = default!;
        public FORCChunk FORCChunk { get; set; } = default!;
        public WAVChunk WAVChunk { get; set; } = default!;
        public PTEXChunk PTEXChunk { get; set; } = default!;
        public TECXChunk TECXChunk { get; set; } = default!;
        public MBRFChunk MBRFChunk { get; set; } = default!;
        public TRIGChunk TRIGChunk { get; set; } = default!;
        public UPRPChunk UPRPChunk { get; set; } = default!;
        public UPUSChunk UPUSChunk { get; set; } = default!;
        public SWNMChunk SWNMChunk { get; set; } = default!;

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
