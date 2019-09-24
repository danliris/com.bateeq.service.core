using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Services;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using Com.Bateeq.Service.Core.Test.Helpers;
using System.Collections.Generic;
using Models = Com.Bateeq.Service.Core.Lib.Models;
using Xunit;
using Com.Bateeq.Service.Core.Test.DataUtils;

namespace Com.Bateeq.Service.Core.Test.Controllers.BudgetCurrency
{
	[Collection("TestFixture Collection")]
	public class BudgetCurrencyBasicTest : BasicControllerTest<CoreDbContext, BudgetCurrencyService, Models.BudgetCurrency, BudgetCurrencyViewModel, BudgetCurrencyDataUtil>
	{
		private const string URI = "v1/master/budget-currencies";
		private static List<string> CreateValidationAttributes = new List<string> { };
		private static List<string> UpdateValidationAttributes = new List<string> { };

		public BudgetCurrencyBasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
		{
		}
		
	}
}