using MySongsWebApp.DTO;
using MySongsWebApp.Models;

namespace MySongsWebApp.Interfaces
{
    public interface ISongService
    {
        List<SongViewModel> GetSongs();
        List<SongViewModel> GetTypes();
    }
}
