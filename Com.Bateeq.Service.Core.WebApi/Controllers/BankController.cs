using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Com.Bateeq.Service.Core.Lib.Facades.Logic;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.ViewModels;

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/banks")]
    [Authorize]
    public class BankController : BaseImplController<BankLogic, Bank, BankVM>
    {
        public BankController(BankLogic logic) : base(logic)
        {
        }
    }
}