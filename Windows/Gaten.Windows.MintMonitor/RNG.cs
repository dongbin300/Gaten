using Gaten.Net.Data;
using Gaten.Net.Network;

using System.Text.Json;

namespace Gaten.Windows.MintMonitor
{
    internal class RNG
    {
        public static string key = string.Empty;

        public static void Init()
        {
            key = CommonResource.GetText("randomorg_api.txt");
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
                var responseObject = JsonSerializer.Deserialize<RNG_response_generateIntegers>(response);

                return responseObject.result.random.data[0].ToString();
            }
            catch
            {

            }

            return string.Empty;
        }
    }

    record RNG_generateIntegers(string jsonrpc, string method, RNG_generateIntegers_params @params, int id);
    record RNG_generateIntegers_params(string apiKey, int n, int min, int max);

    record RNG_response_generateIntegers(RNG_response_generateIntegers_result result);
    record RNG_response_generateIntegers_result(RNG_response_generateIntegers_result_random random);
    record RNG_response_generateIntegers_result_random(int[] data);
}
