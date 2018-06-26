using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Bateeq.Service.Core.WebApi.ViewModels
{
    public class BankVM : BaseVM, IValidatableObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Code))
            {
                yield return new ValidationResult("Code is Empty", new List<string> { "code" });
            }

            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is Empty", new List<string> { "name" });
            }

        }
    }
}
