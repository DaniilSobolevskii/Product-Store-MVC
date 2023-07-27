using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication2.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static int constId= 3;
    private static List<Product> _products = new()
    {
        new Product { Id = 0, Name = "Властелин колец", Description = "Книга", Price = 1250.4, Count = 2 },
        new Product { Id = 1, Name = "Остров Проклятых", Description = "Фильм", Price = 2000, Count = 12 },
        new Product { Id = 2, Name = "Бойцовский клуб", Description = "Комикс", Price = 1300, Count = 1 },
        
    };
    
    [HttpGet("getProducts")]
    public List<Product> GetProducts()
    {
        var model = new IndexModel
        {
            Products = _products
        };
        return model.Products;

    }

    [HttpGet("{id}")]
    public Product GetProduct([FromRoute] int id)
    {
        return _products.FirstOrDefault(x=>x.Id==id);
    }

    [HttpPost("{id}")]
    public Product UpdateProduct([FromRoute] int id, [FromBody] Product updatedProduct)
    {
        _products.FirstOrDefault(x=>x.Id==id).Description = updatedProduct.Description;
        _products.FirstOrDefault(x => x.Id == id).Count = updatedProduct.Count;
        _products.FirstOrDefault(x => x.Id == id).Price = updatedProduct.Price;
        _products.FirstOrDefault(x => x.Id == id).Name = updatedProduct.Name;
        return _products[id];
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
        newProduct.Id = constId;
        constId++;
        _products.Add(newProduct);

        return newProduct;

    }

    
}