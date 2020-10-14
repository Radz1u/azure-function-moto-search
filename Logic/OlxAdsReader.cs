namespace Radz1u.Logic {
    using System.Net.Http;
    using System.Threading.Tasks;
  
    public class OlxAdsReader {
        private string _adUrl;
        private HttpClient _httpClient;
        private OlxAdExtractor _olxAdExtractor;

        public OlxAdsReader () {
            _adUrl = "https://www.olx.pl/motoryzacja/motocykle-skutery/q-street-triple/?search%5Bfilter_enum_mark%5D%5B0%5D=triumph&search%5Bfilter_float_price%3Ato%5D=15000&search%5Bfilter_float_year%3Afrom%5D=2009&search%5Bfilter_enum_condition%5D%5B0%5D=notdamaged";
            _httpClient = new HttpClient ();
            _olxAdExtractor = new OlxAdExtractor();
        }

        public async Task<OlxAdContract[]> Read () {
            var content = await _httpClient.GetStringAsync (_adUrl);
            return null;
        }
    }
}