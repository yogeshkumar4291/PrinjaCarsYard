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

namespace PrinjaCarsYard.Pages.Accessories
{
    public class EditModel : PageModel
    {
        private readonly PrinjaCarsYard.Data.PrinjaCarsYardContext _context;

        public EditModel(PrinjaCarsYard.Data.PrinjaCarsYardContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Accessorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessorieExists(Accessorie.ID))
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

        private bool AccessorieExists(int id)
        {
            return _context.Accessorie.Any(e => e.ID == id);
        }
    }
}
