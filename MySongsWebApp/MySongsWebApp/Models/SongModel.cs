namespace MySongsWebApp.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public List<string> Authors { get; set; } = new List<string>();
    }
}