using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication2.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> _products = new()
    {
        new Product { Id = 0, Name = "Властелин колец", Description = "Книга", Price = 1250.4, Count = 2 },
        new Product { Id = 1, Name = "Остров Проклятых", Description = "Фильм", Price = 2000, Count = 12 },
        new Product { Id = 2, Name = "Бойцовский клуб", Description = "Комикс", Price = 1300, Count = 1 }
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
        return _products[id];
    }

    [HttpPost("{id}")]
    public Product UpdateProduct([FromRoute] int id, [FromBody] Product updatedProduct)
    {
        _products[id] = updatedProduct;
        return _products[id];
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteProduct([FromRoute] int id)
    {
        var productDelete = _products.Find((x => x.Id == id));
        _products.Remove(productDelete);
        
        return RedirectToAction("GetProducts");
        
    }

    [HttpPost("addProduct")]
    public IActionResult AddProduct([FromBody] Product newProduct)
    {
        newProduct.Id = _products.Count;
        _products.Add(newProduct);

        return RedirectToAction("GetProducts");
       
    }

    
}