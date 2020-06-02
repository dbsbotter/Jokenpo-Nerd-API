using Jokenpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<JokenpoItem> Jokenpos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<JokenpoItem>()
                .ToTable("Jokenpo");

            modelBuilder
                .Entity<JokenpoItem>()
                .Property(x => x.Id);

            modelBuilder
                .Entity<JokenpoItem>()
                .Property(x => x.PlayerOne)
                .HasMaxLength(1)
                .HasColumnType("char");

            modelBuilder
                .Entity<JokenpoItem>()
                .Property(x => x.PlayerTwo)
                .HasMaxLength(1)
                .HasColumnType("char");

            modelBuilder
                .Entity<JokenpoItem>()
                .Property(x => x.PlayerWinner)
                .HasColumnType("smallint");

            modelBuilder
                .Entity<JokenpoItem>()
                .HasCheckConstraint("CK_Jokenpos_PlayerOne", "PlayerOne = 'R' OR PlayerOne = 'P' PlayerOne = 'S' PlayerOne = 'L' PlayerOne = 'K'")
                .HasCheckConstraint("CK_Jokenpos_PlayerTwo", "PlayerOne = 'R' OR PlayerOne = 'P' PlayerOne = 'S' PlayerOne = 'L' PlayerOne = 'K'");
        }
    }
}