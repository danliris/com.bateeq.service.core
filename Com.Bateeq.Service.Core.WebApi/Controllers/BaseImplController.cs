using AutoMapper;
using Com.Bateeq.Service.Core.Lib.Facades.Logic;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.Common.Utils;
using Com.Bateeq.Service.Core.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    public abstract class BaseImplController<TBusinessLogic, TModel, TViewModel> : Controller, IBaseController<TViewModel>
        where TBusinessLogic : BaseLogicImpl<TModel>
        where TModel : MigrationModel, IValidatableObject
        where TViewModel : BaseVM, IValidatableObject
    {
        TBusinessLogic BusinessLogic;
        private string ApiVersion = "1";
        private string Username;
        private string Token;
        private string Message;

        public BaseImplController(TBusinessLogic businessLogic)
        {
            BusinessLogic = businessLogic;
        }

        [HttpGet("{Id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
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
                    var config = new MapperConfiguration(cfg => {

                        cfg.CreateMap<TModel, TViewModel>();

                    });

                    IMapper iMapper = config.CreateMapper();
                    TViewModel viewModel = iMapper.Map<TModel, TViewModel>(model);
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
                Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
                Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");

                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<TViewModel, TModel>();

                });

                IMapper iMapper = config.CreateMapper();         
                TModel model = iMapper.Map<TViewModel, TModel>(viewModel);

                await BusinessLogic.CreateModel(Username, model);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.CREATED_STATUS_CODE, StatusMessage.OK_MESSAGE)
                    .Ok();
                return Created(String.Concat(Request.Path, "/", 0), Result);
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
                Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
                Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");

                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<TViewModel, TModel>();

                });

                IMapper iMapper = config.CreateMapper();
                TModel model = iMapper.Map<TViewModel, TModel>(viewModel);

                var isExist = await BusinessLogic.IsExsist(id);

                if (isExist && model.Id == id)
                {
                    await BusinessLogic.UpdateModel(Username, model);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpDelete("{Id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
                Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
                
                var isExist = await BusinessLogic.IsExsist(id);

                if (isExist)
                {
                    await BusinessLogic.DeleteModelAsync(Username, id);
                } else
                {
                    Message = StatusMessage.NOT_FOUND_MESSAGE;
                }

                return NoContent();
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