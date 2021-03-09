using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrinjaCarsYard.Models;

namespace PrinjaCarsYard.Data
{
    public class PrinjaCarsYardContext : DbContext
    {
        public PrinjaCarsYardContext (DbContextOptions<PrinjaCarsYardContext> options)
            : base(options)
        {
        }

        public DbSet<PrinjaCarsYard.Models.Accessorie> Accessorie { get; set; }

        public DbSet<PrinjaCarsYard.Models.Brand> Brand { get; set; }

        public DbSet<PrinjaCarsYard.Models.Serie> Serie { get; set; }
    }
}
