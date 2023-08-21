using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WebApplication2.Ado;

namespace WebApplication2.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IDataContext _dataContext;
    public ProductController() {
        var connectionStringBuilder = new MySqlConnectionStringBuilder {
            Server = "localhost",
            Database = "productsdb",
            UserID = "root",
            Password = "Volk5801"
        };

        //_dataContext = new RawSqlDataContext("Datasource=localhost;Database=shop;User=root;Password=root123;");
        _dataContext = new AdoDataContext(connectionStringBuilder.ConnectionString);
    }
   
   // private AppDbContext db = new AppDbContext();
    
    private static int constId= 3;
    
    private static List<Product> _products = new()
    {
        new Book() { Id = 0, Name = "Властелин колец", Description = "Книга", Price = 1250.4, Count = 2},
        new Movie { Id = 1, Name = "Остров Проклятых", Description = "Фильм", Price = 2000, Count = 12},
        new Accessories { Id = 2, Name = "Бойцовский клуб", Description = "Комикс", Price = 1300, Count = 1}
        
    };
    
    [HttpGet("getProducts")]
    public IList<Product> GetProducts()
    {
        return _dataContext.SelectProducts();
        var model = new IndexModel
        {
            Products = _products
        };
      //  db.Products.Add(_products);
        return model.Products;
        

    }

    [HttpGet("{id}")]
    public Product GetProduct([FromRoute] int id)
    {
        return _dataContext.GetProduct(id);
        return _products.FirstOrDefault(x=>x.Id==id);
    }

    
    [HttpPost("{id}")]
    public void UpdateProduct([FromRoute] int id, [FromBody] Product updProduct)
    {
   
        var x =  _dataContext.UpdateProduct(id, updProduct);
        
       /* var xProduct = _products.FirstOrDefault(x => x.Id == id);
        xProduct.Description = updatedProduct.Description;
        xProduct.Count = updatedProduct.Count;
        xProduct.Price = updatedProduct.Price;
        xProduct.Name = updatedProduct.Name;*/
      
    }

    [HttpDelete("{id}")]
    public void DeleteProduct([FromRoute] int id)
    {
        var productDelete = _products.FirstOrDefault(x=>x.Id==id);
   
        _products.Remove(productDelete);
        
       // return RedirectToAction("GetProducts");
        
    }

    [HttpPost("addProduct")]
    public Product AddProduct([FromBody] Product newProduct)
    {
        var x = _dataContext.InsertProduct(newProduct);
        /*newProduct.Id = constId;
        constId++;
        _products.Add(newProduct);*/
        newProduct.Id = x;
        return newProduct;

    }

    
}