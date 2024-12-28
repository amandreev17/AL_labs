using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab12.Models;

namespace lab12.Data
{
    public class lab12Contex : DbContext
    {
        public lab12Contex (DbContextOptions<lab12Contex> options)
            : base(options)
        {
        }

        public DbSet<lab12.Models.Student> Student { get; set; } = default!;

        public DbSet<lab12.Models.Group> Group { get; set; } = default!;

        public DbSet<lab12.Models.Scholarship> Scholarship { get; set; } = default!;
    }
}
