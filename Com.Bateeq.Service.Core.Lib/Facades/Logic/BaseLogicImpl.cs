using Com.Bateeq.Service.Core.Lib.Common.Helper;
using Com.Bateeq.Service.Core.Lib.Common.Utils;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Moonlay.Models;
using Com.Moonlay.NetCore.Lib.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.Lib.Facades.Logic
{
    public abstract class BaseLogicImpl<TModel> : IBaseLogic<TModel>
         where TModel : MigrationModel
    {
        protected CoreDbContext CoreDbContext;

        public BaseLogicImpl(CoreDbContext coreDbContext)
        {
            CoreDbContext = coreDbContext;
        }

        public virtual async Task<int> CreateModel(UserIdentity user, TModel model)
        {
            Validate(model);
            EntityExtension.FlagForCreate(model, user.Username, "core-service");
            CoreDbContext.Set<TModel>().Add(model);

            return await CoreDbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteModelAsync(UserIdentity user, int id)
        {
            var model = await ReadModelById(id);
            EntityExtension.FlagForDelete(model, user.Username, "core-service");
            CoreDbContext.Set<TModel>().Update(model);

            return await CoreDbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> IsExsist(int id)
        {
            var result = CoreDbContext.Set<TModel>().Count(field => field.Id == id && field.IsDeleted == false) > 0;

            return await Task.FromResult(result);
        }

        public virtual async Task<TModel> ReadModelById(int id)
        {
            var model = CoreDbContext
                .Set<TModel>()
                .Where<TModel>(item => item.Id == id && item.IsDeleted == false)
                .FirstOrDefault();

            return await Task.FromResult(model);
        }

        public virtual async Task<TModel> ReadModelById(string id)
        {
            var model = CoreDbContext
                .Set<TModel>()
                .Where<TModel>(entity => entity._id == id && entity.IsDeleted == false)
                .FirstOrDefault();

            return await Task.FromResult(model);
        }

        public virtual async Task<int> UpdateModel(UserIdentity user, TModel model)
        {
            Validate(model);
            EntityExtension.FlagForUpdate(model, user.Username, "core-service");
            CoreDbContext.Set<TModel>().Update(model);
            return await CoreDbContext.SaveChangesAsync();
        }

        public abstract Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> ReadModel(int Page, int Size, string Order, List<string> Select, string Keyword, string Filter);

        public virtual IQueryable<TModel> ConfigureSearch(IQueryable<TModel> Query, List<string> SearchAttributes, string Keyword)
        {
            /* Search with Keyword */
            if (Keyword != null)
            {
                Query = Query.Where(GeneralTransform.BuildSearch(SearchAttributes), Keyword);
            }
            return Query;
        }

        public virtual IQueryable<TModel> ConfigureFilter(IQueryable<TModel> Query, Dictionary<string, object> FilterDictionary)
        {
            if (FilterDictionary != null && !FilterDictionary.Count.Equals(0))
            {
                foreach (var f in FilterDictionary)
                {
                    string Key = f.Key;
                    object Value = f.Value;
                    string filterQuery = string.Concat(string.Empty, Key, " == @0");

                    Query = Query.Where(filterQuery, Value);
                }
            }
            return Query;
        }

        public virtual IQueryable<TModel> ConfigureOrder(IQueryable<TModel> Query, Dictionary<string, string> OrderDictionary)
        {
            /* Default Order */
            if (OrderDictionary.Count.Equals(0))
            {
                OrderDictionary.Add("LastModifiedUtc", GeneralTransform.DESCENDING);

                Query = Query.OrderByDescending(b => b.LastModifiedUtc);
            }
            /* Custom Order */
            else
            {
                string Key = OrderDictionary.Keys.First();
                string OrderType = OrderDictionary[Key];
                string TransformKey = GeneralTransform.TransformOrderBy(Key);

                BindingFlags IgnoreCase = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

                Query = OrderType.Equals(GeneralTransform.ASCENDING) ?
                    Query.OrderBy(b => b.GetType().GetProperty(TransformKey, IgnoreCase).GetValue(b)) :
                    Query.OrderByDescending(b => b.GetType().GetProperty(TransformKey, IgnoreCase).GetValue(b));
            }
            return Query;
        }

        protected void Validate(TModel model)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(model);

            if (!Validator.TryValidateObject(model, validationContext, validationResults, true))
                throw new ServiceValidationExeption(validationContext, validationResults);
        }
    }
}
