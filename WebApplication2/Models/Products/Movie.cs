namespace WebApplication2.Models;

public class Movie : Product
{
    public new ProductType ProductType { get; } = ProductType.Movie;
    
}