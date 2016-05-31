using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWebAPI.Models
{
    public class SuccessBase
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}