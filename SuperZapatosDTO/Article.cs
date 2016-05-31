using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosDTO
{
    public class Article : BaseDTO
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Total_In_Shelf { get; set; }
        public int Total_In_Vault { get; set; }
        public Guid StoreId { get; set; }
    }
}
