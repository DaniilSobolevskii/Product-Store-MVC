namespace WebApplication2.Models;

public class Undefined : Product
{
    public new ProductType ProductType { get; } = ProductType.Undefined;
}