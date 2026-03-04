using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Evento_Back_end.DomainModels;
using Evento_Back_end.DTOs;

namespace Evento_Front_end.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class BackendAccountController : ControllerBase
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;
        private readonly IConfiguration _configuration;

        public BackendAccountController(SignInManager<Users> signInManager, UserManager<Users> userManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this._configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
                return Unauthorized("Invalid credentials");

            // Generate JWT here
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            // Stateless if JWT
            return Ok();
        }
    }
}
