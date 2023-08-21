using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using MySql.Data.MySqlClient;
using MyTested.AspNetCore.Mvc.Builders.Controllers;
using WebApplication2.Ado;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[Route("[controller]")]
public class OrderController : Controller
{
    public readonly AppDbContext db = new AppDbContext();
    
    public IActionResult Orders()
    {
        var orders = db.SelectOrders();
        return View(orders);
    }
 
}