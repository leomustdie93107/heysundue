using Heysundue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Heysundue.Views.Home
{
    public class Joinlist2ViewModel
    {
        public List<Joinlist> Joinlists { get; set; } = new List<Joinlist>();
        public Joinlist Joinlist { get; set; } = new Joinlist();
    }
}
