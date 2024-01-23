using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApiWithPostgreSQL.Data;
using WebApiWithPostgreSQL.Models;
public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Laptop> Laptops { get; set; }
}