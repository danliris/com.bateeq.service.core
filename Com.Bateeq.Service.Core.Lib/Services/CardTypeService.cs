using Com.Bateeq.Service.Core.Lib.Context;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.NetCore.Lib.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public class CardTypeService : BaseService<CoreDbContext, CardType>
    {
        public CardTypeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Tuple<List<CardType>, int, Dictionary<string, string>, List<string>> ReadModel(int page, int size, string order, List<string> select, string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
