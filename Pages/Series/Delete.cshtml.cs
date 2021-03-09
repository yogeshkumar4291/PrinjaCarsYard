using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrinjaCarsYard.Data;
using PrinjaCarsYard.Models;

namespace PrinjaCarsYard.Pages.Series
{
    public class DeleteModel : PageModel
    {
        private readonly PrinjaCarsYard.Data.PrinjaCarsYardContext _context;

        public DeleteModel(PrinjaCarsYard.Data.PrinjaCarsYardContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serie Serie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serie = await _context.Serie
                .Include(s => s.Brand).FirstOrDefaultAsync(m => m.ID == id);

            if (Serie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serie = await _context.Serie.FindAsync(id);

            if (Serie != null)
            {
                _context.Serie.Remove(Serie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
