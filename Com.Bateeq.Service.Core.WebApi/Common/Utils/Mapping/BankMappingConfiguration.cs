using AutoMapper;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.WebApi.Common.Utils.Mapping
{
    public class BankMappingConfiguration : Profile
    {
        public BankMappingConfiguration()
        {
            CreateMap<Bank, BankVM>().ReverseMap();
        }
    }
}
