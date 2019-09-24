﻿using Com.Bateeq.Service.Core.Test.Helpers;
using Com.Bateeq.Service.Core.Lib;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Bateeq.Service.Core.Test.Services.AccountBankTests
{
    [Collection("ServiceProviderFixture Collection")]
    public class Basic : BasicServiceTest<CoreDbContext, AccountBankService, AccountBank>
    {
        private static readonly string[] createAttrAssertions = { "BankName", "AccountName","AccountNumber","CurrencyId" };
        private static readonly string[] updateAttrAssertions = { "BankName", "AccountName", "AccountNumber", "CurrencyId" };
        private static readonly string[] existAttrCriteria = { "BankName",  "AccountNumber" };

        public Basic(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(AccountBank model)
        {
            model.BankName = string.Empty;
            model.AccountName = string.Empty;
            model.AccountNumber = string.Empty;
            model.CurrencyId = null;
        }

        public override void EmptyUpdateModel(AccountBank model)
        {
            model.BankName = string.Empty;
            model.AccountName = string.Empty;
            model.AccountNumber = string.Empty;
            model.CurrencyId = null;
        }

        public override AccountBank GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new AccountBank()
            {
                Code = guid,
                AccountName = "TEST BANK" + guid,
                BankName = "TEST BANK" + guid,
                AccountNumber = "TEST BANK" + guid,
                BankAddress = "TEST BANK",
                CurrencyCode = "TEST BANK",
                CurrencyDescription = "TEST BANK",
                DivisionCode = "TEST BANK",
                DivisionName = "TEST BANK",
                Fax = "TEST BANK",
                Phone = "TEST BANK",
                CurrencySymbol = "TEST BANK",
                CurrencyRate=1,
                SwiftCode = "TEST BANK",
                DivisionId=1,
                CurrencyId=1
            };
        }
    }
}