using Com.Moonlay.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Bateeq.Service.Core.Lib.Models
{
    public class Component : StandardEntity, IValidatableObject
    {
        public string _id { get; set; }
        public string _stamp { get; set; }
        public string _type { get; set; }
        public string _version { get; set; }
        public string Level { get; set; }
        public string Uom { get; set; }
        public string Remark { get; set; }
        public int Quantity { get; set; }
        public Item Item { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Level))
            {
                yield return new ValidationResult("Level is required", new List<string> { "Level" });
            }

            if (string.IsNullOrWhiteSpace(Uom))
            {
                yield return new ValidationResult("Uom is required", new List<string> { "Uom" });
            }

            if (string.IsNullOrWhiteSpace(Remark))
            {
                yield return new ValidationResult("Remark is required", new List<string> { "Remark" });
            }

            if (Quantity == 0)
            {
                yield return new ValidationResult("Quantity is required", new List<string> { "Quantity" });
            }

            if (Item == null)
            {
                yield return new ValidationResult("Item is required", new List<string> { "Item" });
            }
        }
    }
}
