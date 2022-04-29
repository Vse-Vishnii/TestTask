using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class GamesContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }

        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {
            //Database.EnsureDeleted();

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity<GenreGame>(
                    gg => gg.HasOne(gg => gg.Genre)
                        .WithMany(g => g.GenreGames)
                        .HasForeignKey(gg => gg.GenreId)
                        .OnDelete(DeleteBehavior.Cascade),
                    gg => gg.HasOne(gg => gg.Game)
                        .WithMany(g => g.GenreGames)
                        .HasForeignKey(gg => gg.GameId)
                        .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Game>().HasOne(g => g.Developer).WithMany(d => d.Games);
        }
    }
}
