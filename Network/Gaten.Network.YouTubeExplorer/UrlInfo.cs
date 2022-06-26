namespace Gaten.Network.YouTubeExplorer
{
    internal class UrlInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public UrlInfo(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
