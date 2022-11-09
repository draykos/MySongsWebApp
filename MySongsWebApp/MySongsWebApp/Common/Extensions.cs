using MySongsWebApp.Models;

namespace MySongsWebApp.Extensions;

public static class Extensions
{
    public static List<SongViewModel> SortByName(this List<SongViewModel> input)
    {
        var sorted = input.OrderBy(s => s.Title).ToList();
        return sorted;
    }
}
