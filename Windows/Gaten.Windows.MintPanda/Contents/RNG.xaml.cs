using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Network;

using System;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;


namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// RNG.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RNG : Window
    {
        public static string key = string.Empty;

        public RNG()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RNG), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RNG), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public static void Init()
        {
            try
            {
                key = GResource.GetText("randomorg_api.txt");
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RNG), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public static string Get(int min, int max)
        {
            try
            {
                var data = new RNG_generateIntegers(
                    "2.0",
                    "generateIntegers",
                    new RNG_generateIntegers_params(key, 1, min, max),
                    DateTime.Now.Millisecond);

                var jsonString = JsonSerializer.Serialize(data);
                var response = Http.Request("https://api.random.org/json-rpc/4/invoke", jsonString);
                var responseObject = JsonSerializer.Deserialize<RNG_response_generateIntegers>(response) ?? default!;

                return responseObject.result.random.data[0].ToString();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RNG), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return string.Empty;
        }

        private void RNGButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RNGResultText.Text = Get(int.Parse(RNGMin.Text), int.Parse(RNGMax.Text));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(RNG), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }

    record RNG_generateIntegers(string jsonrpc, string method, RNG_generateIntegers_params @params, int id);
    record RNG_generateIntegers_params(string apiKey, int n, int min, int max);

    record RNG_response_generateIntegers(RNG_response_generateIntegers_result result);
    record RNG_response_generateIntegers_result(RNG_response_generateIntegers_result_random random);
    record RNG_response_generateIntegers_result_random(int[] data);
}
