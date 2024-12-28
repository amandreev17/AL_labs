using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab12.Data;
using lab12.Models;

namespace lab12.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly lab12.Data.lab12Contex _context;

        public IndexModel(lab12.Data.lab12Contex context)
        {
            _context = context;
        }

        public IList<Group> Group { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Group != null)
            {
                Group = await _context.Group.ToListAsync();
            }
        }
    }
}
