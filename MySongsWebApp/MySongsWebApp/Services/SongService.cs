using MySongsWebApp.Controllers;
using MySongsWebApp.Interfaces;
using MySongsWebApp.Models;

namespace MySongsWebApp.Services
{
    public class SongService : ISongService
    {
        private readonly ILogger<SongService> logger;

        public SongService(ILogger<SongService> logger)
        {
            this.logger = logger;
        }

        public List<SongModel> GetSongs()
        {
            logger.LogInformation("I'm getting songs");

            return new List<SongModel>{
                new SongModel{Id=1, Title="Wish You Were Here", Authors=new List<string>{"Pink Floyd"} },
                new SongModel{Id=2, Title="Dark Side of The Moon", Authors=new List<string>{"Pink Floyd"} },
                new SongModel{Id=3, Title="The Sound of Silence", Authors=new List<string>{"Paul Simon", "Arl Garfunkel"} },
                new SongModel{Id=100, Title="Fear of the Dark", Authors=new List<string>{"Iron Maiden"} },
                new SongModel{Id=102, Title="Run to the Hills", Authors=new List<string>{"Iron Maiden"} },
                new SongModel{Id=201, Title="Nothing Else Matters", Authors=new List<string>{"Metallica"} },
                new SongModel{Id=305, Title="Light My Love", Authors=new List<string>{"Greta Van Fleet"} },
            };
        }
    }
}
