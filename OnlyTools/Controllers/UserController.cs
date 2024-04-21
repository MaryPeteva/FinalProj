using OnlyTools.Infrastructure.Data.IdentityModels;
using OnlyTools.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.User;

namespace OnlyTools.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserServices userServices;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
             IUserServices _userServices)

        {
            userManager = _userManager;
            signInManager = _signInManager;
            userServices = _userServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Generate the email confirmation token
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                // Redirect to a page where the user can manually confirm their email
                return RedirectToAction("ConfirmEmail", "User", new { userId = user.Id, token });
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home"); // Or any other action you prefer
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Error", "Home"); // User not found
            }

            // Confirm the user's email using the provided token
            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                ViewData["ConfirmationStatus"] = "Email confirmed successfully!";
            }
            else
            {
                ViewData["ConfirmationStatus"] = "Email confirmation failed. Please try again.";
            }

            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            Guid id = GetUserId();
            UserModel profile = await userServices.GetProfileAsync(id);
            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            Guid id = GetUserId();
            UserModel userProfile = await userServices.GetProfileAsync(id);
            return View(userProfile);
        }

        [HttpPost]
        public void UploadPicture(IFormFile pic)
        {
            if (pic == null || pic.Length == 0)
            {
                RedirectToAction("Profile");
            }
            else
            {
                Guid id = GetUserId();
                userServices.UploadProfilePicture(id, pic);
                RedirectToAction("Profile");
            }
        }

    }
}