using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab12.Data;
using lab12.Models;

namespace lab12.Pages.Scholarships
{
    public class CreateModel : PageModel
    {
        private readonly lab12.Data.lab12Contex _context;

        public CreateModel(lab12.Data.lab12Contex context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scholarship Scholarship { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Scholarship == null || Scholarship == null)
            {
                return Page();
            }

            _context.Scholarship.Add(Scholarship);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
