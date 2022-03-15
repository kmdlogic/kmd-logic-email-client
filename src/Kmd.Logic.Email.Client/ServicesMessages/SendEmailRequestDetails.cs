using Kmd.Logic.Email.Client.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class SendEmailRequestDetails
    {
        public SendEmailRequestDetails(
            Guid providerConfigurationId,
            RecipientEmailDetails recipients,
            string body,
            string subject,
            IList<AttachmentDetails> attachment,
            Schedule schedule,
            Guid? templateId,
            JObject mergeData,
            string callbackUrl = null)
        {
            this.ProviderConfigurationId = providerConfigurationId;
            this.Body = body;
            this.Recipients = recipients;
            this.Subject = subject;
            this.Attachment = attachment;
            this.Schedule = schedule;
            this.TemplateId = templateId;
            this.MergeData = mergeData;
            this.CallbackUrl = callbackUrl;
        }

        public Guid ProviderConfigurationId { get; }

        public string Body { get; }

        public string Subject { get; }

        public RecipientEmailDetails Recipients { get; set; }

        public IList<AttachmentDetails> Attachment { get; }

        public Schedule Schedule { get; }

        public Guid? TemplateId { get; }

        public JObject MergeData { get; }

        public string CallbackUrl { get; }
    }
}
