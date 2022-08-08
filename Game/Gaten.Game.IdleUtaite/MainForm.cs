namespace Gaten.Game.IdleUtaite
{
    public partial class MainForm : Form
    {
        private readonly Me me = new();
        private readonly Studio.Studio studio = new();

        public MainForm()
        {
            InitializeComponent();
            timer.Start();

            Init();
        }

        private void Init()
        {
            studio.AddMusic();
            foreach (Music music in studio.musics)
            {
                _ = musicListBox.Items.Add(music.title);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            me.ReCalculate();
            Refresh();
        }

        private new void Refresh()
        {
            moneyLabel.Text = me.money.ToString();
            followerLabel.Text = me.follower.ToString();
            awarenessLabel.Text = me.awareness.ToString();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void MusicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Music selectedMusic = studio.musics.Find(m => m.title == (sender as ListBox).SelectedItem.ToString());
            musicInfoLabel.Text = $"���: {selectedMusic.title}, �ְ���: {selectedMusic.highestNote}, ���볭�̵�: {selectedMusic.rhythmDifficulty}\r\n��Ʈ�ν�Ʈ: {selectedMusic.hitBoost}";
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            studio.recordedMusic = studio.musics.Find(m => m.title == musicListBox.SelectedItem.ToString());
            _ = MessageBox.Show("���� �Ϸ�.");
        }

        private void StudioTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedTab.Text)
            {
                case "����":
                    break;
                case "�ͽ�":
                    break;
                case "�Ϸ�":
                    break;
                case "����":
                    break;
                case "�۰�":
                    break;
            }
        }
    }
}