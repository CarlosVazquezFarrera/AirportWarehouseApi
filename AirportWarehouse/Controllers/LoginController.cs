using AirportWarehouse.Core.Request;
using AirportWarehouse.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController(ILoginService loginService)
        {
           _loginService = loginService;
        }

        private readonly ILoginService _loginService;


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest user)
        {
            var existingAgent = await _loginService.Login(user);
            return existingAgent is null ? NotFound() : Ok(existingAgent);
        }
    }
}
