using ArtStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Artist_Artwork> Artist_Artworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Artwork>().HasKey(aa => new
            {
                aa.ArtistId,
                aa.ArtworkId
            });


            modelBuilder.Entity<Artist_Artwork>()
                 .HasOne(aa => aa.Artist)
                 .WithMany(a => a.Artist_Artworks)
                 .HasForeignKey(aa => aa.ArtistId)
                 .OnDelete(DeleteBehavior.Cascade); // Delete artworks when artist is deleted

            modelBuilder.Entity<Artist_Artwork>()
                .HasOne(aa => aa.Artwork)
                .WithMany(a => a.Artist_Artworks)
                .HasForeignKey(aa => aa.ArtworkId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete from Artwork to Artist_Artwork

            modelBuilder.Entity<Artwork>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
