using Microsoft.AspNetCore.Html;
using MySongsWebApp.Models;

namespace MySongsWebApp.Helpers
{
    public static class SongHelper
    {
    
    public static IHtmlContent SongRenderer(SongModel song)
        {
            string html;
            if (song.Authors.Count > 0)
            {
                var authors = String.Join(",", song.Authors);
                html = $"<li class=\"song\">{@song.Id} - {song.Title} (Authors: {authors})</li>";
            } else
            {
                html = $"<li class=\"song\">{@song.Id} - {song.Title}";
            }

            return new HtmlString(html);
        }
    }
}
