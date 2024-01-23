using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithPostgreSQL.Controllers
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult AuthAdmin()
        {
            var response = new
            {
                Message = "Auth is up for admin!",
                ServerTime = DateTime.Now
            };
            return Ok(response);
        }
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public ActionResult AuthUser()
        {
            var response = new
            {
                message = "Auth is up for user!",
                ServerTime = DateTime.Now
            };
            return Ok(response);
        }
    }
}