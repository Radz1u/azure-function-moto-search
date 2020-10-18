namespace Radz1u.Configuration {
    using System;
    public class NotificationConfiguration : BaseConfiguration {
        public string From => Get (nameof (From));
        public string To => Get (nameof (NotificationConfiguration.To));
        public string Subject => Get (nameof (NotificationConfiguration.Subject));
        public string SendGridApiKey => Get (nameof (SendGridApiKey));

        public NotificationConfiguration () : base (nameof (NotificationConfiguration)) { }
    }
}