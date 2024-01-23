using Microsoft.EntityFrameworkCore;
using WebApiWithPostgreSQL.Contracts;
using WebApiWithPostgreSQL.Models;
using static WebApiWithPostgreSQL.DTOs.ServiceResponses;

namespace WebApiWithPostgreSQL.Repositories
{
    public class LaptopRepository(AppDbContext context) : ILaptop
    {
        public async Task<GeneralResponse> CreateProduct(Laptop newLaptop)
        {
            if (newLaptop is null) return new GeneralResponse(false, "Model is empty!");
            context.Laptops.Add(newLaptop);
            await context.SaveChangesAsync();
            return new GeneralResponse(true, "Laptop Created!");
        }
        public async Task<List<Laptop>> GetLaptops()
        {
            return await context.Laptops.ToListAsync();
        }
        public async Task<Laptop?> GetLaptop(int id)
        {
            var laptop = await context.Laptops.FirstOrDefaultAsync(laptop => laptop.LaptopId == id);
            return laptop;
        }
        public async Task<GeneralResponse> UpdateProduct(int id, Laptop updatedLaptop)
        {
            if (id != updatedLaptop.LaptopId)
            {
                return new GeneralResponse(false, "Invalid ID!");
            }
            var laptopToUpdate = await context.Laptops.FindAsync(id);
            if (laptopToUpdate == null)
            {
                return new GeneralResponse(false, "Laptop Not Found!");
            }
            context.Entry(laptopToUpdate).CurrentValues.SetValues(updatedLaptop);
            await context.SaveChangesAsync();
            return new GeneralResponse(true, "Laptop Updated!");
        }
        public async Task<GeneralResponse> DeleteProduct(int id)
        {
            var laptop = await GetLaptop(id);
            if (laptop != null)
            {
                context.Laptops.Remove(laptop);
                return new GeneralResponse(true, "Laptop Deleted!");
            }
            else
            {
                return new GeneralResponse(false, "Laptop Not Found!");
            }
        }
    }
}