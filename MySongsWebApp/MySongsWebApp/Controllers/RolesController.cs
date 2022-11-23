using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

public class RolesController : Controller
{
    private readonly ILogger<SettingsController> logger;
    private readonly RoleManager<IdentityRole> roleManager;

    public RolesController(ILogger<SettingsController> logger, RoleManager<IdentityRole> roleManager)
    {
        this.logger = logger;
        this.roleManager = roleManager;
    }

    [Authorize]
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Roles"] = roleManager.Roles.ToList();
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Index(RoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = new IdentityRole(model.RoleName);
            var result = await roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        ViewData["Roles"] = roleManager.Roles.ToList();
        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var roles = roleManager.Roles.ToList();
        var role = roles.Find(r => r.Name == id);
        if(role != null)
        {
            var result = await roleManager.DeleteAsync(role);
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


}
