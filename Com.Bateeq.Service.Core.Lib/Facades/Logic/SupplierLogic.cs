using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.NetCore.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.Lib.Facades.Logic
{
    public class SupplierLogic : BaseLogicImpl<Supplier>
    {
        public SupplierLogic(CoreDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public async Task<bool> IsExsist(string supplierCode)
        {
            var result = this.CoreDbContext.Supplier.Count(prop => prop.Code == supplierCode && prop.IsDeleted == false) > 0;

            return await Task.FromResult(result);
        }

        public override Tuple<List<Supplier>, int, Dictionary<string, string>, List<string>> ReadModel(int Page, int Size, string Order, List<string> Select, string Keyword, string Filter)
        {
            IQueryable<Supplier> Query = CoreDbContext.Supplier;

            List<string> SearchAttributes = new List<string>()
                {
                    "Code", "Name", "Address", "NPWP", "Import"
                };


            Query = ConfigureSearch(Query, SearchAttributes, Keyword);
            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code", "Name", "Address", "NPWP", "Import", "_id"
                };

            Query = Query
                .Select(supplier => new Supplier
                {
                    Id = supplier.Id,
                    Code = supplier.Code,
                    Name = supplier.Name,
                    Address = supplier.Address,
                    NPWP = supplier.NPWP,
                    Import = supplier.Import,
                    _id = supplier._id,
                    LastModifiedUtc = supplier.LastModifiedUtc
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);
            Pageable<Supplier> pageable = new Pageable<Supplier>(Query, Page - 1, Size);
            List<Supplier> Data = pageable.Data.ToList<Supplier>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }
    }
}
