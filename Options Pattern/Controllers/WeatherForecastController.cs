using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Options_Pattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CompanyOptions _companyIOptions;
        private readonly CompanyOptions _companyIOptionsSnapshot;
        private readonly CompanyOptions _companyIOptionsMonitor;


        private string CompanyName=string.Empty;
        public WeatherForecastController(IOptions<CompanyOptions> companyIOptions,
            IOptionsSnapshot<CompanyOptions> companyIOptionsSnapshot,
            IOptionsMonitor<CompanyOptions> companyIOptionsMonitor)
        {
            _companyIOptions = companyIOptions.Value;
            _companyIOptionsSnapshot = companyIOptionsSnapshot.Value;
            _companyIOptionsMonitor = companyIOptionsMonitor.CurrentValue;
            //listen to onchange and call our private OnComapnyValueChange method
            companyIOptionsMonitor.OnChange(updatedsettings => OnCompanyValueChange());
        }
        
        [HttpGet("[action]")]
        public IActionResult GetOptionsPattern()
        {
            var optionResponse = new 
            {
                IOptions = _companyIOptions.Name,
                IOptionsSnapShot = _companyIOptionsSnapshot.Name,
                IOptionsMonitor = _companyIOptionsMonitor.Name,
                CreationDate= _companyIOptionsMonitor.CreationDate
            };
            CompanyName = _companyIOptionsMonitor.Name;
            Console.WriteLine($"{CompanyName} {_companyIOptionsMonitor.CreationDate}");
            return Ok(optionResponse);
        }
        private void OnCompanyValueChange()
        {

            Console.WriteLine($"{CompanyName} is called from OnValueChange Method {_companyIOptionsMonitor.CreationDate}");

        }
  
    }
}