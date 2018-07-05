using Com.Bateeq.Service.Core.Lib.Common.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Bateeq.Service.Core.Lib.Models
{
    public class Supplier : MigrationModel, IValidatableObject
    {
        [Required]
        [StringLength(150)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string PIC { get; set; }

        [Required]
        [SqlDefaultValueAttribute(DefaultValue = false)]
        [StringLength(200)]
        public string Import { get; set; }

        [StringLength(200)]
        public string NPWP { get; set; }

        [StringLength(200)]
        public string SerialNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Code))
            {
                yield return new ValidationResult("Code not be empty", new List<string> { "code" });
            }

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                yield return new ValidationResult("Code not be empty", new List<string> { "name" });
            }

            if (this.Import == null)
            {
                yield return new ValidationResult("Import not be empty", new List<string> { "import" });
            }
        }
    }
}
