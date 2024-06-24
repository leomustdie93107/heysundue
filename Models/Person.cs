using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }


    }
}
