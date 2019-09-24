﻿using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Test.DataUtils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Bateeq.Service.Core.Test.Services.GarmentSupplierTest
{
	[Collection("ServiceProviderFixture Collection")]
	public class BasicTests : BasicServiceTest<CoreDbContext, GarmentSupplierService, GarmentSupplier>
	{
		private static readonly string[] createAttrAssertions = { "Name" };
		private static readonly string[] updateAttrAssertions = { "Name" };
		private static readonly string[] existAttrCriteria = { "Code" };
		public BasicTests(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
		{
		}
		public override void EmptyCreateModel(GarmentSupplier model)
		{
            model.Code = string.Empty;
			model.Name = string.Empty;
			model.UseTax = true;
            model.IncomeTaxesId = 0;
		}

		public override void EmptyUpdateModel(GarmentSupplier model)
		{
            model.Code = string.Empty;
			model.Name = string.Empty;
			model.UseTax = true;
            model.IncomeTaxesId = 0;
        }
		public override GarmentSupplier GenerateTestModel()
		{
			string guid = Guid.NewGuid().ToString();

			return new GarmentSupplier()
			{
				Code = guid,
				Name = guid,
				UseTax = true,
				UseVat = true,
				Import = true,
				IncomeTaxesId = 1,
                IncomeTaxesName = guid,
                IncomeTaxesRate = 1
			};
		}

        private GarmentSupplierDataUtil DataUtil
        {
            get { return (GarmentSupplierDataUtil)ServiceProvider.GetService(typeof(GarmentSupplierDataUtil)); }
        }

        private GarmentSupplierService Services
        {
            get { return (GarmentSupplierService)ServiceProvider.GetService(typeof(GarmentSupplierService)); }
        }
        [Fact]
        public async void Should_Error_Upload_CSV_Data_with_false_IncomeTax()
        {
            GarmentSupplierViewModel Vmodel1 = await DataUtil.GetNewData1();
            GarmentSupplierViewModel Vmodel2 = await DataUtil.GetNewData2();
            GarmentSupplierViewModel Vmodel3 = await DataUtil.GetNewData3();
            var Response = Services.UploadValidate(new List<GarmentSupplierViewModel> { Vmodel1, Vmodel2, Vmodel3}, null);
            Assert.Equal(Response.Item1, false);
        }
        [Fact]
        public async void Should_Success_Upload_CSV_Data_when_UseTax_False()
        {
            GarmentSupplierViewModel Vmodel4 = await DataUtil.GetNewData4();
            var Response = Services.UploadValidate(new List<GarmentSupplierViewModel> { Vmodel4 }, null);
            Assert.Equal(Response.Item1, true);
        }
        [Fact]
        public async void Should_Error_Upload_CSV_Data_when_UseTax_False()
        {
            GarmentSupplierViewModel Vmodel5 = await DataUtil.GetNewData5();
            GarmentSupplierViewModel Vmodel6 = await DataUtil.GetNewData6();
            GarmentSupplierViewModel Vmodel7 = await DataUtil.GetNewData7();
            var Response = Services.UploadValidate(new List<GarmentSupplierViewModel> { Vmodel5 , Vmodel6, Vmodel7 }, null);
            Assert.Equal(Response.Item1, false);
        }
    }
}
