using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Test.DataUtils;
using Com.Bateeq.Service.Core.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Bateeq.Service.Core.Test.Controllers.StorageTests
{
    [Collection("TestFixture Collection")]
    public class BasicTest : BasicControllerTestOldVM<CoreDbContext, StorageService, Storage, StorageViewModel, StorageDataUtil>
    {
        private const string URI = "v1/master/storages";

        private static List<string> CreateValidationAttributes = new List<string> { };
        private static List<string> UpdateValidationAttributes = new List<string> { };

        public BasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
        {
        }
    }
}
