using Heysundue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Heysundue.Views.Home
{
    public class SetDate3ViewModel
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public Person Person { get; set; } = new Person();
    }
}
