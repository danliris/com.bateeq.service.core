using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
	[Produces("application/json")]
	[ApiVersion("1.0")]
	[Route("v{version:apiVersion}/master/budget-currencies")]
	public class BudgetCurrenciesController : BasicController<BudgetCurrencyService, BudgetCurrency, BudgetCurrencyViewModel, CoreDbContext>
	{
		private static readonly string ApiVersion = "1.0";
		BudgetCurrencyService service;

		public BudgetCurrenciesController(BudgetCurrencyService service) : base(service, ApiVersion)
		{
            this.service = service;
        }

		[HttpGet("byId")]
		public IActionResult GetByIds([Bind(Prefix = "budgetCurrencyList[]")]List<int> budgetCurrencyList)
		{
			try
			{
				service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

				List<BudgetCurrency> Data = service.GetByIds(budgetCurrencyList);

				Dictionary<string, object> Result =
					new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
					.Ok(Data);

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

        [HttpGet("by-code")]
        public IActionResult GetByName(string code)
        {
            try
            {

                service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

                IQueryable<BudgetCurrency> Data = service.GetByCode(code);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok(Data);

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
