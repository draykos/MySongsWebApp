using MySongs.DTO;
using MySongsWebApp.Models;

namespace MySongsWebApp.Common
{
    public static class Mapper
    {
        public static List<SongViewModel> MapSongs(List<SongDTO> songs)
        {
            return songs.Select(s => new SongViewModel
            {
                Id = s.Id,
                Authors = s.Authors,
                Like = false,
                SongType = s.SongType,
                Title = s.Title,
            }).ToList();
        }
    }
}
