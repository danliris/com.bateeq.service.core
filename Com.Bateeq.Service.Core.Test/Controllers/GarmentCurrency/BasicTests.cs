﻿using Com.Bateeq.Service.Core.Lib.ViewModels;
using System;
using Newtonsoft.Json;
using System.Net;
using Models = Com.Bateeq.Service.Core.Lib.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Test.DataUtils;
using System.Collections.Generic;

namespace Com.Bateeq.Service.Core.Test.Controllers.GarmentCurrency
{
	[Collection("TestFixture Collection")]
	public class BasicTests : BasicControllerTest<CoreDbContext, GarmentCurrencyService, Models.GarmentCurrency, GarmentCurrencyViewModel, GarmentCurrencyDataUtil>
	{
		private const string URI = "v1/master/garment-currencies";
		private static List<string> CreateValidationAttributes = new List<string> { };
		private static List<string> UpdateValidationAttributes = new List<string> { };

		public BasicTests(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
		{
		}

        protected GarmentCurrencyDataUtil DataUtil
        {
            get { return (GarmentCurrencyDataUtil)this.TestFixture.Service.GetService(typeof(GarmentCurrencyDataUtil)); }
        }


        //[Fact]
        //public async Task Should_Success_Get_Data_By_Code()
        //{
        //    string byCodeUri = "v1/master/garment-currencies/byCode";
        //    Models.GarmentCurrency Model = await DataUtil.GetTestDataAsync();
        //    GarmentCurrencyViewModel ViewModel = Service.MapToViewModel(Model);

        //    var response = await this.Client.GetAsync(string.Concat(byCodeUri, "/", ViewModel.code));
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //    var json = response.Content.ReadAsStringAsync().Result;
        //    Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());

        //    Assert.True(result.ContainsKey("apiVersion"));
        //    Assert.True(result.ContainsKey("message"));
        //    Assert.True(result.ContainsKey("data"));
        //    Assert.True(result["data"].GetType().Name.Equals("JObject"));
        //}

        [Fact]
        public async Task Should_Success_Get_Data_By_Code()
        {
            string byCodeUri = "v1/master/garment-currencies/byCode";
            Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
            var response = await this.Client.GetAsync($"{byCodeUri}/{model.Code}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
