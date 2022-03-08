using Kmd.Logic.Identity.Authorization;

namespace Kmd.Logic.Email.Client.ConfigurationSample
{
    /// <summary>
    /// Class to get configuration details.
    /// </summary>
    internal class AppConfiguration
    {
        /// <summary>
        /// Gets or sets authorization token.
        /// </summary>
        public LogicTokenProviderOptions TokenProvider { get; set; } = new LogicTokenProviderOptions();

        /// <summary>
        /// Gets or sets Email configuration options.
        /// </summary>
        public EmailOptions EmailOptions { get; set; } = new EmailOptions();
    }
}
