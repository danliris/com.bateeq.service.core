using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Bateeq.Service.Core.Lib.Models
{
    public class Bank : MigrationModel, IValidatableObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
