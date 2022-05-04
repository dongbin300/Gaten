using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaten.Windows.SpeedMacro
{
    public partial class KeyboardSettingForm : Form
    {
        private MainForm mainForm;

        public KeyboardSettingForm(MainForm frm1)
        {
            InitializeComponent();
            mainForm = frm1;
        }

        private void KeyBoardSettingForm_Load(object sender, EventArgs e)
        {
            string workString = mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex].ToString();
            keyTextBox.Text = mainForm.DataSubstring(workString, "(", ")", 0);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            mainForm.ProcedureListBox.Items[mainForm.ProcedureListBox.SelectedIndex] = $"Press({keyTextBox.Text})";
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeyTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string keyText = string.Empty;

            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl";
                else
                    keyText = "Ctrl+" + mainForm.KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.Menu)
                    keyText = "Alt";
                else
                    keyText = "Alt+" + mainForm.KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == Keys.Shift)
            {
                if (e.KeyCode == Keys.ShiftKey)
                    keyText = "Shift";
                else
                    keyText = "Shift+" + mainForm.KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Alt))
            {
                if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Alt";
                else
                    keyText = "Ctrl+Alt+" + mainForm.KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Shift";
                else
                    keyText = "Ctrl+Shift+" + mainForm.KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Alt | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                    keyText = "Alt+Shift";
                else
                    keyText = "Alt+Shift+" + mainForm.KeysString("" + e.KeyCode);
            }
            else if (e.Modifiers == (Keys.Control | Keys.Alt | Keys.Shift))
            {
                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.ControlKey)
                    keyText = "Ctrl+Alt+Shift";
                else
                    keyText = "Ctrl+Alt+Shift+" + mainForm.KeysString("" + e.KeyCode);
            }
            else
            {
                keyText = mainForm.KeysString("" + e.KeyCode);
            }
            keyTextBox.Text = keyText;
        }
    }
}
