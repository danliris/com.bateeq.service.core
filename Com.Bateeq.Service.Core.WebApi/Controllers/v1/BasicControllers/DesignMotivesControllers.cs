using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
namespace Com.Bateeq.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/design-motives")]
    public class DesignMotivesControllers : BasicController<DesignMotiveService, DesignMotive, DesignMotiveViewModel, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public DesignMotivesControllers(DesignMotiveService service) : base(service, ApiVersion)
        {
        }
    }
}
