using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Test.Helpers;
using System.Collections.Generic;
using Models = Com.Bateeq.Service.Core.Lib.Models;
using Xunit;
using Com.Bateeq.Service.Core.Test.DataUtils;

namespace Com.Bateeq.Service.Core.Test.Controllers.IncomeTax
{
    [Collection("TestFixture Collection")]
    public class IncomeTaxBasicTest : BasicControllerTest<CoreDbContext, IncomeTaxService, Models.IncomeTax, IncomeTaxViewModel, IncomeTaxDataUtil>
    {
        private const string URI = "v1/master/income-taxes";

        private static List<string> CreateValidationAttributes = new List<string> { };
        private static List<string> UpdateValidationAttributes = new List<string> { };

        public IncomeTaxBasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
        {
        }
    }
}
