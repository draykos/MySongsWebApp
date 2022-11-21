using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySongs.DAL.Models;
using MySongs.DAL.Students;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<SettingsController> logger;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signinManager;

    public UsersController(ILogger<SettingsController> logger, UserManager<ApplicationUser> userManager, SignInManager<IdentityUser> signinManager)
    {
        this.logger = logger;
        this.userManager = userManager;
        this.signinManager = signinManager;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UserViewModel user)
    {
        if (ModelState.IsValid)
        {
            // Here the WebUser should be saved. Afterwards we would normally return another View, to 
            // indicate that the User has been successfully created, or redirect to another page 
            logger.LogInformation("User is valid");
            return View("CreateSuccess", user);
        }
        return View();
    }

    #region Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            logger.LogInformation("register is valid");
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signinManager.SignInAsync(user, isPersistent: false);
                return View("RegisterSuccess", model);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

        }

        return View(model);
    }

    #endregion

    #region Login / Logout
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await signinManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {

        if (ModelState.IsValid)
        {
            var result = await signinManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("LoginError", "utente o password non validi");
        }

        return View(model);
    }
    #endregion

}
