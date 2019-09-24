using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using System;
using Xunit;
using Models = Com.Bateeq.Service.Core.Lib.Models;

namespace Com.Bateeq.Service.Core.Test.Services.MaterialConstruction
{
    [Collection("ServiceProviderFixture Collection")]
    public class MaterialConstructionBasicTest : BasicServiceTest<CoreDbContext, MaterialConstructionService, Models.MaterialConstruction>
    {
        //private static readonly string[] createAttrAssertions = { "Code", "Name" };
        //private static readonly string[] updateAttrAssertions = { "Code", "Name" };
        //private static readonly string[] existAttrCriteria = { "Code" };

        private static readonly string[] createAttrAssertions = { "Name" };
        private static readonly string[] updateAttrAssertions = { "Name" };
        private static readonly string[] existAttrCriteria = { "Name" };

        public MaterialConstructionBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }
        public override void EmptyCreateModel(Models.MaterialConstruction model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.Remark = string.Empty;
        }

        public override void EmptyUpdateModel(Models.MaterialConstruction model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.Remark = string.Empty;
        }

        public override Models.MaterialConstruction GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new Models.MaterialConstruction()
            {
                Code = guid,
                Name = string.Format("TEST {0}", guid),
                Remark = "remark",
            };
        }
    }
}

