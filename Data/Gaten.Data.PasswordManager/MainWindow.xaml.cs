using Gaten.Net.Data.Collections;
using Gaten.Net.Data.IO;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.Data.PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> accounts = new List<Account>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IdComboBox.Items.Clear();
            IdComboBox.Items.Add("gaten");
            IdComboBox.Items.Add("dongbin30");
            IdComboBox.Items.Add("dongbin300");
            IdComboBox.Items.Add("dongbin30@naver.com");
            IdComboBox.Items.Add("dongbin30@hanmail.net");
            IdComboBox.Items.Add("dongbin300@gmail.com");

            PasswordComboBox.Items.Clear();
            PasswordComboBox.Items.Add("n.d.d0n'b|n");
            PasswordComboBox.Items.Add("d0n'b|n1011");
            PasswordComboBox.Items.Add("d0n'b|n101!");
            PasswordComboBox.Items.Add("d0n'b|n10!!");
            PasswordComboBox.Items.Add("D0n'b|n1011");
            PasswordComboBox.Items.Add("D0n'b|n10!!");
            PasswordComboBox.Items.Add("d0n'b|n1194619");
            PasswordComboBox.Items.Add("||q|l|l");
            PasswordComboBox.Items.Add("||q|l|ls.m-_k");

            Load();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string pf = PlatformText.Text.Length < 1 ? " " : PlatformText.Text;
            string ad = DescriptionText.Text.Length < 1 ? " " : DescriptionText.Text;
            string id = IdText.Text.Length < 1 ? " " : IdText.Text;
            string pw = PasswordText.Text.Length < 1 ? " " : PasswordText.Text;
            string sp = SecondPasswordText.Text.Length < 1 ? " " : SecondPasswordText.Text;
            string dd = AdditionalDescriptionText.Text.Length < 1 ? " " : AdditionalDescriptionText.Text;

            Account account = new Account(pf, ad, id, pw, sp, dd);

            Save(account);
            Load();

            PlatformText.Clear();
            DescriptionText.Clear();
            IdText.Clear();
            PasswordText.Clear();
            SecondPasswordText.Clear();
            AdditionalDescriptionText.Clear();
            IdComboBox.SelectedIndex = -1;
            PasswordComboBox.SelectedIndex = -1;
            PlatformText.Focus();
        }

        private void IdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                IdText.Text = (string)e.AddedItems[0];
            }
        }

        private void PasswordComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                PasswordText.Text = (string)e.AddedItems[0];
            }
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = SearchText.Text.Length < 1 ? "" : SearchText.Text;

            var filteredAccounts = accounts.Where(a => a.SerialData.ToLower().Contains(keyword.ToLower())).ToList();

            DataSource source = new DataSource("Platform", "Description", "Id", "Password", "SecondPassword", "AdditionalDescription");
            foreach (var account in filteredAccounts)
            {
                source.AddRow(account.Platform, account.Description, account.ID, account.Password, account.SecondPassword, account.AdditionalDescription);
            }
            SearchDataGrid.ItemsSource = null;
            SearchDataGrid.ItemsSource = source.Data;
        }

        void Save(Account account)
        {
            GResource.AppendText("pm-data.txt", "\n" + account.SerialData);
        }

        void Load()
        {
            string[] data = GResource.GetTextLines("pm-data.txt");

            accounts.Clear();
            foreach (string d in data)
            {
                string[] dd = d.Split('$');
                Account account = new Account(dd[0], dd[1], dd[2], dd[3], dd[4], dd[5]);
                accounts.Add(account);
            }
        }
    }
}
