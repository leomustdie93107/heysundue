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
    public DbSet<Member> Members { get; set; } = default!;

    public DbSet<Registration> Registrations { get; set; } = default!;

    public DbSet<Login> Login { get; set; } = default!;

    public DbSet<Joinlist> Joinlists { get; set; } = default!;
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置 Login 实体为无键实体
        modelBuilder.Entity<Login>().HasNoKey();

        // 你可以在這裡添加其他實體的配置，如果有需要
        // 例如，如果某個實體需要其他特殊配置，也可以在這裡進行設定

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Doorsystem>  Doorsystems { get; set; } = default!;

    public DbSet<Accessdoor> Accessdoors { get; set; } = default!;

}
