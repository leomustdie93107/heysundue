using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
public class Person
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age is required")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }
}
}
