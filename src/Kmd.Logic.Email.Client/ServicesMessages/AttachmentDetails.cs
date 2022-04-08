using System;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class AttachmentDetails
    {
        public AttachmentDetails(Guid attachmentId)
        {
            this.AttachmentId = attachmentId;
        }

        public Guid AttachmentId { get; }
    }
}
