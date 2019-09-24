using Microsoft.AspNetCore.Mvc;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Lib;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/currencies")]
    public class CurrenciesController : BasicController<CurrencyService, Currency, CurrencyViewModel, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public CurrenciesController(CurrencyService service) : base(service, ApiVersion)
        {
        }
    }
}
