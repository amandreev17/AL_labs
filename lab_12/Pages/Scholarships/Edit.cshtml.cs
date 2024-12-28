using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab12.Data;
using lab12.Models;

namespace lab12.Pages.Scholarships
{
    public class EditModel : PageModel
    {
        private readonly lab12.Data.lab12Contex _context;

        public EditModel(lab12.Data.lab12Contex context)
        {
            _context = context;
        }

        [BindProperty]
        public Scholarship Scholarship { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scholarship == null)
            {
                return NotFound();
            }

            var scholarship =  await _context.Scholarship.FirstOrDefaultAsync(m => m.StipId == id);
            if (scholarship == null)
            {
                return NotFound();
            }
            Scholarship = scholarship;
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

            _context.Attach(Scholarship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScholarshipExists(Scholarship.StipId))
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

        private bool ScholarshipExists(int id)
        {
          return (_context.Scholarship?.Any(e => e.StipId == id)).GetValueOrDefault();
        }
    }
}
