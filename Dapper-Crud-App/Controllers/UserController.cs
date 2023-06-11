using Dapper_Crud_App.Entities;
using Dapper_Crud_App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Crud_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInsert user)
        {
            return Ok(await _userService.AddAsync(user)); 
        }

        // PUT api/<UserController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            return Ok(await _userService.UpdateAsync(user));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _userService.DeleteAsync(id));
        }
    }
}
