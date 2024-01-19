using ComputerTopiaStoreApi.Models;
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
        public async Task<ActionResult> Get(
            string username = "",
            int page = 1,
            int pageSize = 10
        )
        {
            var query = context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(u => u.Username == username);
            }
            var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPut("{id:int}", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] User user)
        {
            var existingUser = await context.Users.FindAsync(user.UserId);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            await context.SaveChangesAsync();
            return Ok(existingUser);
        }
        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult> AddUser([FromBody] User newUser)
        {
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            return Ok(newUser);
        }
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var existingUser = await context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            context.Users.Remove(existingUser);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}