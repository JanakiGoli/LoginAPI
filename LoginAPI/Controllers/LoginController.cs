using LoginAPI.Models;
using LoginAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository userRepo;
        public LoginController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin loginRequest)
        {
            var user = await userRepo.LoginAsync(loginRequest.username,loginRequest.password);
           
            if (user != null && user.password == loginRequest.password && user.username == loginRequest.username)
            {
                return Ok("Login success");
            }
            return BadRequest("username or password is incorrect");
        }
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(Register register)
        {
            if (register == null)
                return BadRequest();
            var newUser = new Register { 
                username = register.username,
                password = register.password,
                Email = register.Email
            };
            await userRepo.RegisterAsync(newUser);
            return Ok("User created successfully");
        }
    }
}
