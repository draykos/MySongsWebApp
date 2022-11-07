using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySongsWebApp.Models;

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

            var songs = new List<SongModel>{
                new SongModel{Id=1, Title="Wish You Were Here", Authors=new List<string>{"Pink Floyd"} },
                new SongModel{Id=2, Title="Dark Side of The Moon", Authors=new List<string>{"Pink Floyd"} },
                new SongModel{Id=3, Title="The Sound of Silence", Authors=new List<string>{"Paul Simon", "Arl Garfunkel"} },
                new SongModel{Id=100, Title="Fear of the Dark", Authors=new List<string>{"Iron Maiden"} },
                new SongModel{Id=102, Title="Run to the Hills", Authors=new List<string>{"Iron Maiden"} },
                new SongModel{Id=201, Title="Nothing Else Matters", Authors=new List<string>{"Metallica"} },
                new SongModel{Id=305, Title="Light My Love", Authors=new List<string>{"Greta Van Fleet"} },
            };
            ViewData["Title"] = "Songs";
            ViewData["Songs"] = songs;

            return View();
        }
    }
}
