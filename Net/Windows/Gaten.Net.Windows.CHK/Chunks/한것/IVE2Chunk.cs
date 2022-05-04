namespace Gaten.Net.Windows.CHK.Chunks
{
    public class IVE2Chunk : Chunk
    {

        public IVE2Chunk()
        {
            Name = "IVE2";
            Size = 2;

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
                case StarcraftVersion._StarcraftVersion.BroodWar:
                case StarcraftVersion._StarcraftVersion.Remastered:
                    AddData((ushort)11);
                    break;
            }
        }
    }
}
