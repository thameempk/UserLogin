using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersLogin.Manager.Interface;
using UsersLogin.Models;

namespace UsersLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager loginManager;
        public LoginController(ILoginManager loginManager)
        {
            this.loginManager = loginManager;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] Login login)
        {
            return Ok(await loginManager.LoginUser(login));
        }

    }
}
