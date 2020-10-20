namespace Radz1u.Logic
{
    using System.Collections.Generic;
    using Radz1u.Configuration;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;

    public class NotificationService
    {
        private readonly NotificationConfiguration _configuration;
        private readonly string _url;
        private readonly SendGridClient _sendGridClient;

        public NotificationService(){
            _configuration = new NotificationConfiguration();
            _url = new OlxConfiguration().Url;
            _sendGridClient=  new SendGridClient(_configuration.SendGridApiKey);
        }

        public async Task SendAsync()
        {
            var emailFrom = new EmailAddress(_configuration.From);
            var emailTo= new EmailAddress(_configuration.To);
            var msg = MailHelper.CreateSingleEmail(emailFrom,emailTo,_configuration.Subject,_url,string.Empty);
            await _sendGridClient.SendEmailAsync(msg);
        }
    }
}