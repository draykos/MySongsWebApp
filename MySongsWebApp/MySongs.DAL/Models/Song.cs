using System;
using System.Collections.Generic;

namespace MySongs.DAL.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int SongTypeId { get; set; }
    }
}
