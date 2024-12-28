using System;
using System.ComponentModel.DataAnnotations;

namespace lab12.Models
{
	public class Scholarship
	{
        [Key]
        public int StipId { get; set; }
        [Required]
        public decimal Size { get; set; }
    }
}

