using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Login
    {
        public int ID { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
