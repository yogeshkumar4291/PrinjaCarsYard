using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrinjaCarsYard.Data;
using PrinjaCarsYard.Models;

namespace PrinjaCarsYard.Pages.Series
{
    public class EditModel : PageModel
    {
        private readonly PrinjaCarsYard.Data.PrinjaCarsYardContext _context;

        public EditModel(PrinjaCarsYard.Data.PrinjaCarsYardContext context)
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
           ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(Serie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SerieExists(int id)
        {
            return _context.Serie.Any(e => e.ID == id);
        }
    }
}
