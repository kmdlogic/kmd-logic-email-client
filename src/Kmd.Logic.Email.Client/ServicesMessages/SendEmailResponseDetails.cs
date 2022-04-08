using System;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class SendEmailResponseDetails
    {
        public SendEmailResponseDetails(Guid emailRequestId)
        {
            this.EmailRequestId = emailRequestId;
        }

        public Guid EmailRequestId { get; set; }
    }
}
