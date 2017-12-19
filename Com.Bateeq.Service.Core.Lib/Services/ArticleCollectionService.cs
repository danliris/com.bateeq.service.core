using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models.Article;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class ArticleCollectionService : BaseService<CoreDbContext, ArticleCollection>

    {
        public ArticleCollectionService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
