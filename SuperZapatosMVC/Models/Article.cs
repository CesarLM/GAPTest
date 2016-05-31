using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatosMVC.Models
{
    public class Article : BaseModel
    {
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }

        [Required(ErrorMessage="Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }

        [Required(ErrorMessage="Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Total_In_Shelf { get; set; }

        [Required(ErrorMessage="Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Total_In_Vault { get; set; }

        [Required(ErrorMessage="Required")]
        public Guid StoreId { get; set; }

    }
}