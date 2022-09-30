using Gaten.Net.Extensions;

namespace Gaten.Net.Stock.MercuryTradingModel.IO
{
    public class BackTestTmFile
    {
        public string FileName { get; set; } = string.Empty;
        public string Name => FileName.GetOnlyFileName();
        public string MenuString => Name + " 실행";

        public BackTestTmFile(string fileName)
        {
            FileName = fileName;
        }

        public override string ToString()
        {
            return FileName + "|+|" + Name + "|+|" + MenuString;
        }
    }
}
