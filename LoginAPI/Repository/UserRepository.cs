using LoginAPI.Data;
using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoginAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<UserLogin> LoginAsync(string username,string password)
        {
            var user = await context.UserLogins.FirstOrDefaultAsync(x => x.username.ToLower() == username.ToLower() && x.password == password);
            if (user == null)
                return null;
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<Register> RegisterAsync(Register register)
        {
            var user = new Register
            { 
                username = register.username, 
                password = register.password,
                Email = register.Email
            };
            context.UserRegister.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
