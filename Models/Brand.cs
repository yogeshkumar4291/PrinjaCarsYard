using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrinjaCarsYard.Models
{
    public class Brand// TABLE BRAND
    {
        public int ID { get; set; } //PRIMARY KEY

        public string Name { get; set; }
        public ICollection<Serie> serie{ get; set; }// NAVIGATE SERIE MODE
    }
}
