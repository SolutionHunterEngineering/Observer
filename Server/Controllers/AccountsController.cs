using Microsoft.AspNetCore.Mvc;
using Observer.Shared;
using Shared;
using Server.Database;
using Server.Database;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            var user = Seed.Users.FirstOrDefault(u =>
                u.Username == request.Username &&
                u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(new { message = "Login successful", username = user.Username, role = user.Role });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out" });
        }
    }
}