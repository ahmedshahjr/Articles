
namespace KeyedServices.Services
{
    public class GmailService : IEmailService
    {
        public string SendEmailAsync(string email)
        {
            return $"{email} Gmail Service";
        }
    }
}
