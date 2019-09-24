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
    public class StorageDataUtil : BasicDataUtil<CoreDbContext, StorageService, Storage>, IEmptyData<StorageViewModel>
    {
        public StorageDataUtil(CoreDbContext dbContext, StorageService service) : base(dbContext, service)
        {
        }

        public StorageViewModel GetEmptyData()
        {
            return new StorageViewModel();
        }

        public override Storage GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            return new Storage
            {
                Name = string.Format("StorageName {0}", guid),
                UnitId = 1,
            };
        }

        public override async Task<Storage> GetTestDataAsync()
        {
            var data = GetNewData();
            await Service.CreateModel(data);
            return data;
        }
    }
}
