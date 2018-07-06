using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Com.Bateeq.Service.Core.Lib.Facades.Logic;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.ViewModels;
using AutoMapper;
using Com.Bateeq.Service.Core.Lib.Common.Helper;
using Com.Bateeq.Service.Core.WebApi.Common.Utils;
using Com.Moonlay.NetCore.Lib.Service;

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    public abstract class BaseController<TBusinessLogic, TModel, TViewModel> : Controller
        where TBusinessLogic : BaseLogic<TModel>
        where TModel : MigrationModel
        where TViewModel : BaseVM
    {
        protected TBusinessLogic BusinessLogic;
        protected string ApiVersion = "1";
        protected UserIdentity UserIdentity;
        private int MessageCode;
        private TViewModel viewModel;
        private IMapper Mapper;

        public BaseController(TBusinessLogic businessLogic, IMapper mapper)
        {
            BusinessLogic = businessLogic;
            Mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int Page = 1, int Size = 25, string Order = "{}", [Bind(Prefix = "Select[]")]List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            try
            {
                List<TViewModel> DataVM = new List<TViewModel>();
                Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> Data = BusinessLogic.ReadModel(Page, Size, Order, Select, Keyword, Filter);

                foreach (TModel d in Data.Item1)
                {
                    viewModel = Mapper.Map<TViewModel>(d);
                    DataVM.Add(viewModel);
                }

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.OK_STATUS_CODE, StatusMessage.OK_MESSAGE)
                    .Ok<TModel, TViewModel>(DataVM, Page, Size, Data.Item2, Data.Item1.Count, Data.Item3, Data.Item4);

                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("UId/{Id}")]
        public virtual async Task<IActionResult> GetByUId([FromRoute] string id)
        {
            try
            {
                TModel model = await BusinessLogic.ReadModelById(id);

                if (model == null)
                {
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, StatusMessage.NOT_FOUND_STATUS_CODE, StatusMessage.NOT_FOUND_MESSAGE)
                        .Fail();
                    return NotFound(Result);
                }
                else
                {
                    TViewModel viewModel = Mapper.Map<TViewModel>(model);
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, StatusMessage.OK_STATUS_CODE, StatusMessage.OK_MESSAGE)
                        .Ok<TViewModel>(viewModel);

                    return Ok(Result);
                }
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("{Id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                TModel model = await BusinessLogic.ReadModelById(id);

                if (model == null)
                {
                    model = await BusinessLogic.ReadModelById(id.ToString());
                }

                if (model == null)
                {
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, StatusMessage.NOT_FOUND_STATUS_CODE, StatusMessage.NOT_FOUND_MESSAGE)
                        .Fail();
                    return NotFound(Result);
                }
                else
                {
                    TViewModel viewModel = Mapper.Map<TViewModel>(model);
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, StatusMessage.OK_STATUS_CODE, StatusMessage.OK_MESSAGE)
                        .Ok<TViewModel>(viewModel);

                    return Ok(Result);
                }
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> Post([FromBody] TViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UserIdentity = new UserIdentity();
                UserIdentity.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
                UserIdentity.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
                TModel model = Mapper.Map<TModel>(viewModel);

                MessageCode = await BusinessLogic.CreateModel(UserIdentity, model);

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

        [HttpPut("{Id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] TViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UserIdentity = new UserIdentity();
                UserIdentity.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
                UserIdentity.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
                TModel model = Mapper.Map<TModel>(viewModel);
                MessageCode = await BusinessLogic.UpdateModel(UserIdentity, model);

                return NoContent();
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
                    new ResultFormatter(ApiVersion, MessageCode, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpDelete("{Id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                UserIdentity = new UserIdentity();
                UserIdentity.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
                UserIdentity.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
                MessageCode = await BusinessLogic.DeleteModelAsync(UserIdentity, id);

                return NoContent();
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, MessageCode, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }
    }
}