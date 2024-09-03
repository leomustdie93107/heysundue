using Heysundue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Heysundue.Views.Home
{
    public class InputUser2ViewModel
    {
        public List<Member> Members { get; set; } = new List<Member>();
        public Member Member { get; set; } = new Member();
    }
}
