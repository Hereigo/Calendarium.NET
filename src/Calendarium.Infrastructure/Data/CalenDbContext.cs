using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendarium.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Calendarium.Infrastructure.Data;

public class CalenDbContext : DbContext
{
    public CalenDbContext(DbContextOptions<CalenDbContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlServer(Сonfiguration.GetConnectionString("DefaultConnection"));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=aaa250505;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    // public DbSet<Note> Notes { get; set; }
}
