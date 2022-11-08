using MySongsWebApp.DTO;

namespace MySongsWebApp.Models
{
    public class SongViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public SongType SongType { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}