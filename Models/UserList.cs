using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Heysundue.Models;

namespace Heysundue.Views.Home
{
    public class Userlist2Model
    {
        public IList<Member> Members { get; set; } = new List<Member>();

        public List<SelectListItem> LevelOptions { get; set; } = new List<SelectListItem>();

        public string? SearchColumn { get; set; }
        public string? SearchKeyword { get; set; }
    }
}
