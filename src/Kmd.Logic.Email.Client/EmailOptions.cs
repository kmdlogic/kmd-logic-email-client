using System;

namespace Kmd.Logic.Email.Client
{
    /// <summary>
    /// Provide the configuration options for using the Email service.
    /// </summary>
    public sealed class EmailOptions
    {
        /// <summary>
        /// Gets or sets the Logic Email service.
        /// </summary>
        /// <remarks>
        /// This option should not be overridden except for testing purposes.
        /// </remarks>
        public Uri EmailServiceUri { get; set; } = new Uri("https://gateway.kmdlogic.io/email/v1");

        /// <summary>
        /// Gets or sets the Logic Subscription.
        /// </summary>
        public Guid SubscriptionId { get; set; }
    }
}
