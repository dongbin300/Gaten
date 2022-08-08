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
            musicInfoLabel.Text = $"∞Ó∏Ì: {selectedMusic.title}, √÷∞Ì¿Ω: {selectedMusic.highestNote}, ∏ÆµÎ≥≠¿Ãµµ: {selectedMusic.rhythmDifficulty}\r\n»˜∆Æ∫ŒΩ∫∆Æ: {selectedMusic.hitBoost}";
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            studio.recordedMusic = studio.musics.Find(m => m.title == musicListBox.SelectedItem.ToString());
            _ = MessageBox.Show("≥Ï¿Ω øœ∑·.");
        }

        private void StudioTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedTab.Text)
            {
                case "≥Ï¿Ω":
                    break;
                case "πÕΩÃ":
                    break;
                case "¿œ∑Ø":
                    break;
                case "øµªÛ":
                    break;
                case "¿€∞Ó":
                    break;
            }
        }
    }
}