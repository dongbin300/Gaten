namespace Gaten.Network.YouTubeExplorer
{
    internal class YouTubeVideoInfo
    {
        public UrlInfo Video { get; set; }
        public UrlInfo Channel { get; set; }
        public string Length { get; set; }
        public string View { get; set; }
        public string Like { get; set; }
        public string Upload { get; set; }
        public string Reply { get; set; }

        public YouTubeVideoInfo()
        {

        }

        public YouTubeVideoInfo(string title, string videoUrl, string channel, string channelUrl, string length, string view, string like, string upload)
        {
            Video = new UrlInfo(title, videoUrl);
            Channel = new UrlInfo(channel, channelUrl);
            Length = length;
            View = view;
            Like = like;
            Upload = upload;
        }
    }
}
