using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySongsWebApp.Controllers;

public class SettingsController : Controller
{
    private readonly ILogger<SettingsController> logger;

    public SettingsController(ILogger<SettingsController> logger)
    {
        this.logger = logger;
    }

    public IActionResult Index()
    {
        logger.LogInformation("Hello, I'm settings");
        return View();
    }
}
