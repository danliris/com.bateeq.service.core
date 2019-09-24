using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Models = Com.Bateeq.Service.Core.Lib.Models;

namespace Com.Bateeq.Service.Core.Test.Services.Quality
{
    [Collection("ServiceProviderFixture Collection")]
   public class QualityBasicTest : BasicServiceTest<CoreDbContext, QualityService, Models.Quality>
    {

        private static readonly string[] createAttrAssertions = { "Name" };
        private static readonly string[] updateAttrAssertions = { "Name" };
        private static readonly string[] existAttrCriteria = { "Code" };
        public QualityBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(Models.Quality model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
        }

        public override void EmptyUpdateModel(Models.Quality model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
        }

        public override Models.Quality GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new Models.Quality()
            {
                Code = guid,
                Name = string.Format("TEST {0}", guid),
            };
        }
    }
}
