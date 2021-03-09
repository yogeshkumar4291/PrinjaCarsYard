using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrinjaCarsYard.Models
{
    public class Serie// TABTLE SERIES MODEL
    {
        public int ID { get; set; } //PRIMARY KEY
        public int BrandID { get; set; }
        public Brand Brand { get; set; } //BRAND NAME CONNECTED WITH BRAND MODEL
        public string name { get; set; }
        public int price { get; set; }
      
        public string Colours { get; set; }

    }
}
