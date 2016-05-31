using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreDTO = SuperZapatosDTO.Store;

namespace SuperZapatosWebAPI.Models
{
    public class StoreModel : SuccessBase
    {
        public StoreDTO Store { get; set; }
    }
}