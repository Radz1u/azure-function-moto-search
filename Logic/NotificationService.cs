namespace Radz1u.Logic
{
    using System.Net.Mail;
    using System;
    using System.Collections.Generic;

    public class NotificationService
    {
        private readonly SmtpClient _smtpClient;
        private const string _from = "aa@aa.com";
        private const string _to   = "aa@aa.com";
        private const string _subject = "subject";

        public NotificationService(){
            var server = "";
            var port = 0;
            _smtpClient = new SmtpClient(server,port);
        }

        public void Send(IEnumerable<string> adUrls)
        {
            var body = string.Join(System.Environment.NewLine,adUrls);

            var message = new MailMessage(_from,_to,_subject,body);
            
            _smtpClient.Send(message);
        }
    }
}