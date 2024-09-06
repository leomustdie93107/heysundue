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

        public int CurrentPage { get; set; }  // 當前頁數
        public int TotalPages { get; set; }   // 總頁數
    }
}
