using Gaten.Net.GameRule.osu;
using Gaten.Net.GameRule.osu.OsbFile;
using Gaten.Net.GameRule.osu.OsuFile;

namespace Gaten.GameTool.osu.Macro
{
    internal class SBGenerator
    {
        public SBGenerator(string fileName)
        {
            Log("OSU파일을 분석중입니다.");
            OsuFileObject obj = new (fileName);
            Log("OSB파일을 생성중입니다.");
            OsbFileObject sbObj = NoteParser.ToOsbFileObject(obj, fileName);
            sbObj.WriteToOsbFile();
            Log("OSB파일을 생성했습니다.");
        }

        void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
