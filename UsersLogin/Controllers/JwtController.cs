using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersLogin.Manager.Interface;
using UsersLogin.Models;

namespace UsersLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtManager jwtManager;
        public JwtController(IJwtManager jwtManager)
        {
            this.jwtManager = jwtManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken([FromBody] Users user)
        {
            return Ok(await jwtManager.JwtToken(user));
        }
    }
}
