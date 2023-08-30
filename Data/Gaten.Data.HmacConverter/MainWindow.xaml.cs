using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.Data.HmacConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ParameterTextBox.Text = "endpoint=%2Finfo%2Faccount&order_currency=BTC";
        }

        private string GetHmacSha512(string secret, string message)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secret);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                var hashBytes = hmac.ComputeHash(messageBytes);
                return Encoding.UTF8.GetString(hashBytes);
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //var message = InputTextBox.Text;
                var message = "/info/account\0endpoint=%2Finfo%2Faccount&order_currency=BTC\01683617697430";
                var secret = "31bbf0283b77ad838825540e0721ae42";
                var hashBytes = Array.Empty<byte>();
                using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(secret)))
                {
                    hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                }
                var hex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                var apiSign = Convert.ToBase64String(Encoding.UTF8.GetBytes(hex));
            }
            catch
            {
            }
        }

        private void NonceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nonce = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds).ToString();
                NonceTextBox.Text = nonce;

                var message = $"{EndpointTextBox.Text}\0{ParameterTextBox.Text}\0{NonceTextBox.Text}";
                InputTextBox.Text = message;
            }
            catch
            {
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Base64TextBox.Text);
        }
    }
}
