using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using System;
using Xunit;
using Models = Com.Bateeq.Service.Core.Lib.Models;

namespace Com.Bateeq.Service.Core.Test.Services.GarmentSection
{
    [Collection("ServiceProviderFixture Collection")]
    public class GarmentSectionBasicTest : BasicServiceTest<CoreDbContext, GarmentSectionService, Models.GarmentSection>
    {
        private static readonly string[] createAttrAssertions = { "Code", "Name" };
        private static readonly string[] updateAttrAssertions = { "Code", "Name" };
        private static readonly string[] existAttrCriteria = { "Code", "Name" };
        public GarmentSectionBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(Models.GarmentSection model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
        }

        public override void EmptyUpdateModel(Models.GarmentSection model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
        }

        public override Models.GarmentSection GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new Models.GarmentSection()
            {
                Code = guid,
                Name = string.Format("TEST {0}", guid),
            };
        }

        
    }
}
