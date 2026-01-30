using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GeneratePackingLabel()
    {
        StringBuilder label  = new StringBuilder( "Packing Label:\n");
        
        foreach (Product p in _products)
        {
            label.AppendLine($"Product ID: {p.GetId()}, Name: {p.GetName()}");
        }
        return label.ToString();
    }
    public string GenerateShippingLabel()
    {
        StringBuilder label = new StringBuilder("Shipping Label:\n");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddressDetails());
        return label.ToString();
    }


}