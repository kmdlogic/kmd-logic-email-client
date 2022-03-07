namespace Kmd.Logic.Email.Client.ServicesMessages
{
    /// <summary>
    /// This class will be used as MSExchange Configuration type data to be created using EmailClient.cs.
    /// </summary>
    public class MSExchangeConfigurationRequestDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MSExchangeConfigurationRequestDetails"/> class.
        /// </summary>
        /// <param name="configurationName">Name of the configuration.</param>
        /// <param name="fromAddress">From email address.</param>
        public MSExchangeConfigurationRequestDetails(string configurationName, string fromAddress)
        {
            this.ConfigurationName = configurationName;
            this.FromAddress = fromAddress;
        }

        /// <summary>
        /// Gets the name of the configuration.
        /// </summary>
        public string ConfigurationName { get; }

        /// <summary>
        /// Gets the name of the from address.
        /// </summary>
        public string FromAddress { get; }
    }
}
