using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Models.Article;
using Com.Moonlay.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Com.Bateeq.Service.Core.Lib.Context
{
    public class CoreDbContext : BaseDbContext
    {
        public DbSet<Bank> Bank { get; set; }
        public DbSet<CardType> CardType { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<ArticleCollection> ArticleCollection { get; set; }
        public DbSet<ArticleColor> ArticleColor { get; set; }
        public DbSet<ArticleCounter> ArticleCounter { get; set; }
        public DbSet<ArticleMaterial> ArticleMaterial { get; set; }
        public DbSet<ArticleMaterialComposition> ArticleMaterialComposition { get; set; }
        public DbSet<ArticleMotif> ArticleMotif { get; set; }
        public DbSet<ArticleProcess> ArticleProcess { get; set; }
        public DbSet<ArticleSubCollection> ArticleSubCollection { get; set; }
        public DbSet<ArticleSubCounter> ArticleSubCounter { get; set; }
        public DbSet<ArticleSubMaterialComposition> ArticleSubMaterialComposition { get; set; }
        public DbSet<ArticleSubProcess> ArticleSubProcess { get; set; }

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
