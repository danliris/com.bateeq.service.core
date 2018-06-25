using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Com.Bateeq.Service.Core.Lib.Models.ConfigurationModel;

namespace Com.Bateeq.Service.Core.Lib
{
    public class CoreDbContext : StandardDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        public DbSet<Bank> Bank { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankConfigurationModel());
            base.OnModelCreating(modelBuilder);
        }
    }
}
