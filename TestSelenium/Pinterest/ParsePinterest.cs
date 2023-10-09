using HtmlAgilityPack;
using System.Net;

namespace ImgesTelegramBot.Pinterest
{
    internal class ParsePinterest
    {
        private HtmlDocument _htmlDocument;

        public List<string> LinksToImages { get; private set; }
        public string HtmlDocument { get; set; }

        public ParsePinterest(string HtmlDocument)
        {
            LinksToImages = new List<string>();
            _htmlDocument = new HtmlDocument();
            this.HtmlDocument = HtmlDocument;

            SearchLinksToImages();
        }

        private void SearchLinksToImages()
        {
            _htmlDocument.LoadHtml(HtmlDocument);

            foreach (HtmlNode link in _htmlDocument.DocumentNode.SelectNodes("//img"))
            {
                if(link.GetAttributeValue("src", "").Contains("236"))
                    LinksToImages.Add(link.GetAttributeValue("src", "").Replace("236","564"));
            }
        }

        public async void DownloadImage(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), "Pictures_From_Pinterest\\last_img.jpg");
            }
        }

    }
}
