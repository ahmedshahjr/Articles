
namespace KeyedServices.Services
{
    public class OutlookService : IEmailService
    {
        public string SendEmailAsync(string email)
        {
            return $"{email} Outlook Service";
        }
    }
}
