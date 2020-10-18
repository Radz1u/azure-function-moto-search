namespace Radz1u.Logic {
    using System.Collections.Generic;
    using System;
    using HtmlAgilityPack;
    using Radz1u.Configuration;

    public class OlxAdExtractor {
        private OlxDateParser _olxDateParser;
        
        public OlxAdExtractor (OlxConfiguration configuration) {
            _olxDateParser = new OlxDateParser (configuration);
        }

        public IEnumerable<OlxAdContract> Extract (string content) {
            var htmlDocument = new HtmlDocument ();
            htmlDocument.LoadHtml (content);
            var offers = htmlDocument.DocumentNode.SelectNodes ("//td[@class='offer']");
            foreach (var offer in offers) {
                yield return new OlxAdContract {
                    PublishDate = ExtractPublishDate (offer),
                        Url = ExtractAdUrl(offer)
                };
            }
        }

        private DateTime ExtractPublishDate (HtmlNode offer) {
            var clockData = offer.SelectNodes ("//i[@data-icon='clock']") [0];
            var dateTime = clockData.InnerText;
            return _olxDateParser.Parse (dateTime);
        }

        private string ExtractAdUrl (HtmlNode offer) {
            var linkData = offer.SelectNodes ("//a") [0];
            return linkData.GetAttributeValue ("href", "");
        }
    }
}