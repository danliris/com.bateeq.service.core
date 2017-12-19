using Com.Moonlay.NetCore.Lib.Service;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Com.Moonlay.Models;
using Newtonsoft.Json;
using System.Reflection;
using Com.Moonlay.NetCore.Lib;

namespace Com.Bateeq.Service.Core.Lib.Services
{
    public abstract class BaseService<TDbContext, TModel> : StandardEntityService<TDbContext, TModel>
        where TDbContext : DbContext
        where TModel : StandardEntity, IValidatableObject
    {
        public BaseService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /*
         * Create Data
         */
        public virtual async Task<int> CreateModel(TModel Model)
        {
            return await this.CreateAsync(Model);
        }

        /*
         * Get All Data with Pagination, Sort, Keyword & Order
         * @parameter page int
         * @parameter size int
         * @parameter order json object 
         * @parameter select List string type
         * @parameter keyword string
         * example order : { "[field]" : "[order]" } where order asc or desc
         */
        public virtual Tuple<List<TModel>, 
                             int, 
                             Dictionary<string, string>, 
                             List<string>> 
            ReadModel(int page, 
                      int size, 
                      string order, 
                      List<string> select, 
                      string keyword)
        {
            IQueryable<TModel> query = DbContext.Set<TModel>();
            Dictionary<string, string> orders = new Dictionary<string, string>();
            string dynamicQuery = "";
            
            //Keyword
            if (!string.IsNullOrEmpty(keyword))
            {
                var keywords = keyword.Split(" ");

                foreach (var word in keywords)
                {
                    if (string.IsNullOrEmpty(dynamicQuery))
                    {
                        dynamicQuery = string.Format("Code = \"{0}\"", word);
                        dynamicQuery += string.Format(" OR Name = \"{0}\"", word);
                    } 
                    else
                    {
                        dynamicQuery += string.Format(" OR Code = \"{0}\"", word);
                        dynamicQuery += string.Format(" OR Name = \"{0}\"", word);
                    }
                }
                
                query = query.Where(dynamicQuery);
            }

            // Order
            if (!string.IsNullOrEmpty(order))
            {
                orders = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            }

            if (orders.Count.Equals(0))
            {
                // Default Order
                orders.Add("_updatedDate", "desc");
                
                query = query.OrderByDescending(b => b._LastModifiedUtc); 
            }
            else
            {
                string Key = orders.Keys.First();
                string OrderType = orders[Key];
                string TransformKey = Key;

                BindingFlags IgnoreCase = BindingFlags.IgnoreCase | 
                                          BindingFlags.Public | 
                                          BindingFlags.Instance;
                query = OrderType.Equals("asc") ? 
                    query.OrderBy(b => b.GetType()
                                        .GetProperty(TransformKey, IgnoreCase)
                                        .GetValue(b)) :
                    query.OrderByDescending(b => b.GetType()
                                                  .GetProperty(TransformKey, IgnoreCase)
                                                  .GetValue(b));
            }

            // Pagination
            Pageable<TModel> pageable = new Pageable<TModel>(query, page - 1, size);
            List<TModel> pageableData = pageable.Data.ToList<TModel>();
            int totalData = pageable.TotalCount;

            return Tuple.Create(pageableData, totalData, orders, select);
        }

        /*
         * Get Data @parameter Id int
         */
        public virtual async Task<TModel> ReadModelById(int Id)
        {
            return await GetAsync(Id);
        }

        /*
         * Get Data @parameter _id string
         */
        public virtual async Task<TModel> ReadModelById(string _id)
        {
            var model = Task.Run(() => GetModelById(_id));

            return await model;
        }

        /*
         * Private Method Get Model @parameter Id int
         */
        private TModel GetModelById(string _id)
        {
            IQueryable<TModel> query = DbContext.Set<TModel>()
                                                .Where("it._id.Contains(@0)", _id);

            return query.FirstOrDefault();
        }

        /*
         * Update Data @parameter Id int and @parameter TModel model
         */
        public virtual async Task<int> UpdateModel(int Id, TModel Model)
        {
            return await this.UpdateAsync(Id, Model);
        }

        /*
         * Delete Data @parameter Id int
         */
        public virtual async Task<int> DeleteModel(int Id)
        {
            return await this.DeleteAsync(Id);
        }
    }
}
