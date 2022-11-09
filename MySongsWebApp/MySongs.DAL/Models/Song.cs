using System;
using System.Collections.Generic;

namespace MySongs.DAL
{
    public partial class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? SongTypeId { get; set; }
    }
}
