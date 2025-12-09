using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace BlazorApp.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public int UserId { get; private set; }

        // ⭐ Navigation property

        [JsonIgnore]
        public User? User { get; private set; }


        private Product() { } // Required for EF Core

        public Product(string name, decimal price, int userId)
        {
            // Domain validation logic here
            Name = name;
            Price = price;
            UserId = userId;
        }

        // Domain methods for modifying the state
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new DomainException("Price cannot be negative.");

            Price = newPrice;
        }
    }
}