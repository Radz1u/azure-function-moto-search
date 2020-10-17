namespace Radz1u.Logic {
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Radz1u.Configuration;

    public class OlxAdsReader {
        private string _adUrl;
        private HttpClient _httpClient;
        private OlxAdExtractor _olxAdExtractor;

        public OlxAdsReader (OlxConfiguration configuration) {
            _adUrl = configuration.Url;
            _httpClient = new HttpClient ();
            _olxAdExtractor = new OlxAdExtractor (configuration);
        }

        public async Task<IEnumerable<OlxAdContract>> ReadAsync () {
            var content = await _httpClient.GetStringAsync (_adUrl);
            return _olxAdExtractor.Extract (content);
        }
    }
}