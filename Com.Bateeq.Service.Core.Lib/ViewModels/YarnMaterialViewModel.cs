﻿using Com.Bateeq.Service.Core.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Bateeq.Service.Core.Lib.ViewModels
{
    public class YarnMaterialViewModel : BasicViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }         

    }
}
