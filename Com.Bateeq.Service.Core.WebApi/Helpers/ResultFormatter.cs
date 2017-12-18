using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.ComponentModel.DataAnnotations;
using Com.Moonlay.NetCore.Lib.Service;

namespace Com.Bateeq.Service.Core.WebApi.Helpers
{
    public class ResultFormatter
    {
        public Dictionary<string, object> Result { get; set; }

        public ResultFormatter(InternalMessage ApiVersion, int StatusCode, string Message)
        {
            Result = new Dictionary<string, object>();
            AddResponseInformation(Result, ApiVersion, StatusCode, Message);
        }

        public Dictionary<string, object> Ok()
        {
            return Result;
        }

        public Dictionary<string, object> Ok<TModel>(TModel Data)
        {
            Result.Add("data", Data);

            return Result;
        }

        public Dictionary<string, object> Fail()
        {
            return Result;
        }

        public Dictionary<string, object> Fail(ServiceValidationExeption e)
        {
            Dictionary<string, string> Errors = new Dictionary<string, string>();

            foreach (ValidationResult error in e.ValidationResults)
            {
                Errors.Add(error.MemberNames.First(), error.ErrorMessage);
            }

            Result.Add("error", Errors);
            return Result;
        }

        public void AddResponseInformation(Dictionary<string, object> Result, InternalMessage ApiVersion, int StatusCode, string Message)
        {
            Result.Add("apiVersion", ApiVersion);
            Result.Add("statusCode", StatusCode);
            Result.Add("message", Message);
        }

        public Dictionary<string, object> Ok<TModel>(List<TModel> data, int page, int size, int totalData, int totalPageData, Dictionary<string, string> order, List<string> select)
        {
            Dictionary<string, object> Info = new Dictionary<string, object>
            {
                { "count", totalPageData },
                { "page", page },
                { "size", size },
                { "total", totalData },
                { "order", order }
            };

            if (select.Count > 0)
            {
                var dataObj = data.AsQueryable().Select(string.Concat("new(", string.Join(",", select), ")"));
                Result.Add("data", dataObj);
                Info.Add("select", select);
            }
            else
            {
                Result.Add("data", data);
            }

            Result.Add("info", Info);

            return Result;
        }
    }
}
