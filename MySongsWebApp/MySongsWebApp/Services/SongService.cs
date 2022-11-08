using MySongsWebApp.Controllers;
using MySongsWebApp.DTO;
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

        public List<SongViewModel> GetSongs()
        {
            logger.LogInformation("I'm getting songs");

            var author1 = new Author { Id = 10, Name = "Pink Floyd", Likes = 10000000 };
            var author2 = new Author { Id = 20, Name = "Paul Simon", Likes = 7000 };
            var author3 = new Author { Id = 30, Name = "Arl Garfunkel", Likes = 3000 };
            var author4 = new Author { Id = 40, Name = "Iron Maiden", Likes = 500000 };
            var author5 = new Author { Id = 50, Name = "Metallica", Likes = 300000 };
            var author6 = new Author { Id = 60, Name = "Greta Van Fleet", Likes = 230000 };


            return new List<SongViewModel>{
                new SongViewModel{Id=1, Title="Wish You Were Here", Authors=new List<Author>{ author1 } },
                new SongViewModel{Id=2, Title="Dark Side of The Moon", Authors=new List<Author>{ author1 } },
                new SongViewModel{Id=3, Title="The Sound of Silence", Authors=new List<Author>{ author2, author3 } },
                new SongViewModel{Id=100, Title="Fear of the Dark", Authors=new List<Author>{ author4 } },
                new SongViewModel{Id=102, Title="Run to the Hills", Authors=new List<Author>{ author5 } },
                new SongViewModel{Id=201, Title="Nothing Else Matters", Authors=new List<Author>{ author5} },
                new SongViewModel{Id=305, Title="Light My Love", Authors=new List<Author>{ author6 } },
            };
        }

        public List<SongViewModel> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}
