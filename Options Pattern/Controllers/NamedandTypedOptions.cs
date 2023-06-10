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

        public NamedandTypedOptions(IOptionsSnapshot<CompanyOptions> idividualOptionsAccessor, IOptionsSnapshot<CompanyOptions> CoOpearteOptionsAccessor)
        {
            _individualCompany = idividualOptionsAccessor.Get(CompanyOptions.Individual);
            _coOperateCompany = CoOpearteOptionsAccessor.Get(CompanyOptions.CoOperate);

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
