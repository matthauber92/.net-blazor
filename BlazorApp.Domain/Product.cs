using BlazorApp.Domain.Exceptions;

namespace BlazorApp.Domain
{
    public class Product // Aggregate Root
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        private Product() { } // Required for EF Core

        public Product(string name, decimal price)
        {
            // Domain validation logic here
            Name = name;
            Price = price;
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