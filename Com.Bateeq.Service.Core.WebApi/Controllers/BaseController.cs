using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Com.Bateeq.Service.Core.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Com.Moonlay.Models;
using System.ComponentModel.DataAnnotations;
using Com.Bateeq.Service.Core.WebApi.Helpers;
using System.Threading.Tasks;
using Com.Moonlay.NetCore.Lib.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Com.Bateeq.Service.Core.WebApi.Controllers
{
    public abstract class BaseController<TBaseService, TModel, TDbContext> : Controller
        where TBaseService : BaseService<TDbContext, TModel>
        where TDbContext : DbContext
        where TModel : StandardEntity, IValidatableObject
    {
        private readonly TBaseService _service;

        public BaseController(TBaseService service)
        {
            _service = service;
        }

        /*
         * @parameter page int
         * @parameter size int
         * @parameter order json object 
         * @parameter select List string type
         * @parameter keyword string
         * example order : { "[field]" : "[order]" } where order asc or desc
         */
        [HttpGet]
        public IActionResult Get(int page = 1, 
                                 int size = 25, 
                                 string order = "", 
                                 [Bind(Prefix = "Select[]")]List<string> select = null, 
                                 string keyword = "")
        {
            try
            {
                Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> data = 
                    _service.ReadModel(page, size, order, select, keyword);
                Dictionary<string, object> result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.OK, 
                                        HttpStatusCode.OK.ToString())
                                            .Ok<TModel>(data.Item1, 
                                                        page, 
                                                        size, 
                                                        data.Item2, 
                                                        data.Item1.Count, 
                                                        data.Item3, 
                                                        data.Item4);

                return Ok(result);
            }
            catch (Exception exception)
            {
                Dictionary<string, object> result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.InternalServerError, 
                                        exception.Message)
                                            .Fail();

                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        /*
         * paramater Id for new search by Id int type
         */
        [HttpGet("new/{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var model = await _service.ReadModelById(id);

                if (model == null)
                {
                    Dictionary<string, object> ResultNotFound = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.NotFound, 
                                            HttpStatusCode.NotFound.ToString())
                                                .Fail();

                    return NotFound(ResultNotFound);
                }
                else
                {
                    Dictionary<string, object> Result = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.OK, 
                                            HttpStatusCode.OK.ToString())
                                                .Ok<TModel>(model);

                    return Ok(Result);
                }
            }
            catch (Exception exception)
            {
                Dictionary<string, object> result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.InternalServerError, 
                                        exception.Message)
                                            .Fail();

                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        /*
         * paramater Id for old data from monggoDb _id
         */
        [HttpGet("{_id}")]
        public async Task<IActionResult> GetById(string _id)
        {
            try
            {
                var model = await _service.ReadModelById(_id);

                if (model == null)
                {
                    Dictionary<string, object> ResultNotFound = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.NotFound, 
                                            HttpStatusCode.NotFound.ToString())
                                                .Fail();

                    return NotFound(ResultNotFound);
                }
                else
                {
                    Dictionary<string, object> Result = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.OK, 
                                            HttpStatusCode.OK.ToString())
                                                .Ok<TModel>(model);

                    return Ok(Result);
                }
            }
            catch (Exception exception)
            {
                Dictionary<string, object> result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.InternalServerError, 
                                        exception.Message)
                                            .Fail();

                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        /*
         * Create Method with Model Parameter
         */
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TModel Model)
        {
            try
            {
                await _service.CreateModel(Model);

                Dictionary<string, object> Result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.OK, 
                                        HttpStatusCode.OK.ToString())
                                            .Ok();

                return Created(String.Concat(HttpContext.Request.Path, "/", Model.Id), Result);
            }
            catch (ServiceValidationExeption serviceValidationException)
            {
                Dictionary<string, object> Result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.BadRequest, 
                                        HttpStatusCode.BadRequest.ToString())
                                            .Fail(serviceValidationException);

                return BadRequest(Result);
            }
            catch (Exception exception)
            {
                Dictionary<string, object> Result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.InternalServerError, 
                                        exception.Message)
                                            .Fail();

                return StatusCode((int)HttpStatusCode.InternalServerError, Result);
            }
        }

        /*
         * Update Method parameter Id type of Int and Model
         */
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromRoute] int Id, [FromBody] TModel Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (Id != Model.Id)
                {
                    Dictionary<string, object> Result = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.BadRequest, 
                                            HttpStatusCode.BadRequest.ToString())
                                                .Fail();

                    return BadRequest(Result);
                }

                await _service.UpdateModel(Id, Model);

                return NoContent();
            }
            catch (ServiceValidationExeption serviceValidationException)
            {
                Dictionary<string, object> Result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.BadRequest, 
                                        HttpStatusCode.BadRequest.ToString())
                                            .Fail(serviceValidationException);

                return BadRequest(Result);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                if (!_service.IsExists(Id))
                {
                    Dictionary<string, object> Result = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.NotFound, 
                                            HttpStatusCode.NotFound.ToString())
                                                .Fail();
                    return NotFound(Result);
                }
                else
                {
                    Dictionary<string, object> Result = 
                        new ResultFormatter(InternalMessage.ApiVersion, 
                                            (int)HttpStatusCode.InternalServerError, 
                                            dbUpdateConcurrencyException.Message)
                                                .Fail();
                    return StatusCode((int)HttpStatusCode.InternalServerError, Result);
                }
            }
            catch (Exception exception)
            {
                Dictionary<string, object> Result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.InternalServerError, 
                                        exception.Message)
                                            .Fail();
                return StatusCode((int)HttpStatusCode.InternalServerError, Result);
            }
        }

        /*
         * Delete Method with Id Parameter type of int
         */
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _service.DeleteModel(Id);

                return NoContent();
            }
            catch (Exception exception)
            {
                Dictionary<string, object> Result = 
                    new ResultFormatter(InternalMessage.ApiVersion, 
                                        (int)HttpStatusCode.InternalServerError, 
                                        exception.Message)
                                        .Fail();
                return StatusCode((int)HttpStatusCode.InternalServerError, Result);
            }
        }
    }
}
