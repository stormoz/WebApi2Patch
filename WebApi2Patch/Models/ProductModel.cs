namespace WebApi2Patch.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class ProductModel : IValidatableObject
    {
        [Required]
        public string Code { get; set; }

        public string Name { get; set; }

        public bool Flag { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (Name == "blabla")
            {
                validationResults.Add(new ValidationResult("Model is invalid!"));
            }

            return validationResults;
        }
    }
}