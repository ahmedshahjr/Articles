using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Service1.Models;
using Service1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
 
        private readonly ICustomerService _customerService;
   

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
     
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerInsert customer)
        {
            try
            {
                return Ok( await _customerService.AddCustomer(customer));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
