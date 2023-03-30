using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Gaten.Windows.MintPandaLinux.Utils
{
    public class Http
    {
        public static string RequestPost(string url, string jsonString)
        {
            string result = string.Empty;

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.PostAsync(url, content);
                    response.Wait();
                }
                catch (WebException ex)
                {
                    using WebResponse response = ex.Response ?? default!;
                    var httpResponse = (HttpWebResponse)(response ?? default!);

                    using Stream stream = response?.GetResponseStream() ?? default!;
                    var reader = new StreamReader(stream);
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
