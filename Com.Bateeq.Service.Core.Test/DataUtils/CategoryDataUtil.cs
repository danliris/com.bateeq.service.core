using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Test.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.Test.DataUtils
{
    public class CategoryDataUtil : BasicDataUtil<CoreDbContext, CategoryService, Category>, IEmptyData<CategoryViewModel>
    {
        public CategoryDataUtil(CoreDbContext dbContext, CategoryService service) : base(dbContext, service)
        {
        }

        public CategoryViewModel GetEmptyData()
        {
            return new CategoryViewModel();
        }

        public override Category GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            return new Category
            {
                Code = string.Format("CategoryCode {0}", guid),
                Name = string.Format("CategoryName {0}", guid),
                DivisionId = 0,
                CodeRequirement = string.Format("CodeRequirement {0}" , guid)
            };
        }

        public override async Task<Category> GetTestDataAsync()
        {
            var data = GetNewData();
            await Service.CreateModel(data);
            return data;
        }
    }
}
