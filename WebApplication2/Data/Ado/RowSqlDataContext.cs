using MySql.Data.MySqlClient;
using WebApplication2.Models;

namespace WebApplication2.Ado;

public class RowSqlDataContext
{
    
    private readonly string _connectionString;

    public RowSqlDataContext(string connectionString) {
        _connectionString = connectionString;
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

    public int UpdateProduct(int id, IDictionary<string, object> args)
    {
        throw new NotImplementedException();
    }

    public int DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    
    
    
    public IList<Customer?> SelectCustomers(int? id = null)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var query = "SELECT id, first_name, last_name, age, country FROM Customers";

        if (id.HasValue) {
            query += " WHERE id = @id;";
        }

        query += ";";

        var command = new MySqlCommand(query, connection);

        if (id.HasValue) {
            command.Parameters.AddWithValue("id", id.Value);
        }

        using var reader = command.ExecuteReader();

        var result = new List<Customer?>();

        while (reader.Read()) {
            var customer = new Customer {
                Id = (int)reader[0],
                FirstName = (string)reader[1],
                LastName = (string)reader[2],
                Age = (int)reader[3],
                Country = (string)reader[4]
            };

            result.Add(customer);
        }

        return result;
    }

    public int InsertCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public int UpdateCustomer(int id, IDictionary<string, object> args)
    {
        throw new NotImplementedException();
    }

    public int DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Orders?> SelectOrders(int? id = null)
    {
        throw new NotImplementedException();
    }

    public IList<Orders?> SelectOrders(IDictionary<string, object>? args = null)
    {
        throw new NotImplementedException();
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