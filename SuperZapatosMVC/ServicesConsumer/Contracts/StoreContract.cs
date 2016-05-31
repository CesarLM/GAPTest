using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreDTO = SuperZapatosDTO.Store;

namespace SuperZapatosMVC.ServicesConsumer.Contracts
{
    public class StoreContract : SuccessBase
    {
        public StoreDTO Store { get; set; }
    }
}