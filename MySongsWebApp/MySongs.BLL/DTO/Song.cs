namespace MySongs.DTO;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public SongType SongType { get; set; }
    public List<Author> Authors { get; set; } = new List<Author>();
}
