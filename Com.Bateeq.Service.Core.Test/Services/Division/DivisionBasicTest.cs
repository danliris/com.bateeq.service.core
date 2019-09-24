using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Bateeq.Service.Core.Test.Services.Division
{
    [Collection("ServiceProviderFixture Collection")]
    public class DivisionBasicTest : BasicServiceTest<CoreDbContext, DivisionService, Lib.Models.Division>
    {
        private static readonly string[] createAttrAssertions = { "Name" };
        private static readonly string[] updateAttrAssertions = { "Name" };
        private static readonly string[] existAttrCriteria = { "Name" };

        public DivisionBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(Lib.Models.Division model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
        }

        public override void EmptyUpdateModel(Lib.Models.Division model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
        }

        public override Lib.Models.Division GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new Lib.Models.Division()
            {
                Name = String.Concat("TEST DIVISION ", guid),
            };
        }
    }
}
