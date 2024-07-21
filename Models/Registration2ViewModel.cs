using Heysundue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Heysundue.Views.Home
{
    public class Registration2ViewModel
    {
        public List<Registration> Registrations { get; set; } = new List<Registration>();
        public Registration Registration { get; set; } = new Registration();
    }
}
