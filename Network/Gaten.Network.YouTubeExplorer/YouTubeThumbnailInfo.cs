namespace Gaten.Network.YouTubeExplorer
{
    internal class YouTubeThumbnailInfo
    {
        public UrlInfo Video { get; set; }
        public UrlInfo Channel { get; set; }
        public string Length { get; set; }
        public string View { get; set; }
        public string Upload { get; set; }

        public YouTubeThumbnailInfo(string title, string videoUrl, string channel, string channelUrl, string length, string view, string upload)
        {
            Video = new UrlInfo(title, videoUrl);
            Channel = new UrlInfo(channel, channelUrl);
            Length = length;
            View = view;
            Upload = upload;
        }
    }
}
