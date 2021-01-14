using Microsoft.EntityFrameworkCore;

[assembly: System.CLSCompliant(false)]
namespace CovidTesting.DB
{
    public class PlayerContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<CovidTest> CovidTests { get; set; }

        public PlayerContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null) throw new System.ArgumentNullException(nameof(optionsBuilder), " NULL input param!");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\PlayerDb.mdf; Integrated Security=True; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null) throw new System.ArgumentNullException(nameof(modelBuilder), " NULL input param!");
            modelBuilder.Entity<CovidTest>(entity =>
            {
                entity.
                    HasOne(test => test.Player).
                    WithMany(player => player.Tests).
                    HasForeignKey(test => test.PlayerId);
            });
        }
    }
}
