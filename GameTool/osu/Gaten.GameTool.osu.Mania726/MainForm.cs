using Gaten.Net.GameRule.osu.OsuFile;

namespace Gaten.GameTool.osu.Mania726
{
    public partial class MainForm : Form
    {
        public int[] ManiaXPos = { 36, 109, 182, 256, 329, 402, 475 };
        public int[] ManiaXPos6K = { 42, 128, 213, 298, 384, 469 };
        public int SelectKey = 4;
        public int ExceptType = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void osuFindButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Title = "osu파일 찾아보기";
            ofd.Filter = "osu파일(*.osu)|*.osu";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                osuTextBox.Text = ofd.FileName;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (exceptkeyButton1.Checked) SelectKey = 1;
                if (exceptkeyButton2.Checked) SelectKey = 2;
                if (exceptkeyButton3.Checked) SelectKey = 3;
                if (exceptkeyButton4.Checked) SelectKey = 4;
                if (exceptkeyButton5.Checked) SelectKey = 5;
                if (exceptkeyButton6.Checked) SelectKey = 6;
                if (exceptkeyButton7.Checked) SelectKey = 7;

                if (removeButton.Checked) ExceptType = 1;
                if (moveButton.Checked) ExceptType = 2;

                string fileName = osuTextBox.Text;
                OsuFileObject obj = new(fileName);
                obj.Read();

                if (obj.Difficulty["CircleSize"] != "7")
                {
                    MessageBox.Show("7키 아님 ㅅㄱ");
                    return;
                }

                // 난이도 이름 수정
                if (obj.Metadata["Version"] != null)
                {
                    obj.Metadata["Version"] += "(Gaten 6K)";
                }

                switch (ExceptType)
                {
                    case 1: // 제외
                        for (int i = 0; i < obj.HitObjects.Count; i++)
                        {
                            int KeyNum = Array.IndexOf(ManiaXPos, obj.HitObjects[i].X);

                            if (KeyNum < SelectKey - 1)
                            {
                                obj.HitObjects[i].X = ManiaXPos6K[KeyNum];
                            }
                            else if (KeyNum == SelectKey - 1)
                            {
                                obj.HitObjects.RemoveAt(i);
                                i--;
                            }
                            else
                            {
                                obj.HitObjects[i].X = ManiaXPos6K[KeyNum - 1];
                            }
                        }
                        break;

                    case 2: // 다른 버튼으로 이동
                        for (int i = 0; i < obj.HitObjects.Count; i++)
                        {
                            if (obj.HitObjects[i].X == ManiaXPos[SelectKey - 1])
                            {
                                obj.HitObjects.RemoveAt(i);
                                i--;
                            }
                        }
                        break;

                    default:
                        break;
                }

                string newFileName = fileName.Insert(fileName.LastIndexOf('\\') + 1, "[6K]");
                obj.Write(newFileName);
                MessageBox.Show("변환 완료!");
            }
            catch (Exception)
            {
                MessageBox.Show("누가 지금 버그 소리를 내었는가?");
            }
        }
    }
}