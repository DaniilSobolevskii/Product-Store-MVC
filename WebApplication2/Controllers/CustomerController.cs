using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using MySql.Data.MySqlClient;
using MyTested.AspNetCore.Mvc.Builders.Controllers;
using WebApplication2.Ado;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[Route("[controller]")]
public class CustomerController : Controller
{
    private readonly IDataContext _dataContext;
    public CustomerController() {
        var connectionStringBuilder = new MySqlConnectionStringBuilder {
            Server = "localhost",
            Database = "productsdb",
            UserID = "root",
            Password = "Volk5801"
        };

        //_dataContext = new RawSqlDataContext("Datasource=localhost;Database=shop;User=root;Password=root123;");
        _dataContext = new AdoDataContext(connectionStringBuilder.ConnectionString);
    }
    public readonly AppDbContext db = new AppDbContext();

    
    public IActionResult Customer()
    {
        return View(db.SelectCustomers());
    }

    [HttpPost("{id}")]
    public Customer UpdateCustomer([FromRoute] int id, [FromBody] Customer customer)
    {
        db.UpdateCustomer(customer.Id, customer);
        return db.SelectCustomers().FirstOrDefault(x => x.Id == customer.Id);

    }
}