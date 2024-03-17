using BulkyBook.Models; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess
{
    // ApplicationDbContext class that inherits from IdentityDbContext, which provides the Entity Framework Core identity functionality
    public class ApplicationDbContext : IdentityDbContext
    {
        // Constructor that takes DbContextOptions<ApplicationDbContext> as a parameter
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties representing database tables
        public DbSet<Category> Categories { get; set; } 
        public DbSet<CoverType> CoverTypes { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
        public DbSet<Company> Companies { get; set; } 

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } 
        public DbSet<OrderHeader> OrderHeaders { get; set; } 
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}