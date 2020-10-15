namespace Radz1u.Configuration
{
    using System;
    public class NotificationConfiguration : BaseConfiguration
    {
        public string From => Get(nameof(From));
        public string To  => Get(nameof(NotificationConfiguration.To));
        public string Subject => Get(nameof(NotificationConfiguration.Subject));
        public string Server =>Get(nameof(NotificationConfiguration.Server));
        public int Port => Int32.Parse(Get(nameof(NotificationConfiguration.Port)));

        public NotificationConfiguration () : base (nameof (NotificationConfiguration)) { }
    }
}