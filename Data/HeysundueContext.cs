using Microsoft.EntityFrameworkCore;

namespace Heysundue.Data
{
    public class HeysundueContext : DbContext
    {
        public HeysundueContext (
            DbContextOptions<HeysundueContext> options)
            : base(options)
        {
        }

        public DbSet<Heysundue.Models.Article> Article { get; set; }
    }
}