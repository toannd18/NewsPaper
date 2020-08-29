using NewsPaper.Data.Data;
using NewsPaper.Data.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper.Data
{
    public class NewsPaperDbContext : DbContext
    {
        public NewsPaperDbContext() : base(nameOrConnectionString: "Default")
        {
        }

        public DbSet<NewsArticles> NewsArticles { get; set; }

        public DbSet<NewsCategories> NewsCategories { get; set; }

        public DbSet<NewsArticleCategories> NewsArticleCategories { get; set; }

        public DbSet<Slide> Slides { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }

        public override async Task<int> SaveChangesAsync()
        {
            var now = DateTime.Now;
            var entities = ChangeTracker.Entries().Where(x => x.Entity is Auditable && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Auditable)entity.Entity).CreatedDate = now;
                   
                }

           ((Auditable)entity.Entity).UpdatedDate = now;
              
            };
            return await base.SaveChangesAsync();
        }
    }
}