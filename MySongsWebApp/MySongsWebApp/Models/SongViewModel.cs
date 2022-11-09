using MySongs.DTO;

namespace MySongsWebApp.Models;

public class SongViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public SongTypeDTO SongType { get; set; }
    public List<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();

    //This property added to show that ViewModel can be different to DTO/DAL objects
    public bool Like { get; set; } = false;

}