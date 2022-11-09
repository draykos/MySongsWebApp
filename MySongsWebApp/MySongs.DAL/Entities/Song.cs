using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySongs.DAL.Entities;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int SongTypeId { get; set; }
}
