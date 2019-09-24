﻿using Microsoft.AspNetCore.Mvc;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Lib;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/garment-currencies")]
    public class GarmentCurrenciesController : BasicController<GarmentCurrencyService, GarmentCurrency, GarmentCurrencyViewModel, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";
		GarmentCurrencyService service;

        public GarmentCurrenciesController(GarmentCurrencyService service) : base(service, ApiVersion)
		{
			this.service = service;
		}

		[HttpGet("byId")]
		public IActionResult GetByIds([Bind(Prefix = "garmentCurrencyList[]")]List<int> garmentCurrencyList)
		{
			try
			{
				service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

				List<GarmentCurrency> Data = service.GetByIds(garmentCurrencyList);

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

        [HttpGet("byCode/{code}")]
        public IActionResult GetByCode([FromRoute] string code)
        {
            try
            {
                List<GarmentCurrency> Data = service.GetByCode(code);

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
