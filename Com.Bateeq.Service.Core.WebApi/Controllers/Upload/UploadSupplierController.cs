using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Com.Bateeq.Service.Core.Lib.Common.Helper;
using Com.Bateeq.Service.Core.Lib.Facades.Logic;

namespace Com.Bateeq.Service.Core.WebApi.Controllers.Upload
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/upload-suppliers")]
    [Authorize]
    public class UploadSupplierController
    {
        private UserIdentity UserIdentity;
        private SupplierLogic BusinessLogic;
        protected string ApiVersion = "1";

        public UploadSupplierController(SupplierLogic supplierLogic)
        {
            BusinessLogic = supplierLogic;
        }
    }
}