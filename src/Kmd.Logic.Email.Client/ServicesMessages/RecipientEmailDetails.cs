using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class RecipientEmailDetails
    {
        public RecipientEmailDetails(string email)
        {
            this.Email = email;
        }

        public string Email { get; }
    }
}
