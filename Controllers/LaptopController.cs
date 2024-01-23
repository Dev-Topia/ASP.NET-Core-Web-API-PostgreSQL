using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiWithPostgreSQL.Contracts;
using WebApiWithPostgreSQL.Models;
using WebApiWithPostgreSQL.Repositories;

namespace WebApiWithPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController(ILaptop laptop) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateLaptop(Laptop newLaptop)
        {
            var response = await laptop.CreateProduct(newLaptop);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetLaptops()
        {
            return Ok(await laptop.GetLaptops());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLaptop(int id)
        {
            var response = await laptop.GetLaptop(id);
            if (response == null)
            {
                ModelState.AddModelError("LaptopId", "Laptop doesn't exist anymore.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return new BadRequestObjectResult(problemDetails);
            }
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLaptop(int id, Laptop updateLaptop)
        {
            var response = await laptop.UpdateProduct(id, updateLaptop);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLaptop(int id)
        {
            var response = await laptop.DeleteProduct(id);
            return Ok(response);
        }
    }
}