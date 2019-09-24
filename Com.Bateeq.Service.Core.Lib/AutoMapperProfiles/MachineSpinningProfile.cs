using AutoMapper;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.ViewModels;

namespace Com.Bateeq.Service.Core.Lib.AutoMapperProfiles
{
    public class MachineSpinningProfile : Profile
    {
        public MachineSpinningProfile()
        {
            CreateMap<MachineSpinningModel, MachineSpinningViewModel>()
                .ReverseMap();
            CreateMap<MachineSpinningProcessType, MachineSpinningProcessTypeViewModel>()
                .ReverseMap();
        }
    }
}
