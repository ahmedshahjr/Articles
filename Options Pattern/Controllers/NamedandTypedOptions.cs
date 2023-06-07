using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Options_Pattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamedandTypedOptions : ControllerBase
    {
        private readonly CompanyOptions _individualCompany;
        private readonly CompanyOptions _coOperateCompany;

        public NamedandTypedOptions(IOptions<CompanyOptions> namedOndividualOptionsAccessor, IOptions<CompanyOptions> namedCoOpearteOptionsAccessor)
        {
            _individualCompany = namedOndividualOptionsAccessor.Value;
            _coOperateCompany = namedCoOpearteOptionsAccessor.Value;

        }
        [HttpGet("[action]")]
        public IActionResult GetOptionsPattern()
        { 
            return Ok(new
            {
                _individualCompany,
                _coOperateCompany
            });
        }
    }
}
