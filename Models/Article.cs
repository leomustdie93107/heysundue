using System;
using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string? Number { get; set; }
	public string? Title { get; set; }
	public string? Link { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Gender { get; set; }
        public decimal Count { get; set; }
    }
}