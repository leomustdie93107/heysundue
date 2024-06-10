using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Doorsystem
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string? Session { get; set; }
        public string? SessionName { get; set; }
        public string? Room { get; set; }
        public string? TimeRange { get; set; }
    }
}
