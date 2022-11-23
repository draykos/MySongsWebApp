using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySongs.DAL.Students;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<SettingsController> logger;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signinManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public UsersController(ILogger<SettingsController> logger, 
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signinManager,
        RoleManager<IdentityRole> roleManager)
    {
        this.logger = logger;
        this.userManager = userManager;
        this.signinManager = signinManager;
        this.roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = userManager.Users.ToList();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var user = userManager.Users.FirstOrDefault(r => r.UserName == id);
        if(user != null)
        {
            var roles = await userManager.GetRolesAsync(user);
            ViewData["UserRoles"] = roles;
        }

        ViewData["Roles"] = roleManager.Roles.ToList();
        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> AddAdminRole(string id)
    {
        var user = userManager.Users.FirstOrDefault(r => r.UserName == id);
        if (user != null)
        {
            var result = await userManager.AddToRoleAsync(user, "Admin");
        }

        return RedirectToAction("Details", new { Id = id });
    }

    [HttpGet]
    public async Task<IActionResult> RemoveAdminRole(string id)
    {
        var user = userManager.Users.FirstOrDefault(r => r.UserName == id);
        if (user != null)
        {
            var result = await userManager.RemoveFromRoleAsync(user, "Admin");
        }

        return RedirectToAction("Details", new { Id = id });
    }



    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var user = userManager.Users.FirstOrDefault(r => r.UserName == id);
        if (user != null)
        {
            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return RedirectToAction(nameof(Index));
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
