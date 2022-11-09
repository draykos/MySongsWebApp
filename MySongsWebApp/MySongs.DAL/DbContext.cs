using Microsoft.EntityFrameworkCore;
using MySongs.DAL.Entities;

namespace MySongs.DAL;

public class MySongsContext : DbContext
{
    public MySongsContext(DbContextOptions<MySongsContext> options) : base(options)
    {
    }


    public DbSet<Song> Songs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().ToTable("Songs");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}
