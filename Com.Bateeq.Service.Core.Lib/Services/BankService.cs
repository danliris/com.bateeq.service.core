using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models;
using System;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class BankService : BaseService<CoreDbContext, Bank>
    {
        public BankService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
