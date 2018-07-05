using AutoMapper;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.WebApi.ViewModels;

namespace Com.Bateeq.Service.Core.WebApi.Common.Utils.Mapping
{
    public class SupplierMappingConfiguration : Profile
    {
        public SupplierMappingConfiguration()
        {
            CreateMap<Supplier, SupplierVM>().ReverseMap();
        }
    }
}
