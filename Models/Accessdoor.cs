using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Accessdoor
    {
        public int ID { get; set; }
        
        public DateTime? StartDate { get; set; }
        public string? SearchColumn { get; set; }
        public string? Room { get; set; }
        public string? Session { get; set; }
    public IList<Accessdoor> AllAccessdoor { get; set; } = new List<Accessdoor>();

    }
}
