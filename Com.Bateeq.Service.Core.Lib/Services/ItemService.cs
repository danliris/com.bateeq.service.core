using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class ItemService : BaseService<CoreDbContext, Item>
    {
        public ItemService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
