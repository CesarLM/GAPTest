using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatosMVC.Models
{
    public class BaseModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return null;
        }
    }
}