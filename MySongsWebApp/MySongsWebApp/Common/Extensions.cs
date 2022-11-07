using MySongsWebApp.Models;

namespace MySongsWebApp.Extensions
{
    public static class Extensions
    {
        public static List<SongModel> SortByName(this List<SongModel> input)
        {
            var sorted = input.OrderBy(s => s.Title).ToList();
            return sorted;
        }
    }
}
