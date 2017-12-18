using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.NetCore.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class BankService : BaseService<CoreDbContext, Bank>
    {
        public BankService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
