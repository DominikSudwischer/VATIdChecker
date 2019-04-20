using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATIdChecker.Models;

namespace VATIdChecker.Data
{
    /// <summary>
    /// The main database context for this application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<SettingsModel> Settings { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyModel>().HasIndex(c => c.Valid);
            modelBuilder.Entity<CompanyModel>().HasIndex(c => c.LastWebServiceCall);
        }
    }
}
