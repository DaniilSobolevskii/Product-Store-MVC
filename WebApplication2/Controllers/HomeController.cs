using System.Diagnostics;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class HomeController : Controller
{
    private static List<Product> _products = new()
    {   
        new Book { Id = 0, Name = "Властелин колец", Description = "Книга", Price = 1250.4, Count = 2},
        new Movie { Id = 1, Name = "Остров Проклятых", Description = "Фильм", Price = 2000, Count = 12},
        new Accessories { Id = 2, Name = "Бойцовский клуб", Description = "Комикс", Price = 1300, Count = 1}

    };

    private string[] productName =
    {
        "Книга", "Фильм", "Сериал", "Комикс"
    };

    private string[] description =
    {
        "Гарри Поттер", "Властелин колец", "Записки юного врача", "Хроники Нарнии", "Дуэль",
        "Код да Винчи", "Алиса в стране чудес", "Облачный атлас", "Красный дракон", "Оно",
        "Зеленая миля", "Остров Проклятых", "Мемуары гейши", "Маленькие женщины", "Бойцовский клуб",
        "Мгла", "1984", "Анна Каренина", "Я-легенда", "Стальной гигант"
    };


    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new IndexModel
        {
            Products = _products
        };
        return View(model);
    }


   [HttpPost("product")]
    public IActionResult CreateProduct([FromForm] Product product)
    {
  
        _products.Add(product);
        return RedirectToAction("Index");
    }
    

    [HttpGet("GetProduct")]
    public IActionResult GetProduct(int id)
    {
        var model = new IndexModel
          {
              Products = _products,
              UpdateProduct= _products.Find(x => x.Id == id)
          };
      //  var model = _products.Find((x => x.Id == id));
        
        return View("Update",model);
    }

    [HttpPost("UpgradeProduct")]
    public IActionResult UpgradeProduct(Product product)
    {
        var updateProduct = _products.FirstOrDefault(x => x.Id == product.Id);
        updateProduct.Name = product.Name;
        updateProduct.Description = product.Description;
        updateProduct.Count = product.Count;
        updateProduct.Price = product.Price;
        
        return RedirectToAction("Index");
    }

    
    [HttpPost]
    public IActionResult DeleteProduct(int id)
    {
        var model = _products.Find((x => x.Id == id));
        _products.Remove(model);
        
        return RedirectToAction("Index");
    }
    
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



}