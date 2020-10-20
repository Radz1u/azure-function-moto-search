namespace Radz1u.Configuration {
    public class OlxConfiguration : BaseConfiguration {
        public virtual string Url => Get (nameof (Url));
        public virtual string TodayPrefix => Get (nameof (TodayPrefix));
        public virtual string YesterdayPrefix => Get (nameof (YesterdayPrefix));        
        public virtual string CultureCode => Get(nameof(CultureCode));

        public OlxConfiguration () : base (nameof (OlxConfiguration)) { }
    }
}