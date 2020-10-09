using Com.DanLiris.Service.Core.Lib;
using Com.DanLiris.Service.Core.Lib.Models;
using Com.DanLiris.Service.Core.Lib.Services;
using Com.DanLiris.Service.Core.Lib.ViewModels;
using Com.DanLiris.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/stores")]
    public class StoreController : BasicController<StoreService, Store, StoreViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";
        StoreService service;
        public StoreController(StoreService service) : base(service, ApiVersion)
        {
            this.service = service;
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetRO(string category)
        {
            try
            {

                // service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

                List<Store> Data = await service.GetStoreByCategory(category);



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
