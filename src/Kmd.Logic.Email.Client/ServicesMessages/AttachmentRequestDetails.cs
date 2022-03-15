using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class AttachmentRequestDetails
    {
        public AttachmentRequestDetails(Guid providerConfigurationId, Stream attachment)
        {
            this.ProviderConfigurationId = providerConfigurationId;
            this.Attachment = attachment;
        }

        /// <summary>
        /// Gets Email configuration Id.
        /// </summary>
        public Guid ProviderConfigurationId { get; }

        /// <summary>
        /// Gets memory stream of Attachment to be uploaded.
        /// </summary>
        public Stream Attachment { get; }
    }
}
