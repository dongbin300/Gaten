using Gaten.GameTool.GITADORA.GDRS.RealSkill;
using Gaten.Net.Extension;
using Gaten.Net.GameRule.GITADORA;

namespace Gaten.GameTool.GITADORA.GDRS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TestParse();
        }

        void Log(string text)
        {
            logListBox.Items.Add(text);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
            Log($"{fileName[0].GetFileName()}을 불러옵니다.");

            ParseStart(fileName[0]);
        }

        void ParseStart(string fileName)
        {
            var fumenFile = new FumenFile();
            fumenFile.MakePath(fileName);

            //Log("Path 생성 완료.");
            string title = "";
            int bpm = 118;
            /*switch(fileName.Split('d')[0])
            {
                case "965": title = "7층"; bpm = 196; break;
                case "1112": title = "란카키라"; bpm = 200; break;
                case "1116": title = "졸렬"; bpm = 195; break;
            }*/

            var teacher = new FumenTeacher();
            teacher.Parse(fumenFile, bpm);

            Log($"{title} [리딩]: {string.Format("{0:0.000}", teacher.Reading.Score)}, 탐: {string.Format("{0:0.000}", teacher.Reading.TomDensity)}, 노트: {string.Format("{0:0.000}", teacher.Reading.NoteDensity)}, " +
                $"[체력]: {string.Format("{0:0.000}", teacher.Stamina.Score)}, 페달: {string.Format("{0:0.000}", teacher.Stamina.PedalDensity)}, 노래길이: {string.Format("{0:0.000}", teacher.Stamina.SongLength)}, 노트수: {string.Format("{0:0.000}", teacher.Stamina.NoteCount)}, [민첩]: {string.Format("{0:0.000}", teacher.Agility.Score)}, [집중]: {string.Format("{0:0.000}", teacher.Concentration.Score)}, [정확도]: {string.Format("{0:0.000}", teacher.Accuracy.Score)}");
        }

        void TestParse()
        {
            ParseStart("205de.txt");
            /*ParseStart("965db.txt");
            ParseStart("965da.txt");
            ParseStart("965de.txt");
            ParseStart("965dm.txt");
            ParseStart("1112db.txt");
            ParseStart("1112da.txt");
            ParseStart("1112de.txt");
            ParseStart("1112dm.txt");
            ParseStart("1116db.txt");
            ParseStart("1116da.txt");
            ParseStart("1116de.txt");
            ParseStart("1116dm.txt");*/
        }
    }
}