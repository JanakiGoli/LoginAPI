using LoginAPI.Models;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace LoginAPI.Repository
{
    public interface IUserRepository
    {
        Task<UserLogin> LoginAsync(string username, string password);
       
        Task<Register> RegisterAsync(Register register);

    }
}
