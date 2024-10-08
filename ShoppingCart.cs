using Store;

public class ShoppingCart
{
    private Dictionary<Product, int> _products;

    public ShoppingCart()
    {
        _products = new Dictionary<Product, int>();
    }

    public void AddProduct(Product product)
    {
        if (_products.ContainsKey(product))
        {
            _products[product]++;
        }
        else
        {
            _products[product] = 1;
        }
    }

    public void ClearCart()
    {
        _products.Clear();
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var item in _products)
        {
            total += item.Key.Price * item.Value;
        }
        return total;
    }

    public void ShowCart()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("Din kundvagn är tom.");
        }
        else
        {
            Console.WriteLine("Din kundvagn:");
            foreach (var item in _products)
            {
                Console.WriteLine($"{item.Key.Name} (Pris: {item.Key.Price:C}) x {item.Value} = {item.Key.Price * item.Value:C}");
            }
            Console.WriteLine($"Totalt pris: {GetTotalPrice():C}");
        }
    }
}
