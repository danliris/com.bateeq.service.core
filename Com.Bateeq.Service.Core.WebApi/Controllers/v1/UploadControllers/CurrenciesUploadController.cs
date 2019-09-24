﻿using Microsoft.AspNetCore.Mvc;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.ViewModels;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.UploadControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/upload-currencies")]
    public class CurrenciesUploadController : BasicUploadController<CurrencyService, Currency, CurrencyViewModel, CurrencyService.CurrencyMap, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public CurrenciesUploadController(CurrencyService service) : base(service, ApiVersion)
        {
        }
    }
}