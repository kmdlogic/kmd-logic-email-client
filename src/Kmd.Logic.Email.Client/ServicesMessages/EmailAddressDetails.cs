namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class EmailAddressDetails
    {
        public EmailAddressDetails(string email = default(string))
        {
            this.Email = email;
        }

        public string Email { get; set; }
    }
}
