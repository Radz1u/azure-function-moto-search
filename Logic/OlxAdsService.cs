namespace Radz1u.Logic
{
    using System.Threading.Tasks;
    using System.Linq;
    using System;

    public class OlxAdsService
    {
        private OlxAdsReader _reader;
        
        public OlxAdsService()
        {
            _reader = new OlxAdsReader();    
        }

        public async Task CheckAds(){
            var contracts = await _reader.Read();
            var latestAds = contracts.Where(x=>x.PublishDate > > DateTime.Today.AddDays(-1));
            
            if(latestAdDate )
            {
                
            }
        }
    }
}