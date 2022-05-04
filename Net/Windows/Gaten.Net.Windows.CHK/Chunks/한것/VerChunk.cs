namespace Gaten.Net.Windows.CHK.Chunks
{
    public class VERChunk : Chunk
    {

        public VERChunk()
        {
            Name = "VER ";
            Size = 2;

            Match();
        }

        void Match()
        {
            switch (StarcraftVersion.Version)
            {
                case StarcraftVersion._StarcraftVersion.Starcraft100:
                    AddData((ushort)59);
                    break;
                case StarcraftVersion._StarcraftVersion.Starcraft104:
                case StarcraftVersion._StarcraftVersion.Revelations:
                case StarcraftVersion._StarcraftVersion.Hybrid:
                    AddData((ushort)63);
                    break;
                case StarcraftVersion._StarcraftVersion.BroodWar:
                    AddData((ushort)205);
                    break;
                case StarcraftVersion._StarcraftVersion.Remastered:
                    AddData((ushort)206);
                    break;
            }
        }
    }
}
