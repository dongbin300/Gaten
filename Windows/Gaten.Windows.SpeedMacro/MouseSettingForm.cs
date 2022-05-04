namespace Gaten.Windows.SpeedMacro
{
    public partial class MouseSettingForm : Form
    {
        private MainForm mainForm;

        public MouseSettingForm(MainForm frm1)
        {
            InitializeComponent();
            mainForm = frm1;
        }

        private void MouseSettingForm_Load(object sender, EventArgs e)
        {
            string workString = mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex].ToString();
            xPosTextBox.Text = mainForm.DataSubstring(workString, "(", ",", 0);
            yPosTextBox.Text = mainForm.DataSubstring(workString, ", ", ")", 0);
            switch (workString.Split('(')[0])
            {
                case "Click":
                    clickTypeComboBox.SelectedIndex = 0;
                    break;
                case "DClick":
                    clickTypeComboBox.SelectedIndex = 1;
                    break;
                case "RClick":
                    clickTypeComboBox.SelectedIndex = 2;
                    break;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            switch (clickTypeComboBox.SelectedIndex)
            {
                case 0:
                    mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex] = $"Click({xPosTextBox.Text}, {yPosTextBox.Text})";
                    break;
                case 1:
                    mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex] = $"DClick({xPosTextBox.Text}, {yPosTextBox.Text})";
                    break;
                case 2:
                    mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex] = $"RClick({xPosTextBox.Text}, {yPosTextBox.Text})";
                    break;
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
