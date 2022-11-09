using Microsoft.Extensions.Logging;
using MySongs.DAL;
using MySongsWebApp.DTO;
using MySongsWebApp.Interfaces;
using MySongsWebApp.Models;

namespace MySongs.BLL.Services;

public class SongService : ISongService
{
    private readonly ILogger<SongService> logger;
    private readonly MySongsContext context;

    public SongService(ILogger<SongService> logger, MySongsContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    private void TestDB()
    {
        var songs = context.Songs.ToList();
        var x = songs;

    }

    public List<Song> GetSongs()
    {
        logger.LogInformation("I'm getting songs");
        TestDB();

        var author1 = new Author { Id = 10, Name = "Pink Floyd" };
        var author2 = new Author { Id = 20, Name = "Paul Simon"};
        var author3 = new Author { Id = 30, Name = "Arl Garfunkel"};
        var author4 = new Author { Id = 40, Name = "Iron Maiden"};
        var author5 = new Author { Id = 50, Name = "Metallica"};
        var author6 = new Author { Id = 60, Name = "Greta Van Fleet"};

        var types = GetTypes();


        return new List<Song>{
            new Song{Id=1, Title="Wish You Were Here", SongType=types[0], Authors=new List<Author>{ author1 } },
            new Song{Id=2, Title="Dark Side of The Moon", SongType=types[0], Authors=new List<Author>{ author1 } },
            new Song{Id=3, Title="The Sound of Silence", SongType=types[0], Authors=new List<Author>{ author2, author3 } },
            new Song{Id=100, Title="Fear of the Dark", SongType=types[0], Authors=new List<Author>{ author4 } },
            new Song{Id=102, Title="Run to the Hills", SongType=types[0], Authors=new List<Author>{ author5 } },
            new Song{Id=201, Title="Nothing Else Matters", SongType=types[0], Authors=new List<Author>{ author5} },
            new Song{Id=305, Title="Light My Love", SongType=types[0], Authors=new List<Author>{ author6 } },
        };
    }

    public List<SongType> GetTypes()
    {
        return new List<SongType>
        {
            new SongType{Id=10, Name="Rock"},
            new SongType{Id=200, Name="Classic"},
            new SongType{Id=300, Name="Pop"},
            new SongType{Id=400, Name="Jazz"},
        };
    }
}
