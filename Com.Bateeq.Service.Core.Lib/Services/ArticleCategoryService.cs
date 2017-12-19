using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models.Article;
using System;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class ArticleCategoryService : BaseService<CoreDbContext, ArticleCategory>
    {
        public ArticleCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
