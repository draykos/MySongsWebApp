namespace MySongs.DTO;

public class SongDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public SongTypeDTO SongType { get; set; }
    public List<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();
}
