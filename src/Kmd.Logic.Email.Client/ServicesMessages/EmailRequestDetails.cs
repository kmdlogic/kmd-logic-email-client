using System;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class EmailRequestDetails
    {
        public EmailRequestDetails(Guid requestId, Guid subscriptionId)
        {
            this.RequestId = requestId;
            this.SubscriptionId = subscriptionId;
        }

        public Guid RequestId { get; }

        public Guid SubscriptionId { get; }
    }
}
