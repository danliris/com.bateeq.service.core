using System;

namespace Com.Bateeq.Service.Core.Lib.Common.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        public bool DefaultValue { get; set; }
    }
}
