using WebApiWithPostgreSQL.Models;
using static WebApiWithPostgreSQL.DTOs.ServiceResponses;

namespace WebApiWithPostgreSQL.Contracts
{
    public interface ILaptop
    {
        Task<GeneralResponse> CreateProduct(Laptop newLaptop);
        Task<GeneralResponse> UpdateProduct(int id, Laptop updatedLaptop);
        Task<GeneralResponse> DeleteProduct(int id);
        Task<Laptop?> GetLaptop(int id);
        Task<List<Laptop>> GetLaptops();
    }
}