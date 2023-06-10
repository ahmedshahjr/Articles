using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Options_Pattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CompanyOptions _indvidiualOptions;
        private readonly CompanyOptions _coOperateOptions;

        public WeatherForecastController(IOptionsMonitor<CompanyOptions> options)
        {
          //  _indvidiualOptions = options.Get(CompanyOptions.Individual);
            _coOperateOptions = options.Get(CompanyOptions.CoOperate);


        }

        [HttpGet("[action]")]
        public IActionResult Individual()
        {
            return Ok(_indvidiualOptions);
        }
        [HttpGet("[action]")]
        public IActionResult CoOperate()
        {

            return Ok(_coOperateOptions);
        }

    }
}