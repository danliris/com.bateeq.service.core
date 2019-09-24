using Com.Bateeq.Service.Core.Lib.Helpers;
using Com.Bateeq.Service.Core.Lib.Interfaces;
using Com.Bateeq.Service.Core.Lib.Models;
using Com.Bateeq.Service.Core.Lib.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.Lib.Services.MachineSpinning
{
    public interface IMachineSpinningService : IBaseService<MachineSpinningModel>, IBasicUploadCsvService<MachineSpinningCsvViewModel>
    {
        ReadResponse<MachineSpinningModel> ReadNoOnly(int page, int size, string order, List<string> select, string keyword, string filter);
        List<MachineSpinningModel> MapFromCsv(List<MachineSpinningCsvViewModel> data);
        Task<int> UploadData(List<MachineSpinningModel> data);
        MemoryStream DownloadTemplate();
        List<string> GetMachineTypes();
        List<MachineSpinningModel> GetSimple();
        List<MachineSpinningModel> GetFilteredSpinning(string type, string unitId);
    }
}
