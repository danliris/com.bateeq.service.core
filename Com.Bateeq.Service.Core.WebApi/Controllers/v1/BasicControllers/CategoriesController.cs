using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/categories")]
    public class CategoriesController : BasicController<CategoryService, Category, CategoryViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";
        public CategoriesController(CategoryService service) : base(service, ApiVersion)
        {
        }

        [HttpGet("join-division")]
        public IActionResult JoinDivision(int Page = 1, int Size = 25, string Order = "{}", [Bind(Prefix = "Select[]")]List<string> Select = null, string Keyword = "", string Filter = "{}")
        {
            try
            {
                Tuple<List<CategoryViewModel>, int, Dictionary<string, string>> Data = Service.JoinDivision(Page, Size, Order, Keyword, Filter);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok<CategoryViewModel>(Data.Item1, Page, Size, Data.Item2, Data.Item1.Count, Data.Item3, new List<string>());

                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }
    }
}