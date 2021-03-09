using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrinjaCarsYard.Data;
using PrinjaCarsYard.Models;

namespace PrinjaCarsYard.Pages.Accessories
{
    public class DetailsModel : PageModel
    {
        private readonly PrinjaCarsYard.Data.PrinjaCarsYardContext _context;

        public DetailsModel(PrinjaCarsYard.Data.PrinjaCarsYardContext context)
        {
            _context = context;
        }

        public Accessorie Accessorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accessorie = await _context.Accessorie.FirstOrDefaultAsync(m => m.ID == id);

            if (Accessorie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
