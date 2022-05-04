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
            Log($"{fileName[0].GetFileName()}�� �ҷ��ɴϴ�.");

            ParseStart(fileName[0]);
        }

        void ParseStart(string fileName)
        {
            var fumenFile = new FumenFile();
            fumenFile.MakePath(fileName);

            //Log("Path ���� �Ϸ�.");
            string title = "";
            int bpm = 118;
            /*switch(fileName.Split('d')[0])
            {
                case "965": title = "7��"; bpm = 196; break;
                case "1112": title = "��īŰ��"; bpm = 200; break;
                case "1116": title = "����"; bpm = 195; break;
            }*/

            var teacher = new FumenTeacher();
            teacher.Parse(fumenFile, bpm);

            Log($"{title} [����]: {string.Format("{0:0.000}", teacher.Reading.Score)}, Ž: {string.Format("{0:0.000}", teacher.Reading.TomDensity)}, ��Ʈ: {string.Format("{0:0.000}", teacher.Reading.NoteDensity)}, " +
                $"[ü��]: {string.Format("{0:0.000}", teacher.Stamina.Score)}, ���: {string.Format("{0:0.000}", teacher.Stamina.PedalDensity)}, �뷡����: {string.Format("{0:0.000}", teacher.Stamina.SongLength)}, ��Ʈ��: {string.Format("{0:0.000}", teacher.Stamina.NoteCount)}, [��ø]: {string.Format("{0:0.000}", teacher.Agility.Score)}, [����]: {string.Format("{0:0.000}", teacher.Concentration.Score)}, [��Ȯ��]: {string.Format("{0:0.000}", teacher.Accuracy.Score)}");
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