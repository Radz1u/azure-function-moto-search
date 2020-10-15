namespace Radz1u.Logic
{
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using Radz1u.Configuration;

    public class OlxAdsService
    {
        private OlxAdsReader _reader;
        private NotificationService _notificationService;

        public OlxAdsService()
        {
            var configuration = new OlxConfiguration();
            _reader = new OlxAdsReader(configuration);
            _notificationService = new NotificationService();
        }

        public async Task CheckAds(){
            var contracts = await _reader.Read();
            var latestAds = contracts.Where(x=>x.PublishDate > DateTime.Today.AddDays(-1));
            
            if(latestAds.Any())
            {
                _notificationService.Send(latestAds.Select(x=>x.Url));
            }
        }
    }
}