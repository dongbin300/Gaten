using Gaten.Net.IO;

using MySqlX.XDevAPI.Common;

using System.Net;
using System.Security.Policy;
using System.Text;

namespace Gaten.Net.Network
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
                    // 예외
                    using WebResponse response = ex.Response ?? default!;
                    var httpResponse = (HttpWebResponse)(response ?? default!);

                    using Stream stream = response?.GetResponseStream() ?? default!;
                    var reader = new StreamReader(stream);
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }

        public static string RequestDownload(string url)
        {
            string result = string.Empty;
            string fileName = url.Split('/')[^1];
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(url);
                    response.Wait();
                    GPath.TryCreateDirectory("Downloads");
                    using var stream = new FileStream("Downloads".Down(fileName), FileMode.CreateNew);
                    response.Result.Content.CopyToAsync(stream);
                }
                catch (WebException ex)
                {
                    // 예외
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
