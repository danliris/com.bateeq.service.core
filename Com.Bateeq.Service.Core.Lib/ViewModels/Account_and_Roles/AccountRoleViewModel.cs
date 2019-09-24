using Com.Bateeq.Service.Core.Lib.Helpers;
using Com.Bateeq.Service.Core.Lib.Models.Account_and_Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Core.Lib.ViewModels.Account_and_Roles
{
    public class AccountRoleViewModel :BasicViewModel
    {
        public int AccountId { get; set; }
        //public virtual Account Account { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
