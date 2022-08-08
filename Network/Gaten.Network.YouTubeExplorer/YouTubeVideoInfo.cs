namespace Gaten.Network.YouTubeExplorer
{
    internal class YouTubeVideoInfo
    {
        public UrlInfo Video { get; set; } = default!;
        public UrlInfo Channel { get; set; } = default!;
        public string Length { get; set; } = string.Empty;
        public string View { get; set; } = string.Empty;
        public string Like { get; set; } = string.Empty;
        public string Upload { get; set; } = string.Empty;
        public string Reply { get; set; } = string.Empty;

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
