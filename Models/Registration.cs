using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public string? DisplayLocation { get; set; }

        public string? DisplayStatus { get; set; }
        public string? ItemName { get; set; }
        public int? TotalAmount { get; set; }

        public int? TotalAmountUSD { get; set; }
    }
}
