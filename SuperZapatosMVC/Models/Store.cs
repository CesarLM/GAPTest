using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatosMVC.Models
{
    public class Store : BaseModel
    {
        [Required(ErrorMessage="Required")]
        public string Adress { get; set; }

    }
}