using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Domain;

namespace PhotoSharingApplication.Persistence.Data;

public class PhotosDbContext : DbContext
{
    public PhotosDbContext(DbContextOptions<PhotosDbContext> options) : base(options)
    {
    }

    public DbSet<Photo> Photos { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Photo entity configuration
        modelBuilder.Entity<Photo>().Property(p => p.Title).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Photo>().Property(p => p.Description).HasMaxLength(300).IsRequired(false);
        modelBuilder.Entity<Photo>().Property(p => p.ImageMimeType).HasMaxLength(100);

        // Comment entity configuration
        modelBuilder.Entity<Comment>().Property(c => c.Title).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Comment>().Property(c => c.Body).HasMaxLength(300).IsRequired(false);
    }
}
