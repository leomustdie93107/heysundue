using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Heysundue.Models;

public class ArticleContext : DbContext
{
    public ArticleContext(DbContextOptions<ArticleContext> options)
        : base(options)
    {
    }

    public DbSet<Article> Article { get; set; } = default!;
    public DbSet<Person> Persons { get; set; } = default!;

    public DbSet<Registration> Registrations { get; set; } = default!;

    public DbSet<Login> Login { get; set; } = default!;

    public DbSet<Joinlist> Joinlists { get; set; } = default!;

    public DbSet<Doorsystem>  Doorsystems { get; set; } = default!;

    public DbSet<Accessdoor> Accessdoors { get; set; } = default!;

}
