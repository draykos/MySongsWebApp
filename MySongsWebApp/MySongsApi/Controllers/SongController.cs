using Microsoft.AspNetCore.Mvc;
using MySongs.DTO;
using MySongs.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MySongsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        private readonly ISongService songService;

        public SongController(ILogger<SongController> logger, ISongService songService)
        {
            _logger = logger;
            this.songService = songService;
        }

        [HttpGet(Name = "get-songs")]
        public IEnumerable<SongDTO> Get()
        {
            var songs = songService.GetSongs();
            return songs;
        }
    }
}