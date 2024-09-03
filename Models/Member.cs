using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Member
    {
        public int ID { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserPassword { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int? Phone { get; set; }

        public DateTime? Date { get; set; }

        public string? Level { get; set; }
    }
}