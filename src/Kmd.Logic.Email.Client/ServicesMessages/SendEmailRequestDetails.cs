using Kmd.Logic.Email.Client.Models;
using System;
using System.Collections.Generic;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class SendEmailRequestDetails
    {
        public SendEmailRequestDetails(
            Guid providerConfigurationId,
            string importance,
            RecipientEmailDetails recipients,
            string body,
            string subject,
            IList<AttachmentDetails> attachment,
            Schedule schedule,
            TemplateData? template,
            string callbackUrl = null)
        {
            this.ProviderConfigurationId = providerConfigurationId;
            this.Importance = importance;
            this.Body = body;
            this.Recipients = recipients;
            this.Subject = subject;
            this.Attachment = attachment;
            this.Schedule = schedule;
            this.Template = template;
            this.CallbackUrl = callbackUrl;
        }

        public Guid ProviderConfigurationId { get; }

        public string Importance { get; }

        public string Body { get; }

        public string Subject { get; }

        public RecipientEmailDetails Recipients { get; set; }

        public IList<AttachmentDetails> Attachment { get; }

        public Schedule Schedule { get; }

        public TemplateData Template { get; }

        public string CallbackUrl { get; }
    }
}
