﻿using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/order-types")]
    public class OrderTypeController : BasicController<OrderTypeService, OrderType, OrderTypeViewModel, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public OrderTypeController(OrderTypeService service) : base(service, ApiVersion)
        {
        }
    }
}