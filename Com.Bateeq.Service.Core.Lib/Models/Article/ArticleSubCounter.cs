using Com.Moonlay.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Com.Bateeq.Service.Core.Lib.Context;

namespace Com.Bateeq.Service.Core.Lib.Models.Article
{
    public class ArticleSubCounter : StandardEntity, IValidatableObject
    {
        public string _id { get; set; }
        public string _stamp { get; set; }
        public string _type { get; set; }
        public string _version { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ArticleCounter ArticleCounter { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Code))
            {
                yield return new ValidationResult("Code is required", new List<string> { "Code" });
            }

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                yield return new ValidationResult("Name is required", new List<string> { "Name" });
            }

            if (string.IsNullOrWhiteSpace(this.Description))
            {
                yield return new ValidationResult("Description is required", new List<string> { "Description" });
            }
        }
    }
}