using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.Common.Utils;
using Com.Bateeq.Service.Core.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.Upload
{
    public abstract class BasicUploadController<TModel, TViewModel> : Controller
        where TModel : MigrationModel
        where TViewModel : BaseVM
    {
        //protected string ApiVersion = "1";
        //private readonly string ContentType = "application/vnd.openxmlformats";
        //private readonly string FileName = string.Concat("Error Log - ", typeof(TModel).Name, " ", DateTime.Now.ToString("dd MMM yyyy"), ".csv");

        //[HttpPost]
        //public IActionResult Post()
        //{
        //    try
        //    {
        //        if (Request.Form.Files.Count > 0)
        //        {
        //            var UploadedFile = Request.Form.Files[0];
        //            StreamReader Reader = new StreamReader(UploadedFile.OpenReadStream());
        //            List<string> FileHeader = new List<string>(Reader.ReadLine().Split(","));
        //            var ValidHeader = _service.CsvHeader.SequenceEqual(FileHeader, StringComparer.OrdinalIgnoreCase);

        //            if (ValidHeader)
        //            {
        //                Reader.DiscardBufferedData();
        //                Reader.BaseStream.Seek(0, SeekOrigin.Begin);
        //                Reader.BaseStream.Position = 0;

        //                CsvReader Csv = new CsvReader(Reader);
        //                Csv.Configuration.IgnoreQuotes = false;
        //                Csv.Configuration.Delimiter = ",";
        //                Csv.Configuration.RegisterClassMap<TModelMap>();
        //                Csv.Configuration.HeaderValidated = null;

        //                List<TViewModel> Data = Csv.GetRecords<TViewModel>().ToList();

        //                Tuple<bool, List<object>> Validated = _service.UploadValidate(Data, Request.Form.ToList());

        //                Reader.Close();

        //                if (Validated.Item1) /* If Data Valid */
        //                {
        //                    using (var Transaction = _service.DbContext.Database.BeginTransaction())
        //                    {
        //                        foreach (TViewModel modelVM in Data)
        //                        {
        //                            TModel model = _service.MapToModel(modelVM);
        //                            _service.DbSet.Add(model);
        //                            _service.OnCreating(model);
        //                        }

        //                        _service.DbContext.SaveChanges();

        //                        Transaction.Commit();

        //                        Dictionary<string, object> Result =
        //                            new ResultFormatter(ApiVersion, StatusMessage.CREATED_STATUS_CODE, StatusMessage.OK_MESSAGE)
        //                            .Ok();
        //                        return Created(HttpContext.Request.Path, Result);
        //                    }
        //                }
        //                else
        //                {
        //                    using (MemoryStream memoryStream = new MemoryStream())
        //                    {
        //                        using (StreamWriter streamWriter = new StreamWriter(memoryStream))
        //                        using (CsvWriter csvWriter = new CsvWriter(streamWriter))
        //                        {
        //                            csvWriter.WriteRecords(Validated.Item2);
        //                        }

        //                        return File(memoryStream.ToArray(), ContentType, FileName);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Dictionary<string, object> Result =
        //                   new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, StatusMessage.CSV_ERROR_MESSAGE)
        //                   .Fail();

        //                return NotFound(Result);
        //            }
        //        }
        //        else
        //        {
        //            Dictionary<string, object> Result =
        //                new ResultFormatter(ApiVersion, StatusMessage.BAD_REQUEST_STATUS_CODE, StatusMessage.NO_FILE_ERROR_MESSAGE)
        //                    .Fail();
        //            return BadRequest(Result);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Dictionary<string, object> Result =
        //           new ResultFormatter(ApiVersion, StatusMessage.INTERNAL_ERROR_STATUS_CODE, e.Message)
        //           .Fail();

        //        return StatusCode(StatusMessage.INTERNAL_ERROR_STATUS_CODE, Result);
        //    }
        //}
    }
}