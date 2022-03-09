using System;
using System.Collections.Generic;
using System.Text;

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
