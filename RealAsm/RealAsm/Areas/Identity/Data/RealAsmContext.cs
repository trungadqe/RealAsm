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
        builder.Entity<RealAsmUser>()
            .HasOne<Store>(au => au.Store)
            .WithOne(st => st.User)
            .HasForeignKey<Store>(st => st.UId);

        builder.Entity<Book>()
            .HasOne<Store>(b => b.Store)
            .WithMany(st => st.Books)
            .HasForeignKey(b => b.StoreId);

        builder.Entity<Book>()
            .HasOne<Category>(b => b.Category)
            .WithMany(st => st.Books)
            .HasForeignKey(b => b.CategoryId);

        builder.Entity<Order>()
            .HasOne<RealAsmUser>(o => o.User)
            .WithMany(ap => ap.Orders)
            .HasForeignKey(o => o.UId);

        builder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderId, od.BookIsbn });
        builder.Entity<OrderDetail>()
            .HasOne<Order>(od => od.Order)
            .WithMany(or => or.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        builder.Entity<OrderDetail>()
            .HasOne<Book>(od => od.Book)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(od => od.BookIsbn);

    }
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Store> Store { get; set; } = null!;
    public DbSet<Book> Book { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetail { get; set; }

}
