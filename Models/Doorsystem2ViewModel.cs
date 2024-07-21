using Heysundue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Heysundue.Views.Home
{
    public class Doorsystem2ViewModel
    {
        public List<Doorsystem> Doorsystems { get; set; } = new List<Doorsystem>();
        public Doorsystem Doorsystem { get; set; } = new Doorsystem();
    }
}
