using Com.Bateeq.Service.Core.Lib.Helpers;
using System;

namespace Com.Bateeq.Service.Core.Lib.ViewModels
{
    public class TermOfPaymentViewModel : BasicViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public bool IsExport { get; set; }
    }
}
