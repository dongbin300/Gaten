using Gaten.Net.Data.Diagnostics;

namespace Gaten.Windows.MintMonitor
{
    internal class CheckList
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Info => Title + ": " + Content;

        public CheckList(string title, string content, string url)
        {
            Title = title;
            Content = content;
            Url = url;
        }

        public void Start()
        {
            GProcess.Start(Url);
        }
    }
}
