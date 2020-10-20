namespace Radz1u.Logic {
    using System.Collections.Generic;
    using System;
    using HtmlAgilityPack;
    using Radz1u.Configuration;
    using System.Linq;

    public class OlxAdExtractor {
        private OlxDateParser _olxDateParser;
        
        public OlxAdExtractor (OlxConfiguration configuration) {
            _olxDateParser = new OlxDateParser (configuration);
        }

        public IEnumerable<OlxAdContract> Extract (string content) {
            var htmlDocument = new HtmlDocument ();
            htmlDocument.LoadHtml (content);
            var offerNodes = htmlDocument
            .DocumentNode
            .SelectNodes ("//div[@class='offer-wrapper']");

            foreach(var offer in offerNodes)
            {
                var publishDate = ExtractPublishDate (offer);

                 yield return new OlxAdContract{
                     PublishDate = publishDate
                 };
            }
        }

        private DateTime ExtractPublishDate (HtmlNode offer) {
            var clockIconNodes = offer.SelectNodes(".//span//i[@data-icon='clock']");

            var clockIconNode = clockIconNodes.First();
            var dateTime = clockIconNode.ParentNode.InnerText;
            return _olxDateParser.Parse (dateTime);
        }
    }
}