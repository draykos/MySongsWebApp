using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySongsWebApp.Controllers
{
    public class SongsController : Controller
    {
        private readonly ILogger<SettingsController> logger;

        public SongsController(ILogger<SettingsController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
