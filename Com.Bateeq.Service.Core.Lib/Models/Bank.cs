using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Bateeq.Service.Core.Lib.Models
{
    public class Bank : MigrationModel, IValidatableObject
    {
        [Required]
        [StringLength(150)]
        public string Code { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Code))
            {
                yield return new ValidationResult("Code not be empty", new List<string> { "code" });
            }
            
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                yield return new ValidationResult("Name not be empty", new List<string> { "name" });
            }
        }
    }
}
