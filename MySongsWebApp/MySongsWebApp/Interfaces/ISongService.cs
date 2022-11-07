using MySongsWebApp.Models;

namespace MySongsWebApp.Interfaces
{
    public interface ISongService
    {
        List<SongModel> GetSongs();
    }
}
