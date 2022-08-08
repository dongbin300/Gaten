using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Data.CodeBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Property> properties = new();

        public MainWindow()
        {
            InitializeComponent();

            UsingCheckBox.IsChecked = true;
            PublicCheckBox.IsChecked = true;
            DataTypeText.Text = "string";
            GetCheckBox.IsChecked = true;
            SetCheckBox.IsChecked = true;
        }

        private void BuildCode()
        {
            try
            {
                string namespaceClassText = NamespaceClassText.Text.Length > 0 ? NamespaceClassText.Text : "";
                int idx = namespaceClassText.LastIndexOf('.');
                string namespaceText = idx == -1 ? (namespaceClassText.Length > 0 ? namespaceClassText : "") : namespaceClassText[..idx];
                string classText = idx == -1 ? "" : namespaceClassText[(idx + 1)..];

                StringBuilder? builder = new("");

                if (UsingCheckBox.IsChecked ?? true)
                {
                    _ = builder.AppendLine("using System;");
                    _ = builder.AppendLine("using System.Collections.Generic;");
                    _ = builder.AppendLine("using System.Text;");
                    _ = builder.AppendLine();
                }

                _ = builder.AppendFormat("namespace {1}{0}{{{0}\tpublic class {2}{0}\t{{{0}", Environment.NewLine, namespaceText, classText);

                foreach (Property p in properties)
                {
                    _ = builder.AppendFormat("\t\t{1} {2} {3} {4}{0}", Environment.NewLine, p.AccessModifier, p.DataType, p.Name, p.AccessorString);
                }

                _ = builder.AppendFormat("{0}\t\tpublic {1}({2}){0}\t\t{{{0}", Environment.NewLine, classText, string.Join(", ", properties.Select(p => p.ParameterString)));

                foreach (Property p in properties)
                {
                    _ = builder.AppendFormat("\t\t\t{1}{0}", Environment.NewLine, p.InitString);
                }

                _ = builder.AppendFormat("\t\t}}{0}\t}}{0}}}{0}", Environment.NewLine);

                OutText.Text = builder.ToString();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (PropertyNameText.Text.Length < 1)
            {
                _ = MessageBox.Show("속성 이름을 입력해 주세요.");
                return;
            }

            if (PropertyNameText.Text.Contains(' '))
            {
                _ = MessageBox.Show("속성 이름은 공백을 포함할 수 없습니다.");
                return;
            }

            string accessModifier = PublicCheckBox.IsChecked ?? true ? "public" : "private";
            string dataType = DataTypeText.Text.Length > 0 ? DataTypeText.Text : "object";
            string name = PropertyNameText.Text;
            string upperName = string.Concat(name[..1].ToUpper(), name.AsSpan(1));
            bool get = GetCheckBox.IsChecked ?? true;
            bool set = SetCheckBox.IsChecked ?? true;

            properties.Add(new Property(accessModifier, dataType, upperName, get, set));

            BuildCode();

            PropertyNameText.Clear();
            _ = PropertyNameText.Focus();
        }

        private void StringButton_Click(object sender, RoutedEventArgs e)
        {
            DataTypeText.Text = "string";
            _ = PropertyNameText.Focus();
        }

        private void IntButton_Click(object sender, RoutedEventArgs e)
        {
            DataTypeText.Text = "int";
            _ = PropertyNameText.Focus();
        }

        private void BoolButton_Click(object sender, RoutedEventArgs e)
        {
            DataTypeText.Text = "bool";
            _ = PropertyNameText.Focus();
        }

        private void ListStringButton_Click(object sender, RoutedEventArgs e)
        {
            DataTypeText.Text = "List<string>";
            _ = PropertyNameText.Focus();
        }

        private void ListIntButton_Click(object sender, RoutedEventArgs e)
        {
            DataTypeText.Text = "List<int>";
            _ = PropertyNameText.Focus();
        }

        private void ListBoolButton_Click(object sender, RoutedEventArgs e)
        {
            DataTypeText.Text = "List<bool>";
            _ = PropertyNameText.Focus();
        }

        private void UsingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BuildCode();
        }

        private void UsingCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            BuildCode();
        }

        private void NamespaceClassText_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuildCode();
        }

        private void GetCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetCheckBox.IsChecked = false;
        }

        private void SetCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GetCheckBox.IsChecked = true;
        }

        private void PropertyNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddButton_Click(sender, new RoutedEventArgs());
            }
        }

        private void ClipboardCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OutText.Text);
            _ = MessageBox.Show("복사가 완료되었습니다.\r\n에디터에 붙여넣기 하세요.");
        }
    }
}
