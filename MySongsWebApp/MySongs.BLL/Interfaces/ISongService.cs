using MySongs.DTO;

namespace MySongsWebApp.Interfaces;

public interface ISongService
{
    List<SongDTO> GetSongs();
    List<SongTypeDTO> GetTypes();
}
