using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerTopiaStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        public UsersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "AllUsers")]
        public async Task<ActionResult> GetAll()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }
    }
}