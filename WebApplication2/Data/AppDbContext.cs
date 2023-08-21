using Microsoft.EntityFrameworkCore;
using WebApplication2.Ado;
using WebApplication2.Models;

namespace WebApplication2;

public class AppDbContext: DbContext, IDataContext
{
  
//   public DbSet<Product> Products { get; set; }
   public DbSet<Orders> Orders { get; set; }
   
   public DbSet<Customer> Customers { get; set; }
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseMySQL("Datasource=localhost;Database=productsdb;User=root;Password=Volk5801;");
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Customer>().ToTable("Customers");
      modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnName("first_name");
      modelBuilder.Entity<Customer>().Property(p => p.LastName).HasColumnName("last_name");

      modelBuilder.Entity<Orders>().ToTable("Orders");
      modelBuilder.Entity<Orders>().Property(p => p.Id).HasColumnName("order_id");
      modelBuilder.Entity<Orders>().Property(p => p.CustomerId).HasColumnName("customer_id");
      modelBuilder.Entity<Orders>().Property(p => p.ProductId).HasColumnName("product_id");
      modelBuilder.Entity<Orders>().Property(p => p.CreatedAt).HasColumnName("created_at");
   }


   
   public IList<Product?> SelectProducts(IDictionary<string, object>? args = null)
   {
      throw new NotImplementedException();
   }

   public Product? GetProduct(int id)
   {
      throw new NotImplementedException();
   }

   public int InsertProduct(Product product)
   {
      throw new NotImplementedException();
   }

   public int UpdateProduct(int id, Product product)
   {
      throw new NotImplementedException();
   }

   public int DeleteProduct(int id)
   {
      throw new NotImplementedException();
   }

   public IList<Customer?> SelectCustomers(int? id = null)
   {
      return Customers.Cast<Customer?>().ToList();
   }

   public int InsertCustomer(Customer customer)
   {
      throw new NotImplementedException();
   }

   public int UpdateCustomer(int id, Customer customer)
   {
      var updCustomer = Customers.FirstOrDefault(x => x.Id == customer.Id);
      if (updCustomer == null)
      {
         return 0;
      }
      else
      {
         updCustomer.FirstName = customer.FirstName; 
         updCustomer.LastName = customer.LastName;
         updCustomer.Age = customer.Age;
         updCustomer.Country = customer.Country;
         return SaveChanges();
      }
 
      
   }
   

   public int DeleteCustomer(int id)
   {
      throw new NotImplementedException();
   }


   public IList<Orders?> SelectOrders(int? id = null)
   {
      return Orders.Cast<Orders?>().ToList();
     
   }

   public int InsertOrder(Orders order)
   {
      throw new NotImplementedException();
   }

   public int UpdateOrder(int id, IDictionary<string, object> args)
   {
      throw new NotImplementedException();
   }

   public int DeleteOrder(int id)
   {
      throw new NotImplementedException();
   }
}