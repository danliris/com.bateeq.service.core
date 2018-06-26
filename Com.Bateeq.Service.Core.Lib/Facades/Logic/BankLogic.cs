using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.NetCore.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Bateeq.Service.Core.Lib.Facades.Logic
{
    public class BankLogic : BaseLogicImpl<Bank>
    {
        private CoreDbContext CoreDbContext;

        public BankLogic(CoreDbContext coreDbContext) : base(coreDbContext)
        {
            CoreDbContext = coreDbContext;
        }

        public override Tuple<List<Bank>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int Size = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<Bank> Query = CoreDbContext.Bank;

            List<string> SearchAttributes = new List<string>()
                {
                    "Code", "Name", "Description", "_id"
                };

            Query = ConfigureSearch(Query, SearchAttributes, Keyword);
            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code", "Name", "Description", "_id"
                };
            Query = Query
                .Select(bank => new Bank
                {
                    Id = bank.Id,
                    Code = bank.Code,
                    Name = bank.Name,
                    Description = bank.Description,
                    _id = bank._id
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);
            Pageable<Bank> pageable = new Pageable<Bank>(Query, Page - 1, Size);
            List<Bank> Data = pageable.Data.ToList<Bank>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }
    }
}
