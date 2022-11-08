using MySongsWebApp.DTO;
using MySongsWebApp.Models;

namespace MySongsWebApp.Interfaces;

public interface ISongService
{
    List<Song> GetSongs();
    List<SongType> GetTypes();
}
