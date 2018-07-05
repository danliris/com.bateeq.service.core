using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Com.Bateeq.Service.Core.Lib.Facades.Logic;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.ViewModels;
using AutoMapper;
using System.Threading.Tasks;
using Com.Bateeq.Service.Core.Lib.Common.Helper;
using System.Linq;
using System.Collections.Generic;
using Com.Bateeq.Service.Core.WebApi.Common.Utils;
using System;
using Com.Moonlay.NetCore.Lib.Service;

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/suppliers")]
    [Authorize]
    public class SupplierController : BaseImplController<SupplierLogic, Supplier, SupplierVM>
    {
        private UserIdentity UserIdentity;

        public SupplierController(SupplierLogic supplierLogic, IMapper mapper) : base(supplierLogic, mapper)
        {
        }

        [HttpPost]
        public override async Task<ActionResult> Post([FromBody] SupplierVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UserIdentity = new UserIdentity()
                {
                    Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value,
                    Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "")
                };
                Supplier model = Mapper.Map<Supplier>(viewModel);
                var isExsist = await this.BusinessLogic.IsExsist(model.Code);

                if (isExsist)
                {
                    Dictionary<string, object> ExsistResult =
                    new ResultFormatter(ApiVersion, StatusMessage.BAD_REQUEST_STATUS_CODE, StatusMessage.DATA_IS_EXSIST)
                    .Fail("code", "Bank with this Code has Exsist");
                    return BadRequest(ExsistResult);
                }

                var MessageCode = await BusinessLogic.CreateModel(UserIdentity, model);
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, MessageCode, StatusMessage.OK_MESSAGE)
                    .Ok();
                return Created(String.Concat(Request.Path, "/", 0), Result);

            }
            catch (ServiceValidationExeption e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.BAD_REQUEST_STATUS_CODE, StatusMessage.BAD_REQUEST_MESSAGE)
                    .Fail(e);
                return BadRequest(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }
    }
}