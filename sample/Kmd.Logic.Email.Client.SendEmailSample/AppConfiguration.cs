using Kmd.Logic.Email.Client.ServicesMessages;
using Kmd.Logic.Identity.Authorization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Kmd.Logic.Email.Client.SendEmailSample
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

        /// <summary>
        /// Gets or sets a unique identifier that represents the associated configuration
        /// which this Email message will be sent with.
        /// </summary>
        public Guid ProviderConfigurationId { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");

        /// <summary>
        /// Gets or sets email message body.
        /// </summary>
        public string Body { get; set; } = "Email body message";

        public string Subject { get; set; } = "Email subject";

        /// <summary>
        /// Gets or sets the service window, if specified, will determine when Email are delivered. Email sent outside of the
        /// service window will be queued until the start of the next service window.
        /// </summary>
        public ScheduleDetails Schedule { get; set; } = null;

        /// <summary>
        /// Gets or sets identifier of template to be used.
        /// </summary>
        public Guid? TemplateId { get; set; } = null;

        /// <summary>
        /// Gets or sets dynamic values to be merged inside the template.
        /// </summary>
        public JObject MergeData { get; set; } = null;

        /// <summary>
        /// Gets or sets if provided, this URL endpoint will receive a POST request when there is any
        /// change of the Email status (e.g. sending, sent and failed).
        /// </summary>
        public string CallbackUrl { get; set; } = null;

        // Id of the attachment sent with email
        public static List<AttachmentDetails> EmailAttachments()
        {
            return new List<AttachmentDetails>
            {
                new AttachmentDetails(new Guid("00000000-0000-0000-0000-000000000000")),
                new AttachmentDetails(new Guid("00000000-0000-0000-0000-000000000000")),
            };
        }

        // Email addresses for sending email
        public static IList<EmailAddressDetails> ToEmailRecipients()
        {
            return new List<EmailAddressDetails>
            {
                new EmailAddressDetails("To Email address 1"),
                new EmailAddressDetails("To Email address 2"),
            };
        }

        public static IList<EmailAddressDetails> CcEmailRecipients()
        {
            return new List<EmailAddressDetails>
            {
                new EmailAddressDetails("Cc Email address 1"),
                new EmailAddressDetails("Cc Email address 2"),
            };
        }

        public static IList<EmailAddressDetails> BccEmailRecipients()
        {
            return new List<EmailAddressDetails>
            {
                new EmailAddressDetails("Bcc Email address 1"),
                new EmailAddressDetails("Bcc Email address 2"),
            };
        }
    }
}
