using WebApplication2.Models;

namespace WebApplication2.Ado;

public interface IDataContext
{
    
    public IList<Product?> SelectProducts(IDictionary<string, object>? args = null);
    public Product? GetProduct(int id);
    public int InsertProduct(Product product);
    public int UpdateProduct(int id, Product product);
    public int DeleteProduct(int id);

    public IList<Customer?> SelectCustomers(int? id = null);
    public int InsertCustomer(Customer customer);
    public int UpdateCustomer(int id, Customer customer);
    public int DeleteCustomer(int id);

    public IList<Orders?> SelectOrders(int? id = null);
    public int InsertOrder(Orders order);
    public int UpdateOrder(int id, IDictionary<string, object> args);
    public int DeleteOrder(int id);
}