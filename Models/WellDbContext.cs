using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSDUR2WellsConnector.Models
{
    public class WellDbContext : DbContext
    {
        public DbSet<Well> Wells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=well.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Add LastUpdated and IsDeleted shadow properties
            modelBuilder.Entity<Well>()
                .Property<DateTime>("LastUpdated")
                .HasDefaultValueSql("datetime()")
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Well>()
                .Property<bool>("IsDeleted")
                .IsRequired()
                .HasDefaultValue(false);

            // Exclude any soft-deleted items (IsDeleted = 1) from
            // the default query sets
            modelBuilder.Entity<Well>()
                .HasQueryFilter(a => !EF.Property<bool>(a, "IsDeleted"));
        }

        public override int SaveChanges()
        {
            // Prevent deletes of data, instead mark the item as deleted
            // by setting IsDeleted = true.
            foreach(var entry in ChangeTracker.Entries()
              .Where(e => e.State == EntityState.Deleted))
            {
                if (entry.Entity.GetType() == typeof(Well))
                {
                    SoftDelete(entry);
                }

            }

            return base.SaveChanges();
        }

        private void SoftDelete(EntityEntry entry)
        {
            var partNumber = new SqliteParameter("@UWI",
                entry.OriginalValues["UWI"]);

            Database.ExecuteSqlRaw(
                "UPDATE Well SET IsDeleted = 1 WHERE UWI = @UWI",
                partNumber);

            entry.State = EntityState.Detached;
        }
    }
}