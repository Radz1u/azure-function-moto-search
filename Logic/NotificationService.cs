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
        private readonly SendGridClient _sendGridClient;

        public NotificationService(){
            _configuration = new NotificationConfiguration();
            _sendGridClient=  new SendGridClient(_configuration.SendGridApiKey);
        }

        public async Task SendAsync(IEnumerable<string> adUrls)
        {
            var body = string.Join(System.Environment.NewLine,adUrls);
            var emailFrom = new EmailAddress(_configuration.From);
            var emailTo= new EmailAddress(_configuration.To);
            var msg = MailHelper.CreateSingleEmail(emailFrom,emailTo,_configuration.Subject,body,string.Empty);
            await _sendGridClient.SendEmailAsync(msg);
        }
    }
}