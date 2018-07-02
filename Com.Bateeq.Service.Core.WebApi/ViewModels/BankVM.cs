using Newtonsoft.Json;

namespace Com.Bateeq.Service.Core.WebApi.ViewModels
{
    public class BankVM : BaseVM
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
