using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Core.WebApi.ViewModels
{
    public abstract class BaseVM
    {
        public bool Active { get; set; }
        public DateTime CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAgent { get; set; }
        public DateTime LastModifiedUtc { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedAgent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedUtc { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedAgent { get; set; }
        public string _id { get; set; }
        public string _stamp { get; set; }
        public string _type { get; set; }
        public string _version { get; set; }
    }
}
