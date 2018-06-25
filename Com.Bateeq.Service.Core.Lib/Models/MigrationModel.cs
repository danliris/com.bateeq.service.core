using Com.Moonlay.Models;

namespace Com.Bateeq.Service.Core.Lib.Models
{
    public class MigrationModel : StandardEntity
    {
        public string _id { get; set; }
        public string _stamp { get; set; }
        public string _type { get; set; }
        public string _version { get; set; }
    }
}
