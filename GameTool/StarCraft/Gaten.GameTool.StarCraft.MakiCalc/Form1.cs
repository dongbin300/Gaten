namespace Gaten.GameTool.StarCraft.MakiCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            int v1 = int.Parse(t1.Text);
            int v2 = int.Parse(t2.Text);
            int v3 = int.Parse(t3.Text);
            int v4 = int.Parse(t4.Text);
            int v5 = int.Parse(t5.Text);
            int v6 = int.Parse(t6.Text);
            int v7 = int.Parse(t7.Text);
            int v8 = int.Parse(t8.Text);
            int v9 = int.Parse(t9.Text);
            int v10 = int.Parse(t10.Text);
            int v11 = int.Parse(t11.Text);

            int vSum = v1 + v2 * v3 + Sigma(v4, v5, v6) + Sigma(v7, v8, v9) + v10;
            int value = (int)(vSum * (0.01 * v11));

            resultTextBox.Text = value.ToString();
        }

        int Sigma(int start, int gap, int count)
        {
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                result += start + gap * i;
            }
            return result;
        }
    }
}