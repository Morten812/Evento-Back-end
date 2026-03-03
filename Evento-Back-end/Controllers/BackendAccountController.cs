using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Evento_Back_end.DomainModels;

namespace Evento_Front_end.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class BackendAccountController : ControllerBase
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;

        public BackendAccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect.");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
