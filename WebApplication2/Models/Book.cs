namespace WebApplication2.Models;

public class Book : Product
{
    public new ProductType ProductType { get; } = ProductType.Book;
}