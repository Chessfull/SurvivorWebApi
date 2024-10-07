using Microsoft.EntityFrameworkCore;
using SurvivorWebApi.Entities;

namespace SurvivorWebApi.Data
{
    public class SurvivorDbContext:DbContext
    {
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ▼ Adding seed data for both entity ▼
            modelBuilder.Entity<Category>().HasData(
                new Category {  Id=1, Name="Celebrities"},
                new Category { Id=2, Name= "Volunteers" }
                );

            modelBuilder.Entity<Competitor>().HasData(
                new Competitor {Id=1, FirstName="Mert", LastName="Topcu",CategoryId=2 }
                );
        }

        // ▼ For calling UpdateModified overriding savechanges methods of context ▼
        public override int SaveChanges()
        {
            UpdateModifiedDate();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateModifiedDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        // ▼ This is a method for tracking modifieddate ▼
        private void UpdateModifiedDate()
        {
            // ▼ Checking updates with Ef Core ChangeTracker, if modified iterates with foreach and setting modified date ▼
            var entries = ChangeTracker.Entries<BaseEntity>()
                                       .Where(e => e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                entityEntry.Entity.ModifiedDate = DateTime.Now;
            }
        }
    }
}
