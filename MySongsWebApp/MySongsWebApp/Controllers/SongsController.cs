using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySongs.BLL.Services;
using MySongsWebApp.Common;
using MySongsWebApp.DTO;
using MySongsWebApp.Interfaces;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

public class SongsController : Controller
{
    private readonly ILogger<SettingsController> logger;
    private readonly ISongService songService;

    public SongsController(ILogger<SettingsController> logger, ISongService songService)
    {
        this.logger = logger;
        this.songService = songService;
    }

    public IActionResult Index()
    {

        ViewData["Title"] = "Songs";

        var songs = songService.GetSongs();
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
