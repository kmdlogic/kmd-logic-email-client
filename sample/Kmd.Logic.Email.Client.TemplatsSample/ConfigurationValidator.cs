using Serilog;

namespace Kmd.Logic.Email.Client.TemplateSample
{
    /// <summary>
    /// Class to validate configuration details.
    /// </summary>
    internal class ConfigurationValidator
    {
        private readonly AppConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationValidator"/> class.
        /// </summary>
        /// <param name="configuration">Email configuration details.</param>
        public ConfigurationValidator(AppConfiguration configuration)
        {
            this.configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        internal bool Validate()
        {
            if (string.IsNullOrWhiteSpace(this.configuration.TokenProvider?.ClientId)
                || string.IsNullOrWhiteSpace(this.configuration.TokenProvider?.ClientSecret)
                || string.IsNullOrWhiteSpace(this.configuration.TokenProvider?.AuthorizationScope))
            {
                Log.Error(
                    "Invalid configuration. Please provide proper information to `appsettings.json`. Current data is: {@Settings}",
                    this.configuration);

                return false;
            }

            if (this.configuration.EmailOptions?.SubscriptionId == null)
            {
                Log.Error(
                    "Invalid configuration. Email must have a configured SubscriptionId in `appsettings.json`. Current data is: {@Settings}",
                    this.configuration);

                return false;
            }

            return true;
        }
    }
}