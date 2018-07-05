using Newtonsoft.Json;

namespace Com.Bateeq.Service.Core.WebApi.ViewModels
{
    public class SupplierVM : BaseVM
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("PIC")]
        public string PIC { get; set; }

        [JsonProperty("import")]
        public string Import { get; set; }

        [JsonProperty("NPWP")]
        public string NPWP { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }
    }
}
