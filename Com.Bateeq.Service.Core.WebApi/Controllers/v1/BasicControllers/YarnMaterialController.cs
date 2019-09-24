﻿using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/yarn-materials")]
    public class YarnMaterialController : BasicController<YarnMaterialService, YarnMaterial, YarnMaterialViewModel, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";
        public YarnMaterialController(YarnMaterialService service) : base(service, ApiVersion)
        {
        }
    }
}