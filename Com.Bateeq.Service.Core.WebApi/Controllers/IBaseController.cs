using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    public interface IBaseController<TViewModel>
    {
        Task<IActionResult> GetById([FromRoute] int id);
        Task<ActionResult> Post([FromBody] TViewModel viewModel);
        Task<IActionResult> Put([FromRoute] int id, [FromBody] TViewModel viewModel);
        Task<IActionResult> Delete([FromRoute] int id);
    }
}
