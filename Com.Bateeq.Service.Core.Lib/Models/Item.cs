using Com.Moonlay.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Bateeq.Service.Core.Lib.Models
{
    public class Item : StandardEntity, IValidatableObject
    {
        public string _id { get; set; }
        public string _stamp { get; set; }
        public string _type { get; set; }
        public string _version { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public string Tags { get; set; }
        public ICollection<Component> Components  { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                yield return new ValidationResult("Code is required", new List<string> { "Code" });
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required", new List<string> { "Name" });
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                yield return new ValidationResult("Description is required", new List<string> { "Description" });
            }

            if (string.IsNullOrWhiteSpace(Uom))
            {
                yield return new ValidationResult("Uom is required", new List<string> { "Uom" });
            }

            if (string.IsNullOrWhiteSpace(Tags))
            {
                yield return new ValidationResult("Tags is required", new List<string> { "Tags" });
            }
        }
    }
}
