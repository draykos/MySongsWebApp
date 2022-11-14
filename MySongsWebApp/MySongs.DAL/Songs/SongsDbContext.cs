using Microsoft.EntityFrameworkCore;

namespace MySongs.DAL.Models;

public partial class SongsDbContext : DbContext
{
    public SongsDbContext()
    {
    }

    public SongsDbContext(DbContextOptions<SongsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Server=LAPTOP-GIANNI\\SQLEXPRESS;Database=SongsDb;User Id=admin;Password=admin;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(50);

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
