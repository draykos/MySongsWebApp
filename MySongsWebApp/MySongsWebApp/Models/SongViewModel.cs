using MySongs.DTO;

namespace MySongsWebApp.Models;

public class SongViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public SongType SongType { get; set; }
    public List<Author> Authors { get; set; } = new List<Author>();

    //This property added to show that ViewModel can be different to DTO/DAL objects
    public bool Like { get; set; } = false;

}