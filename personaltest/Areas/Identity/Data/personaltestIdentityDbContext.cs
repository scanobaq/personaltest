using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using personaltest.Areas.Entities;

namespace personaltest.Areas.Identity.Data;

public class personaltestIdentityDbContext : IdentityDbContext<UserTest>
{
    public personaltestIdentityDbContext(DbContextOptions<personaltestIdentityDbContext> options) : base(options)
    {
    }


    public virtual DbSet<Poliza> Polizas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUser>().ToTable("UserTest");
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
