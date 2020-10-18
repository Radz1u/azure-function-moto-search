namespace Radz1u.Configuration {
    public class OlxConfiguration : BaseConfiguration {
        public string Url => Get (nameof (Url));
        public string TodayPrefix => Get (nameof (TodayPrefix));
        
        public string CultureCode => Get(nameof(CultureCode));

        public OlxConfiguration () : base (nameof (OlxConfiguration)) { }
    }
}