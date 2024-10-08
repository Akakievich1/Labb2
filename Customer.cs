namespace Store
{
    public class Customer
    {
        public string Name { get; private set; }
        private string Password { get; set; }
        public ShoppingCart Cart { get; private set; }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            Cart = new ShoppingCart();
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Total Cart Value: {Cart.GetTotalPrice():C}";
        }
    }
}
