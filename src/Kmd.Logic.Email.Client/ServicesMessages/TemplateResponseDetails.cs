using System;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class TemplateResponseDetails
    {
        public TemplateResponseDetails(Guid? templateId)
        {
            this.TemplateId = templateId;
        }

        public Guid? TemplateId { get; }
    }
}
