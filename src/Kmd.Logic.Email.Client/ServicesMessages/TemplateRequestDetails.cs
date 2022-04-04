using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class TemplateRequestDetails
    {
        public TemplateRequestDetails(Guid providerConfigurationId, Stream template)
        {
            this.ProviderConfigurationId = providerConfigurationId;
            this.Template = template;
        }

        /// <summary>
        /// Gets Email configuration Id.
        /// </summary>
        public Guid ProviderConfigurationId { get; }

        /// <summary>
        /// Gets memory stream of Template to be uploaded.
        /// </summary>
        public Stream Template { get; }
    }
}
