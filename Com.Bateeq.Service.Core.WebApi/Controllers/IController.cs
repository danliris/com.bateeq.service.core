using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    public interface IController<TViewModel>
    {
        IActionResult Get(int Page = 1, int Size = 25, string Order = "{}", [Bind(Prefix = "Select[]")]List<string> Select = null, string Keyword = null, string Filter = "{}");
        Task<IActionResult> GetByUId([FromRoute] string id);
        Task<IActionResult> GetById([FromRoute] int id);
        Task<ActionResult> Post([FromBody] TViewModel viewModel);
        Task<IActionResult> Put([FromRoute] int id, [FromBody] TViewModel viewModel);
        Task<IActionResult> Delete([FromRoute] int id);
    }
}
