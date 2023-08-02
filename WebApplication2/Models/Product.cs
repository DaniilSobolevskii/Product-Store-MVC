using System.Text.Json.Serialization;

namespace WebApplication2.Models;


public abstract class Product
{
   [JsonPropertyOrder(1)]
   public int Id { get; set; }
   
   [JsonPropertyOrder(2)]
   public string Name { get; set; }
   [JsonPropertyOrder(3)]
   public string Description { get; set; }
   [JsonPropertyOrder(4)]
   public double Price  { get; set; }
   [JsonPropertyOrder(5)]
   public int Count { get; set; }
   
   [JsonPropertyOrder(-1)]
   public ProductType ProductType { get; set; }
}