using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosMVC.ServicesConsumer.Contracts
{
    public class Error : SuccessBase
    {
        public bool ErrorCode { get; set; }
        public bool ErrorMessage { get; set; }
    }
}