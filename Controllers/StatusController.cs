using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [Authorize]
        [HttpGet("auth", Name = "AuthStatus")]
        public ActionResult AuthStatus()
        {
            var response = new
            {
                Message = "Auth is up!.",
                ServerTime = DateTime.Now
            };
            return Ok(response);
        }
    }
}