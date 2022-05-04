namespace Gaten.Game.GangHwaProject
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = "텍스트박스에 무기이름을 적어주시고,\r\n강화버튼을 누르면 됩니다.\r\n강화를 성공하면 다음 강화 확률이 낮아지고,\r\n강화를 실패하면 다음 강화 확률이 높아집니다.\r\n\r\n참 쉽죠잉~?";
        }
    }
}
