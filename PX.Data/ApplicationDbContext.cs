using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PX.Core.Audit;
using PX.Domain.Entities;

namespace PX.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=localhost;Database=PanxDB;User ID=sa;Password=Maksud99cse#;Trusted_Connection=True;");
        //}

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is IFullyAuditedEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((IFullyAuditedEntity)entry.Entity).CreateDate = DateTime.UtcNow;
                    ((IFullyAuditedEntity)entry.Entity).CreatedBy = 1;
                    ((IFullyAuditedEntity)entry.Entity).IsDeleted = false;
                }
                ((IFullyAuditedEntity)entry.Entity).UpdateDate = DateTime.UtcNow;
                ((IFullyAuditedEntity)entry.Entity).UpdateBy = 1;
            }
        }

        //Add entities here
        public DbSet<Book> Books { get; set; }

    }
}