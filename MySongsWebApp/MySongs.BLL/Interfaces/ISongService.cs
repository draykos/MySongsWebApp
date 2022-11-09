using MySongs.DTO;

namespace MySongsWebApp.Interfaces;

public interface ISongService
{
    List<Song> GetSongs();
    List<SongType> GetTypes();
}
