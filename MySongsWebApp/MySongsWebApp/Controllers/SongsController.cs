using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySongsWebApp.Interfaces;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers
{
    public class SongsController : Controller
    {
        private readonly ILogger<SettingsController> logger;
        private readonly ISongService songProvider;

        public SongsController(ILogger<SettingsController> logger, ISongService songProvider)
        {
            this.logger = logger;
            this.songProvider = songProvider;
        }

        public IActionResult Index()
        {

            ViewData["Title"] = "Songs";
            ViewData["Songs"] = songProvider.GetSongs();

            return View();
        }
    }
}
