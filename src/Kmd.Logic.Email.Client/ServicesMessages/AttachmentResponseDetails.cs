using System;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class AttachmentResponseDetails
    {
        public AttachmentResponseDetails(Guid? attachmentId)
        {
            this.AttachmentId = attachmentId;
        }

        public Guid? AttachmentId { get; set; }
    }
}
