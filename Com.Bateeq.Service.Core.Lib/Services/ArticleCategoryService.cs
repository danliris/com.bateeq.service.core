using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models.Article;
using Com.Moonlay.NetCore.Lib.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class ArticleCategoryService : StandardEntityService<CoreDbContext, ArticleCategory>
    {
        public ArticleCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
