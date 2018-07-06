using Com.Bateeq.Service.Core.Lib.Common.Helper;
using Com.Bateeq.Service.Core.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.Lib.Facades.Logic
{
    public interface ILogic<TModel>
        where TModel : MigrationModel
    {
        Task<int> CreateModel(UserIdentity user, TModel model);
        Task<int> UpdateModel(UserIdentity user, TModel model);
        Task<int> DeleteModelAsync(UserIdentity user, int id);
        Task<TModel> ReadModelById(int id);
        Task<TModel> ReadModelById(string id);
        Task<bool> IsExsist(int id);
        Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> ReadModel(int Page, int Size, string Order, List<string> Select, string Keyword, string Filter);
        IQueryable<TModel> ConfigureSearch(IQueryable<TModel> Query, List<string> SearchAttributes, string Keyword);
        IQueryable<TModel> ConfigureFilter(IQueryable<TModel> Query, Dictionary<string, object> FilterDictionary);
        IQueryable<TModel> ConfigureOrder(IQueryable<TModel> Query, Dictionary<string, string> OrderDictionary);
    }
}
