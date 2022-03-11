using System.Collections.Generic;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class RecipientEmailDetails
    {
        public RecipientEmailDetails(IList<EmailAddressDetails> to, IList<EmailAddressDetails> cc, IList<EmailAddressDetails> bcc)
        {
            this.To = to;
            this.Cc = cc;
            this.Bcc = bcc;
        }

        public IList<EmailAddressDetails> To { get; set; }

        public IList<EmailAddressDetails> Cc { get; set; }

        public IList<EmailAddressDetails> Bcc { get; set; }

    }
}
