namespace Gaten.Net.Windows.CHK.Chunks
{
    public class VCODChunk : Chunk
    {

        public VCODChunk()
        {
            Name = "VCOD";
            Size = 1040;

            Match();
        }

        void Match()
        {
            AddData(VerificationCode.Seed);
            AddData(VerificationCode.Hash);
        }
    }
}
