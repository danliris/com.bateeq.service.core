using Microsoft.AspNetCore.Mvc;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    [Route("v1/master/banks")]
    public class BankController : BaseController<BankService, Bank, CoreDbContext>
    {
        public BankController(BankService service) : base(service)
        {
        }
    }
}
