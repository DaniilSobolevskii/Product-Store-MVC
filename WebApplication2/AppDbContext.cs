using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2;

public class AppDbContext: DbContext
{
  
   public DbSet<Product> Products { get; set; }
   public DbSet<Orders> Orders { get; set; }
   public DbSet<Customer> Customers { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.LogTo(Console.Write);
      optionsBuilder.UseMySQL("");
    
   }

   public AppDbContext(): base()
   {
      Database.EnsureCreated();
   }


}