using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreDTO = SuperZapatosDTO.Store;


namespace SuperZapatosWebAPI.Models
{
    public class StoresModel : SuccessBase
    {
        public IList<StoreDTO> Stores { get; set; }
        public int TotalElements { get; set; }
    }
}