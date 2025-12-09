namespace BlazorApp.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }


        public List<Product> Products { get; private set; } = new();

        private User() { }

        public User(string firstName, string lastName, string email, string passwordHash)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
