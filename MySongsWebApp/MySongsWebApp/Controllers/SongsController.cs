using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySongsWebApp.Common;
using MySongsWebApp.DTO;
using MySongsWebApp.Interfaces;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

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

        var songs = songProvider.GetSongs();
        ViewData["Songs"] = Mapper.MapSongs(songs);

        return View();
    }

    public IActionResult Create(SongViewModel song)
    {
        if(!ModelState.IsValid)
        {
            return View(song);
        }
        return Content("Success");
    }
}
