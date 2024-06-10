using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Joinlist
    {
        public int ID { get; set; }

        public string? SearchColumn { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public string?  SearchKeyword{ get; set; }

        public string? Participants { get; set; }

        public string? RegNo { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ChineseName { get; set; }

        public string? Country { get; set; }

        public string? RegistrationStatus { get; set; }

    }
}
