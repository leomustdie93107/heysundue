using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
 
 
    public class Joinlist
    {
        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public string? RegNo { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ChineseName { get; set; }

        public string? Country { get; set; }

        public string? RegistrationStatus { get; set; }

        public IList<Joinlist> AllJoinlist { get; set; } = new List<Joinlist>();

    }
}
