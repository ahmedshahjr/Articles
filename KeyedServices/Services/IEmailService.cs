namespace KeyedServices.Services
{
    public interface IEmailService
    {
        string SendEmailAsync(string email);
    }
}
