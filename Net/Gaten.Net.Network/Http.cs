using System.Net;
using System.Text;

namespace Gaten.Net.Network
{
    public class Http
    {
        public static string Request(string url, string jsonString)
        {
            string returnString = string.Empty;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    returnString = client.UploadString(url, jsonString);
                }
                catch (WebException ex)
                {
                    // 예외
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            returnString = reader.ReadToEnd();
                        }
                    }
                }
            }

            return returnString;
        }
    }
}
