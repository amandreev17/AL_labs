using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab12.Data;
using lab12.Models;

namespace lab12.Pages.Scholarships
{
    public class DeleteModel : PageModel
    {
        private readonly lab12.Data.lab12Contex _context;

        public DeleteModel(lab12.Data.lab12Contex context)
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

            var scholarship = await _context.Scholarship.FirstOrDefaultAsync(m => m.StipId == id);

            if (scholarship == null)
            {
                return NotFound();
            }
            else 
            {
                Scholarship = scholarship;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Scholarship == null)
            {
                return NotFound();
            }
            var scholarship = await _context.Scholarship.FindAsync(id);

            if (scholarship != null)
            {
                Scholarship = scholarship;
                _context.Scholarship.Remove(Scholarship);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
