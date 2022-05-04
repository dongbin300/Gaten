namespace Gaten.Net.Windows.CHK.Chunks
{
    public class TYPEChunk : Chunk
    {

        public TYPEChunk()
        {
            Name = "TYPE";
            Size = 4;

            Match();
        }

        void Match()
        {
            switch (StarcraftVersion.Version)
            {
                case StarcraftVersion._StarcraftVersion.Starcraft100:
                case StarcraftVersion._StarcraftVersion.Starcraft104:
                case StarcraftVersion._StarcraftVersion.Revelations:
                case StarcraftVersion._StarcraftVersion.Hybrid:
                    AddData(1398227282);
                    break;
                case StarcraftVersion._StarcraftVersion.BroodWar:
                case StarcraftVersion._StarcraftVersion.Remastered:
                    AddData(1113014610);
                    break;
            }
        }
    }
}
