namespace Radz1u.Configuration {
    using System;

    public class BaseConfiguration {
        private readonly string _configurationName;

        protected BaseConfiguration (string configurationName) {
            _configurationName = configurationName;
        }

        protected string Get (string propertyName) {
            return Environment.GetEnvironmentVariable ( _configurationName.ToUpper() + "_" + propertyName.ToUpper());
        }
    }
}