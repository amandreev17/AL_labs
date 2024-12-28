using System;
using System.ComponentModel.DataAnnotations;

namespace lab12.Models
{
	public class Student
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public int StipId { get; set; }
    }
}

