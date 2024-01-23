using WebApiWithPostgreSQL.DTOs;
using static WebApiWithPostgreSQL.DTOs.ServiceResponses;

namespace WebApiWithPostgreSQL.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}