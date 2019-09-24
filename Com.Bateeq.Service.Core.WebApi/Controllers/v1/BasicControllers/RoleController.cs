using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models.Account_and_Roles;
using Com.Bateeq.Service.Core.Lib.Services.Account_and_Roles;
using Com.Bateeq.Service.Core.Lib.ViewModels.Account_and_Roles;
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
    [Route("v{version:apiVersion}/roles")]
    public class RoleController : BasicController<RolesService, Role, RoleViewModel, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";
        public RoleController(RolesService service) : base(service, ApiVersion)
        {
        }
    }
}
