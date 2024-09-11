using KeyedServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyedServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEmailService _emailService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, [FromKeyedServices(nameof(EmailServiceEnum.Gmail))] IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpGet(Name = "SendEmail")]
        public string SendEmail()
        {
           return _emailService.SendEmailAsync("Sending Email From");
        }
    }
}
