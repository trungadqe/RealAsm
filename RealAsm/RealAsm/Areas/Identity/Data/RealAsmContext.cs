using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealAsm.Areas.Identity.Data;
using RealAsm.Models;

namespace RealAsm.Areas.Identity.Data;

public class RealAsmContext : IdentityDbContext<RealAsmUser>
{
    public RealAsmContext(DbContextOptions<RealAsmContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Category> Categories { get; set; } = null!;
}
