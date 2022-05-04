using HtmlAgilityPack;

using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Gaten.Network.WebArticleHooker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;
            string source = string.Empty;

            articleTextBox.Clear();

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                source = client.DownloadString(url);
            }

            /*var removedTagSource = RemoveTag(source);
            removedTagSource = removedTagSource.Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("	","");

            articleTextBox.AppendText(removedTagSource);*/

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            var nodes = doc.DocumentNode.SelectNodes("//body//*[not(self::script)]");
            //var nodes = doc.DocumentNode.SelectNodes("//body//*[not(self::script)][count(./*) < 1]");

            foreach (HtmlNode node in nodes)
            {
                string text = node.InnerText;

                text = text.Replace("&nbsp;", " ").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("	", "");

                if (IsEmptyString(text))
                {
                    continue;
                }

                articleTextBox.AppendText(text + "\r\n");
            }
        }

        bool IsEmptyString(string str)
        {
            return str.Select(c => c).Where(c => !c.Equals(' ')).ToList() == null;
        }

        string RemoveTag(string html)
        {
            return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }
    }
}