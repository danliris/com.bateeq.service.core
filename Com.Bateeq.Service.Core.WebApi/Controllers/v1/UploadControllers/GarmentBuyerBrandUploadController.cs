using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.UploadControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/garment-buyer-brand-upload")]
    public class GarmentBuyerBrandUploadController : BasicUploadController<GarmentBuyerBrandService, GarmentBuyerBrand, GarmentBuyerBrandViewModel, GarmentBuyerBrandService.GarmentBuyerBrandMap, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public GarmentBuyerBrandUploadController(GarmentBuyerBrandService service) : base(service, ApiVersion)
        {
        }
    }
}