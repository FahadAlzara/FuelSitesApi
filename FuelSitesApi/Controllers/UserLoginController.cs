using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FuelSitesApi.Models;

namespace FuelSitesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private static User user = new User { UserName = "fahad", Password = "123" };

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.UserName == "fahad" && user.Password == "123")
                return Ok("Login successful");
            else return BadRequest("User not found");
        }
    }
}
