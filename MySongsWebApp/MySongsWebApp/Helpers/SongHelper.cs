using Microsoft.AspNetCore.Html;
using MySongsWebApp.DTO;
using MySongsWebApp.Models;

namespace MySongsWebApp.Helpers;

public static class SongHelper
{

public static IHtmlContent SongRenderer(SongViewModel song)
    {
        string html;
        if (song.Authors.Count > 0)
        {
            var names = song.Authors.Select(x => x.Name).ToList();
            var authors = String.Join(",", names);
            html = $"<li class=\"song\">{@song.Id} - {song.Title} (Authors: {authors})</li>";
        } else
        {
            html = $"<li class=\"song\">{@song.Id} - {song.Title}";
        }

        return new HtmlString(html);
    }
}
