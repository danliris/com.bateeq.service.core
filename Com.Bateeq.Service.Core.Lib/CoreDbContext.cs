using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Com.Bateeq.Service.Core.Lib
{
    public class CoreDbContext : StandardDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        public DbSet<Bank> Bank { get; set; }
    }
}
