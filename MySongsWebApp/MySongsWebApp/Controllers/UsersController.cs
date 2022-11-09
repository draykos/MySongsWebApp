using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySongsWebApp.Common;
using MySongsWebApp.DTO;
using MySongsWebApp.Interfaces;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<SettingsController> logger;

    public UsersController(ILogger<SettingsController> logger)
    {
        this.logger = logger;
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
}
