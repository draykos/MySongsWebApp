using MySongs.DTO;

namespace MySongs.BLL.Interfaces;

public interface ISongService
{
    List<SongDTO> GetSongs();
    List<SongTypeDTO> GetTypes();
}
