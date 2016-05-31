using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreDTO = SuperZapatosDTO.Store;


namespace SuperZapatosMVC.ServicesConsumer.Contracts
{
    public class StoresContract : SuccessBase
    {
        public List<StoreDTO> Stores { get; set; }
        public int TotalElements { get; set; }
    }
}