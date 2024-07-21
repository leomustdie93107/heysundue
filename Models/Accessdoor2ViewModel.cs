using Heysundue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Heysundue.Views.Home
{
    public class Accessdoor2ViewModel
    {
        public List<Accessdoor> Accessdoors { get; set; } = new List<Accessdoor>();
        public Accessdoor Accessdoor { get; set; } = new Accessdoor();

        public IList<DateTime?> UniqueDates { get; set; } = new List<DateTime?>();
        public IList<string> UniqueRooms { get; set; } = new List<string>();
        public IList<string> UniqueSessions { get; set; } = new List<string>();
    }
}
