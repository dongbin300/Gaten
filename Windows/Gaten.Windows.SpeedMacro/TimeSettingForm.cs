namespace Gaten.Windows.SpeedMacro
{
    public partial class TimeSettingForm : Form
    {
        private MainForm mainForm;

        public TimeSettingForm(MainForm frm1)
        {
            InitializeComponent();
            mainForm = frm1;
        }

        private void TimeSettingForm_Load(object sender, EventArgs e)
        {
            string workString = mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex].ToString();
            waitTextBox.Text = mainForm.DataSubstring(workString, "(", "ms", 0);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex] = $"Wait({waitTextBox.Text}ms)";
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
