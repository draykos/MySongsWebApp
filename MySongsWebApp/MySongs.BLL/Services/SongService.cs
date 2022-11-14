using Microsoft.Extensions.Logging;
using MySongs.DAL.Models;
using MySongs.DTO;
using MySongs.BLL.Interfaces;

namespace MySongs.BLL.Services;

public class SongService : ISongService
{
    private readonly ILogger<SongService> logger;
    private readonly SongsDbContext context;

    public SongService(ILogger<SongService> logger, SongsDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public List<SongDTO> GetSongs()
    {
        logger.LogInformation("I'm getting songs");
        var songs = context.Songs.ToList();
        var songTypes = GetTypes();
        var authors = GetAuthors();
        var types = GetTypes();

        //This map is fake and only for training purposes
        return songs.Select(s => new SongDTO
        {
            Id = s.Id,
            Title = s.Title,
            SongType = songTypes.FirstOrDefault(t => t.Id == s.Id) ?? new SongTypeDTO(),
            Authors = new List<AuthorDTO> { GetRandomAuthor(authors) }
        }).ToList();


        //return new List<SongDTO>{
        //    new SongDTO{Id=1, Title="Wish You Were Here", SongType=types[0], Authors=new List<AuthorDTO>{ author1 } },
        //    new SongDTO{Id=2, Title="Dark Side of The Moon", SongType=types[0], Authors=new List<AuthorDTO>{ author1 } },
        //    new SongDTO{Id=3, Title="The Sound of Silence", SongType=types[0], Authors=new List<AuthorDTO>{ author2, author3 } },
        //    new SongDTO{Id=100, Title="Fear of the Dark", SongType=types[0], Authors=new List<AuthorDTO>{ author4 } },
        //    new SongDTO{Id=102, Title="Run to the Hills", SongType=types[0], Authors=new List<AuthorDTO>{ author5 } },
        //    new SongDTO{Id=201, Title="Nothing Else Matters", SongType=types[0], Authors=new List<AuthorDTO>{ author5} },
        //    new SongDTO{Id=305, Title="Light My Love", SongType=types[0], Authors=new List<AuthorDTO>{ author6 } },
        //};
    }

    public List<SongTypeDTO> GetTypes()
    {
        return new List<SongTypeDTO>
        {
            new SongTypeDTO{Id=10, Name="Rock"},
            new SongTypeDTO{Id=200, Name="Classic"},
            new SongTypeDTO{Id=300, Name="Pop"},
            new SongTypeDTO{Id=400, Name="Jazz"},
        };
    }

    private AuthorDTO GetRandomAuthor(List<AuthorDTO> authors)
    {
        Random r = new Random();
        return authors[r.Next(0, authors.Count - 1)];
    }

    public List<AuthorDTO> GetAuthors()
    {
        return new List<AuthorDTO>
        {
            new AuthorDTO { Id = 10, Name = "Pink Floyd" },
            new AuthorDTO { Id = 20, Name = "Paul Simon" },
            new AuthorDTO { Id = 30, Name = "Arl Garfunkel" },
            new AuthorDTO { Id = 40, Name = "Iron Maiden" },
            new AuthorDTO { Id = 50, Name = "Metallica" },
            new AuthorDTO { Id = 60, Name = "Greta Van Fleet" },
        };
    }

}
