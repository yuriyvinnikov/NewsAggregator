using DataAccessLayer.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class RssFeedReaderDbContext : DbContext
    {
        public RssFeedReaderDbContext(DbContextOptions<RssFeedReaderDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewsAgency> NewsAgencies { get; set; }
        public DbSet<JobSettings> JobSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsAgencyConfiguration());
            modelBuilder.ApplyConfiguration(new JobSettingsConfiguration());
        }

        public async Task<int> SaveChangesAsync(string username)
        {
            OnBeforeSaveChanges(username);

            return await SaveChangesAsync();
        }

        private void OnBeforeSaveChanges(string userName)
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                    entity.CreatedBy = userName;
                }

                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = userName;
            }
        }
    }
}
